using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OA_Service.AppServices;
using OA_Web.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OA_Web.Controllers
{
    [Authorize]
    [NoDirectAccess]
    public class NotificationController : Controller
    {
        private readonly NotificationAppService _notificationAppService;
        private readonly AccountAppService _accountAppService;

        public NotificationController(
            NotificationAppService notificationAppService,
            AccountAppService accountAppService
        )
        {
            _notificationAppService = notificationAppService;
            _accountAppService = accountAppService;
        }

        
        public IActionResult Get()
        {
            string id = _accountAppService.FindByEmail(User.Identity.Name).Id;
            var notifications = _notificationAppService.GetUnseenUserNotifications(id);

            if (notifications == null || notifications.Count == 0)
            {
                notifications = _notificationAppService.GetLastUserNotifications(id);
                ViewBag.NoNew = true;
            }

            return PartialView("_Notifications",notifications);
        }

        //allseen
        public IActionResult AllSeen()
        {
            string id = _accountAppService.FindByEmail(User.Identity.Name).Id;
            _notificationAppService.UserSawNotifications(id);
            return Content("sucess");
        }
    }
}
