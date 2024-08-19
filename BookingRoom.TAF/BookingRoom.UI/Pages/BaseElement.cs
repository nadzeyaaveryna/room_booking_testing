using Microsoft.Playwright;

namespace BookingRoom.UI.Pages
{
    public abstract class BaseElement
    {
        protected readonly IPage _page;
        protected readonly ILocator _rootElement;

        protected BaseElement(ILocator rootElement, IPage page)
        {
            _page = page;
            _rootElement = rootElement;
        }

    }
}
