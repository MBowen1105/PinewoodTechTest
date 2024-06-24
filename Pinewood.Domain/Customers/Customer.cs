using Pinewood.Domain.Shared;

namespace Pinewood.Domain.Customers
{
    public sealed class Customer : Entity
    {
        public required string Name { get; set; }
        public string? Email { get; set; }
    }
}
