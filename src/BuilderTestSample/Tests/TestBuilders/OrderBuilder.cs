﻿using BuilderTestSample.Model;
using System;

namespace BuilderTestSample.Tests.TestBuilders
{
    /// <summary>
    /// Reference: https://ardalis.com/improve-tests-with-the-builder-pattern-for-test-data
    /// </summary>
    public class OrderBuilder
    {
        private readonly Order _order = new ();

        public OrderBuilder()
        {
            _order.Id = 0;
            _order.TotalAmount = 100m;

            // TODO: replace next lines with a CustomerBuilder you create
            // _order.Customer = new Customer();
            // _order.Customer.HomeAddress = new Address();
        }

        public OrderBuilder WithId(int id)
        {
            _order.Id = id;
            return this;
        }

        public OrderBuilder WithTotalAmount(int totalAmount)
        {
            _order.TotalAmount = totalAmount;
            return this;
        }

        public OrderBuilder WithCustomer(Customer customer)
        {
            _order.Customer = customer;
            return this;
        }

        public Order Build()
        {
            return _order;
        }
    }
}
