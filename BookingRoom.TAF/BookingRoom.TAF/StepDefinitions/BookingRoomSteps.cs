using BookingRoom.UI.Pages.BookPage;
using Microsoft.Playwright;

namespace BookingRoom.TAF.StepDefinitions
{
    [Binding]
    public class BookingRoomSteps
    {
        private readonly IPage _page;
        private readonly BookPage _bookPage;

        public BookingRoomSteps(IPage page)
        {
            _page = page;
            _bookPage = new BookPage(_page);
        }

        [Given(@"I navigate to booking application")]
        public async Task GivenINavigateToBookingApplication()
        {
            await _bookPage.OpenPage();
        }

        [When(@"I find room and click ‘Book this room’ button")]
        public async Task WhenIFindRoomAndClickBookThisRoomButton()
        {
           var rooms =  _bookPage.GetRoomsList().Result;

           var firstRoom = rooms.FirstOrDefault();
              await firstRoom?.ClickBookButton();

            //await _bookPage.ClickBookThisRoomButton();
        }

        [When(@"Select two night \(three day\) stay on calendar")]
        public void WhenSelectTwoNightThreeDayStayOnCalendar()
        {
            throw new PendingStepException();
        }

        [When(@"Input personal details into form")]
        public void WhenInputPersonalDetailsIntoForm()
        {
            throw new PendingStepException();
        }

        [When(@"Click on ‘Book this room’ button")]
        public void WhenClickOnBookThisRoomButton()
        {
            throw new PendingStepException();
        }

        [Then(@"I check that ‘Book Successful’ dialog appears with correct booking date")]
        public void ThenICheckThatBookSuccessfulDialogAppearsWithCorrectBookingDate()
        {
            throw new PendingStepException();
        }
    }
}
