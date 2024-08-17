using BookingRoom.UI.Pages.BookPage;
using Microsoft.Playwright;

namespace BookingRoom.TAF.StepDefinitions
{
    [Binding]
    public sealed class CalculatorStepDefinitions
    {
        private readonly IPage _page;
        private readonly BookPage _bookPage;

        public CalculatorStepDefinitions(IPage page)
        {
            _page = page;
            _bookPage = new BookPage(_page);
        }

        [Given("the first number is (.*)")]
        public async Task GivenTheFirstNumberIs(int number)
        {
            await _bookPage.OpenPage();
            await _bookPage.ClickBookThisRoomButton();
        }

        [Given("the second number is (.*)")]
        public void GivenTheSecondNumberIs(int number)
        {
            //TODO: implement arrange (precondition) logic

            throw new PendingStepException();
        }

        [When("the two numbers are added")]
        public void WhenTheTwoNumbersAreAdded()
        {
            //TODO: implement act (action) logic

            throw new PendingStepException();
        }

        [Then("the result should be (.*)")]
        public void ThenTheResultShouldBe(int result)
        {
            //TODO: implement assert (verification) logic

            throw new PendingStepException();
        }
    }
}
