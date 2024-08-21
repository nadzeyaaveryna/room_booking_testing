using BookingRoom.UI.Helpers;
using Microsoft.Playwright;

namespace BookingRoom.UI.Pages.BookPage.Components
{
    public class BookingFormElement : BaseElement
    {
        public BookingFormElement(ILocator rootElement, IPage page) : base(rootElement, page)
        {
        }


        private ILocator FirstNameInput => _rootElement.Locator(".room-firstname");

        private ILocator LastNameInput => _rootElement.Locator(".room-lastname");

        private ILocator EmailInput => _rootElement.Locator(".room-email");

        private ILocator PhoneInput => _rootElement.Locator(".room-phone");

        private ILocator BookButton => _rootElement.GetByRole(AriaRole.Button, new() { Name = "Book" });

        private ILocator CancelButton => _rootElement.GetByRole(AriaRole.Button, new() { Name = "Cancel" });

        private ILocator ErrorElement => _rootElement.Locator(@$".alert.alert-danger");

        private ILocator ErrorMessageElement(string errorMessage) =>
            _rootElement.Locator(@$".alert.alert-danger p:has-text('{errorMessage}')");

        public async Task<string?> GetFirstName() => await FirstNameInput.TextContentAsync();

        public async Task SetFirstName(string firstName) => await FirstNameInput.FillAsync(firstName);

        public async Task<string?> GetLastName() => await LastNameInput.TextContentAsync();

        public async Task SetLastName(string lastName) => await LastNameInput.FillAsync(lastName);

        public async Task<string?> GetEmail() => await EmailInput.TextContentAsync();

        public async Task SetEmail(string email) => await EmailInput.FillAsync(email);

        public async Task<string?> GetPhone() => await PhoneInput.TextContentAsync();

        public async Task SetPhone(string phone) => await PhoneInput.FillAsync(phone);

        public async Task ClickBookButton() => await BookButton.ClickAsync();

        public async Task ClickCancelButton() => await CancelButton.ClickAsync();

        public async Task<bool> IsErrorPresent()
        {
            await ErrorElement.WaitForElement(1000);
            return await ErrorElement.IsVisibleAsync();
        }

        public async Task<bool> IsErrorMessagePresent(string errorMessage) => await ErrorMessageElement(errorMessage).IsVisibleAsync();
    }
}
