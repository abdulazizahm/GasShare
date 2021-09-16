using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OA_DAL.Models;
using OA_Repository.Identity;
using OA_Repository.Repositories;
using OA_Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA_Service.Repositories
{
    public class UnitOfWork: IUnitOfWork
    {

        private DbContext EC_Context { get; set; }
        private UserManager<ApplicationUser> manager;

        #region Props and Data Fields

        private AccountRepository account;
        public AccountRepository Account
        {
            get
            {
                account = account ?? new AccountRepository(manager, EC_Context);
                return account;
            }
        }

        private CarRepository car;
        public CarRepository Car
        {
            get
            {
                car = car ?? new CarRepository(EC_Context);
                return car;
            }
        }

        private JourneyRateRepository journeyRate;
        public JourneyRateRepository JourneyRate
        {
            get
            {
                journeyRate = journeyRate ?? new JourneyRateRepository(EC_Context);
                return journeyRate;
            }
        }
       

        private JourneyRepository journey;
        public JourneyRepository Journey
        {
            get
            {
                journey = journey ?? new JourneyRepository(EC_Context);
                return journey;
            }
        }

        private ComplainRepository complain;
        public ComplainRepository Complain
        {
            get
            {
                complain = complain ?? new ComplainRepository(EC_Context);
                return complain;
            }
        }


        private UserPhotoRepositories userPhoto;
        public UserPhotoRepositories UserPhoto
        {
            get
            {
                userPhoto = userPhoto ?? new UserPhotoRepositories(EC_Context);
                return userPhoto;
            }
        }

        private UserRateRepository userRate;
        public UserRateRepository UserRate
        {
            get
            {
                userRate = userRate ?? new UserRateRepository(EC_Context);
                return userRate;
            }
        }
        private RequestRepository request;
        public RequestRepository Request
        {
            get
            {
                request = request ?? new RequestRepository(EC_Context);
                return request;
            }
        }
        private RequestPhotoRepository requestohoto;
        public RequestPhotoRepository RequestPhoto
        {
            get
            {
                requestohoto = requestohoto ?? new RequestPhotoRepository(EC_Context);
                return requestohoto;
            }
        }

        private CommentRepository comment;
        public CommentRepository Comment
        {
            get
            {
                comment = comment ?? new CommentRepository(EC_Context);
                return comment;
            }
        }

        private NotificationRepository notification;

        public NotificationRepository Notification
        {
            get
            {
                notification = notification ?? new NotificationRepository(EC_Context);
                return notification;
            }
        }

        private RoleRepository role;

        public RoleRepository Role
        {
            get
            {
                role = role ?? new RoleRepository(EC_Context);
                return role;
            }
        }

        #endregion

        public UnitOfWork(ApplicationDbContext _Context, UserManager<ApplicationUser> _manager)
        {
            EC_Context = _Context;
            manager = _manager;

            //EC_Context.Configuration.LazyLoadingEnabled = false;
        }


        #region Methods

        public int Commit()
        {
            return EC_Context.SaveChanges();
        }

        public void Dispose()
        {
            EC_Context.Dispose();
        }
        #endregion
    }
}
