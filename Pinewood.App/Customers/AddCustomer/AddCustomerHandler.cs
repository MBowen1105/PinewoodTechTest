using MediatR;
using Pinewood.Domain.Customers;
using Pinewood.Domain.Shared;

namespace Pinewood.App.Customers.AddCustomer
{
    public sealed class AddCustomerHandler(
        ICustomerRepository CustomerRepository)
               : IRequestHandler<AddCustomerCommand, Result<AddCustomerCommandResponse>>
    {
        public async Task<Result<AddCustomerCommandResponse>> Handle(
            AddCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = new Customer
            {
                Id = CustomerRepository.NextId(),
                Name = request.Name,
                Email = request.Email,
            };

            CustomerRepository.Add(customer);

            CustomerRepository.SaveChanges();

            var response = new AddCustomerCommandResponse(
                customer.Id,
                customer.Name,
                customer.Email);

            return Result<AddCustomerCommandResponse>.Success(response);
        }
    }
}
