using MediatR;
using Pinewood.Domain.Shared;

namespace Pinewood.App.Customers.GetCustomer
{
    public record GetCustomerQuery(int Id)
        :IRequest<Result<GetCustomerQueryResponse>>;
}
