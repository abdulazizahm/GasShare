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

    public class RequestPhotoRepository : BaseRepository<Request_Photo>
    {
        public RequestPhotoRepository(DbContext db) : base(db)
        {
        }
        #region CRUB

        public List<Request_Photo> GetAllRequestPhotos()
        {
            return GetAll().ToList();
        }

        public bool InsertRequestPhoto(Request_Photo RequestPhoto)
        {
            return Insert(RequestPhoto);
        }
        public void UpdateRequestPhoto(Request_Photo RequestPhoto)
        {
            Update(RequestPhoto);
        }
        public void DeleteRequestPhoto(int id)
        {
            Delete(id);
        }

        public bool CheckRequestPhotoExists(Request_Photo RequestPhoto)
        {
            return GetAny(b => b.Id == RequestPhoto.Id);
        }
        public Request_Photo GetRequestPhotoById(int id)
        {
            return GetFirstOrDefault(b => b.Id == id);
        }

        public void DeleteRequestPhotoList(List<Request_Photo> list)
        {
            DeleteList(list);
        }
        #endregion
    }
}
