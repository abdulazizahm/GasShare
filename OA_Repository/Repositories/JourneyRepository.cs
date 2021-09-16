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
    public class JourneyRepository:BaseRepository<Journey>
    {
        public JourneyRepository(DbContext db) : base(db)
        {

        }

        #region CRUB

        public IQueryable<Journey> GetAllJourneys()
        {
            var journeys = GetAll()
                .Include(j => j.Car_Owner)
                .Include(j => j.Car_Owner).ThenInclude( u=> u.Car)
                .Include(j => j.Comments).Include(j => j.Requests)
                .Include(j => j.Rates);
            return journeys;
        }

        public bool InsertJourney(Journey Journey)
        {
            return Insert(Journey);
        }
        public void UpdateJourney(Journey Journey)
        {
            Update(Journey);
        }
        public void DeleteJourney(int id)
        {
            Delete(id);
        }

        public bool CheckJourneyExists(Journey Journey)
        {
            return GetAny(b => b.Id == Journey.Id);
        }
        public Journey GetJourneyById(int id)
        {
            return GetAllJourneys().FirstOrDefault(b => b.Id == id);
        }
        public List<Journey> GetJourneysByUserId(string userId)
        {
            return GetAllJourneys().Where(b => b.Car_Owner_Id == userId).ToList();
        }
        #endregion
    }
}
