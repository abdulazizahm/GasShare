using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OA_DAL.Models;
using OA_Service.AppServices;
using OA_Service.ViewModels;
using OA_Web.Security;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OA_Web.Controllers
{
    [NoDirectAccess]
    public class CarController : Controller
    {
        private CarAppService carAppService;
        private AccountAppService account;
     
        public CarController(CarAppService _car, AccountAppService _account)
        {
            carAppService = _car;
            account = _account;
          
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {

            return View(carAppService.GetAllCars());
        }

        [Authorize(Roles = "Car_Owner")]
      
        public IActionResult AddCar()
        {
          
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Car_Owner")]
        public IActionResult AddCar(CarViewModel carView)
        {
            
            if (!ModelState.IsValid)
            {
                return View(carView);
            }

            try
            {
                ImageUploaderService photoUploader = new ImageUploaderService(carView.PhotoFormFile, Directories.Cars);
                ImageUploaderService licenceUploader = new ImageUploaderService(carView.LicenceFormFile, Directories.Cars);

                carView.Car_Photo = photoUploader.GetImageName();
                carView.Licence_Photo = licenceUploader.GetImageName();
                //carAppService.SaveNewCar(carView);
                carView.Owner_User_Id = account.FindByEmail(email: User.Identity.Name).Id;
                carAppService.SaveNewCar(carView);
                photoUploader.SaveImageAsync();
                licenceUploader.SaveImageAsync();

                return RedirectToAction("Index", "Home");
            }
            catch(Exception ex) 
            {
                ModelState.AddModelError("", ex.Message);
                return View(carView);
            }
           
        }

        [Authorize(Roles = "Car_Owner")]
        public IActionResult updateCar(int id)
        {
            var car = carAppService.GetById(id);
            return View(car);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Car_Owner")]
        public IActionResult updateCar(CarViewModel carView)
        {
            var car = carAppService.GetByModelId(carView.Id);
            //if (!ModelState.IsValid)
            //{
            //    return View(carView);
            //}

            try
            {
                if (carView.PhotoFormFile != null)
                {
                    ImageUploaderService photoUploader = new ImageUploaderService(carView.PhotoFormFile, Directories.Cars);
                   
                   
                    if (!car.Car_Photo.Contains("default"))
                    {
                        ImageUploaderService.DeleteImage(car.Car_Photo, Directories.Cars);
                    }
                    
                    car.Car_Photo = photoUploader.GetImageName();
                    
                    photoUploader.SaveImageAsync();
                }

                if (carView.LicenceFormFile != null)
                {
                    ImageUploaderService licenceUploader = new ImageUploaderService(carView.LicenceFormFile, Directories.Cars);

                    //delete old image if its not the default
                    if (!car.Licence_Photo.Contains("default") )
                    {
                        ImageUploaderService.DeleteImage(car.Licence_Photo, Directories.Cars);
                    }
                    //save new image name to user
                    car.Licence_Photo = licenceUploader.GetImageName();
                    //save new image to serve
                    licenceUploader.SaveImageAsync();
                }

                car.Car_Model = carView.Car_Model;
                car.Car_Number = carView.Car_Number;
                carAppService.UpdateCarMyModel(car);
             
                return RedirectToAction("Index", "Profile");
            }
          

        

          
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(carView);
            }

        }
    }
}
