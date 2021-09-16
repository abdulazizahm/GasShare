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
    public class RequestAppService : BaseAppService<Request>
    {
        public RequestAppService(IUnitOfWork _unit) : base(_unit)
        {
        }

        public List<RequestViewModel> GetAllRequests()
        {
            return Mapper.Map<List<RequestViewModel>>(TheUnitOfWork.Request.GetAllRequests().ToList());
        }

        public List<RequestViewModel> GetJourneyRequests(int id)
        {
            var requests = TheUnitOfWork.Request.GetAllRequests().Where(r => r.Journey_Id == id).ToList();
            return Mapper.Map<List<RequestViewModel>>(requests);
        }

        public RequestViewModel GetById(int id)
        {
            return Mapper.Map<RequestViewModel>(TheUnitOfWork.Request.GetRequestById(id));
        }


        public Request GetModelById(int id)
        {
            return TheUnitOfWork.Request.GetRequestById(id);
        }


        public bool InsertRequest(RequestViewModel r)
        {
            var result = false;
            var Request = Mapper.Map<Request>(r);
            if (TheUnitOfWork.Request.InsertRequest(Request))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }

        public void UpdateRequest(Request r)
        {
            TheUnitOfWork.Request.UpdateRequest(r);
            TheUnitOfWork.Commit();
        }

        public void DeleteRequestById(int id)
        {
            TheUnitOfWork.Request.DeleteRequest(id);
            TheUnitOfWork.Commit();
        }


    }
}
