namespace Pinewood.App.Customers.EditCustomer
{
    public sealed record EditCustomerCommandResponse(int Id, string Name, string? Email);
}
