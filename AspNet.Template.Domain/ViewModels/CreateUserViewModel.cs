using System.ComponentModel.DataAnnotations;

namespace AspNet.Template.Domain.ViewModels
{
    public class CreateUserViewModel
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public int Age { get; set; }
    }
}