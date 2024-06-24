using MediatR;
using Pinewood.Domain.Shared;

namespace Pinewood.App.Customers.EditCustomer
{
    public sealed record EditCustomerCommand(int Id, string Name, string? Email)
        : IRequest<Result<EditCustomerCommandResponse>>;
}
