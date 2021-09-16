using Microsoft.EntityFrameworkCore;
using OA_DAL.Models;
using OA_Repository.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA_Repository.Repositories
{
    public class RequestRepository : BaseRepository<Request>
    {
        public RequestRepository(DbContext db) : base(db)
        {
        }

        #region CRUB

        public IQueryable<Request> GetAllRequests()
        {
            return GetAll().Include(r => r.Journey).Include(r => r.Photos).Include(r => r.User);
        }

        public bool InsertRequest(Request Request)
        {
            Request.Created_at = DateTime.Now;
            return Insert(Request);
        }
        public void UpdateRequest(Request Request)
        {
            Update(Request);
        }
        public void DeleteRequest(int id)
        {
            Delete(id);
        }

        public bool CheckRequestExists(Request Request)
        {
            return GetAny(b => b.Id == Request.Id);
        }
        public Request GetRequestById(int id)
        {
            return GetAllRequests().FirstOrDefault(b => b.Id == id);
        }
        #endregion
    }
}
