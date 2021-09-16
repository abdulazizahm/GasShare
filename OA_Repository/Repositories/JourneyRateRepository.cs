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
    public class JourneyRateRepository: BaseRepository<JourneyRate>
    {
        public JourneyRateRepository(DbContext db) : base(db)
        {
        }

        #region CRUB

        public IQueryable<JourneyRate> GetAllJourneyRates()
        {
            return GetAll().Include(r=>r.User);
        }

        public bool InsertJourneyRate(JourneyRate JourneyRate)
        {
            return Insert(JourneyRate);
        }
        public void UpdateJourneyRate(JourneyRate JourneyRate)
        {
            Update(JourneyRate);
        }
        public void DeleteJourneyRate(int id)
        {
            Delete(id);
        }

        public bool CheckJourneyRateExists(JourneyRate JourneyRate)
        {
            return GetAny(b => b.User_Id == JourneyRate.User_Id && b.Journey_Id==JourneyRate.Journey_Id);
        }
        public JourneyRate GetJourneyRateByUserIdAndJourneyId(int JourneyId,string userId)
        {
            return GetFirstOrDefault(b => b.Journey_Id == JourneyId && b.User_Id==userId);
        }
        public List<JourneyRate> GetJourneyRateByJourneyId(int JourneyId)
        {
            return this.GetAllJourneyRates().Where(b => b.Journey_Id == JourneyId).ToList();
        }
        #endregion
    }
}
