using Pinewood.Domain.Customers;

namespace Pinewood.App.Customers
{
    public sealed class CustomerService : ICustomerService
    {
        List<Customer> _customerList = [];
        Customer _newCustomer = new() { Name = ""};

        public int Add(Customer customer)
        {
            int nextId = _customerList.Any() ?
                _customerList.Max(x => x.Id)
                : 0;
            nextId++;
            _newCustomer = new()
            {
                Id = nextId,
                Name = customer.Name
            };
            return nextId;
        }

        public int SaveChanges()
        {
            _customerList.Add(_newCustomer);
            return 1;
        }
    }
}