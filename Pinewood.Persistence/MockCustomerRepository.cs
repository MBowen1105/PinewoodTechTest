using Pinewood.App;
using Pinewood.Domain.Customers;

namespace Pinewood.Persistence
{
    public sealed class MockCustomerRepository : ICustomerRepository
    {
        private readonly List<Customer> _customers = [
            new Customer { Id = 1, Name = "Customer 1", Email = "info@Customer1.com"},
            new Customer { Id = 2, Name = "Customer 2", Email = "info@Customer2.com"}
            ];

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

        public bool Delete(int id)
        {
            Customer? customer = GetById(id);
            if (customer != null)
            {
                _customers.Remove(customer);
                return true;
            }
            return false;
        }

        public int SaveChanges()
        {
            return 1;
        }
    }
}
