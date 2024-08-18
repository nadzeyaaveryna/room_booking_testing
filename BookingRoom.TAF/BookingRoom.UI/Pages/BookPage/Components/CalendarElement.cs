using BookingRoom.Core.Constants;
using BookingRoom.Core.Utils;
using Microsoft.Playwright;
using System;

namespace BookingRoom.UI.Pages.BookPage.Components
{
    public class CalendarElement
    {
        private readonly ILocator _rootElement;

        public CalendarElement(ILocator rootElement)
        {
            _rootElement = rootElement;
        }

        private ILocator TodayButton => _rootElement.GetByRole(AriaRole.Button, new() { Name = "Today" });
        
        private ILocator BackButton => _rootElement.GetByRole(AriaRole.Button, new() { Name = "Back" });

        private ILocator NextButton => _rootElement.GetByRole(AriaRole.Button, new() { Name = "Next" });

        private ILocator MonthSpan => _rootElement.Locator(".rbc-toolbar-label");

        private ILocator DayPicker(int day) =>
            _rootElement.Locator(
                $"xpath=//button[@role='cell' and text()='{day.ToString()}' and not(ancestor::*[contains(@class, 'rbc-off-range')])]");

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
                await DayPicker(expectedStartDay).DragToAsync(DayPicker(expectedEndDay));
            }
            else
            {
                var endOfMonth = DateTime.DaysInMonth(startDate.Year, startDate.Month);

                await DayPicker(expectedStartDay).DragToAsync(DayPicker(endOfMonth));
                await NavigateToMonth(endDate);
                await DayPicker(1).DragToAsync(DayPicker(expectedEndDay));
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
    }
}
