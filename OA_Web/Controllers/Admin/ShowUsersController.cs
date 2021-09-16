using Microsoft.AspNetCore.Mvc;
using OA_Service.AppServices;
using OA_Service.ViewModels;
using OA_Web.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OA_Web.Controllers.Admin
{
    [NoDirectAccess]
    public class ShowUsersController : Controller
    {
        private UserPhotoAppService userPhotoAppService;

        public ShowUsersController(UserPhotoAppService _userPhotoAppService)
        {
            userPhotoAppService = _userPhotoAppService;
        }
        public IActionResult Index()
        {
            return View();
        }
        //this action to show images for this user
        public IActionResult GetImagesForThisUser(string id)
        {
            var userPhotos = userPhotoAppService.GetUserPhotosByUserID(id);
            return View(userPhotos);
        }
        public IActionResult Details(int id)
        {
          UserPhotoViewModel userPhoto=  userPhotoAppService.GetUserPhotoByID(id);
            return View(userPhoto);
        }
    }
}
