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
   public class UserPhotoViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Id Photo")]
        public string SSN_Photo { get; set; }

        [Display(Name = "Licence Photo")]
        public string LicencePhoto { get; set; }

        public string User_Id { get; set; }
        public IFormFile FormFileSSN { get; set; }
        public IFormFile FormFileLicencePhoto { get; set; }

         public virtual ApplicationUser User { get; set; }
    }
}
