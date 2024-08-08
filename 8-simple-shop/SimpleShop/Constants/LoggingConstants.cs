namespace SimpleShop.Constants;

public static class LoggingConstants
{
    public const string RootCategory = "SimpleShop";

    public const string PagesCategory = RootCategory + ".Pages";

    public static string CreatePageCategory(string pageName)
    {
        return string.Concat(PagesCategory, ".", pageName);
    }
}