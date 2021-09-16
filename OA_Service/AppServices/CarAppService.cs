using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OA_DAL.Models;
using OA_Repository.Identity;
using OA_Service.Bases;
using OA_Service.Interfaces;
using OA_Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA_Service.AppServices
{
    public class CarAppService: BaseAppService<Car>
    {
        public CarAppService(IUnitOfWork _unit) : base(_unit)
        {
        }

        public List<CarViewModel> GetAllCars()
        {
            //return TheUnitOfWork.Car.GetAllCars();
            return Mapper.Map<List<CarViewModel>>(TheUnitOfWork.Car.GetAllCars());
        }

        public CarViewModel GetById(int id)
        {
            return Mapper.Map<CarViewModel>(TheUnitOfWork.Car.GetCarById(id));
        }

        public Car GetByModelId(int id)
        {
            return TheUnitOfWork.Car.GetCarById(id);
        }


        public bool SaveNewCar(CarViewModel carViewModel)
        {
            bool result = false;
            var car = Mapper.Map<Car>(carViewModel);
            if (TheUnitOfWork.Car.InsertCar(car))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }

        public bool UpdateCar(CarViewModel carViewModel)
        {
            var car = Mapper.Map<Car>(carViewModel);
            TheUnitOfWork.Car.UpdateCar(car);
            TheUnitOfWork.Commit();

            return true;
        }

        public bool UpdateCarMyModel(Car car)
        { 
            TheUnitOfWork.Car.UpdateCar(car);
            TheUnitOfWork.Commit();

            return true;
        }
        public bool DeleteCar(int id)
        {
            TheUnitOfWork.Car.DeleteCar(id);
            bool result = TheUnitOfWork.Commit() > new int();

            return result;
        }

        public bool CheckCarExists(CarViewModel carViewModel)
        {
            Car car = Mapper.Map<Car>(carViewModel);
            return TheUnitOfWork.Car.CheckCarExists(car);
        }
    }
}
