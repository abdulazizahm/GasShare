using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OA_DAL.Models;
using OA_Service.AppServices;
using OA_Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using OA_Web.Security;
using System.Threading.Tasks;

namespace OA_Web.Controllers
{
    [NoDirectAccess]
    public class JourneyController : Controller
    {
        private JourneyAppService journeyAppService;
        private AccountAppService accountAppService;
        private JourneyRateAppService journeyRateAppService;

        public JourneyController(JourneyAppService _journeyAppService, AccountAppService _account, JourneyRateAppService _journeyRateAppService)
        {
            journeyAppService = _journeyAppService;
            accountAppService = _account;
            journeyRateAppService = _journeyRateAppService;
        }
        [Route("Admin/Journey")]
        [Authorize (Roles ="Admin")]
        public IActionResult IndexJourney()
        {
            return View(journeyAppService.GetAllJourneys().Where(j=>j.IsActive==true).ToList());
        }
        public IActionResult Active(int id)
        {
            var journey = journeyAppService.GetJourneyById(id);
            journey.IsActive = true;
            journeyAppService.UpdateJourney(journey);
            return RedirectToAction("IndexJourney");
        }
        public IActionResult Index()
        {
            return View(journeyAppService.GetAllJourneys());
        }


        [HttpGet]
        [Authorize(Policy = "IsActive")]
        [Authorize(Roles ="Car_Owner")]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy ="IsActive")]
        public IActionResult Create(JourneyViewModel journeyViewModel)
        {

            if (!ModelState.IsValid)
            {
                return View(journeyViewModel);
            }
            try
            {
                if (User.IsInRole(Role_Name.Car_Owner.ToString()))
                {
                    journeyViewModel.Car_Owner_Id = accountAppService.FindByEmail(email: User.Identity.Name).Id;
                }
                else
                {
                    ModelState.AddModelError("", "you should register first by account type (Car Owner) to complete this operation");
                    return View(journeyViewModel);
                }
                journeyViewModel.IsActive = true;
                journeyAppService.SaveNewJourney(journeyViewModel);
                return RedirectToAction("Index", "Profile", new { tabId = "tab" });
            }
            catch (Exception ee)
            {
                ModelState.AddModelError("", ee.Message);
                return View(journeyViewModel);
            }
        }


        [HttpGet]
        [Authorize(Roles = "Car_Owner")]
        [Authorize(Policy = "IsActive")]
        public IActionResult Edit(int id)
        {
            return View(journeyAppService.GetJourneyById(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Car_Owner")]
        public IActionResult Edit(JourneyViewModel journeyViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(journeyViewModel);
            }
            try
            {
                journeyViewModel.IsActive = true;
                journeyAppService.UpdateJourney(journeyViewModel);
                return RedirectToAction("Index","Profile",new {tabId="tab" });
            }
            catch (Exception ee)
            {
                ModelState.AddModelError("", ee.Message);
                return View(journeyViewModel);
            }
        }

        [Authorize(Policy = "IsActive")]
        [Authorize(Roles = "Car_Owner")]
        public IActionResult Delete(int id)
        {
            journeyAppService.DeleteJourney(id);
          
            return RedirectToAction("Index", "Profile", new { tabId = "tab" });
        }


        public IActionResult Search(SearchViewModel search)
        {
            List<JourneyViewModel> jourenys = null;
            if (!ModelState.IsValid)
            {
                ViewBag.search = search;
                return View(jourenys);
            }
            if (search.Passengers_Number == null && search.Time == null
                && search.Date == null)
            {
                jourenys = journeyAppService.GetAllJourneys().Where(j => j.To.ToLower().Contains(search.To.ToLower()) && j.From.ToLower().Contains(search.From.ToLower())).ToList();
            }
            else if (search.Passengers_Number == null && search.Time == null)
            {
                jourenys = journeyAppService.GetAllJourneys().Where(j => j.To.ToLower().Contains(search.To.ToLower()) && j.From.ToLower().Contains(search.From.ToLower()) && j.Date == search.Date).ToList();
            }
            else if (search.Passengers_Number == null && search.Date == null)
            {
                jourenys = journeyAppService.GetAllJourneys().Where(j => j.To.ToLower().Contains(search.To.ToLower()) && j.From.ToLower().Contains(search.From.ToLower()) && j.Time == search.Time).ToList();
            }
            else if (search.Passengers_Number == null)
            {
                jourenys = journeyAppService.GetAllJourneys().Where(j => j.To.Contains(search.To) && j.From.Contains(search.From) &&
                j.Date == search.Date && j.Time >= search.Time).ToList();
            }
            else
            {
                jourenys = journeyAppService.GetAllJourneys().Where(j => j.To.ToLower().Contains(search.To.ToLower()) && j.From.ToLower().Contains(search.From.ToLower()) &&
                j.Date == search.Date && j.Passengers_Number >= search.Passengers_Number && j.Time == j.Time).ToList();
            }
            /*jourenys = jounrenyappservice.GetAllJourneys().Where(j => j.To.Contains(search.To) && j.From.Contains(search.From) &&
                j.Date == search.Date).ToList();*/
            ViewBag.search = search;
            return View(jourenys);
        }
        [Authorize(Roles ="Car_Owner")]
        [Authorize(Policy = "IsActive")]
        public string updateLocation(string address, int id)
        {
            try
            {
                var journey = journeyAppService.GetJourneyModelById(id);
                journey.CurrentPosition = address;

                journeyAppService.UpdateJourneyByModel(journey);
                return "success";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        public ActionResult JourneyPatialView(JourneyViewModel jourenyView)
        {
            return PartialView("_JourneyPartial", jourenyView);
        }

        [HttpPost]
        [Authorize(Roles ="User")]
        [Authorize(Policy = "IsActive")]
        public IActionResult AddRateToJourney(JourneyRateViewModel journeyRateViewModel)
        {
            if (ModelState.IsValid)
            {
                if (journeyRateAppService.CheckIfThisUserRateThisJourney(journeyRateViewModel))
                {
                    var journeyRate = journeyRateAppService.GetByUserIdAndJourneyId(journeyRateViewModel.Journey_Id, journeyRateViewModel.User_Id);
                    journeyRate.Comment = journeyRateViewModel.Comment;
                    journeyRate.Rate = journeyRateViewModel.Rate;
                    journeyRateAppService.UpdateJourneyRateByModel(journeyRate);
                }
                else
                    journeyRateAppService.InsertJourneyRate(new JourneyRateViewModel { Journey_Id = journeyRateViewModel.Journey_Id, Comment = journeyRateViewModel.Comment, Rate = journeyRateViewModel.Rate, User_Id = journeyRateViewModel.User_Id });

            }
            TempData["message"] = "Rate was added successfully";

            return RedirectToAction("Details", "Journey",new { id = journeyRateViewModel.Journey_Id});
        }

        [Authorize(Roles ="Admin")]
        public IActionResult DeActivateFinishedJourney()
        {
            var journeys = journeyAppService.GetActivJourneys();

            var count = 0;

            foreach (var item in journeys)
            {
                var journeyDate = new DateTime(
                item.Date.Year,
                item.Date.Month,
                item.Date.Day,
                item.Time.Hour,
                item.Time.Minute,
                item.Time.Second
                );

                if ((journeyDate - DateTime.Now).TotalDays < 0)
                {
                    var journy = journeyAppService.GetJourneyModelById(item.Id);
                    journy.IsActive = false;
                    journeyAppService.UpdateJourneyByModel(journy);
                    count++;
                }
            }

            TempData["message"] = $"{count} Journeys finished and were deactivated Successfully";
            return RedirectToAction("Inactive", "User");
        }

        [Authorize]
        public IActionResult Details(int id)
        {
            var rates = journeyRateAppService.GetJourneyRateByJourneyId(id);
            ViewBag.Journey = journeyAppService.GetJourneyById(id);

            if (TempData["message"] != null)
            {
                ViewBag.message = TempData["message"];
            }

            return View(rates);
        }
    }
}
