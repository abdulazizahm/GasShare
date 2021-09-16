using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA_DAL.Models
{
    public class UserRate
    {
        public int Id { get; set; }
        public int Rate { get; set; }
        public string Comment { get; set; }

        public string User_Id { get; set; }

        public string Car_Owner_Id { get; set; }

        [ForeignKey("User_Id")]
        public virtual ApplicationUser User { get; set; }

        [ForeignKey("Car_Owner_Id")]
        public virtual ApplicationUser Car_Owner { get; set; }
    }
}
