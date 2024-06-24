using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pinewood.App.Customers.EditCustomer;
using Pinewood.Domain.Shared;

namespace Pinewood.API.Customers.EditCustomer
{
    public class EditCustomerEndpoint
        : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPut("/customers", async (IMediator mediator, [FromBody] EditCustomerApiRequest request) =>
            {
                var command = new EditCustomerCommand(
                    request.Id,
                    request.Name,
                    request.Email);

                await mediator.Send(command);

                return Results.NoContent();

            }).Produces(StatusCodes.Status204NoContent)
              .Produces<Error>(StatusCodes.Status400BadRequest)
              .WithName("EditCustomer")
              .WithTags("Customers");
        }
    }
}
