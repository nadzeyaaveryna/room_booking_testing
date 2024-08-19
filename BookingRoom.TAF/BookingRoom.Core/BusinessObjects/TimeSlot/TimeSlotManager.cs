namespace BookingRoom.Core.BusinessObjects.TimeSlot
{
    public class TimeSlotManager
    {

        public List<TimeSlot> BookedSlots { get; set; }

        public TimeSlotManager(List<TimeSlot> bookedSlots)
        {
            BookedSlots = bookedSlots;
        }

        public TimeSlot FindAvailableSlotStartingFromCurrentMonth(int timeSlotDays)
        {
            DateTime currentDay = DateTime.Now;
            DateTime endOfThisMonth = new DateTime(currentDay.Year, currentDay.Month, DateTime.DaysInMonth(currentDay.Year, currentDay.Month));

            var sortedBookedSlots = BookedSlots.Where(slot => slot.EndDate >= currentDay)
                .OrderBy(slot => slot.StartDate)
                .ToList();

            while (currentDay <= endOfThisMonth)
            {
                bool isOverlapping = sortedBookedSlots.Any(slot => slot.StartDate <= currentDay && slot.EndDate >= currentDay);

                if (!isOverlapping)
                {
                    DateTime potentialEndDate = currentDay.AddDays(timeSlotDays - 1);
                    if (potentialEndDate <= endOfThisMonth && !IsOverlappingWithAnySlot(sortedBookedSlots, currentDay, potentialEndDate))
                    {
                        return new TimeSlot(currentDay, potentialEndDate) {IsBookedInTest = true};
                    }
                }

                currentDay = currentDay.AddDays(1);
            }

            return null;
        }

        public TimeSlot FindAvailablePastSlot(int timeSlotDays)
        {
            DateTime currentDate = DateTime.Now.Date;
            DateTime currentDay = currentDate.AddMonths(-1); 

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

        private bool IsOverlappingWithAnySlot(List<TimeSlot> timeSlots, DateTime startDate, DateTime endDate)
        {
            return timeSlots.Any(slot => slot.StartDate <= endDate && slot.EndDate >= startDate);
        }
    }
}