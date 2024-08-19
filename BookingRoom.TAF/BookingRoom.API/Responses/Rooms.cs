using Newtonsoft.Json;

namespace BookingRoom.API.Responses
{
    public class Rooms
    {
        [JsonProperty("rooms")]
        public List<OneRoom> RoomsList { get; set; }
    }

    public class OneRoom
    {
        [JsonProperty("roomid")]
        public int RoomId { get; set; }

        [JsonProperty("roomName")]
        public string RoomName { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("accessible")]
        public bool Accessible { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("features")]
        public List<string> Features { get; set; }

        [JsonProperty("roomPrice")]
        public decimal RoomPrice { get; set; }
    }
}
