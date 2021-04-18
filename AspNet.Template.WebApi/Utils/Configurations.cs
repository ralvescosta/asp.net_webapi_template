namespace AspNet.Template.WebApi.Utils
{
    public class Configurations
    {
        public string ConnectionString { get; set; }
        public Logging Logging { get; set; }
    }

    public class Logging {
        public string ElmahIoApiKey { get; set; }
        public string ElmahIoLogId { get; set; }
        public string Sentry { get; set; }
    }
}