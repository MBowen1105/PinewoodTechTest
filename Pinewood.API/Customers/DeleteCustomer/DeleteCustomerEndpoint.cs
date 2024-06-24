using Carter;
using MediatR;
using Pinewood.App.Customers.DeleteCustomer;

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
                await mediator.Send(command);
                return Results.NoContent();
            })
            .Produces(StatusCodes.Status204NoContent)
                          .WithName("DeleteCustomer")
                          .WithTags("Customers");
        }
    }
}
