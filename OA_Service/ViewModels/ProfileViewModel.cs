using Microsoft.AspNetCore.Http;
using OA_DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA_Service.ViewModels
{
    public class ProfileViewModel
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Username { get; set; }

        [DisplayName("Profile Photo")]
        public string Photo { get; set; }

     
        [DataType(DataType.Upload)]
        public IFormFile FormFileProfilPhoto { get; set; }

        public string Email { get; set; }
        public virtual List<Complain> Complains_About { get; set; }
        public string Address { get; set; }
        public User_Status User_Status { get; set; }

        [Display(Name = "National Id")]
        public string SSN { get; set; }


        public UserPhoto userPhoto { get; set; }

        [DataType(DataType.Upload)]
        public IFormFile FormFileSSN_Photo { get; set; }
        public string PhoneNumber { get; set; }
        public string Role { get; set; }
    }
}
