using BuilderTestSample.Exceptions;
using BuilderTestSample.Model;
using BuilderTestSample.Services;
using BuilderTestSample.Tests.TestBuilders;
using Xunit;

namespace BuilderTestSample.Tests
{
    public class OrderServicePlaceOrder
    {
        private readonly OrderService _orderService = new ();
        private readonly OrderBuilder _orderBuilder = new ();
        private readonly CustomerBuilder _customerBuilder = new ();
        private readonly AddressBuilder _addressBuilder = new ();


        [Fact]
        public void ThrowsExceptionCountryIsNull()
        {
            var address = _addressBuilder
                            .WithCountry(null)
                            .Build();

            var customer = _customerBuilder
                .WithAddress(address)
                .Build();

            var order = _orderBuilder
                            .WithCustomer(customer)
                            .Build();

            Assert.Throws<InvalidAddressException>(() => _orderService.PlaceOrder(order));
        }

        [Fact]
        public void ThrowsExceptionPostalCodeIsNull()
        {
            var address = _addressBuilder
                            .WithPostalCode(null)
                            .Build();

            var customer = _customerBuilder
                .WithAddress(address)
                .Build();

            var order = _orderBuilder
                            .WithCustomer(customer)
                            .Build();

            Assert.Throws<InvalidAddressException>(() => _orderService.PlaceOrder(order));
        }

        [Fact]
        public void ThrowsExceptionStateIsNull()
        {
            var address = _addressBuilder
                            .WithState(null)
                            .Build();

            var customer = _customerBuilder
                .WithAddress(address)
                .Build();

            var order = _orderBuilder
                            .WithCustomer(customer)
                            .Build();

            Assert.Throws<InvalidAddressException>(() => _orderService.PlaceOrder(order));
        }

        [Fact]
        public void ThrowsExceptionCityIsNull()
        {
            var address = _addressBuilder
                            .WithCity(null)
                            .Build();

            var customer = _customerBuilder
                .WithAddress(address)
                .Build();

            var order = _orderBuilder
                            .WithCustomer(customer)
                            .Build();

            Assert.Throws<InvalidAddressException>(() => _orderService.PlaceOrder(order));
        }

        [Fact]
        public void ThrowsExceptionAddressIsNull()
        {
            var address = _addressBuilder
                            .WithStreet1(null)
                            .Build();

            var customer = _customerBuilder
                .WithAddress(address)
                .Build();

            var order = _orderBuilder
                            .WithCustomer(customer)
                            .Build();

            Assert.Throws<InvalidAddressException>(() => _orderService.PlaceOrder(order));
        }

        [Fact]
        public void ThrowsExceptionGivenCustomerTotalPurchasesLessThan0()
        {
            var customer = _customerBuilder
                .WithTotalPurchases(-1)
                .Build();

            var order = _orderBuilder
                            .WithCustomer(customer)
                            .Build();

            Assert.Throws<InvalidCustomerException>(() => _orderService.PlaceOrder(order));
        }

        [Fact]
        public void ThrowsExceptionGivenCustomerCreditIsLessThan201()
        {
            var customer = _customerBuilder
                .WithCredit(200)
                .Build();

            var order = _orderBuilder
                            .WithCustomer(customer)
                            .Build();

            Assert.Throws<InsufficientCreditException>(() => _orderService.PlaceOrder(order));
        }

        [Fact]
        public void ThrowsExceptionGivenCustomerHasNoFirstAndLastName()
        {
            var customer = _customerBuilder
                .WithFirstName("")
                .WithLastName("")
                .Build();

            var order = _orderBuilder
                            .WithCustomer(customer)
                            .Build();

            Assert.Throws<InvalidCustomerException>(() => _orderService.PlaceOrder(order));
        }

        [Fact]
        public void ThrowsExceptionGivenCustomerAddressIsNull()
        {
            var customer = _customerBuilder
                .WithAddress(null)
                .Build();

            var order = _orderBuilder
                            .WithCustomer(customer)
                            .Build();

            Assert.Throws<InvalidCustomerException>(() => _orderService.PlaceOrder(order));
        }

        [Fact]
        public void ThrowsExceptionGivenCustomerIdIs0()
        {
            var customer = _customerBuilder
                .WithId(0)
                .Build();

            var order = _orderBuilder
                            .WithCustomer(customer)
                            .Build();

            Assert.Throws<InvalidCustomerException>(() => _orderService.PlaceOrder(order));
        }

        [Fact]
        public void ThrowsExceptionGivenOrderWithExistingId()
        {
            var order = _orderBuilder
                            .WithId(123)
                            .Build();

            Assert.Throws<InvalidOrderException>(() => _orderService.PlaceOrder(order));
        }


        [Fact]
        public void ThrowsExceptionGivenOrderTotalAmountIs0()
        {
            var order = _orderBuilder
                            .WithTotalAmount(0)
                            .Build();

            Assert.Throws<InvalidOrderException>(() => _orderService.PlaceOrder(order));
        }


        [Fact]
        public void ThrowsExceptionGivenOrderHasNoCustomer()
        {
            var order = _orderBuilder
                            .WithCustomer(null)
                            .Build();

            Assert.Throws<InvalidOrderException>(() => _orderService.PlaceOrder(order));
        }
    }
}
