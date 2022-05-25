namespace WebShop.API.ExtensionMethods
{
    public static class FilterExtensionMethods
    {
        public static bool IsFilterable(this string property)
        {
            switch (property)
            {
                case "Page":
                case "DisplayCount":
                case "OnSale":
                case "InStock":
                    return false;

                default:
                    return true;
            }
        }
    }
}
