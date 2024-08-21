using BookingRoom.API.Responses;
using BookingRoom.Core.Configuration;
using Microsoft.Playwright;

namespace BookingRoom.API.ApiControllers
{
    public class RoomReportApi : BaseApi
    {
        protected override string HostEndpoint => AppConfiguration.TestSettings.ApplicationUrl;

        private string ReportRoomUrl(int roomId) => $"{HostEndpoint}report/room/{roomId}";

        public RoomReportApi(IAPIRequestContext requestContext) : base(requestContext)
        {
        }

        public async Task<RoomReport?> GetRoomReportAsync(int roomId)
        { 
            return await Get<RoomReport>(ReportRoomUrl(roomId));
        }
    }
}

