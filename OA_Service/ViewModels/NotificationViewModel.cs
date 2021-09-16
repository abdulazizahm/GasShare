using OA_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA_Service.ViewModels
{
    public class NotificationViewModel
    {
        public NotificationViewModel()
        {
            Created_at = DateTime.Now;
            Seen = false;
        }

        public int Id { get; set; }
        public string User_Id { get; set; }
        public string Body { get; set; }

        public DateTime Created_at { get; set; }

        public bool Seen { get; set; }

        public string Url { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
