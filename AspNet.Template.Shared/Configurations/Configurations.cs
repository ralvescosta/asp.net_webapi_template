namespace AspNet.Template.Shared.Configurations
{
    public class Configurations
    {
        public string ConnectionString { get; set; }
        public Logging Logging { get; set; }

        public JwtConfigs JwtConfigs { get; set; }
    }

    public class Logging 
    {
        public string ElmahIoApiKey { get; set; }
        public string ElmahIoLogId { get; set; }
        public string Sentry { get; set; }
    }

    public class JwtConfigs 
    {
        public string Issuer { get; set; }
        public string PrivateKey { get; set; }
        public string PublicKey { get; set; }
    }
}