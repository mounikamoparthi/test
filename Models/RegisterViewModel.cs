
using System.ComponentModel.DataAnnotations;
namespace test.Models
{
    public class RegisterViewModel : BaseEntity
    {
        [Required]
        [MinLength(2)]
        [RegularExpression(@"^[a-zA-Z]+$")]
        public string FirstName { get; set; }

        [Required]
        [MinLength(2)]
        [RegularExpression(@"^[a-zA-Z]+$")]
        public string LastName { get; set; }

        [Required]
        [MinLength(3, ErrorMessage ="Username has to be 3 characters in length at least")]
        [RegularExpression(@"^[a-zA-Z]+$")]
        public string UserName { get; set; }
 
 
        [Required] //change this to 8 at the end
        [MinLength(3, ErrorMessage="Password has to be 8 characters in length at least")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
 
        [Compare("Password", ErrorMessage = "Password and confirmation must match.")]
        public string PasswordConfirmation { get; set; }
    }
}