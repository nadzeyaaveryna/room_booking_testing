namespace BookingRoom.Core.Utils.TestsContext
{
    public class TestContextVariable
    {
        private TestContextVariable(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public static readonly TestContextVariable RoomElement = new("Room Element");
        public static readonly TestContextVariable Room = new("Room Entity");
        public static readonly TestContextVariable ExpectedRoom = new("Expected Room from API");
        public static readonly TestContextVariable CalendarOpenedDate = new("Calendar opened date");
    }
}
