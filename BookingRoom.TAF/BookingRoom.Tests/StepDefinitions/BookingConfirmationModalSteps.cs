using BookingRoom.Core.BusinessObjects;
using BookingRoom.Core.Constants;
using BookingRoom.Core.Utils;
using BookingRoom.Core.Utils.TestsContext;
using BookingRoom.UI.Pages.BookPage;
using Microsoft.Playwright;
using NUnit.Framework;

namespace BookingRoom.Tests.StepDefinitions
{
    [Binding]
    public class BookingConfirmationModalSteps
    {
        private const string ExpectedConfirmationHeader = "Booking Successful!";
        private const string ExpectedConfirmationMessage = "Congratulations! Your booking has been confirmed for:";

        private readonly IPage _page;
        private readonly BookingConfirmationModal _confirmationModal;

        public BookingConfirmationModalSteps(IPage page)
        {
            _page = page;
            _confirmationModal = new BookingConfirmationModal(_page);
        }

        [When("Close ‘Booking Successful’ modal")]
        public async Task WhenICloseBookingSuccessfulModal()
        {
            await _confirmationModal.CloseModalAsync();
        }

        [Then(@"I check that ‘Booking Successful’ modal is ('(?:present|not present)')")]
        public async Task ThenICheckThatBookingSuccessfulModalAppears(bool isPresent)
        {
            var isActuallyPresent = await _confirmationModal.IsModalDisplayed();
            Assert.AreEqual(isActuallyPresent, isPresent, $"Booking confirmation modal should be {isPresent.ToString()}");
        }

        [Then(@"I check that ‘Booking Successful’ modal appears with correct dates and text")]
        public async Task ThenICheckThatBookingSuccessfulModalAppearsWithCorrectDatesAndText()
        {
            var room = TestContextVariable.Room.Get<Room>();

            var status = await _confirmationModal.GetBookingConfirmationStatus();
            var message = await _confirmationModal.GetBookingConfirmationMessage();
            var dates = await _confirmationModal.GetBookingConfirmationDates();

            var bookedDate = room.BookedSlots.First(el => el.IsBookedInTest);

            Assert.Multiple(() =>
            {
                Assert.That(status, Is.EqualTo(ExpectedConfirmationHeader), "Confirmation Modal Header is incorrect.");
                Assert.That(message, Is.EqualTo(ExpectedConfirmationMessage), "Confirmation Modal Message is incorrect.");
                Assert.That(dates,
                    Is.EqualTo(
                        $"{bookedDate.StartDate.GetFormattedString(DateTimeFormats.DateYearMonthDayFormat)} - {bookedDate.EndDate.GetFormattedString(DateTimeFormats.DateYearMonthDayFormat)}"),
                    "Confirmation Modal Dates are incorrect.");
            });
        }

    }
}
