﻿using BuilderTestSample.Exceptions;
using BuilderTestSample.Model;

namespace BuilderTestSample.Services
{
    public class OrderService
    {
        public void PlaceOrder(Order order)
        {
            ValidateOrder(order);

            ExpediteOrder(order);

            AddOrderToCustomerHistory(order);
        }

        private void ValidateOrder(Order order)
        {
            // throw InvalidOrderException unless otherwise noted.

            if (order.Id != 0) throw new InvalidOrderException("Order ID must be 0.");
            if (order.TotalAmount <= 0) throw new InvalidOrderException("Order total amount must be greater 0.");
            if (order.Customer is null) throw new InvalidOrderException("Order must have a customer");

            ValidateCustomer(order.Customer);
        }

        private void ValidateCustomer(Customer customer)
        {
            // throw InvalidCustomerException unless otherwise noted

            if (customer.Id <= 0) throw new InvalidCustomerException("Customer must have an ID > 0.");
            if (customer.HomeAddress is null) throw new InvalidCustomerException("Customer must have address.");
            if (string.IsNullOrEmpty(customer.FirstName) || string.IsNullOrEmpty(customer.LastName)) throw new InvalidCustomerException("Customer must have a first and last name.");
            if (customer.CreditRating <= 200) throw new InsufficientCreditException("Customer must have credit rating > 200.");
            if (customer.TotalPurchases < 0) throw new InvalidCustomerException("Customer must have total purchases >= 0");
            
            ValidateAddress(customer.HomeAddress);
        }

        private void ValidateAddress(Address homeAddress)
        {
            // throw InvalidAddressException unless otherwise noted
            // create an AddressBuilder to implement the tests for these scenarios
            if (string.IsNullOrEmpty(homeAddress.Street1)) throw new InvalidAddressException("Address must have street1.");
            if (string.IsNullOrEmpty(homeAddress.City)) throw new InvalidAddressException("Address must have city.");
            if (string.IsNullOrEmpty(homeAddress.State)) throw new InvalidAddressException("Address must have state.");
            if (string.IsNullOrEmpty(homeAddress.PostalCode)) throw new InvalidAddressException("Address must have postal code.");
            if (string.IsNullOrEmpty(homeAddress.Country)) throw new InvalidAddressException("Address must have country.");
        }

        private void ExpediteOrder(Order order)
        {
            if (order.Customer.TotalPurchases > 5000
                && order.Customer.CreditRating > 500)
            {
                order.IsExpedited = true;

            }
        }

        private void AddOrderToCustomerHistory(Order order)
        {
            order.Customer.OrderHistory.Add(order);
            order.Customer.TotalPurchases = order.TotalAmount;
        }
    }
}
