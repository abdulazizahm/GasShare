using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OA_DAL.Models;
//using NetTopologySuite.Geometries;
using OA_Service.AppServices;
using OA_Service.ViewModels;
using OA_Web.Models;
using OA_Web.Security;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace OA_Web.Controllers
{
  //  [NoDirectAccess]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly JourneyAppService jounrenyappservice;

        public HomeController(ILogger<HomeController> logger,JourneyAppService _jounrenyappservice )
        {
            _logger = logger;
            jounrenyappservice = _jounrenyappservice;
        }
        public IActionResult Search(SearchViewModel search) 
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }
            List<JourneyViewModel> jourenys;
            if (search.Passengers_Number == 0)
            {
                 jourenys = jounrenyappservice.GetAllJourneys().Where(j => j.To.Contains(search.To) && j.From.Contains(search.From) &&
                 j.Date == search.Date && j.Time >= search.Time).ToList();
            }
            else
            {
                jourenys = jounrenyappservice.GetAllJourneys().Where(j => j.To.Contains(search.To) && j.From.Contains(search.From) &&
                j.Date == search.Date && j.Passengers_Number >= search.Passengers_Number && j.Time == j.Time).ToList();
            }
            /*jourenys = jounrenyappservice.GetAllJourneys().Where(j => j.To.Contains(search.To) && j.From.Contains(search.From) &&
                j.Date == search.Date).ToList();*/
            return Ok(jourenys);
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Policy = "IsActive")]
        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    
        public IActionResult GetClosetJourney(double lat,double lng)
        {
            List<JourneyViewModel> journeyViewModels = jounrenyappservice.GetAllJourneys();
            List<KeyValuePair<int, double>> distances = new List<KeyValuePair<int, double>>();

       

            foreach (var j in journeyViewModels)
            {
                distances.Add(new KeyValuePair<int, double>(j.Id,DistanceTo(lat, lng, Convert.ToDouble(j.Form_Lat),Convert.ToDouble(j.Form_Long))));

            }
            var sortedList=distances.OrderBy(x => x.Value);
            var newJeournes = new List<JourneyViewModel>();
            foreach (var journy in sortedList.ToList())
            {
                newJeournes.Add(jounrenyappservice.GetJourneyById(journy.Key));
            }
         
            return PartialView("_ListJourneys", newJeournes.Take(5).ToList());
        }
        public IActionResult GetAllJourneys(double lat, double lng,int pg=1)
        {
            ViewBag.lat = lat;
            ViewBag.lng = lng;
            List<JourneyViewModel> journeyViewModels = jounrenyappservice.GetAllJourneys();
            List<KeyValuePair<int, double>> distances = new List<KeyValuePair<int, double>>();



            foreach (var j in journeyViewModels)
            {
                distances.Add(new KeyValuePair<int, double>(j.Id, DistanceTo(lat, lng, Convert.ToDouble(j.Form_Lat), Convert.ToDouble(j.Form_Long))));

            }
            var sortedList = distances.OrderBy(x => x.Value);
            var newJeournes = new List<JourneyViewModel>();
            foreach (var journy in sortedList.ToList())
            {
                newJeournes.Add(jounrenyappservice.GetJourneyById(journy.Key));
            }
            if (pg < 1)
            {
                pg = 1;
            }
            int count = newJeournes.Count();
            Pager page = new Pager(count, pg, 3);
            int rowskip = (pg - 1) * page.PageSize;
            var data = newJeournes.Skip(rowskip).Take(page.PageSize);
            ViewBag.Pager = page;
            return View(data);
        }
        [HttpGet]
        public double DistanceTo(double lat1, double lon1, double lat2, double lon2, char unit = 'K')
        {
            double rlat1 = Math.PI * lat1 / 180;
            double rlat2 = Math.PI * lat2 / 180;
            double theta = lon1 - lon2;
            double rtheta = Math.PI * theta / 180;
            double dist =
                Math.Sin(rlat1) * Math.Sin(rlat2) + Math.Cos(rlat1) *
                Math.Cos(rlat2) * Math.Cos(rtheta);
            dist = Math.Acos(dist);
            dist = dist * 180 / Math.PI;
            dist = dist * 60 * 1.1515;

            switch (unit)
            {
                case 'K': //Kilometers -> default
                    return dist * 1.609344;
                case 'N': //Nautical Miles 
                    return dist * 0.8684;
                case 'M': //Miles
                    return dist;
            }

            return dist;
        }
    }
}
