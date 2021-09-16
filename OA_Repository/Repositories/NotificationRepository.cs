using Microsoft.EntityFrameworkCore;
using OA_DAL.Models;
using OA_Repository.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA_Repository.Repositories
{
    public class NotificationRepository : BaseRepository<Notification>
    {
        public NotificationRepository(DbContext db) : base(db)
        {
        }

        #region CRUB

        public IQueryable<Notification> GetAllNotifications()
        {
            return GetAll();
        }

        public bool InsertNotification(Notification Notification)
        {
            return Insert(Notification);
        }
        public void UpdateNotification(Notification Notification)
        {
            Update(Notification);
        }
        public void DeleteNotification(int id)
        {
            Delete(id);
        }

        public bool CheckNotificationExists(Notification Notification)
        {
            return GetAny(b => b.Id == Notification.Id);
        }
        public Notification GetNotificationById(int id)
        {
            return GetFirstOrDefault(b => b.Id == id);
        }
        #endregion
    }
}
