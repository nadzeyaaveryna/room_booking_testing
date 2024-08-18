using BookingRoom.Core.BusinessObjects;
using BookingRoom.Core.BusinessObjects.TimeSlot;
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

        public RoomCalendarSteps(IPage page)
        {
            _page = page;
            _bookPage = new BookPage(_page);
        }


        [When(@"Select two night three day stay on calendar in current month")]
        public async Task WhenSelectTwoNightThreeDayStayOnCalendarInCurrentMont()
        {
            var room = TestContextVariable.Room.Get<Room>();
            var roomElement = TestContextVariable.RoomElement.Get<RoomElement>();

            Assert.That(room, Is.Not.Null, "Room is not registered is object container.");

            var newSlot = new TimeSlotManager(room.BookedSlots).FindAvailableSlotStartingFromCurrentMonth(3);

            await roomElement.Calendar.SelectDate(newSlot.StartDate, newSlot.EndDate);

        }
    }
}
