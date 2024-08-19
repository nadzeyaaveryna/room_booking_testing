using Microsoft.Playwright;

namespace BookingRoom.UI.Pages
{
    public abstract class BaseModal
    {
        protected readonly IPage Page;

        protected abstract ILocator RootElement { get; }

        protected BaseModal(IPage page)
        {
            Page = page;
        }

        public async Task<bool> IsModalDisplayed()
        {
            return await RootElement.IsVisibleAsync();
        }
    }
}
