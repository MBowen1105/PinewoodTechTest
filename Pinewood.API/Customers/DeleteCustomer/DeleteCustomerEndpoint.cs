using Carter;
using MediatR;
using Pinewood.App.Customers.DeleteCustomer;
using Pinewood.Domain.Shared;

namespace Pinewood.API.Customers.DeleteCustomer
{
    public class DeleteCustomerEndpoint
        : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("/customers/{id:int}", async (IMediator mediator, int id) =>
            {
                var command = new DeleteCustomerCommand(id);

                Result<bool> response = await mediator.Send(command);

                if (response.IsFailure)
                {
                    return Results.NotFound(response.Error.Description);
                }
                return Results.NoContent();
            })
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .WithName("DeleteCustomer")
            .WithTags("Customers");
        }
    }
}
