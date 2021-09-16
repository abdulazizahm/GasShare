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
   public class UserRateAppService : BaseAppService<UserRate>
    {
        public UserRateAppService(IUnitOfWork _unit):base(_unit) { }
        public List<UserRateViewModel> GetAllUserRate()
        {

            return Mapper.Map<List<UserRateViewModel>>(TheUnitOfWork.UserRate.GetAllUserRate());
        }
        public List<UserRateViewModel> GetRatesByCarOwnerID(string car_onwer_id)
        {

            return Mapper.Map<List<UserRateViewModel>>(TheUnitOfWork.UserRate.GetRateForThisOnweCarByUserId(car_onwer_id));
        }
        public UserRateViewModel GetUserPhotoByID(int id)
        {
            UserRate user = TheUnitOfWork.UserRate.GetUserRateById(id);
            return Mapper.Map<UserRateViewModel>(user);
        }
        public bool InsertUserRate(UserRateViewModel userRateViewModel)
        {
            UserRate user = Mapper.Map<UserRate>(userRateViewModel);
            return TheUnitOfWork.UserRate.InsertUserRate(user);
        }
        public void UpdateUserRate(UserRateViewModel userRateViewModel)
        {
            var user = Mapper.Map<UserRate>(userRateViewModel);
            TheUnitOfWork.UserRate.UpdateUserRate(user);
        }

        public void DeleteUserRateById(int id)
        {
            TheUnitOfWork.UserRate.DeleteUserRate(id);
        }
    }
}
