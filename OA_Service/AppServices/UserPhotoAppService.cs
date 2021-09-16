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
   public class UserPhotoAppService: BaseAppService<UserPhoto>
    {
        public UserPhotoAppService(IUnitOfWork _unit) : base(_unit)
        {

        }
        public List<UserPhotoViewModel> GetAllUserPhotos()
        {
           
            return Mapper.Map<List<UserPhotoViewModel>>(TheUnitOfWork.UserPhoto.GetAllUserPhoto());
        }
        public List<UserPhotoViewModel> GetUserPhotosByUserID(string user_id)
        {
            var x = Mapper.Map<List<UserPhotoViewModel>>(TheUnitOfWork.UserPhoto.GetuserPhotoByUserId(user_id));
            return x;
        }

        public UserPhoto GetUserPhotosModelByUserID(string user_id)
        {
            var userPhoto = TheUnitOfWork.UserPhoto.GetAllUserPhoto().FirstOrDefault(p => p.User_Id == user_id);
            return userPhoto;
        }

        public UserPhotoViewModel GetUserPhotoByID(int id)
        {
            UserPhoto user = TheUnitOfWork.UserPhoto.GetuserPhotoById(id);
            return Mapper.Map<UserPhotoViewModel>(user);
        }
        public bool InsertUserPhoto(UserPhotoViewModel userPhotoViewModel)
        {
            UserPhoto user = Mapper.Map<UserPhoto>(userPhotoViewModel);
            bool result = false;
            if (TheUnitOfWork.UserPhoto.InsertUserPhoto(user))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }
        public void UpdateUserPhotos(UserPhotoViewModel userPhotoViewModel)
        {
            var user = Mapper.Map<UserPhoto>(userPhotoViewModel);
            TheUnitOfWork.UserPhoto.UpdateUserPhoto(user);
            TheUnitOfWork.Commit();
        }
        public void UpdateUserPhotos_ByModel(UserPhoto user)
        {
           
            TheUnitOfWork.UserPhoto.UpdateUserPhoto(user);
            TheUnitOfWork.Commit();
        }

        public void DeleteUserPhotosById(int id)
        {
            TheUnitOfWork.UserPhoto.DeleteUserPhoto(id);
            TheUnitOfWork.Commit();
        }
    }
}
