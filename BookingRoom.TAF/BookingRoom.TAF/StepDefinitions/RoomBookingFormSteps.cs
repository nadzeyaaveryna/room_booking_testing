using BookingRoom.Core.BusinessObjects;
using BookingRoom.Core.BusinessObjects.Person;
using BookingRoom.Core.Utils.TestsContext;
using BookingRoom.UI.Pages.BookPage;
using BookingRoom.UI.Pages.BookPage.Components;
using Microsoft.Playwright;
using NUnit.Framework;

namespace BookingRoom.TAF.StepDefinitions
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

            var roomPersonBookedTheRoom = room.PersonBookedTheRoom ?? new PersonManager().GenerateRandomPersonDetails();

            room.PersonBookedTheRoom = roomPersonBookedTheRoom;

            await roomElement.BookingForm.SetFirstName(roomPersonBookedTheRoom.FirstName);
            await roomElement.BookingForm.SetLastName(roomPersonBookedTheRoom.LastName);
            await roomElement.BookingForm.SetEmail(roomPersonBookedTheRoom.Email);
            await roomElement.BookingForm.SetPhone(roomPersonBookedTheRoom.Phone);
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
    }
}
