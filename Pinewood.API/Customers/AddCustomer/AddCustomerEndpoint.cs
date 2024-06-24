using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pinewood.App.Customers.AddCustomer;

namespace Pinewood.API.Customers.AddCustomer
{
    public class AddCustomerEndpoint
        : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            _ = app.MapPost("/customers", async (IMediator mediator,
                [FromBody] AddCustomerApiRequest apiRequest) =>
            {
                var command = new AddCustomerCommand(
                    apiRequest.Name,
                    apiRequest.Email);

                var response = await mediator.Send(command);

                if (response.IsFailure)
                {
                    return Results.BadRequest(command);
                }

                var apiResponse = new AddCustomerCommandResponse(
                    response.Value.Id,
                    response.Value.Name,
                    response.Value.Email);

                return Results.Created($"/customers/{response.Value.Id}", null);
            }).Produces(StatusCodes.Status201Created)
              .Produces(StatusCodes.Status400BadRequest)
              .WithName("AddCustomer")
              .WithTags("Customers");
        }
    }
}
