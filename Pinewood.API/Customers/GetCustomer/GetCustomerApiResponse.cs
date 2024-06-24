namespace Pinewood.API.Customers.GetCustomer
{
    public sealed record GetCustomerApiResponse(int Id, string Name, string? Email);
}
