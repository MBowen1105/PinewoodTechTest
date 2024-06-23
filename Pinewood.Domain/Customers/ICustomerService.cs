namespace Pinewood.Domain.Customers
{
    public interface ICustomerService
    {
        int Add(Customer customer);

        int SaveChanges();
    }
}
