using BookingRoom.Core.BusinessObjects;
using BookingRoom.Core.BusinessObjects.Person;
using BookingRoom.Core.Utils;
using BookingRoom.Core.Utils.TestsContext;
using BookingRoom.UI.Pages.BookPage;
using BookingRoom.UI.Pages.BookPage.Components;
using Microsoft.Playwright;
using NUnit.Framework;

namespace BookingRoom.Test.StepDefinitions
{
    [Binding]
    public class RoomBookingFormSteps
    {
        private readonly IPage _page;
        private readonly BookPage _bookPage;

        public RoomBookingFormSteps(IPage page)
        {
            _page = page;
            _bookPage = new BookPage(_page);
        }


        [When(@"Input personal details into form")]
        public async Task WhenInputPersonalDetailsIntoForm()
        {
            var room = TestContextVariable.Room.Get<Room>();
            var roomElement = TestContextVariable.RoomElement.Get<RoomElement>();

            Assert.That(room, Is.Not.Null, "Room is not registered is object container.");

            var roomPersonBookedTheRoom =
                room.PersonBookedTheRoom ?? new PersonManager().GenerateRandomPersonDetails().Build();

            room.PersonBookedTheRoom = roomPersonBookedTheRoom;

            await roomElement.BookingForm.SetFirstName(roomPersonBookedTheRoom.FirstName);
            await roomElement.BookingForm.SetLastName(roomPersonBookedTheRoom.LastName);
            await roomElement.BookingForm.SetEmail(roomPersonBookedTheRoom.Email);
            await roomElement.BookingForm.SetPhone(roomPersonBookedTheRoom.Phone);
        }

        [When(@"Input first name with length '(.*)'")]
        public async Task WhenInputFirstNameWithLength(int firstNameLength)
        {
            var room = TestContextVariable.Room.Get<Room>();
            var roomElement = TestContextVariable.RoomElement.Get<RoomElement>();

            await roomElement.BookingForm.SetFirstName(StringGenerationHelper.GenerateRandomString(firstNameLength));
        }

        [When(@"Input last name with length '(.*)'")]
        public async Task WhenInputLastNameWithLength(int lastNameLength)
        {
            var roomElement = TestContextVariable.RoomElement.Get<RoomElement>();

            await roomElement.BookingForm.SetLastName(StringGenerationHelper.GenerateRandomString(lastNameLength));
        }

        [When(@"Input email with length '(.*)'")]
        public async Task WhenInputEmailWithLength(int emailLength)
        { 
            var roomElement = TestContextVariable.RoomElement.Get<RoomElement>();

            await roomElement.BookingForm.SetEmail(StringGenerationHelper.GenerateRandomString(emailLength));
        }

        [When(@"Input phone with length '(.*)'")]
        public async Task WhenInputPhoneWithLength(int phoneLength)
        {
            var roomElement = TestContextVariable.RoomElement.Get<RoomElement>();

            await roomElement.BookingForm.SetPhone(StringGenerationHelper.GenerateRandomNumericString(phoneLength));
        }

        [When(@"Click on ‘Book’ button on room form")]
        public async Task WhenClickOnBookButtonOnRoomForm()
        {
            var roomElement = TestContextVariable.RoomElement.Get<RoomElement>();

            await roomElement.BookingForm.ClickBookButton();
        }

        [When(@"Click on ‘Cancel’ button on room form")]
        public async Task WhenClickOnCancelButtonOnRoomForm()
        {
            var roomElement = TestContextVariable.RoomElement.Get<RoomElement>();

            await roomElement.BookingForm.ClickCancelButton();
        }

        [Then(@"Check that error message is ('(?:present|not present)')")]
        public async Task ThenCheckThatErrorMessageIsPresent(bool isPresent)
        {
            var roomElement = TestContextVariable.RoomElement.Get<RoomElement>();

            Assert.That(await roomElement.BookingForm.IsErrorPresent(), Is.EqualTo(isPresent), $"Error message should be {isPresent}.");
        }

        [Then("Check that personal details are not filled in")]
        public void ThenCheckThatPersonalDetailsAreNotFilledIn()
        {
            var roomElement = TestContextVariable.RoomElement.Get<RoomElement>();

            Assert.Multiple(async () =>
            {
                Assert.That(await roomElement.BookingForm.GetFirstName(), Is.Null.Or.Empty, "First name should be empty.");
                Assert.That(await roomElement.BookingForm.GetLastName(), Is.Null.Or.Empty, "Last name should be empty.");
                Assert.That(await roomElement.BookingForm.GetEmail(), Is.Null.Or.Empty, "Email should be empty.");
                Assert.That(await roomElement.BookingForm.GetPhone(), Is.Null.Or.Empty, "phone should be empty.");
            });

        }
    }
}
