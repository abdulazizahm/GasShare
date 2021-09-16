using OA_DAL.Models;
using OA_Service.Bases;
using OA_Service.Interfaces;
using OA_Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA_Service.AppServices
{
    public class NotificationAppService: BaseAppService<Notification>
    {
        public NotificationAppService(IUnitOfWork _unit): base(_unit)
        {
        }

        public List<Notification> GetAllNotifications()
        {
            return TheUnitOfWork.Notification.GetAllNotifications().ToList();
        }

        public List<NotificationViewModel> GetUnseenUserNotifications(string id)
        {
            var notis = TheUnitOfWork.Notification.GetAllNotifications()
                .Where(n => n.User_Id == id).Where(n => n.Seen == false)
                .OrderByDescending(n => n.Created_at);
            return Mapper.Map<List<NotificationViewModel>>(notis);
        }

        public List<NotificationViewModel> GetLastUserNotifications(string id)
        {
            var notis = TheUnitOfWork.Notification.GetAllNotifications()
                .Where(n => n.User_Id == id)
                .OrderByDescending(n => n.Created_at)
                .Take(10);
            return Mapper.Map<List<NotificationViewModel>>(notis);
        }

        public void UserSawNotifications(string id)
        {
            var notis = TheUnitOfWork.Notification.GetAllNotifications()
                .Where(n => n.User_Id == id).Where(n => n.Seen == false).ToList();
            foreach (var noti in notis)
            {
                noti.Seen = true;
            }
            TheUnitOfWork.Notification.UpdateList(notis);
            TheUnitOfWork.Commit();
        }

        public NotificationViewModel GetById(int id)
        {
            return Mapper.Map<NotificationViewModel>(TheUnitOfWork.Notification.GetNotificationById(id));
        }


        public bool InsertNotification(Notification n)
        {
            var result = false;
            if (TheUnitOfWork.Notification.InsertNotification(n))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }

        public void UpdateNotification(NotificationViewModel n)
        {
            var Notification = Mapper.Map<Notification>(n);
            TheUnitOfWork.Notification.UpdateNotification(Notification);
            TheUnitOfWork.Commit();
        }

        public void DeleteNotificationById(int id)
        {
            TheUnitOfWork.Notification.DeleteNotification(id);
            TheUnitOfWork.Commit();
        }

    }
}
