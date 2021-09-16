using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA_DAL.Models
{
    public class Car
    {
        public int Id { get; set; }

        public string Car_Photo { get; set; }

        public string Licence_Photo { get; set; }

        public string Car_Number { get; set; }

        public string Car_Model { get; set; }


        
        public string Owner_User_Id { get; set; }

        [ForeignKey("Owner_User_Id")]
        public virtual ApplicationUser Owner { get; set; }
    }
}
