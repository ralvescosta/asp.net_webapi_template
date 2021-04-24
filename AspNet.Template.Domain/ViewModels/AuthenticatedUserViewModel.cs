namespace AspNet.Template.Domain.ViewModels
{
    public class AuthenticatedUserViewModel
    {
        public string Email { get; set; }
        public string AccessToken { get; set; }
        public string ExpiredAt { get; set; }
    }
}