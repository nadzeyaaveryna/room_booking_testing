using BookingRoom.API.Responses;
using BookingRoom.Core.Configuration;
using Microsoft.Playwright;

namespace BookingRoom.API.ApiControllers
{
    public class RoomApi : BaseApi
    {
        protected override string HostEndpoint => AppConfiguration.TestSettings.ApplicationUrl;

        private string RoomsUrl => $"{HostEndpoint}room/";
   
        public RoomApi(IAPIRequestContext requestContext) : base(requestContext)
        {
        }

        public async Task<Rooms?> GetRoomReportAsync()
        {
            return await Get<Rooms>(RoomsUrl);
        }
    }
}
