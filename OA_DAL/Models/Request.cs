using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA_DAL.Models
{
    public enum Request_Status
    {
        Pending,
        Cancelled,
        Approved,
        Rejected,
        Updated
    }

    public class Request
    {

        public Request()
        {
            Created_at = DateTime.Now;
            Status = Request_Status.Pending;
        }

        public int Id { get; set; }

        public int Journey_Id { get; set; }
        public string User_Id { get; set; }

        public int Seats { get; set; }

        public bool IncludeUser { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Created_at { get; set; }

        public Request_Status Status { get; set; }

        [ForeignKey("User_Id")]
        public virtual ApplicationUser User { get; set; }

        [ForeignKey("Journey_Id")]
        public virtual Journey Journey { get; set; }

        public virtual List<Request_Photo> Photos { get; set; }
    }
}
