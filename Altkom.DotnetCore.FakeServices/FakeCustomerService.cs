using Altkom.Dotnecore.IServices;
using Altkom.DotnetCore.Models;
using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Altkom.DotnetCore.FakeServices
{
    public class FakeCustomerService : ICustomerService
    {
        private readonly ICollection<Customer> _customers;

        public FakeCustomerService(Faker<Customer> faker)
        {
            _customers = faker.Generate(100);
        }

        public void Add(Customer customer)
        {
            _customers.Add(customer);
        }

        public IEnumerable<Customer> Get()
        {
            return _customers;
        }

        public Customer Get(Guid id)
        {
            return _customers.SingleOrDefault(x => x.Id == id);
        }

        public void Remove(Guid id)
        {
            _customers.Remove(Get(id));
        }

        public void Update(Customer customer)
        {
            Remove(customer.Id);
            Add(customer);
        }
    }
}
