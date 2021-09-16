using Microsoft.AspNetCore.Mvc;
using OA_DAL.Models;
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
    public class UserController : Controller
    {
        private AccountAppService _accountAppService;
        private NotificationAppService _notificationAppService;
        private JourneyAppService journeyAppService;
        private RequestAppService requestAppService;

        public UserController(
            AccountAppService accountAppService,
            NotificationAppService notificationAppService,JourneyAppService _journeyAppService,RequestAppService _requestAppService
        )
        {
            _accountAppService = accountAppService;
            _notificationAppService = notificationAppService;
            journeyAppService = _journeyAppService;
            requestAppService = _requestAppService;
        }

        public IActionResult Index()
        {
            var users = _accountAppService.GetAllActive();
            ViewBag.Active = true;
            return View(users);
        }

        public IActionResult Blocked()
        {
            var users = _accountAppService.GetAllBlocked();
            ViewBag.Active = false;
            return View("Index", users);
        }

        public IActionResult Search(string query, bool active)
        {
            List<AdminDisplayUserViewModel> users;
            if (active)
            {
                ViewBag.Active = true;
                if (query == null || query == "")
                {
                    users = _accountAppService.GetAllActive();
                }
                else
                {
                    users = _accountAppService.GetAll().Where(
                        u => u.IsActive == true && ($"{u.FirstName} {u.LastName}".ToLower().Contains(query.ToLower()) || (u.SSN == null ? "" : u.SSN).Contains(query))).ToList();
                }
            }
            else {
                ViewBag.Active = false;
                if (query == null || query == "")
                {
                    users = _accountAppService.GetAllBlocked();
                }
                else
                {
                    users = _accountAppService.GetAll().Where(
                        u => u.User_Status == User_Status.Block && ($"{u.FirstName} {u.LastName}".ToLower().Contains(query.ToLower()) || u.SSN.Contains(query))).ToList();
                }

                    
            }
            
            return PartialView("_SearchUsers", users);
        }



        public IActionResult InActive()
        {
            var users = _accountAppService.GetAllInActive();
            ViewBag.message = TempData["message"];
            return View(users);
        }


        public IActionResult UserInfo(string id)
        {
            var user = _accountAppService.FindByIdForAdminView(id);
            ViewBag.carOwner = false;
            if (_accountAppService.IsInRole(id, Role_Name.Car_Owner))
            {
                ViewBag.carOwner = true;
            }
            return View(user);
        }

        public IActionResult Activate (string id)
        {
            var user = _accountAppService.FindById(id);
            user.User_Status = User_Status.Active;
            user.IsActive = true;
            _accountAppService.Update(user);

            //send notification to user
            var notification = new Notification
            {
                Body    = "Your Account has been activated",
                User_Id = user.Id,
                Url     = "/Profile"
            };

            _notificationAppService.InsertNotification(notification);

            TempData["message"] = "User is Activated Successfully";
            return RedirectToAction("InActive");
        }

        public IActionResult Decline(string id, string reason)
        {
            var user = _accountAppService.FindById(id);
            user.User_Status = User_Status.Declined;
            user.IsActive = false;
            _accountAppService.Update(user);

            //send notification to user
            var notification = new Notification
            {
                Body = $"Your Account has been Rejected due to {reason}, Please update your info and resubmit your profile",
                User_Id = id,
                Url = "/Identity/Account/Manage"
            };

            _notificationAppService.InsertNotification(notification);

            TempData["message"] = "User is Declined Successfully";
            return RedirectToAction("InActive");
        }

        public IActionResult DashBoard()
        {
            ViewBag.users = _accountAppService.GetAllUsers().Where(u=>u.IsActive==true).Count();
            ViewBag.CarOwner = _accountAppService.GetAllCarOwners().Where(u => u.IsActive == true).Count();
            ViewBag.Jouernys = journeyAppService.GetActivJourneys().Count();
            ViewBag.request = requestAppService.GetAllRequests().Count();
            return View();
        }
        public IActionResult CreateAdmin()
        {
            return View();    
        }


        [HttpPost]
        public IActionResult CreateAdmin(CreateAdminViewModel createAdminViewModel)
        {
            if (!ModelState.IsValid)
            {
                TempData["failed_Create"] = "Admin Adding Failed";
                return View(createAdminViewModel);
            }
            else
            {
                try
                {
                    createAdminViewModel.IsActive = true;
                    createAdminViewModel.User_Status = User_Status.Active;
                    createAdminViewModel.UserName = createAdminViewModel.Email;
                     ApplicationUser user = _accountAppService.Register(createAdminViewModel);
                    _accountAppService.AssignToRole(_accountAppService.FindByEmail(user.Email).Id, Role_Name.Admin);
                    TempData["Success_create"] = "Admin Added Succefully";
                    return View();
                }
                catch (Exception ex) {
                    ModelState.AddModelError("",ex.Message);
                    TempData["failed_Create"] = "Admin Added Failed";
                    return View(createAdminViewModel);
                }
            }
        }
    }
}
