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
    public class CommentAppService: BaseAppService<Comment>
    {
        public CommentAppService(IUnitOfWork _unit) : base(_unit)
        {
        }


        public List<CommentViewModel> GetAllComments()
        {
            return Mapper.Map<List<CommentViewModel>>(TheUnitOfWork.Comment.GetAllComments().OrderByDescending(e=>e.Id));
        }

        public CommentViewModel GetComment_ById(int id)
        {
            return Mapper.Map<CommentViewModel>(TheUnitOfWork.Comment.GetCommentById(id));
        }

        public Comment GetComment_ByModelId(int id)
        {
            return TheUnitOfWork.Comment.GetCommentById(id);
        }

        public bool SaveNewComment(CommentViewModel commentViewModel)
        {
            bool result = false;
            var comment  = Mapper.Map<Comment>(commentViewModel);
            if(TheUnitOfWork.Comment.InsertComment(comment));
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }

        public bool UpdateComment(CommentViewModel commentViewModel)
        {
            var comment = Mapper.Map<Comment>(commentViewModel);
            TheUnitOfWork.Comment.UpdateComment(comment);
            TheUnitOfWork.Commit();

            return true;
        }

        public bool UpdateComment_ByModel(Comment comment)
        {
            TheUnitOfWork.Comment.UpdateComment(comment);
            TheUnitOfWork.Commit();

            return true;
        }

        public bool DeleteComment(int id)
        {
            TheUnitOfWork.Comment.DeleteComment(id);
            bool result = TheUnitOfWork.Commit() > new int();

            return result;
        }

        public bool CheckComplainExists(CommentViewModel commentViewModel)
        {
            Comment comment = Mapper.Map<Comment>(commentViewModel);
            return TheUnitOfWork.Comment.CheckCommentExists(comment);
        }

    }
}
