using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuilderTestSample.Model;

namespace BuilderTestSample.Tests.TestBuilders
{
    public class AddressBuilder
    {
        private string _street1;
        private string _street2;
        private string _street3;
        private string _city;
        private string _state;
        private string _postalCode;
        private string _country;

        public AddressBuilder()
        {
            _street1 = "testStreet1";
            _street2 = "testStreet2";
            _street3 = "testStreet3";
            _city = "testCity";
            _state = "testState";
            _postalCode = "testPostalCode";
            _country = "testCountry";
        }

        public AddressBuilder WithStreet1(string street1)
        {
            _street1 = street1;
            return this;
        }

        public Address Build()
        {
            return new Address()
            {
                Street1 = _street1,
                Street2 = _street2,
                Street3 = _street3,
                City = _city,
                State = _state,
                PostalCode = _postalCode,
                Country = _country
            };
        }
    }
}
