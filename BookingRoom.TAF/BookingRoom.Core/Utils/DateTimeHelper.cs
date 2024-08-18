using System.Globalization;
using BookingRoom.Core.Utils.Logger;

namespace BookingRoom.Core.Utils
{
    public static class DateTimeHelper
    {
        private static ILogger Logger => LoggerInstance.Instance();
        private static readonly Random Random = new();

        public static DateTime ParseDateTime(this string date, string format)
        {
            try
            {
                return DateTime.ParseExact(date, format, CultureInfo.InvariantCulture);
            }
            catch (Exception ex)
            {
                Logger.Error($"Unable to convert displayed time to Date Time format: {format}! Displayed is date:[{date}]");
                Logger.Error(ex);
                throw;
            }
        }

        public static DateTime GetRandomDateTime()
        {
            var time = DateTime.Today;
            time = time.AddDays(Random.Next(1, 170));
            time = time.AddHours(Random.Next(9, 20));

            return time;
        }
    }
}
