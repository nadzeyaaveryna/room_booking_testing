using BookingRoom.Core.Constants;
using BookingRoom.Core.Utils;
using Microsoft.Playwright;
using System;

namespace BookingRoom.UI.Pages.BookPage.Components
{
    public class CalendarElement
    {
        private readonly ILocator _rootElement;
        private readonly IPage _page;

        public CalendarElement(ILocator rootElement, IPage page)
        {
            _page = page;
            _rootElement = rootElement;
        }

        private ILocator TodayButton => _rootElement.GetByRole(AriaRole.Button, new() { Name = "Today" });
        
        private ILocator BackButton => _rootElement.GetByRole(AriaRole.Button, new() { Name = "Back" });

        private ILocator NextButton => _rootElement.GetByRole(AriaRole.Button, new() { Name = "Next" });

        private ILocator MonthSpan => _rootElement.Locator(".rbc-toolbar-label");

        private ILocator DayPicker(int day) =>
            _rootElement.Locator(
                $"xpath=//button[@role='cell' and text()='{day.ToString()}' and not(ancestor::*[contains(@class, 'rbc-off-range')])]");


        private ILocator DayCell(int day) =>
            _rootElement.Locator(
                $"xpath=//*[@role='cell'][.//button[@role='cell' and text()='{day.ToString()}' and not(ancestor::*[contains(@class, 'rbc-off-range')])]]");
        
        
        public async Task<DateTime> GetCalendarMonth(string format = DateTimeFormats.DateFullMonthYearFormatFormat)
        {
            var elementText = await MonthSpan.TextContentAsync();

            return elementText.ParseDateTime(format);
        }

        public async Task SelectDate(DateTime startDate, DateTime endDate)
        {
            var expectedStartDay = startDate.Day;
            var expectedEndDay = endDate.Day;

            await NavigateToMonth(startDate);

            if(startDate.Month == endDate.Month)
            {
                await SelectDateWithinSameMonth(startDate.Day, endDate.Day);
            }
            else
            {
                await SelectDateAcrossDifferentMonths(startDate, endDate);
            }
        }

        public async Task NavigateToMonth(DateTime expectedDateTime, int safeCount = 100)
        {

            var actualMonth = await GetCalendarMonth();
            var expectedMonth = new DateTime(expectedDateTime.Year, expectedDateTime.Month, 1);

            var button = actualMonth < expectedDateTime ? NextButton : BackButton;

            while (await GetCalendarMonth() != expectedMonth && safeCount-- > 0)
            {
                await button.ClickAsync();
            }
        }

        public void GetSelectedSlots()
        {
        }

        private async Task SelectDateWithinSameMonth(int startDay, int endDay)
        {
            var startDayLocator = DayCell(startDay);
            var endDayLocator = DayCell(endDay);

            await startDayLocator.ScrollIntoViewIfNeededAsync();

            await DragFromOneCellToAnother(startDayLocator, endDayLocator);
        }

        private async Task SelectDateAcrossDifferentMonths(DateTime startDate, DateTime endDate)
        {
            int endOfMonthDay = DateTime.DaysInMonth(startDate.Year, startDate.Month);
            int startOfNextMonthDay = 1;

            // Drag from start date to the end of the month
            await DragFromOneCellToAnother(DayCell(startDate.Day), DayCell(endOfMonthDay));

            // Navigate to the month of the end date
            await NavigateToMonth(endDate);

            // Drag from the beginning to the end date of the new month
            await DragFromOneCellToAnother(DayCell(startOfNextMonthDay), DayCell(endDate.Day));
        }

        private async Task DragFromOneCellToAnother(ILocator startElement, ILocator endElement)
        {
            await startElement.WaitForAsync();
            await startElement.ScrollIntoViewIfNeededAsync();

            await startElement.HoverAsync();
            await startElement.FocusAsync();

            await _page.Mouse.DownAsync();
            var boundingBox = await startElement.BoundingBoxAsync();

            // Calculate the hover position: Slightly to the right (e.g., 10 pixels)
            var hoverX = boundingBox.X + boundingBox.Width / 2 + 10;
            var hoverY = boundingBox.Y + boundingBox.Height / 2;

            // Perform the hover action
            await _rootElement.Page.Mouse.MoveAsync(hoverX, hoverY);

            await endElement.HoverAsync();
            await endElement.HoverAsync();

            await Task.Delay(500);

            await _page.Mouse.UpAsync();

            await Task.Delay(500);
        }
    }
}
