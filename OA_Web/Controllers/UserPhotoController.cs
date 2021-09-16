using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    public class UserPhotoController : Controller
    {

        private UserPhotoAppService userPhotoAppService;

        public UserPhotoController(UserPhotoAppService _userPhotoAppService)
        {
            userPhotoAppService = _userPhotoAppService;
        }
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult SavePhoto()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SavePhoto(UserPhotoViewModel userPhotoViewModel)
        {
            ImageUploaderService imageUploaderService=null;
            userPhotoViewModel.User_Id = "a3275a8f-e151-4702-b922-d59df6d7a3e7";
            if (userPhotoViewModel.FormFileSSN != null)
            {
                //Set Key Name
                //string ImageName = Guid.NewGuid().ToString() + Path.GetExtension(userPhotoViewModel.FormFileSSN.FileName);

                ////Get url To Save
                //string SavePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/UserPhotos", ImageName);

                //using (var stream = new FileStream(SavePath, FileMode.Create))
                //{
                //    userPhotoViewModel.FormFileSSN.CopyTo(stream);
                //}
                 imageUploaderService = new ImageUploaderService(userPhotoViewModel.FormFileSSN, Directories.UserPhotos);
                userPhotoViewModel.SSN_Photo = imageUploaderService.GetImageName();
            }
            if (ModelState.IsValid)
            {
          
                try
                {
               bool x= userPhotoAppService.InsertUserPhoto(userPhotoViewModel);
                    imageUploaderService.SaveImageAsync();
                  
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    return View(userPhotoViewModel);
                }
            }
            else
            {
                return View(userPhotoViewModel);
            }
          //  return View();
        }
    }
}
