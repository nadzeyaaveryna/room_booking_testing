using BoDi;
using BookingRoom.API.ApiControllers;
using BookingRoom.Core.BusinessObjects;
using BookingRoom.Core.Constants;
using BookingRoom.Core.Utils;
using BookingRoom.Core.Utils.TestsContext;
using BookingRoom.UI.Pages.BookPage;
using BookingRoom.UI.Pages.BookPage.Components;
using Microsoft.Playwright;
using NUnit.Framework;

namespace BookingRoom.TAF.StepDefinitions
{
    [Binding]
    public class RoomCalendarSteps
    {
        private readonly IPage _page;
        private readonly BookPage _bookPage;
        private readonly IObjectContainer _objectContainer;

        public RoomCalendarSteps(IPage page, IObjectContainer objectContainer)
        {
            _page = page;
            _bookPage = new BookPage(_page);
            _objectContainer = objectContainer;
        }


        [When(@"Select two night \(three day\) stay on calendar in current month")]
        public async Task WhenSelectTwoNightThreeDayStayOnCalendarInCurrentMont()
        {
            var room = TestContextVariable.Room.Get<Room>();
            var apiContext = _objectContainer.Resolve<IAPIRequestContext>();

            Assert.That(room, Is.Not.Null, "Room is not registered is object container.");
            Assert.That(apiContext, Is.Not.Null, "API Context is not registered is object container.");

            var roomReport = await new RoomReportApi(apiContext).GetRoomReportAsync(room.Index + 1);

            foreach (var roomReportItem in roomReport.Report)
            {
                room.BookedSlots.Add(new TimeSlot(
                    roomReportItem.Start.ParseDateTime(DateTimeFormats.DateYearMonthDayFormat),
                    roomReportItem.End.ParseDateTime(DateTimeFormats.DateYearMonthDayFormat)));
            }

        }
    }
}
