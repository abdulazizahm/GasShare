using Microsoft.AspNetCore.Http;
using OA_DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA_Service.ViewModels
{
    public class RegisterViewModel
    {

        [Required]
        [MaxLength(20)]
        public string FirstName { get; set; }

        [MaxLength(20)]
        [Required]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(14)]
        [MaxLength(14)]
        [MinLength(14)]
       /// [RegularExpression("(2|3)[0-9][1-9][0-1][1-9][0-3][1-9](01|02|03|04|11|12|13|14|15|16|17|18|19|21|22|23|24|25|26|27|28|29|31|32|33|34|35|88)\\d\\d\\d\\d\\d", ErrorMessage ="National ID Number Is Incorrect")]
        public string SSN { get; set; }


        [Required]
        [RegularExpression("^01[0125][0-9]{8}$",ErrorMessage ="Please Enter a Valid Phone Number")]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public Role_Name Account_Type { get; set; }

        [Display(Name ="Profile Photo")]
        public string Photo { get; set; }

        public string Address { get; set; }

        public virtual UserPhoto UserPhoto { get; set; }

        public IFormFile FormFileSSN { get; set; }
        public IFormFile FormFileProfile { get; set; }
        public IFormFile FormFileLicencePhoto { get; set; }

    }
}
