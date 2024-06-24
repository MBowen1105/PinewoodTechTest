using MediatR;
using Pinewood.App.Customers.GetCustomer;
using Pinewood.Domain.Customers;
using Pinewood.Domain.Shared;

namespace Pinewood.App.Customers.EditCustomer
{
    public sealed class EditCustomerHandler(
        ICustomerRepository CustomerRepository)
               : IRequestHandler<EditCustomerCommand, Result<EditCustomerCommandResponse>>
    {
        public async Task<Result<EditCustomerCommandResponse>> Handle(
            EditCustomerCommand command,
            CancellationToken cancellationToken)
        {
            var modifiedCustomer = new Customer
            {
                Id = command.Id,
                Name = command.Name,
                Email = command.Email,
            };

            Customer? customer = CustomerRepository
                .Edit(modifiedCustomer);

            if (customer is null)
            {
                return Result<EditCustomerCommandResponse>.Failure(
                    new Error("EditCustomer", $"Customer {command.Id} Not Found"));
            }

            CustomerRepository.SaveChanges();

            var editCustomerCommandResponse = new EditCustomerCommandResponse(
                modifiedCustomer.Id, 
                modifiedCustomer.Name,
                modifiedCustomer.Email);

            return Result<EditCustomerCommandResponse>
                .Success(editCustomerCommandResponse);
        }
    }
}
