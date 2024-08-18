namespace BookingRoom.Core.BusinessObjects
{
    public class Room
    {
        public int Index { get; set; }

        public string Type { get; set; }

        public string Description { get; set; }

        public List<string> Amenities { get; set; }

        public bool HasWheelchairAccess { get; set; }

        public List<TimeSlot> BookedSlots { get; set; }

        public Room()
        {
            Amenities = new List<string>();
            BookedSlots = new List<TimeSlot>();
        }
    }
}
