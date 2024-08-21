using BookingRoom.API.Responses;
using BookingRoom.Core.BusinessObjects;
using BookingRoom.Core.BusinessObjects.TimeSlot;
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

        public RoomCalendarSteps(IPage page)
        {
            _page = page;
            _bookPage = new BookPage(_page);
        }


        [When(@"Select '(.*)' day stay on calendar in current month")]
        public async Task WhenSelectTwoNightThreeDayStayOnCalendarInCurrentMont(int numberOfDays)
        {
            var room = TestContextVariable.Room.Get<Room>();
            var roomElement = TestContextVariable.RoomElement.Get<RoomElement>();

            Assert.That(room, Is.Not.Null, "Room is not registered is object container.");

            var newSlot = new TimeSlotManager(room.BookedSlots).FindAvailableSlotStartingFromCurrentMonth(numberOfDays);

            room.BookedSlots.Add(newSlot);

            await roomElement.Calendar.SelectDate(newSlot.StartDate, newSlot.EndDate);
        }

        [When("Try to select time slot with past date")]
        public async Task WhnTryToSelectTimeSlotWithPastDate()
        {
            var room = TestContextVariable.Room.Get<Room>();
            var roomElement = TestContextVariable.RoomElement.Get<RoomElement>();

            Assert.That(room, Is.Not.Null, "Room is not registered is object container.");

            var newSlot = new TimeSlotManager(room.BookedSlots).FindAvailablePastSlot(3);

            room.BookedSlots.Add(newSlot);

            await roomElement.Calendar.SelectDate(newSlot.StartDate, newSlot.EndDate);
        }


        [When("Click '(Today|Back|Next)' calendar button")]
        public async Task WhenClickCalendarButton(string buttonName)
        {
            var roomElement = TestContextVariable.RoomElement.Get<RoomElement>();
            var calendar = roomElement.Calendar;

            TestContextVariable.CalendarOpenedDate.SetIfNotExist(DateTime.Now);
            var calendarDate = TestContextVariable.CalendarOpenedDate.Get<DateTime>();

            switch (buttonName)
            {
                case "Today":
                {
                    await calendar.ClickTodayButton();
                    calendarDate = DateTime.Now;
                    break;
                }
                case "Back":
                    await calendar.ClickBackButton(); 
                    calendarDate = calendarDate.AddMonths(-1);
                    break;
                case "Next":
                    await calendar.ClickNextButton();
                    calendarDate = calendarDate.AddMonths(1);
                    break;
            }

            TestContextVariable.CalendarOpenedDate.Set(calendarDate);
        }

        [Then(@"Check that Calendar is ('(?:present|not present)') in a room card")]
        public async Task ThenCheckThatCalendarIsInARoomCard(bool isPresent)
        {
            var roomElement = TestContextVariable.RoomElement.Get<RoomElement>();
            var isVisible = await roomElement.Calendar.IsElementDisplayed();

            Assert.That(isVisible, Is.EqualTo(isPresent));
        }


        [Then("Check that calendar necessary elements appear")]
        public void ThenCheckThatCalendarNecessaryElementsAppear()
        {
            var roomElement = TestContextVariable.RoomElement.Get<RoomElement>();
            var calendar = roomElement.Calendar;

            Assert.Multiple(async () =>
            {
                Assert.That(await calendar.IsTodayButtonVisible(), Is.True, "Today button should be visible.");
                Assert.That(await calendar.IsBackButtonVisible(), Is.True, "Back button should be visible.");
                Assert.That(await calendar.IsNextButtonVisible(), Is.True, "Next button should be visible.");
                Assert.That(await calendar.IsMonthSpanVisible(), Is.True, "Month span should be visible.");
            });
        }

        [Then(@"Check that calendar shows correct month and year")]
        public async Task ThenCheckThatCalendarShowsCorrectMonthAndYear()
        {
            TestContextVariable.CalendarOpenedDate.SetIfNotExist(DateTime.Now);

            var calendarDate = TestContextVariable.CalendarOpenedDate.Get<DateTime>();
            var roomElement = TestContextVariable.RoomElement.Get<RoomElement>();
            var calendar = roomElement.Calendar;

            Assert.That(await calendar.GetMonthSpanText(),
                Is.EqualTo(calendarDate.GetFormattedString(DateTimeFormats.DateFullMonthYearFormatFormat)), "Calendar month is incorrect");
        }

        [Then("Check that days from previous month are disabled")]
        public async Task ThenCheckThatDaysFromPreviousMonthAreGrey()
        {
            var monthStartingNotOnSunday = DateTimeHelper.FindNearestMonthStartingNotOnSunday();
            var roomElement = TestContextVariable.RoomElement.Get<RoomElement>();
            var calendar = roomElement.Calendar;

            await calendar.NavigateToMonth(monthStartingNotOnSunday);

            var daysFromPreviousMonth = DateTimeHelper.GetVisibleDaysFromPreviousMonth(monthStartingNotOnSunday);

            var listOfStates = new List<bool>();

            foreach (var day in daysFromPreviousMonth)
            {
                var state = await calendar.IsOffRangeDayEnabled(day);
                listOfStates.Add(state);
            }

            Assert.IsTrue(listOfStates.All(el => el.Equals(false)),
                "Days from previous month should be disabled in calendar.");
        }

        [Then("Check that selected slot is ('(?:present|not present)') on calendar")]
        public async Task ThenCheckThatSelectedSlotIsVisibleOnCalendar(bool isPreset)
        {
            var room = TestContextVariable.Room.Get<Room>();
            var roomElement = TestContextVariable.RoomElement.Get<RoomElement>();
            var expectedRoom = TestContextVariable.ExpectedRoom.Get<OneRoom>();
            var calendar = roomElement.Calendar;

            var timeSlot = room.BookedSlots.First(el => el.IsBookedInTest);

            var numberOfNights = DateTimeHelper.CalculateNights(timeSlot.StartDate, timeSlot.EndDate);

            var expectedSlotText =@$"{numberOfNights} night(s) - £{numberOfNights * expectedRoom.RoomPrice}";

            var isSlotFound =
                await calendar.IsSelectedSlotPresent(timeSlot.StartDate, expectedSlotText);

            Assert.That(isSlotFound, Is.EqualTo(isPreset));
        }
    }
}
