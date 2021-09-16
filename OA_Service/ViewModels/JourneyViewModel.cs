using OA_DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OA_Service.ViewModels
{
   public class JourneyViewModel
    {
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public DateTime Time { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public DateTime Created_at { get; set; }

        [Required]
        [Display(Name = "Passengers Number")]
        public int Passengers_Number { get; set; }
        [Required(ErrorMessage = "Please select the (from location) from the map to enable us to find your coordinates")]

        public string From { get; set; }
        [Required(ErrorMessage = "Please select the (from location) from the map to enable us to find your coordinates")]
        public string To { get; set; }

        [Display(Name ="Distance In KM")]
        public double Distance { get; set; }

        [Display(Name ="Price Per Person")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Please select the (from location) from the map to enable us to find your coordinates")]
        public string Form_Long { get; set; }
        [Required(ErrorMessage = "Please select the (from location) from the map to enable us to find your coordinates")]
        public string Form_Lat { get; set; }
        [Required(ErrorMessage = "Please select the (from location) from the map to enable us to find your coordinates")]
        public string To_Long { get; set; }
        [Required(ErrorMessage = "Please select the (from location) from the map to enable us to find your coordinates")]
        public string To_Lat { get; set; }

        public bool IsActive { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Description")]
        public string Desc { get; set; }

        [Display(Name = "Car Owner")]
        public string Car_Owner_Id { get; set; }

        [Display(Name = "Current Position")]
        public string CurrentPosition { set; get; }

        public virtual ApplicationUser Car_Owner { get; set; }
       
        public virtual List<Request> Requests { get; set; }
       
        public virtual List<Comment> Comments { get; set; }
     
        public virtual List<JourneyRate> Rates { get; set; }
    }
}
