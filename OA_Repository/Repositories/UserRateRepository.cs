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
  public  class UserRateRepository : BaseRepository<UserRate>
    {
        public UserRateRepository(DbContext db) : base(db)
        {
        }
        public List<UserRate> GetAllUserRate()
        {
            return GetAll().ToList();
        }

        public bool InsertUserRate(UserRate userRate)
        {
            return Insert(userRate);
        }
        public void UpdateUserRate(UserRate userRate)
        {
            Update(userRate);
        }
        public void DeleteUserRate(int id)
        {
            Delete(id);
        }

        public bool CheckUserRateExists(UserRate userRate)
        {
            return GetAny(b => b.Id == userRate.Id);
        }
        public UserRate GetUserRateById(int id)
        {
            return GetFirstOrDefault(b => b.Id == id);
        }
        public List<UserRate> GetRateForThisOnweCarByUserId(string car_onwer_id)
        {
            return GetWhere(u => u.Car_Owner_Id == car_onwer_id).ToList();
        }
    }
}
