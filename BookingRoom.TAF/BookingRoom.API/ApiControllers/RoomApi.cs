using BookingRoom.API.Responses;
using Microsoft.Playwright;
using Newtonsoft.Json;

namespace BookingRoom.API.ApiControllers
{
    public class RoomApi
    {
        private readonly IAPIRequestContext _requestContext;

        private string RoomsUrl => $"https://automationintesting.online/room/";

        public RoomApi(IAPIRequestContext requestContext)
        {
            _requestContext = requestContext;
        }

        public async Task<Rooms?> GetRoomReportAsync()
        {
            var response = await _requestContext.GetAsync(RoomsUrl);

            if (response.Status == 200)
            {
                var jsonResponse = await response.TextAsync();

                var settings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Ignore,
                    DateTimeZoneHandling = DateTimeZoneHandling.Utc
                };

                return JsonConvert.DeserializeObject<Rooms>(jsonResponse, settings);
            }

            throw new InvalidOperationException($"Failed to fetch room report with status code: {response.Status}");
        }
    }
}
