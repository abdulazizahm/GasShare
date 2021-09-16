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
    public class ComplainRepository : BaseRepository<Complain>
    {

        public ComplainRepository(DbContext db) : base(db)
        {

        }

        #region CRUB

        public List<Complain> GetAllComplains()
        {
            return GetAll().Include(c => c.Comlainer).Include(c => c.Complained_About).ToList();
        }

        public bool InsertComplain(Complain Complain)
        {
            return Insert(Complain);
        }
        public void UpdateComplain(Complain Complain)
        {
            Update(Complain);
        }
        public void DeleteComplain(int id)
        {
            Delete(id);
        }

        public bool CheckComplainExists(Complain Complain)
        {
            return GetAny(b => b.Id == Complain.Id);
        }
        public Complain GetComplainById(int id)
        {
            return GetFirstOrDefault(b => b.Id == id);
        }
        #endregion
    }
}
