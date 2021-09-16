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
    public class JourneyAppService:BaseAppService<Journey>
    {
        public JourneyAppService(IUnitOfWork _unit) : base(_unit)
        {
        }
        #region CURD

        public List<JourneyViewModel> GetAllJourneys()
        {
            return Mapper.Map<List<JourneyViewModel>>(TheUnitOfWork.Journey.GetAllJourneys().ToList());
        }

        public List<JourneyViewModel> GetActivJourneys()
        {
            return Mapper.Map<List<JourneyViewModel>>(TheUnitOfWork.Journey.GetAllJourneys().Where(c=>c.IsActive==true).ToList());
        }
        public JourneyViewModel GetJourneyById(int id)
        {
            return Mapper.Map<JourneyViewModel>(TheUnitOfWork.Journey.GetJourneyById(id));
        }

        public Journey GetJourneyModelById(int id)
        {
            return TheUnitOfWork.Journey.GetJourneyById(id);
        }



        public bool SaveNewJourney(JourneyViewModel JourneyViewModel)
        {
            bool result = false;
            var Journey = Mapper.Map<Journey>(JourneyViewModel);
            if (TheUnitOfWork.Journey.InsertJourney(Journey))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }


        public bool UpdateJourney(JourneyViewModel JourneyViewModel)
        {
            var Journey = Mapper.Map<Journey>(JourneyViewModel);
            TheUnitOfWork.Journey.UpdateJourney(Journey);
            TheUnitOfWork.Commit();

            return true;
        }

        public bool UpdateJourneyByModel(Journey journey)
        {
          
            TheUnitOfWork.Journey.UpdateJourney(journey);
            TheUnitOfWork.Commit();

            return true;
        }
        public bool DeleteJourney(int id)
        {
            TheUnitOfWork.Journey.DeleteJourney(id);
            bool result = TheUnitOfWork.Commit() > new int();

            return result;
        }

        public bool CheckJourneyExists(JourneyViewModel JourneyViewModel)
        {
            Journey Journey = Mapper.Map<Journey>(JourneyViewModel);
            return TheUnitOfWork.Journey.CheckJourneyExists(Journey);
        }
        public List<JourneyViewModel> GetJourneysByUserId(string userId)
        {
            return Mapper.Map<List<JourneyViewModel>>(TheUnitOfWork.Journey.GetJourneysByUserId(userId));
        }
        #endregion
    }
}
