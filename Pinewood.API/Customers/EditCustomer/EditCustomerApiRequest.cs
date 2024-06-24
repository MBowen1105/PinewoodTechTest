namespace Pinewood.API.Customers.EditCustomer
{
    public sealed record EditCustomerApiRequest(int Id, string Name, string? Email);
}
