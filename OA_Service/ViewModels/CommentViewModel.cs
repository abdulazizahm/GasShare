using OA_DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA_Service.ViewModels
{
    public class CommentViewModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [Display(Name ="Comment")]
        public string Body { get; set; }

        
        public int Journey_Id { get; set; }

        public string User_Id { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual Journey Journey { get; set; }
    }
}
