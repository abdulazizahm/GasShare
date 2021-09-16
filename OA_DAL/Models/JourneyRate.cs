using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA_DAL.Models
{
    public class JourneyRate
    {
        public int Id { get; set; }
        public int Rate { get; set; }
        public string Comment { get; set; }

        public string User_Id { get; set; }

        public int Journey_Id { get; set; }

        [ForeignKey("User_Id")]
        public virtual ApplicationUser User { get; set; }

        [ForeignKey("Journey_Id")]
        public virtual Journey Journey { get; set; }
    }
}
