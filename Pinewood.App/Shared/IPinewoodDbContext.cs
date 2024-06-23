using Microsoft.EntityFrameworkCore;
using Pinewood.Domain.Customers;

namespace Pinewood.App.Shared
{
    public interface IPinewoodDbContext
    {
        DbSet<Customer> Customers { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
