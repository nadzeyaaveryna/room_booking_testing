using Microsoft.Playwright;
using Newtonsoft.Json;

namespace BookingRoom.API.ApiControllers
{
    public abstract class BaseApi
    {
        private readonly IAPIRequestContext _requestContext;

        protected abstract string HostEndpoint { get; }

        protected BaseApi(IAPIRequestContext requestContext)
        {
            _requestContext = requestContext;
        }

        protected async Task<T?> Get<T>(string resourceUrl) where T : class
        {
            var response = await _requestContext.GetAsync(resourceUrl);

            if (response.Status == 200)
            {
                var jsonResponse = await response.TextAsync();

                var settings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Ignore,
                    DateTimeZoneHandling = DateTimeZoneHandling.Utc
                };

                return JsonConvert.DeserializeObject<T>(jsonResponse, settings);
            }

            throw new InvalidOperationException($"Failed to fetch room report with status code: {response.Status}");
        }

    }
}
