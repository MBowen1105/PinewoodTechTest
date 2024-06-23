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

            var result = await CustomerService.AddAsync(newCustomer, cancellationToken);

            await CustomerService.SaveChangesAsync();

            var addCustomerCommandResponse = new AddCustomerCommandResponse(result.Id);

            return Result<AddCustomerCommandResponse>.Success(addCustomerCommandResponse);
        }
    }
}
