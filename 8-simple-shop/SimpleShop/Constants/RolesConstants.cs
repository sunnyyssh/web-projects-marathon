namespace SimpleShop.Constants;

public static class RolesConstants
{
    public const string Admin = "Admin";
    
    public const string Supplier = "Supplier";

    public const string Customer = "Customer";

    public const string AdminAndCustomer = Admin + "," + Customer;
    
    public const string AdminAndSupplier = Admin + "," + Customer;

    public const string All = Admin + "," + Supplier + "," + Customer;
}