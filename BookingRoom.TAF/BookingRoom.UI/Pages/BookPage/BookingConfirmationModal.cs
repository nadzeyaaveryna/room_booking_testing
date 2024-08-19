using BookingRoom.Core.Configuration;
using Microsoft.Playwright;

namespace BookingRoom.UI.Pages.BookPage
{
    public class BookingConfirmationModal : BaseModal
    {
        public BookingConfirmationModal(IPage page) : base(page)
        {
        }

        protected override ILocator RootElement => RootElement.Locator(".ReactModal__Content--after-open");

        private ILocator BookingConfirmationStatusElement => RootElement.Locator("h3");

        private ILocator BookingConfirmationMessageElement => RootElement.Locator("p:nth-of-type(1)");

        private ILocator BookingConfirmationDatesElement => RootElement.Locator("p:nth-of-type(2)");

        private ILocator CloseButton => RootElement.Locator("button.btn-outline-primary");

        public async Task<string> GetBookingConfirmationStatus()
        {
            var headerText = await BookingConfirmationStatusElement.InnerTextAsync();
            return headerText;
        }

        public async Task<string> GetBookingConfirmationMessage()
        {
            var messageText = await BookingConfirmationMessageElement.InnerTextAsync();
            return messageText;
        }

        public async Task<string> GetBookingConfirmationDates()
        {
            var dates = await BookingConfirmationDatesElement.InnerTextAsync();
            return dates;
        }

        public async Task CloseModalAsync()
        {
            await CloseButton.ClickAsync();
        }

    }
}
