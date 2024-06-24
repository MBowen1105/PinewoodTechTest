using Pinewood.Domain.Customers;

namespace Pinewood.App
{
    public interface ICustomerRepository
    {
        int NextId();
        void Add(Customer customer);
        Customer? GetById(int id);
        Customer? Edit(Customer customer);
        bool Delete(int id);
        int SaveChanges();
    }
}
