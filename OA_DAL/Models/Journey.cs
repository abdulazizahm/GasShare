using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA_DAL.Models
{
    public class Journey
    {
        public Journey()
        {
            Created_at = DateTime.Now;
        }


        public int Id { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public DateTime Time { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public DateTime Created_at { get; set; }

        [Required]
        public int Passengers_Number { get; set; }
        [Required]
        public string From { get; set; }
        [Required]
        public string To { get; set; }

        public double Distance { get; set; }
        
        public double Price { get; set; }

        public string Form_Long { get; set; }
        public string Form_Lat { get; set; }
        public string To_Long { get; set; }
        public string To_Lat { get; set; }
        
        public string CurrentPosition { set; get; }
        public bool IsActive { get; set; }
        public string Desc { get; set; }

        public string Car_Owner_Id { get; set; }

        [ForeignKey("Car_Owner_Id")]
        public virtual ApplicationUser Car_Owner { get; set; }

        public virtual List<Request> Requests { get; set; }

        public virtual List<Comment> Comments { get; set; }

        public virtual List<JourneyRate> Rates { get; set; }

    }
}
