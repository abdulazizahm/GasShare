using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA_DAL.Models
{
    public class Request_Photo
    {
        public int Id { get; set; }
        public string Photo { get; set; }
        public int Request_Id { get; set; }

        [ForeignKey("Request_Id")]
        public virtual Request Request { get; set; }
    }
}
