namespace Vasilek.Web
{
    public static class StaticDitels
    {
        public static string? ProductApiBase { get; set; }
        public static string? ShoppingCartApiBase { get; set; }
        public enum ApiType
        { 
            GET,
            POST,
            PUT,
            DELETE
        }
    }
}
