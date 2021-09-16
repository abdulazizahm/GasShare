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
    public class RequestPhotoAppService :BaseAppService<Request_Photo>
    {
        public RequestPhotoAppService(IUnitOfWork _unit) : base(_unit)
        {
        }

        public List<RequestPhotoViewModel> GetAllRequestPhotos()
        {
            return Mapper.Map<List<RequestPhotoViewModel>>(TheUnitOfWork.RequestPhoto.GetAllRequestPhotos());
        }

        public RequestPhotoViewModel GetById(int id)
        {
            return Mapper.Map<RequestPhotoViewModel>(TheUnitOfWork.RequestPhoto.GetRequestPhotoById(id));
        }


        public bool InsertRequestPhoto(RequestPhotoViewModel r)
        {
            var result = false;
            var RequestPhoto = Mapper.Map<Request_Photo>(r);
            if (TheUnitOfWork.RequestPhoto.InsertRequestPhoto(RequestPhoto))
            {
                result = TheUnitOfWork.Commit() > new int();
            }

            return result;
        }

        public void UpdateRequestPhoto(RequestPhotoViewModel r)
        {
            var RequestPhoto = Mapper.Map<Request_Photo>(r);
            TheUnitOfWork.RequestPhoto.UpdateRequestPhoto(RequestPhoto);
            TheUnitOfWork.Commit();
        }

        public void DeleteRequestPhotoById(int id)
        {
            TheUnitOfWork.RequestPhoto.DeleteRequestPhoto(id);
            TheUnitOfWork.Commit();
        }

        public void DeleteList(List<Request_Photo> list)
        {
            TheUnitOfWork.RequestPhoto.DeleteList(list);
        }
    }
}
