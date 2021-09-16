using OA_DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA_Service.ViewModels
{
    public class AdminDisplayUserViewModel
    {
        public string Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public bool IsActive { get; set; }

        public User_Status User_Status { get; set; }

        public string Photo { get; set; }

        [Display(Name ="National Id")]
        public string SSN { get; set; }

        public virtual Car Car { get; set; }

        public virtual UserPhoto UserPhoto { get; set; }
    }
}
