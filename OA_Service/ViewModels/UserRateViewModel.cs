using OA_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA_Service.ViewModels
{
   public class UserRateViewModel
    {
        public int Id { get; set; }
        public int Rate { get; set; }
        public string Comment { get; set; }

        public string User_Id { get; set; }

        public string Car_Owner_Id { get; set; }

      
        public virtual ApplicationUser User { get; set; }

       
        public virtual ApplicationUser Car_Owner { get; set; }
    }
}
