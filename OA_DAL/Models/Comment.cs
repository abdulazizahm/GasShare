using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA_DAL.Models
{
    public class Comment
    {
        public Comment()
        {
            Crated_at = DateTime.Now;
        }

        public int Id { get; set; }
        public string Body { get; set; }

        public int Journey_Id { get; set; }
        public string User_Id { get; set; }

        public DateTime Crated_at { get; set; }

        [ForeignKey("User_Id")]
        public virtual ApplicationUser User { get; set; }

        [ForeignKey("Journey_Id")]
        public virtual Journey Journey { get; set; }

    }
}
