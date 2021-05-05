namespace AspNet.Template.Shared.Configurations
{
    public class Configurations
    {
        public string ConnectionString { get; set; }
        public Logging Logging { get; set; }

        public Keys Keys { get; set; }
    }

    public class Logging 
    {
        public string ElmahIoApiKey { get; set; }
        public string ElmahIoLogId { get; set; }
        public string Sentry { get; set; }
    }

    public class Keys 
    {
        public string PrivateKey { get; set; }
        public string PublicString { get; set; }
    }
}