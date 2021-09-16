using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
    public class AccountAppService : BaseAppService<ApplicationUser>
    {
        public AccountAppService(IUnitOfWork _unit) : base(_unit)
        { 
        }

        public ApplicationUser Find(string emial, string password)
        {
            return TheUnitOfWork.Account.Find(emial, password);
        }

        public ApplicationUser FindById(string id) 
        {
            return TheUnitOfWork.Account.Find(id);
        }
        public ProfileViewModel FindProfile(string email)
        {
            return Mapper.Map<ProfileViewModel>(TheUnitOfWork.Account.FindByEmail(email));
        }
       

        public ProfileViewModel FindProfileById(string id)
        {
            return Mapper.Map<ProfileViewModel>(FindById(id));
        }

        public AdminDisplayUserViewModel FindByIdForAdminView(string id)
        {
            return Mapper.Map<AdminDisplayUserViewModel>(TheUnitOfWork.Account.Find(id));
        }

        public ApplicationUser FindByEmail(string email)
        {
            return TheUnitOfWork.Account.FindByEmail(email);
        }
        
        public List<AdminDisplayUserViewModel> GetAll()
        {
            return Mapper.Map<List<AdminDisplayUserViewModel>>(TheUnitOfWork.Account.GetAllUsers().ToList());
        }

        public ApplicationUser FindUserById(string id)
        {
            return TheUnitOfWork.Account.Where(u => u.Id == id).FirstOrDefault();
        }

        //public AdminDisplayUserViewModel FindAdminUserById(string id)
        //{
        //    AdminDisplayUserViewModel user = Mapper.Map<AdminDisplayUserViewModel>(TheUnitOfWork.Account.Where(u => u.Id == id).FirstOrDefault());
        //    return user;
        //}


        //public ProfileEditViewModel GetForEdit(string username)
        //{
        //    return Mapper.Map<ProfileEditViewModel>(Find(username));
        //}

        //public IdentityResult Register(RegisterViewModel userModel)
        //{
        //    ApplicationUser user = Mapper.Map<ApplicationUser>(userModel);
        //    return TheUnitOfWork.Account.Register(user);
        //}

        public IdentityResult AssignToRole(string userId, Role_Name role)
        {
            var user = FindUserById(userId);
            return TheUnitOfWork.Account.AssignToRole(user, role.ToString());
        }


        //public ApplicationUser FindByEmailAndPassword(string email, string password)
        //{
        //    return TheUnitOfWork.Account.FindByEmailAndPassword(email, password);
        //}

        public IdentityResult Update(ApplicationUser user)
        {
            return TheUnitOfWork.Account.Edit(user);
        }

        //public IdentityResult AssignToRole(string userId, string roleName)
        //{
        //    return TheUnitOfWork.Account.AssignToRole(userId, roleName);
        //}

        //public IdentityResult RemoveFromRole(string userId, string roleName)
        //{
        //    if (!IsInRole(userId, Role_Name.User))
        //        AssignToRole(userId, Role_Name.User);
        //    return TheUnitOfWork.Account.RemoveFromRole(userId, roleName);
        //}

        public bool IsInRole(string user_id, Role_Name role)
        {
            var user = FindById(user_id);
            return TheUnitOfWork.Account.IsInRole(user, role);
        }

        //public bool HasEmail(string email)
        //{
        //    return TheUnitOfWork.Account.HasEmail(email);
        //}


        public List<AdminDisplayUserViewModel> GetAllAdmins()
        {
            return Mapper
                .Map<List<AdminDisplayUserViewModel>>(
                TheUnitOfWork.Account.GetAllUsersByRole(Role_Name.Admin)
                );
        }

        public List<AdminDisplayUserViewModel> GetAllInActive()
        {
            return Mapper
                .Map<List<AdminDisplayUserViewModel>>(
                TheUnitOfWork.Account.GetAllUsers().Where(u => u.User_Status == User_Status.InActive).ToList()
                );
        }

        public List<AdminDisplayUserViewModel> GetAllActive()
        {
            return Mapper
                .Map<List<AdminDisplayUserViewModel>>(
                TheUnitOfWork.Account.GetAllUsers().Where(u => u.User_Status == User_Status.Active).ToList()
                );
        }

        public List<AdminDisplayUserViewModel> GetAllBlocked()
        {
            return Mapper
                .Map<List<AdminDisplayUserViewModel>>(
                TheUnitOfWork.Account.GetAllUsers().Where(u => u.User_Status == User_Status.Block).ToList()
                );
        }

        public List<AdminDisplayUserViewModel> GetAllUsers()
        {
            return Mapper
                .Map<List<AdminDisplayUserViewModel>>(
                TheUnitOfWork.Account.GetAllUsersByRole(Role_Name.User)
                );
        }

        public List<AdminDisplayUserViewModel> GetAllCarOwners()
        {
            return Mapper
                .Map<List<AdminDisplayUserViewModel>>(
                TheUnitOfWork.Account.GetAllUsersByRole(Role_Name.Car_Owner)
                );
        }
        public ApplicationUser Register(CreateAdminViewModel createAdminViewModel)
        {
            ApplicationUser user = Mapper.Map<ApplicationUser>(createAdminViewModel);
            TheUnitOfWork.Account.Register(user);
            return user;
        }
    }
}
