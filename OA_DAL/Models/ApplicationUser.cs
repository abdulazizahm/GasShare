using Microsoft.AspNetCore.Identity;
using OA_DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA_DAL.Models
{
    public enum Role_Name { Admin, Car_Owner, User }
    public enum User_Status { InActive, Active, Declined,Block }


    public class ApplicationUser : IdentityUser
    {

        [MaxLength(20)]
        public string FirstName { get; set; }
        [MaxLength(20)]
        public string LastName { get; set; }

        public string Address { get; set; }
        public bool IsActive { get; set; }

        public User_Status User_Status { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Created_at = DateTime.Now;
        public string Photo { get; set; }

        //[Required]
        [StringLength(14)]
        public string SSN { get; set; }



        public virtual Car Car { get; set; }

        public virtual UserPhoto UserPhoto { get; set; }

        [InverseProperty("User")]
        public virtual List<UserRate> User_Rates { get; set; }

        [InverseProperty("Car_Owner")]
        public virtual List<UserRate> Car_Owner_Rates { get; set; }

        public virtual List<JourneyRate> JourneyRates { get; set; }

        public virtual List<Journey> Journeys { get; set; }

        public virtual List<Request> Requests { get; set; }

        public virtual List<Comment> Comments { get; set; }

        public virtual List<Notification> Notifications { get; set; }

        [InverseProperty("Comlainer")]
        public virtual List<Complain> Complains { get; set; }

        [InverseProperty("Complained_About")]
        public virtual List<Complain> Complains_About { get; set; }


    }
}
