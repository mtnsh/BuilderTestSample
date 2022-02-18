using BuilderTestSample.Model;

namespace BuilderTestSample.Tests.TestBuilders
{
    public class CustomerBuilder
    {
        private int _id;
        private Address _address;
        private string _firstName;
        private string _lastName;
        private int _credit;
        private int _totalPurchases;


        public Customer Build()
        {
            return new Customer(_id)
            {
                HomeAddress = _address,
                FirstName = _firstName,
                LastName = _lastName,
                CreditRating = _credit,
                TotalPurchases = _totalPurchases
            };
        }

        public CustomerBuilder()
        {
            _id = 111;
            _address = new Address();
            _firstName = "john";
            _lastName = "doe";
            _credit = 201;
            _totalPurchases = 0;
        }

        public CustomerBuilder WithId(int id)
        {
            _id = id;
            return this;
        }

        public CustomerBuilder WithAddress(Address address)
        {
            _address = address;
            return this;
        }

        public CustomerBuilder WithFirstName(string firstName)
        {
            _firstName = firstName;
            return this;
        }

        public CustomerBuilder WithLastName(string lastName)
        {
            _lastName = lastName;
            return this;
        }

        public CustomerBuilder WithCredit(int credit)
        {
            _credit = credit;
            return this;
        }

        public CustomerBuilder WithTotalPurchases(int totalPurchases)
        {
            _totalPurchases = totalPurchases;
            return this;
        }
    }
}