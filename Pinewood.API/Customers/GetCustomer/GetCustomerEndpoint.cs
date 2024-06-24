using Carter;
using MediatR;
using Pinewood.App.Customers.GetCustomer;
using Pinewood.Domain.Shared;

namespace Pinewood.API.Customers.GetCustomer
{
    public class GetCustomerEndpoint
           : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/customers/{id:int}", async (IMediator mediator, int id) =>
            {
                var query = new GetCustomerQuery(id);

                Result<GetCustomerQueryResponse> response = await mediator.Send(query);

                if (response.IsFailure)
                {
                    return Results.NotFound(new { error = response.Error.Description });
                }

                var getCustomerApiResponse = new GetCustomerApiResponse(
                    response.Value.Id,
                    response.Value.Name,
                    response.Value.Email);

                return Results.Ok(getCustomerApiResponse);

            }).Produces(StatusCodes.Status200OK)
              .Produces(StatusCodes.Status404NotFound)
              .WithName("GetCustomer")
              .WithTags("Customers"); ;
        }
    }
}
