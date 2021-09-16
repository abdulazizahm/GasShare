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
    public class CarViewModel
    {
        public int Id { get; set; }

        
  
        [Required]
        public string Car_Number { get; set; }

        [Required]
        public string Car_Model { get; set; }

        [Required(ErrorMessage = "Please Enter car photo")]
        [DataType(DataType.Upload)]
        public IFormFile PhotoFormFile { get; set; }


        [Required(ErrorMessage = "Please Enter licence image")]
        [DataType(DataType.Upload)]
        public IFormFile LicenceFormFile { get; set; }

        [Display(Name = "Car_Photo Picture")]
        public string Car_Photo { get; set; }

        public string Licence_Photo { get; set; }

        public string Owner_User_Id { get; set; }

       
        public virtual ApplicationUser Owner { get; set; }
    }
}
