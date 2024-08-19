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

        public static string GetFormattedString(this DateTime date, string format) =>
            date.ToString(format);

        public static DateTime GetRandomDateTime()
        {
            var time = DateTime.Today;
            time = time.AddDays(Random.Next(1, 170));
            time = time.AddHours(Random.Next(9, 20));

            return time;
        }


        public static DateTime FindNearestMonthStartingNotOnSunday(DateTime? startDate = null)
        { 
            DateTime date = startDate ?? DateTime.Today;

            int month = date.Month;
            int year = date.Year;

            while (true)
            {
                DateTime firstDayOfNextMonth = new DateTime(year, month, 1);

                // Check if the first day is not a Sunday
                if (firstDayOfNextMonth.DayOfWeek != DayOfWeek.Sunday)
                {
                    return firstDayOfNextMonth;
                }

                if (month == 12)
                {
                    month = 1;  
                    year++;     
                }
                else
                {
                    month++;    
                }

                
            }
        }

        public static List<int> GetVisibleDaysFromPreviousMonth(DateTime currentDate)
        {
            List<int> daysFromPreviousMonth = new List<int>();
            DateTime firstDayOfCurrentMonth = new DateTime(currentDate.Year, currentDate.Month, 1);

            DayOfWeek firstDayOfWeek = firstDayOfCurrentMonth.DayOfWeek;


            if (firstDayOfWeek == DayOfWeek.Sunday)
            {
                return daysFromPreviousMonth;
            }

            DateTime lastDayOfPreviousMonth = firstDayOfCurrentMonth.AddDays(-1);

            // Calculate how many days from previous month are visible
            int daysVisible = (int)firstDayOfWeek;

            for (int i = 0; i < daysVisible; i++)
            {
                // Add day numbers starting from the last day of the previous month and moving backwards
                daysFromPreviousMonth.Add(lastDayOfPreviousMonth.Day - i);
            }

            // Since we added days in reverse order, reverse the list to make them sequential
            daysFromPreviousMonth.Reverse();

            return daysFromPreviousMonth;
        }


        public static int CalculateNights(DateTime startDate, DateTime endDate)
        {
            if (endDate < startDate)
            {
                throw new ArgumentException("End date must be greater than or equal to start date.");
            }

            TimeSpan dateDifference = endDate - startDate;
            return dateDifference.Days;
        }
    }
}
