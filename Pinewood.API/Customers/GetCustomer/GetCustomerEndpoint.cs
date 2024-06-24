using Carter;
using MediatR;
using Pinewood.App.Customers.GetCustomer;

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
                var customer = await mediator.Send(query);
                return customer is not null
                    ? Results.Ok(customer)
                    : Results.NotFound(new { error = "Customer not found" });
            }).Produces(StatusCodes.Status200OK)
              .Produces(StatusCodes.Status404NotFound)
              .WithName("GetCustomer")
              .WithTags("Customers"); ;
        }
    }
}
