using BookingRoom.Core.Utils;

namespace BookingRoom.Core.BusinessObjects.Person
{
    public  class PersonManager
    {
        public Person GenerateRandomPersonDetails()
        {
            return new Person
            {
                FirstName = StringGenerationHelper.GenerateRandomString(15),
                LastName = StringGenerationHelper.GenerateRandomString(10),
                Email = StringGenerationHelper.GenerateRandomEmail(5),
                Phone = StringGenerationHelper.GenerateRandomNumericString(13)
            };
        }
    }
}
