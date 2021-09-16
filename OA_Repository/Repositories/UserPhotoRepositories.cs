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
   public class UserPhotoRepositories:BaseRepository<UserPhoto>
    {
        public UserPhotoRepositories(DbContext db) : base(db)
        {
        }
        public List<UserPhoto> GetAllUserPhoto()
        {
            return GetAll().ToList();
        }

        public bool InsertUserPhoto(UserPhoto userPhoto)
        {
            return Insert(userPhoto);
        }
        public void UpdateUserPhoto(UserPhoto userPhoto)
        {
            Update(userPhoto);
        }
        public void DeleteUserPhoto(int id)
        {
            Delete(id);
        }

        public bool CheckUserPhotoExists(UserPhoto userPhoto)
        {
            return GetAny(b => b.Id == userPhoto.Id);
        }
        public UserPhoto GetuserPhotoById(int id)
        {
            return GetFirstOrDefault(b => b.Id == id);
        }
        public List<UserPhoto> GetuserPhotoByUserId(string user_id)
        {
            return GetWhere(u => u.User_Id == user_id).ToList();
        }
    }
}
