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
    public class CommentRepository: BaseRepository<Comment>
    {
        public CommentRepository(DbContext db) : base(db)
        {
        }

        #region CRUB

        public IQueryable<Comment> GetAllComments()
        {
            return GetAll().Include(u=>u.User).Include(j=>j.Journey);
        }

        public bool InsertComment(Comment comment)
        {
            return Insert(comment);
        }
        public void UpdateComment(Comment comment)
        {
            Update(comment);
        }
        public void DeleteComment(int id)
        {
            Delete(id);
        }

        public bool CheckCommentExists(Comment comment)
        {
            return GetAny(b => b.Id == comment.Id);
        }
        public Comment GetCommentById(int id)
        {
            return GetAllComments().FirstOrDefault(b => b.Id == id);
        }
        #endregion

    }
}
