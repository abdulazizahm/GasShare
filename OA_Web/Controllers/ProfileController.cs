using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OA_DAL.Models;
using OA_Service.AppServices;
using OA_Service.ViewModels;
using OA_Web.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OA_Web.Controllers
{
    [NoDirectAccess]
    public class ProfileController : Controller
    {
        private CarAppService carAppService;
        private AccountAppService account;
        private UserPhotoAppService userPhotoApp;
        private NotificationAppService notificationAppService;

        public ProfileController(
            CarAppService _car, AccountAppService _account,
            UserPhotoAppService _userPhotoApp,
            NotificationAppService _notificationAppService
            )
        {
            carAppService = _car;
            account = _account;
            userPhotoApp = _userPhotoApp;
            notificationAppService = _notificationAppService;
        }
        [Authorize]
        public IActionResult Index(string tabId)
        {
            var user = account.FindProfile(User.Identity.Name);
            if (account.IsInRole(user.Id, Role_Name.Admin))
            {
                user.Role = Role_Name.Admin.ToString();
            }
            else
            {
               
                user.Role = account.IsInRole(user.Id, Role_Name.Car_Owner) ? "Car_Owner" : "User";
            }

            if (user.Role == Role_Name.Car_Owner.ToString())
            {
                
                ViewData["Car"] = carAppService.GetAllCars().FirstOrDefault(p => p.Owner_User_Id == user.Id);
            }

            ViewBag.message = TempData["message"];

            return View(user);
        }

        [Authorize]
        public IActionResult Id(string id,string complainID)
        {
            var user = account.FindProfileById(id);
            if (account.IsInRole(user.Id, Role_Name.Admin))
            {
                user.Role = Role_Name.Admin.ToString();
            }
            else
            {
                
                user.Role = account.IsInRole(user.Id, Role_Name.Car_Owner) ? "Car_Owner" : "User";
            }

            if (user.Role == Role_Name.Car_Owner.ToString())
            {

                ViewData["Car"] = carAppService.GetAllCars().FirstOrDefault(p => p.Owner_User_Id == user.Id);
            }
            ViewBag.complainsTab = complainID;
            ViewBag.message = TempData["message"];

            return View("Index",user);
        }

        [Authorize(Roles ="Admin")]
        public IActionResult BlockUser(string id)
        {
            var user = account.FindById(id);
            user.User_Status = User_Status.Block;
            user.IsActive = false;
            account.Update(user);
            var noti = new Notification
            {
                User_Id = user.Id,
                Body = "Your Account Was Blocked by admin",
                Url = "/Identity/Account/Manage"
            };

            notificationAppService.InsertNotification(noti);

            TempData["message"] = "User is Blocked Successfully";
            return RedirectToAction("Id",new {id=id, complainID="complain" });
        }

        [Authorize(Roles ="Admin")]
        public IActionResult UnBlockUser(string id)
        {
            var user = account.FindById(id);
            user.User_Status = User_Status.Active;
            user.IsActive = true;
            account.Update(user);

            var noti = new Notification
            {
                User_Id = user.Id,
                Body = "Your account was unblocked by admin",
                Url = "/Profile"
            };

            notificationAppService.InsertNotification(noti);

            TempData["message"] = "User is UnBlocked Successfully";
            return RedirectToAction("Id", new { id = id, complainID = "complain" });
        }

        [Authorize]
        public IActionResult EditProfile()
        {
            var user = account.FindProfile(User.Identity.Name);
            return View(user);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult EditProfile(ProfileViewModel profileView)
        {
            var userid = account.FindProfile(User.Identity.Name).Id;
            var user = account.FindById(userid);
            var userPhoto = userPhotoApp.GetUserPhotosModelByUserID(userid);

            try
            {
                if (profileView.FormFileProfilPhoto != null)
                {
                    ImageUploaderService photoUploader = new ImageUploaderService(profileView.FormFileProfilPhoto, Directories.Users);


                    if (!user.Photo.Contains("default"))
                    {
                        ImageUploaderService.DeleteImage(user.Photo, Directories.Users);
                    }

                    user.Photo = photoUploader.GetImageName();

                    photoUploader.SaveImageAsync();
                }

                if (profileView.FormFileSSN_Photo != null)
                {
                    ImageUploaderService SSNUploader = new ImageUploaderService(profileView.FormFileSSN_Photo, Directories.UserPhotos);


                    if (!userPhoto.SSN_Photo.Contains("default"))
                    {
                        ImageUploaderService.DeleteImage(userPhoto.SSN_Photo, Directories.UserPhotos);
                    }

                    userPhoto.SSN_Photo = SSNUploader.GetImageName();

                    SSNUploader.SaveImageAsync();
                }

                user.FirstName = profileView.FirstName;
                user.LastName = profileView.LastName;
                user.Address = profileView.Address;
                user.SSN = profileView.SSN;
                account.Update(user);
                userPhotoApp.UpdateUserPhotos_ByModel(userPhoto);


                TempData["message"] = "Changes saved Successfully";
                return RedirectToAction("Index", "Profile");
            }





            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(profileView);
            }
        }

        public IActionResult SubmitProfile()
        {
            var user = account.FindByEmail(User.Identity.Name);
            user.User_Status = User_Status.InActive;
            account.Update(user);
            TempData["message"] = "Profile was submitted for review successfully";
            return RedirectToAction("Index");
        }
    }


}
