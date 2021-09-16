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
    public class CarRepository : BaseRepository<Car>
    {
        public CarRepository(DbContext db) : base(db)
        {
        }

        #region CRUB

        public IQueryable<Car> GetAllCars()
        {
            return GetAll().Include(c => c.Owner);
        }

        public bool InsertCar(Car Car)
        {
            return Insert(Car);
        }
        public void UpdateCar(Car Car)
        {
            Update(Car);
        }
        public void DeleteCar(int id)
        {
            Delete(id);
        }

        public bool CheckCarExists(Car Car)
        {
            return GetAny(b => b.Id == Car.Id);
        }
        public Car GetCarById(int id)
        {
            return GetAllCars().FirstOrDefault(c => c.Id == id);
        }
        #endregion
    }
}
