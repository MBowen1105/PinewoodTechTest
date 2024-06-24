using MediatR;
using Pinewood.Domain.Shared;

namespace Pinewood.App.Customers.AddCustomer
{
    public sealed record AddCustomerCommand(string Name, string? Email)
        : IRequest<Result<AddCustomerCommandResponse>>;
}
