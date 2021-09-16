using AutoMapper;
using OA_DAL.Models;
using OA_Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA_Service.Configurations
{
    public class MapperConfig
    {
        public static IMapper Mapper { get; set; }

        static MapperConfig()
        {
            var conig = new MapperConfiguration(
                cfg =>
                {
                    cfg.CreateMap<Car, CarViewModel>().ReverseMap();
                    cfg.CreateMap<JourneyRate, JourneyRateViewModel>().ReverseMap();
                    cfg.CreateMap<UserPhoto, UserPhotoViewModel>().ReverseMap();
                    cfg.CreateMap<UserRate, UserRateViewModel>().ReverseMap();
                    cfg.CreateMap<Journey, JourneyViewModel>().ReverseMap();
                    cfg.CreateMap<Complain, ComplainViewModel>().ReverseMap();
                    cfg.CreateMap<Request, RequestViewModel>().ReverseMap();
                    cfg.CreateMap<Request_Photo, RequestPhotoViewModel>().ReverseMap();
                    cfg.CreateMap<Comment, CommentViewModel>().ReverseMap();
                    cfg.CreateMap<Notification, NotificationViewModel>().ReverseMap();
                    cfg.CreateMap<ApplicationUser, AdminDisplayUserViewModel>().ReverseMap();
                    cfg.CreateMap<ApplicationUser, ProfileViewModel>().ReverseMap();
                    cfg.CreateMap<ApplicationUser, CreateAdminViewModel>().ReverseMap();
                });

            Mapper = conig.CreateMapper();
        }
    }
}
