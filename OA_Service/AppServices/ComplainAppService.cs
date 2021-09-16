using OA_DAL.Models;
using OA_Repository.Identity;
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
    public class ComplainAppService:BaseAppService<Complain>
    {
        public ComplainAppService(IUnitOfWork _unit) : base(_unit)
        {
        }
        #region CURD

        public List<ComplainViewModel> GetAllComplains()
        {
            return Mapper.Map<List<ComplainViewModel>>(TheUnitOfWork.Complain.GetAllComplains());
        }
        public ComplainViewModel GetComlain_ById(int id)
        {
            return Mapper.Map<ComplainViewModel>(TheUnitOfWork.Complain.GetComplainById(id));
        }

        public Complain GetComlainModelById(int id)
        {
            return TheUnitOfWork.Complain.GetComplainById(id);
        }

        public bool SaveNewComplain(ComplainViewModel ComplainViewModel)
        {
            bool result = false;
            var complain = Mapper.Map<Complain>(ComplainViewModel);
            if (TheUnitOfWork.Complain.InsertComplain(complain))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }


        public bool UpdateComplain(ComplainViewModel ComplainViewModel)
        {
            var complain = Mapper.Map<Complain>(ComplainViewModel);
            TheUnitOfWork.Complain.UpdateComplain(complain);
            TheUnitOfWork.Commit();

            return true;
        }


        public bool DeleteComplain(int id)
        {
            TheUnitOfWork.Complain.DeleteComplain(id);
            bool result = TheUnitOfWork.Commit() > new int();

            return result;
        }

        public bool CheckComplainExists(ComplainViewModel ComplainViewModel)
        {
            Complain complain = Mapper.Map<Complain>(ComplainViewModel);
            return TheUnitOfWork.Complain.CheckComplainExists(complain);
        }
        public void UpdateStatus(int id) 
        {
            
            var com = GetComlainModelById(id);
            com.Status = true;
            TheUnitOfWork.Commit();
        }
        #endregion
    }
}
