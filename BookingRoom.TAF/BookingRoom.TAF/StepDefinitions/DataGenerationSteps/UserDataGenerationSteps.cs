using BookingRoom.Core.BusinessObjects;
using BookingRoom.Core.BusinessObjects.Person;
using BookingRoom.Core.Utils;
using BookingRoom.Core.Utils.TestsContext;

namespace BookingRoom.Test.StepDefinitions.DataGenerationSteps
{
    [Binding]
    public class UserDataGenerationSteps
    {

        [Given("Prepare user details with '(First Name|Last Name|Email|Phone)' as '(.*)'")]
        [When("Prepare user details with '(First Name|Last Name|Email|Phone)' as '(.*)'")]
        public void WhenPrepareUserDetailsWithInputAs(string userParameter, string value)
        {
            var room = TestContextVariable.Room.Get<Room>();
            var roomPersonBookedTheRoom = room.PersonBookedTheRoom ?? new PersonManager().GenerateRandomPersonDetails().Build();

            room.PersonBookedTheRoom = roomPersonBookedTheRoom;
            switch (userParameter)
            {
                case "First Name":
                    room.PersonBookedTheRoom.FirstName = value;
                    break;
                case "Last Name":
                    room.PersonBookedTheRoom.LastName = value;
                    break;
                case "Email":
                    room.PersonBookedTheRoom.Email = value;
                    break;
                case "Phone":
                    room.PersonBookedTheRoom.Phone = value;
                    break;
                default:
                    throw new ArgumentException("Invalid field name or value", nameof(userParameter));
            }
        }

        [Given("Prepare user details with '(First Name|Last Name|Email|Phone)' with length as '(.*)'")]
        [When("Prepare user details with '(First Name|Last Name|Email|Phone)' with length as '(.*)'")]
        public void WhenPrepareUserDetailsWithLegthAs(string userParameter, int length)
        {
            var room = TestContextVariable.Room.Get<Room>();
            var roomPersonBookedTheRoom = room.PersonBookedTheRoom ?? new PersonManager().GenerateRandomPersonDetails().Build();

            room.PersonBookedTheRoom = roomPersonBookedTheRoom;
            switch (userParameter)
            {
                case "First Name":
                    room.PersonBookedTheRoom.FirstName = StringGenerationHelper.GenerateRandomString(length);
                    break;
                case "Last Name":
                    room.PersonBookedTheRoom.LastName = StringGenerationHelper.GenerateRandomString(length); 
                    break;
                case "Email":
                    room.PersonBookedTheRoom.Email = StringGenerationHelper.GenerateRandomEmail(length);
                    break;
                case "Phone":
                    room.PersonBookedTheRoom.Phone = StringGenerationHelper.GenerateRandomNumericString(length);
                    break;
                default:
                    throw new ArgumentException("Invalid field name or value", nameof(userParameter));
            }

        }
    }
}
