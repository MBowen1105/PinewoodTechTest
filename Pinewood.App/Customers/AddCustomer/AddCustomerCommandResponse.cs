namespace Pinewood.App.Customers.AddCustomer
{
    public sealed record AddCustomerCommandResponse(int Id, string Name, string? Email);
}
