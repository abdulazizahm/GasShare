using OA_DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA_Service.ViewModels
{
    public class JourneyRateViewModel
    {
        public int Id { get; set; }
        [Required]
        public int Rate { get; set; }
        public string Comment { get; set; }

        public string User_Id { get; set; }

        public int Journey_Id { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual Journey Journey { get; set; }
    }
}
