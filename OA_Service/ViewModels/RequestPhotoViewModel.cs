using OA_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA_Service.ViewModels
{
    public class RequestPhotoViewModel
    {
        public int Id { get; set; }
        public string Photo { get; set; }
        public int Request_Id { get; set; }
        public virtual Request Request { get; set; }
    }
}
