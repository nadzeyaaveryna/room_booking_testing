using BoDi;
using BookingRoom.API.ApiControllers;
using BookingRoom.Core.BusinessObjects;
using BookingRoom.Core.Constants;
using BookingRoom.UI.Pages.BookPage;
using Microsoft.Playwright;
using NUnit.Framework;
using System;
using BookingRoom.Core.BusinessObjects.TimeSlot;
using BookingRoom.Core.Utils;
using BookingRoom.Core.Utils.TestsContext;

namespace BookingRoom.TAF.StepDefinitions.ApiSteps
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

            foreach (var roomReportItem in roomReport.Report)
            {
                room.BookedSlots.Add(new TimeSlot(
                    roomReportItem.Start.ParseDateTime(DateTimeFormats.DateYearMonthDayFormat),
                    roomReportItem.End.ParseDateTime(DateTimeFormats.DateYearMonthDayFormat)));
            }

            TestContextVariable.Room.Set(room);
        }
    }
}
