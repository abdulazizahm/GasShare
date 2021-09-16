using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA_Service.ViewModels
{
    public class SearchViewModel
    {
        [DataType(DataType.Time)]
        public DateTime? Time { get; set; }


        [DataType(DataType.Date)]
        public DateTime? Date { get; set; }


        [Display(Name = "Passengers Number")]
        public int? Passengers_Number { get; set; }

        [Required]
        public string From { get; set; }
        [Required]
        public string To { get; set; }
    }
}
