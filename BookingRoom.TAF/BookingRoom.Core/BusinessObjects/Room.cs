namespace BookingRoom.Core.BusinessObjects
{
    public class Room
    {
        public string Type { get; set; }

        public string Description { get; set; }

        public List<string> Amenities { get; set; }

        public bool HasWheelchairAccess { get; set; }

        public TimeSlot BookingTime { get; set; }

        public Room()
        {
            Amenities = new List<string>();
            BookingTime = new TimeSlot();
        }
    }
}
