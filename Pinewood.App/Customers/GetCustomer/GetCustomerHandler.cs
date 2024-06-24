using MediatR;
using Pinewood.Domain.Shared;

namespace Pinewood.App.Customers.GetCustomer
{
    public sealed class GetCustomerHandler(
        ICustomerRepository CustomerRepository)
               : IRequestHandler<GetCustomerQuery, Result<GetCustomerQueryResponse>>
    {
        public async Task<Result<GetCustomerQueryResponse>> Handle(
            GetCustomerQuery request, CancellationToken cancellationToken)
        {
            var customer  = CustomerRepository.GetById(request.Id);

            if (customer == null)
            {
                return Result<GetCustomerQueryResponse>.Failure(
                    new Error("GetCustomer", $"Customer {request.Id} Not Found"));
            }

            var response = new GetCustomerQueryResponse(
                customer.Id,
                customer.Name,
                customer.Email);

            return Result<GetCustomerQueryResponse>.Success(response);
        }
    }
}
