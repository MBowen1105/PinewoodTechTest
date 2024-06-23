using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pinewood.App.Customers.AddCustomer;
using Pinewood.Domain.Shared;

namespace Pinewood.API.Customers.AddCustomer
{
    public class AddCustomerEndpoint
        : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("api/v1/customers", async (
                ISender sender, 
                [FromBody] AddCustomerApiRequest apiRequest) =>
            {
                var command = new AddCustomerCommand(apiRequest.Name);

                var commandResponse = await sender.Send(command);

                if (commandResponse.IsFailure)
                {
                    return Results.BadRequest(commandResponse.Error);
                }

                string url = $"api/v1/customers/{commandResponse.Value.Id}";

                return Results.Ok(url);
            }).Produces(StatusCodes.Status201Created)
              .Produces<Error>(StatusCodes.Status400BadRequest)
              .WithName("AddCustomer")
              .WithTags("Customers");
        }
    }
}
