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
            app.MapPut("/customers/{id:int}", async (IMediator mediator, int id, string name) =>
            {
                var command = new EditCustomerCommand(id, name);
                await mediator.Send(command);
                return Results.NoContent();
            }).Produces(StatusCodes.Status200OK)
              .Produces<Error>(StatusCodes.Status400BadRequest)
              .WithName("EditCustomer")
              .WithTags("Customers");
        }
    }
}
