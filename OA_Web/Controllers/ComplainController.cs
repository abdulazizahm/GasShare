using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OA_DAL.Models;
using OA_Service.AppServices;
using OA_Service.Interfaces;
using OA_Service.ViewModels;
using OA_Web.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OA_Web.Controllers
{
    [NoDirectAccess]
    public class ComplainController : Controller
    {
        private ComplainAppService complain;
        private AccountAppService account;
        private NotificationAppService notification;
        private IMailService mailService;

        public ComplainController(ComplainAppService _complain, AccountAppService _account, NotificationAppService _not, IMailService mailService)
        {
            complain = _complain;
            account = _account;
            notification = _not;
            this.mailService = mailService;
        }
        [Route("Admin/Complain")]
        [Authorize]
        public IActionResult Index()
        {
            ViewBag.message = TempData["message"];
            return View(complain.GetAllComplains().Where(c => c.Status == false).ToList());
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Notification(Notification not)
        {
            var complained_about = account.FindUserById(not.User_Id);
            not.Url = "javascript:void(0)";
            notification.InsertNotification(not);

            MailRequest request = new MailRequest();
            request.ToEmail = complained_about.Email;
            request.Body = not.Body;
            request.Subject = "Gas Share Admin";
            await mailService.SendEmailAsync(request);

            return Ok("Notification sent Successfully to " + complained_about.FirstName + " " + complained_about.LastName);
        }

        [HttpPost]
        [Authorize]
        public IActionResult AddComplain(ComplainViewModel com)
        {
            if (User.Identity.IsAuthenticated)
            {
                var complain = account.FindByEmail(User.Identity.Name);
                com.Comlainer_Id = complain.Id;
            }
            else
            {
                return Ok("you are not Authonticated");
            }
            com.Status = false;
            complain.SaveNewComplain(com);
            return Ok("we will take action immediately after we review your complain");
        }

        public IActionResult Done(int id)
        {
            complain.UpdateStatus(id);
            TempData["message"] = "Complain is archived Successfully";

            return RedirectToAction("index");
        }
    }
}
