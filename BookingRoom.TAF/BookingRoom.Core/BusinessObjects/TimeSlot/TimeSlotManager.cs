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
                        return new TimeSlot(currentDay, potentialEndDate);
                    }
                }

                currentDay = currentDay.AddDays(1);
            }

            return null;
        }

        private bool IsOverlappingWithAnySlot(List<TimeSlot> timeSlots, DateTime startDate, DateTime endDate)
        {
            return timeSlots.Any(slot => slot.StartDate <= endDate && slot.EndDate >= startDate);
        }
    }
}