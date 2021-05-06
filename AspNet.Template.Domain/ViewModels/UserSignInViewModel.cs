using System.ComponentModel.DataAnnotations;

namespace AspNet.Template.Domain.ViewModels
{
    public class UserSignInViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        [Required]
        public string Password { get; set; }

        [Required]
        public string Surname { get; set; }
    }
}