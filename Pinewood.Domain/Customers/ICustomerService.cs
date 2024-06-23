namespace Pinewood.Domain.Customers
{
    public interface ICustomerService
    {
        Task<Customer> AddAsync(Customer customer, CancellationToken cancellationToken);

        Task<int> SaveChangesAsync();
    }
}
