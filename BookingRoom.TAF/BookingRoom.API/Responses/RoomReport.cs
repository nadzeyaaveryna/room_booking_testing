namespace BookingRoom.API.Responses
{
    public  class RoomReport
    { 
        public List<ReportItem> Report { get; set; }
    }

    public class ReportItem
    {
        public string Start { get; set; }

        public string End { get; set; }

        public string Title { get; set; }
    }
}

