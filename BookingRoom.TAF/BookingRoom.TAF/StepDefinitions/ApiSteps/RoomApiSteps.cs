using BoDi;
using BookingRoom.API.ApiControllers;
using BookingRoom.Core.BusinessObjects;
using BookingRoom.Core.BusinessObjects.TimeSlot;
using BookingRoom.Core.Constants;
using BookingRoom.Core.Utils;
using BookingRoom.Core.Utils.TestsContext;
using Microsoft.Playwright;
using NUnit.Framework;

namespace BookingRoom.Test.StepDefinitions.ApiSteps
{
    [Binding]
    public class RoomApiSteps
    {
        private readonly IObjectContainer _objectContainer;

        public RoomApiSteps(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        [When("Retrieve booked slots for room")]
        public async Task WhenRetrieveBookedSlotsForRoom()
        {
            var room = TestContextVariable.Room.Get<Room>();
            var apiContext = _objectContainer.Resolve<IAPIRequestContext>();

            Assert.That(room, Is.Not.Null, "Room is not registered is object container.");
            Assert.That(apiContext, Is.Not.Null, "API Context is not registered is object container.");

            var roomReport = await new RoomReportApi(apiContext).GetRoomReportAsync(room.Index + 1);
            Assert.That(roomReport, Is.Not.Null.Or.Empty, "Rooms list should not be empty. ");

            foreach (var roomReportItem in roomReport?.Report)
            {
                room.BookedSlots.Add(new TimeSlot(
                    roomReportItem.Start.ParseDateTime(DateTimeFormats.DateYearMonthDayFormat),
                    roomReportItem.End.ParseDateTime(DateTimeFormats.DateYearMonthDayFormat)));
            }

            TestContextVariable.Room.Set(room);
        }

        [When("Retrieve selected room details")]
        public async Task WhenRetrieveAvailableRooms()
        {
            var room = TestContextVariable.Room.Get<Room>();
            var apiContext = _objectContainer.Resolve<IAPIRequestContext>();

            var rooms = await new RoomApi(apiContext).GetRoomReportAsync();
            Assert.That(rooms, Is.Not.Null.Or.Empty, "Rooms list should not be empty. ");

            TestContextVariable.ExpectedRoom.Set(rooms?.RoomsList.First(el => el.RoomId.Equals(room.Index + 1)));
        }

    }
}
