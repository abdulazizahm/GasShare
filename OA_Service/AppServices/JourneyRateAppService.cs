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
    public class JourneyRateAppService: BaseAppService<JourneyRate>
    {
        public JourneyRateAppService(IUnitOfWork _unit) : base(_unit)
        {
        }

        public List<JourneyRateViewModel> GetAllJourneyRates()
        {
            return Mapper.Map<List<JourneyRateViewModel>>(TheUnitOfWork.JourneyRate.GetAllJourneyRates());
        }

        //public JourneyRateViewModel GetById(int id)
        //{
        //    return Mapper.Map<JourneyRateViewModel>(TheUnitOfWork.JourneyRate.GetJourneyRateById(id));
        //}
        public JourneyRate GetByUserIdAndJourneyId(int JourneyId,string userId)
        {
            return TheUnitOfWork.JourneyRate.GetJourneyRateByUserIdAndJourneyId(JourneyId, userId);
        }


        public bool InsertJourneyRate(JourneyRateViewModel j)
        {
            var result = false;
            var JourneyRate = Mapper.Map<JourneyRate>(j);
            if (TheUnitOfWork.JourneyRate.InsertJourneyRate(JourneyRate))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
          
        }

        public void UpdateJourneyRate(JourneyRateViewModel j)
        {
            var JourneyRate = Mapper.Map<JourneyRate>(j);
            TheUnitOfWork.JourneyRate.UpdateJourneyRate(JourneyRate);
            TheUnitOfWork.Commit();
        }
        public void UpdateJourneyRateByModel(JourneyRate j)
        {
           
            TheUnitOfWork.JourneyRate.UpdateJourneyRate(j);
            TheUnitOfWork.Commit();
        }
        public void DeleteJourneyRateById(int id)
        {
            TheUnitOfWork.JourneyRate.DeleteJourneyRate(id);
            TheUnitOfWork.Commit();
        }
        public bool CheckIfThisUserRateThisJourney(JourneyRateViewModel j)
        {
            var JourneyRate = Mapper.Map<JourneyRate>(j);
            if (TheUnitOfWork.JourneyRate.CheckJourneyRateExists(JourneyRate))
            {
                return true;
            }
            else
                return false;

        }
        public List<JourneyRate> GetJourneyRateByJourneyId(int JourneyId)
        {
            return TheUnitOfWork.JourneyRate.GetJourneyRateByJourneyId(JourneyId);
        }
    }
}
