using BookingRoom.API.Responses;
using Microsoft.Playwright;
using Newtonsoft.Json;

namespace BookingRoom.API.ApiControllers
{
    public class RoomReportApi
    {
        private readonly IAPIRequestContext _requestContext;

        private string ReportRoomUrl(int roomId) => $"https://automationintesting.online/report/room/{roomId}";

        public RoomReportApi(IAPIRequestContext requestContext)
        {
            _requestContext = requestContext;
        }

        public async Task<RoomReport> GetRoomReportAsync(int roomId)
        {
            var response = await _requestContext.GetAsync(ReportRoomUrl(roomId));

            if (response.Status == 200)
            {
                var jsonResponse = await response.TextAsync();

                var settings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Ignore,
                    DateTimeZoneHandling = DateTimeZoneHandling.Utc
                };

                return JsonConvert.DeserializeObject<RoomReport>(jsonResponse, settings);
            }

            throw new InvalidOperationException($"Failed to fetch room report with status code: {response.Status}");
        }
    }
}

