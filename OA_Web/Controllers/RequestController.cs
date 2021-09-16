using Microsoft.AspNetCore.Authorization;
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
using System.Threading;
using System.Threading.Tasks;

namespace OA_Web.Controllers
{
    [NoDirectAccess]
    public class RequestController : Controller
    {
        private readonly RequestAppService _requestAppService;
        private readonly AccountAppService _accountAppSetvace;
        private readonly JourneyAppService _journeyAppSetvace;
        private readonly NotificationAppService _notificationAppService;
        private readonly RequestPhotoAppService _requestPhotoAppService;
        private readonly UserPhotoAppService _userPhotoAppService;

        public RequestController(
            RequestAppService requestAppService,
            AccountAppService accountAppService,
            JourneyAppService journeyAppService,
            NotificationAppService notificarionAppService,
            RequestPhotoAppService requestPhotoAppService,
            UserPhotoAppService userPhotoAppService

        )
        {
            _requestAppService = requestAppService;
            _accountAppSetvace = accountAppService;
            _journeyAppSetvace = journeyAppService;
            _notificationAppService = notificarionAppService;
            _requestPhotoAppService = requestPhotoAppService;
            _userPhotoAppService = userPhotoAppService;
        }
        

        [Authorize]
        public IActionResult Index(string tab)
        {
            
            var user = _accountAppSetvace.FindByEmail(User.Identity.Name);
            List<RequestViewModel> requests;
            ViewBag.tab = tab;

            if (User.IsInRole(Role_Name.Car_Owner.ToString())) {
                requests = _requestAppService.GetAllRequests()
                    .Where(r => r.Journey.Car_Owner_Id == user.Id).ToList();
            }
            else
            {
                requests = _requestAppService.GetAllRequests()
                    .Where(r => r.User_Id == user.Id).ToList();
            }
            if(TempData["message"] != null)
            {
                ViewBag.message = TempData["message"];
            }

            return View(requests);
        }

        
        [HttpGet]
        [Authorize]
        [Authorize(Policy = "IsActive")]
        public IActionResult Create(int id)
        {
            var user = _accountAppSetvace.FindByEmail(User.Identity.Name);

            var journey = _journeyAppSetvace.GetJourneyModelById(id);

            var request = new RequestViewModel
            {
                Journey_Id = journey.Id,
                User_Id = user.Id,
                Seats = 1,
                IncludeUser = true,
                Journey = journey
            };
            

            return View(request);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create(RequestViewModel request)
        {
            request.Id = new int();
            List<ImageUploaderService> uploaders = new();
            request.Photos = new();
            var journey = _journeyAppSetvace.GetJourneyById(request.Journey_Id);

            if (!ModelState.IsValid || journey == null)
            {
                ModelState.AddModelError("", "Invalid Request");
                return View(request);
            }
            if (request.Seats > journey.Passengers_Number)
            {
                var seats = journey.Passengers_Number;
                ModelState.AddModelError("", $"this journey only has {seats} left");
                request.Seats = seats;
                return View(request);
            }
            if (request.PhotosFiles != null && !(request.Seats == 1 && request.IncludeUser == true) ) { 
                foreach (var photoFile in request.PhotosFiles)
                {
                    ImageUploaderService uploader = new ImageUploaderService(photoFile, Directories.Requests);
                    request.Photos.Add(new Request_Photo { Photo = uploader.GetImageName() });
                    uploaders.Add(uploader);
                }
            }

            var result = _requestAppService.InsertRequest(request);

            if (result)
            {

                foreach (var uploader in uploaders)
                {
                    uploader.SaveImageAsync();
                }
                var noti = new Notification
                {
                    User_Id = journey.Car_Owner_Id,
                    Body = "You have new requests",
                    Url = $"/Journey/Details/{journey.Id}",
                };

                _notificationAppService.InsertNotification(noti);
                TempData["message"] = "Request was submitted successfully";

                return RedirectToAction("Details", "Journey",new { id=$"{journey.Id}"});
            }
            else
            {
                return View(request);
            }
        }

        [Authorize]
        public IActionResult Journey(int id)
        {
            var requests = _requestAppService.GetAllRequests();
            return View(requests);
        }

        [Authorize(Roles ="Car_Owner")]
        [Authorize(Policy = "IsActive")]
        public IActionResult Approve(int id)
        {
            var request = _requestAppService.GetModelById(id);
            if (request.Seats > request.Journey.Passengers_Number)
            {
                TempData["message"] = "Invalid Request";
                return RedirectToAction("Details", "Journey", new { id = request.Journey_Id });
            }

            request.Journey.Passengers_Number -= request.Seats;

            if (request.Journey.Passengers_Number < 1)
            {
                request.Journey.IsActive = false;
            }
            

            request.Status = Request_Status.Approved;

            _requestAppService.UpdateRequest(request);
            
            TempData["message"] = "Request was approved successfully";

            var noti = new Notification
            {
                User_Id = request.User_Id,
                Body = $"your request on the journey from {request.Journey.From} to {request.Journey.To} has been approved",
                Url = $"/Journey/Details/{request.Journey.Id}",
            };
            _notificationAppService.InsertNotification(noti);

            return RedirectToAction("Details", "Journey", new { id = request.Journey_Id });

        }

        [Authorize]
        [Authorize(Policy = "IsActive")]
        public IActionResult Decline(int id,string reason)
        {
            var request = _requestAppService.GetModelById(id);
            if(request.Status != Request_Status.Pending && request.Status != Request_Status.Updated)
            {
                TempData["message"] = "Request Cannot be declined";
                return RedirectToAction("Details", "Journey", new { id = request.Journey_Id });
            }
            

            request.Status = Request_Status.Rejected;

            _requestAppService.UpdateRequest(request);

            foreach (var photo in request.Photos)
            {
                ImageUploaderService.DeleteImage(photo.Photo, Directories.Requests);
            }

            _requestPhotoAppService.DeleteList(request.Photos);

            var noti = new Notification
            {
                User_Id = request.User_Id,
                Body = $"your request on the journey from {request.Journey.From} to {request.Journey.To} is declined and the reason is {reason}",
                Url = $"/Journey/Details/{request.Journey.Id}"
            };

            _notificationAppService.InsertNotification(noti);

            TempData["message"] = "Request was declined successfully";

            return RedirectToAction("Details", "Journey", new { id = request.Journey_Id });
        }


        [Authorize]
        [Authorize(Policy = "IsActive")]
        public IActionResult Cancel(int id)
        {
            var request = _requestAppService.GetModelById(id);

            if(request.Status == Request_Status.Approved || request.Status == Request_Status.Updated)
            {
                request.Status = Request_Status.Cancelled;
                request.Journey.Passengers_Number += request.Seats;
                request.Journey.IsActive = true;

                var noti = new Notification
                {
                    User_Id = request.Journey.Car_Owner_Id,
                    Body = $"{request.User.FirstName} {request.User.LastName} Canceled his seats in your journey from {request.Journey.From} to {request.Journey.To}",
                    Url = $"/Journey/Details/{request.Journey.Id}",
                };

                _notificationAppService.InsertNotification(noti);

                if (request.Photos != null)
                    _requestPhotoAppService.DeleteList(request.Photos);
            }
            else if(request.Status == Request_Status.Rejected)
            {

                TempData["message"] = "cannot Delete a request after it has been rejected by Car Owner";
            }
            else if (request.Status == Request_Status.Cancelled)
            {
                TempData["message"] = "This request is already cancelled";
            }

            var journeyId = request.Journey_Id;
            if (request.Status == Request_Status.Pending)
            {
                _requestAppService.DeleteRequestById(request.Id);
                TempData["message"] = "Request was deleted Successfully";
            }
            else
            {
                _requestAppService.UpdateRequest(request);
            }
            
            foreach (var photo in request.Photos)
            {
                ImageUploaderService.DeleteImage(photo.Photo, Directories.Requests);
            }

            TempData["message"] = "Request was Cancelled Successfully";

            return RedirectToAction("Details", "Journey", new { id = journeyId});
        }



        [Authorize]
        [Authorize(Policy = "IsActive")]
        public IActionResult View(int id)
        {

            var request = _requestAppService.GetById(id);
            if (request.IncludeUser == true)
            {
                request.User.UserPhoto = _userPhotoAppService.GetUserPhotosModelByUserID(request.User_Id);
            }
            return View(request);
        }

        [Authorize]
        [Authorize(Policy = "IsActive")]
        public IActionResult Edit(int id)
        {
            var request = _requestAppService.GetById(id);
            request.Journey = _journeyAppSetvace.GetJourneyModelById(request.Journey_Id);
            var journeyDate = new DateTime(
                request.Journey.Date.Year,
                request.Journey.Date.Month,
                request.Journey.Date.Day,
                request.Journey.Time.Hour,
                request.Journey.Time.Minute,
                request.Journey.Time.Second
            );

            if ((journeyDate - DateTime.Now).TotalDays < 0)
            {
                ViewBag.warnning = $"";
                ViewBag.cannotEdit = false;
            }
            else if ((journeyDate - DateTime.Now).TotalDays < 1 && request.Status == Request_Status.Approved)
            {
                ViewBag.warnning = $"The request cannot be modified after the journey time is over";
                ViewBag.cannotEdit = false;
            }
            else if (request.Status == Request_Status.Approved)
            {
                ViewBag.warnning = $"this request has been approved by {request.Journey.Car_Owner.FirstName} {request.Journey.Car_Owner.LastName} editing will cause it to be re-reviewed and either approved or declined";
            }
            else if (request.Status == Request_Status.Rejected)
            {
                ViewBag.warnning = $"this request has been declined by {request.Journey.Car_Owner.FirstName} {request.Journey.Car_Owner.LastName} and can't be edited search for new journeys";
            }
            else if (request.Status == Request_Status.Cancelled)
            {
                ViewBag.warnning = $"this request has been cancelled by you and can't be edited search for new journeys";
            }
            return View(request);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Edit(RequestViewModel request)
        {
            var newReq = _requestAppService.GetModelById(request.Id);
            List<ImageUploaderService> uploaders = new();

            if (newReq.Status == Request_Status.Approved)
            {
                newReq.Status = Request_Status.Updated;
                newReq.Journey.Passengers_Number += newReq.Seats;
                newReq.Journey.IsActive = true;

                var noti = new Notification
                {
                    User_Id = newReq.Journey.Car_Owner_Id,
                    Body = $"{newReq.User.FirstName} {newReq.User.LastName} has updated his request on your journey from {newReq.Journey.From} to {newReq.Journey.To}",
                    Url = $"~/Journey/Details/{newReq.Journey_Id}"
                };

                _notificationAppService.InsertNotification(noti);
            }

            if (request.PhotosFiles != null)
            {
                foreach (var photo in newReq.Photos)
                {
                    ImageUploaderService.DeleteImage(photo.Photo, Directories.Requests);
                }

                if(newReq.Photos != null)
                    _requestPhotoAppService.DeleteList(newReq.Photos);

                newReq.Photos = new();

                foreach (var photoFile in request.PhotosFiles)
                {
                    ImageUploaderService uploader = new ImageUploaderService(photoFile, Directories.Requests);
                    newReq.Photos.Add(new Request_Photo { Photo = uploader.GetImageName() });
                    uploaders.Add(uploader);

                }
            }

            newReq.Seats = request.Seats;
            newReq.IncludeUser = request.IncludeUser;
            _requestAppService.UpdateRequest(newReq);

            foreach (var uploader in uploaders)
            {
                uploader.SaveImageAsync();
            }


            TempData["message"] = "Request was updated Successfully";

            return RedirectToAction("Details", "Journey", new { id = request.Journey_Id });
        }
    }
}
