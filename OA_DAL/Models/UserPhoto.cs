using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA_DAL.Models
{
    public class UserPhoto
    {
        public int Id { get; set; }

        public string SSN_Photo { get; set; }
        public string LicencePhoto { get; set; }
        public string User_Id { get; set; }

        [ForeignKey("User_Id")]
        public virtual ApplicationUser User { get; set; }

    }
}
