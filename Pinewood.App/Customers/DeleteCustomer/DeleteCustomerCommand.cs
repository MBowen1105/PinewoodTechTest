using MediatR;
using Pinewood.Domain.Shared;

namespace Pinewood.App.Customers.DeleteCustomer
{
    public sealed record DeleteCustomerCommand(int Id)
        : IRequest<Result<bool>>;
}
