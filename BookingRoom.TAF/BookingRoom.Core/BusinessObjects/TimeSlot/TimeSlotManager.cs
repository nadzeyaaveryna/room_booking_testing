namespace BookingRoom.Core.BusinessObjects.TimeSlot
{
    /// <summary>
    /// Provides search of available slots for booking
    /// </summary>
    public class TimeSlotManager
    {

        public List<TimeSlot> BookedSlots { get; set; }

        public TimeSlotManager(List<TimeSlot> bookedSlots)
        {
            BookedSlots = bookedSlots;
        }

        /// <summary>
        /// Searches for an available time slot in the past, starting from a month ago and going backwards.
        /// </summary>
        /// <param name="timeSlotDays">The number of consecutive days needed for the time slot.</param>
        /// <returns>An available time slot if found; otherwise, null.</returns>
        public TimeSlot FindAvailablePastSlot(int timeSlotDays)
        {
            var currentDate = DateTime.Now.Date;
            var currentDay = currentDate.AddMonths(-1); 

            var sortedBookedSlots = BookedSlots.Where(slot => slot.EndDate <= currentDate)
                .OrderByDescending(slot => slot.StartDate)
                .ToList();

            // Continue backward in time
            while (currentDay >= DateTime.MinValue)
            {
                bool isOverlapping = sortedBookedSlots.Any(slot =>
                    slot.StartDate <= currentDay && slot.EndDate >= currentDay);

                if (!isOverlapping)
                {
                    DateTime potentialEndDate = currentDay.AddDays(-timeSlotDays + 1);
                    if (potentialEndDate >= DateTime.MinValue && !IsOverlappingWithAnySlot(sortedBookedSlots, potentialEndDate, currentDay))
                    {
                        return new TimeSlot(potentialEndDate, currentDay) { IsBookedInTest = true };
                    }
                }

                currentDay = currentDay.AddDays(-1); // Move back a day
            }

            return null;
        }

        /// <summary>
        /// Attempts to find an available time slot in future months, starting either from today or a specified number of months ahead.
        /// The search length is determined by the maxMonthsToCheck parameter starting from today or the month calculated by monthsAhead.
        /// </summary>
        /// <param name="timeSlotDays">The number of consecutive days needed for the time slot.</param>
        /// <param name="monthsAhead">Number of months to skip from the current month before beginning the search (0 means start from today).</param>
        /// <param name="maxMonthsToCheck">The maximum number of months to check, starting either from today or the calculated future month.</param>
        /// <returns>An available time slot if found; otherwise, null.</returns>
        public TimeSlot FindAvailableFutureSlot(int timeSlotDays, int monthsAhead = 0, int maxMonthsToCheck = 12)
        {
            // Ensure the list of booked slots is sorted by start date.
            BookedSlots = BookedSlots.OrderBy(slot => slot.StartDate).ToList();

            var currentDate = DateTime.Now;
            var startingPoint = monthsAhead == 0 ? currentDate : new DateTime(currentDate.Year, currentDate.Month, 1).AddMonths(monthsAhead);

            for (int i = 0; i < maxMonthsToCheck; i++)
            {
                var searchStart = monthsAhead == 0 && i == 0 ? startingPoint : new DateTime(startingPoint.Year, startingPoint.Month, 1).AddMonths(i);
                var searchEnd = new DateTime(searchStart.Year, searchStart.Month, DateTime.DaysInMonth(searchStart.Year, searchStart.Month));


                while (searchStart <= searchEnd)
                {
                    var potentialEndDate = searchStart.AddDays(timeSlotDays - 1); 

                    if (potentialEndDate > searchEnd)
                        break;

                    if (!IsOverlappingWithAnySlot(BookedSlots, searchStart, potentialEndDate))
                    {
                        return new TimeSlot(searchStart, potentialEndDate) { IsBookedInTest = true };
                    }

                    searchStart = searchStart.AddDays(1);
                }
            }
            return default;
        }

        private bool IsOverlappingWithAnySlot(List<TimeSlot> timeSlots, DateTime startDate, DateTime endDate)
        {
            return timeSlots.Any(slot => slot.StartDate <= endDate && slot.EndDate >= startDate);
        }
    }
}