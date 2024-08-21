using BookingRoom.Core.Utils;

namespace BookingRoom.Core.BusinessObjects.Person
{
    public  class PersonManager
    {
        private readonly Person _person;

        public PersonManager()
        {
            _person = new Person();
        }

        public PersonManager GenerateRandomPersonDetails()
        {
            _person.FirstName = StringGenerationHelper.GenerateRandomString(15);
            _person.LastName = StringGenerationHelper.GenerateRandomString(10);
            _person.Email = StringGenerationHelper.GenerateRandomEmail(5);
            _person.Phone = StringGenerationHelper.GenerateRandomNumericString(13);

            return this;
        }

        public PersonManager AddFirstName(string firstName = null)
        {
            _person.FirstName = firstName ?? StringGenerationHelper.GenerateRandomString(15);
            return this;
        }

        public PersonManager AddLastName(string lastName = null)
        {
            _person.LastName = lastName ?? StringGenerationHelper.GenerateRandomString(10);
            return this;
        }

        public PersonManager AddEmail(string email = null)
        {
            _person.Email = email ?? StringGenerationHelper.GenerateRandomEmail(5);
            return this;
        }

        public PersonManager AddPhone(string phone = null)
        {
            _person.Phone = phone ?? StringGenerationHelper.GenerateRandomNumericString(13);
            return this;
        }
        public Person Build() => _person;
    }
}
