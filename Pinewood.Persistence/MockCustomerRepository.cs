using Pinewood.App;
using Pinewood.Domain.Customers;

namespace Pinewood.Persistence
{
    public sealed class MockCustomerRepository : ICustomerRepository
    {
        private readonly List<Customer> _customers = [];

        public int NextId()
        {
            return _customers.Count + 1;
        }

        public void Add(Customer customer)
        {
            _customers.Add(customer);
        }

        public Customer? GetById(int id)
        {
            return _customers.Find(c => c.Id == id);
        }

        public Customer? Edit(Customer customer)
        {
            var existingCustomer = _customers.Find(c => c.Id == customer.Id);
            if (existingCustomer is null)
            {
                return null;
            }
            _customers.Remove(existingCustomer);
            _customers.Add(customer);
            return customer;
        }

        public void Delete(int id)
        {
            Customer? customer = GetById(id);
            if (customer != null)
            {
                _customers.Remove(customer);
            }
        }

        Customer? void Edit(Customer customer)
        {
            Customer? thisCustomer = GetById(customer.Id);
            if (thisCustomer != null)
            {
                _customers.Remove(customer);
            }
        }

        public int SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
