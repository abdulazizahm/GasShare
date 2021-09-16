using OA_DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA_Service.ViewModels
{
   public class ComplainViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Body { get; set; }

        [Required]
        public string Comlainer_Id { get; set; }
        public bool Status { get; set; }
        [Required]
        public string Complained_About_Id { get; set; }

      


        public virtual ApplicationUser Comlainer { get; set; }

   
        public virtual ApplicationUser Complained_About { get; set; }

    }
}
