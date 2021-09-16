using Microsoft.AspNetCore.Http;
using OA_DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA_Service.ViewModels
{
    public class RequestViewModel
    {
        public int Id { get; set; }

        public int Journey_Id { get; set; }
        public string User_Id { get; set; }

        public int Seats { get; set; }

        [Display(Name = "Created at")]
        public DateTime Created_at { get; set; }

        public Request_Status Status { get; set; }

        public List<IFormFile> PhotosFiles { get; set; }

        public bool IncludeUser { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual Journey Journey { get; set; }

        public virtual List<Request_Photo> Photos { get; set; }
    }
}
