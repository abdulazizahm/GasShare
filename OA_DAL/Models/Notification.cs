using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA_DAL.Models
{
    public class Notification
    {
        public Notification()
        {
            Created_at = DateTime.Now;
            Seen = false;
        }

        public int Id { get; set; }
        public string User_Id { get; set; }
        public string Body { get; set; }
        public string Url { get; set; }

        public DateTime Created_at { get; set; }

        public bool Seen { get; set; }

        [ForeignKey("User_Id")]
        public virtual ApplicationUser User { get; set; }
    }
}
