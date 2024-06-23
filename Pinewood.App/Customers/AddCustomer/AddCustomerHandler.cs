using MediatR;
using Pinewood.Domain.Customers;
using Pinewood.Domain.Shared;

namespace Pinewood.App.Customers.AddCustomer
{
    public sealed class AddCustomerHandler(
        ICustomerService CustomerService)
               : IRequestHandler<AddCustomerCommand,
           Result<AddCustomerCommandResponse>>
    {
        public async Task<Result<AddCustomerCommandResponse>> Handle(
            AddCustomerCommand command,
            CancellationToken cancellationToken)
        {
            var newCustomer = new Customer { Name = command.Name };

            int newId = CustomerService.Add(newCustomer);

            CustomerService.SaveChanges();

            var addCustomerCommandResponse = new AddCustomerCommandResponse(newId);

            return Result<AddCustomerCommandResponse>.Success(addCustomerCommandResponse);
        }
    }
}
