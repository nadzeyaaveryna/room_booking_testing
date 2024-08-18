namespace BookingRoom.Core.BusinessObjects.TimeSlot
{
    public class TimeSlot
    {
        public TimeSlot(DateTime startDate, DateTime endDate)
        {
            StartDate = startDate;
            EndDate = endDate;
        }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool IsBookedInTest { get; set; }
    }
}
