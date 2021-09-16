using OA_Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA_Service.Interfaces
{
    public interface IUnitOfWork
    {
        AccountRepository Account { get; }
        CarRepository Car { get; }
        UserPhotoRepositories UserPhoto { get; }

        JourneyRateRepository JourneyRate { get; }
        

        ComplainRepository Complain { get; }

        JourneyRepository Journey { get; }
        RequestRepository Request { get; }
        RequestPhotoRepository RequestPhoto { get; }

        CommentRepository Comment { get; }

        NotificationRepository Notification { get; }

        UserRateRepository UserRate { get; }
        RoleRepository Role { get; }

        void Dispose();

        int Commit();
    }
}
