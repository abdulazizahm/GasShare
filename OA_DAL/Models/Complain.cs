using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA_DAL.Models
{
    public class Complain
    {
        public int Id { get; set; }
        public string Body { get; set; }

        public string Comlainer_Id { get; set; }

        public bool Status { get; set; }

        public string Complained_About_Id { get; set; }

        [ForeignKey("Comlainer_Id")]
        public virtual ApplicationUser Comlainer { get; set; }

        [ForeignKey("Complained_About_Id")]
        public virtual ApplicationUser Complained_About { get; set; }

    }
}
