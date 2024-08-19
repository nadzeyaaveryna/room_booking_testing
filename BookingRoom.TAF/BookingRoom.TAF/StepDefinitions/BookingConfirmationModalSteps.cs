using BookingRoom.UI.Pages.BookPage;
using Microsoft.Playwright;
using NUnit.Framework;

namespace BookingRoom.TAF.StepDefinitions
{
    [Binding]
    public class BookingConfirmationModalSteps
    {
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
            Assert.That(isActuallyPresent, Is.EqualTo(isPresent),$"Booking confirmation modal should be {isPresent.ToString()}");
        }

        [Then(@"I check that ‘Booking Successful’ modal appears with correct dates and text")]
        public async Task ThenICheckThatBookingSuccessfulModalAppearsWithCorrectDatesAndText()
        {
            Assert.Multiple(async () =>
            {
                var isActuallyPresent = await _confirmationModal.IsModalDisplayed();

                if (isActuallyPresent)
                {
                    Assert.That(await _confirmationModal.GetBookingConfirmationStatus(), Is.EqualTo(""));
                    Assert.That(await _confirmationModal.GetBookingConfirmationMessage(), Is.EqualTo(""));
                    Assert.That(await _confirmationModal.GetBookingConfirmationDates(), Is.EqualTo(""));
                }
                else
                {
                    Assert.That(isActuallyPresent, Is.True, $"Booking confirmation modal is not present.");
                }
            });
        }

    }
}
