using MediatR;
using Pinewood.Domain.Shared;

namespace Pinewood.App.Customers.DeleteCustomer
{
    public sealed class DeleteCustomerHandler(
        ICustomerRepository CustomerRepository)
               : IRequestHandler<DeleteCustomerCommand, Result<bool>>
    {
        public async Task<Result<bool>> Handle(
            DeleteCustomerCommand request,
            CancellationToken cancellationToken)
        {
            bool result = CustomerRepository.Delete(request.Id);
            if (!result)
            {
                return Result<bool>.Failure(
                    new Error("EditCustomer", $"Customer {request.Id} Not Found"));
            }

            CustomerRepository.SaveChanges();

            return Result<bool>.Success(true);
        }
    }
}
