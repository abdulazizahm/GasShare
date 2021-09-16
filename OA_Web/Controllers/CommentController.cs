using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OA_Service.AppServices;
using OA_Service.ViewModels;
using OA_Web.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OA_Web.Controllers
{
    [Authorize]
    [NoDirectAccess]
    public class CommentController : Controller
    {
        private CommentAppService commentAppService;
        private AccountAppService account;

        public CommentController(CommentAppService _comment, AccountAppService _account)
        {
            commentAppService = _comment;
            account = _account;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            ViewData["commentNumber"] = commentAppService.GetAllComments().Count;
            
            return View(commentAppService.GetAllComments());
        }

        public IActionResult Journey(int id)
        {
            return PartialView("_CommentsList",commentAppService.GetAllComments().Where(c => c.Journey_Id == id));
        }

        public IActionResult AddComment(int id)
        {
            ViewData["commentNumber"] = commentAppService.GetAllComments().Count;
            ViewData["comments"] = commentAppService.GetAllComments();
            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult AddComment(CommentViewModel commentView)
        {
            if (commentView.Id > 0)
            {
                return RedirectToAction("UpdateComment", commentView);
            }

            if (!ModelState.IsValid)
            {
                return View(commentView);
            }
            try
            {
                commentView.User_Id = account.FindByEmail(email:User.Identity.Name).Id;
               // commentView.User_Id = "fe684e54-a444-4e57-8f43-74963a2807d6";
                //commentView.Journey_Id = 2;
                commentAppService.SaveNewComment(commentView);
                return Content("Success");


            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", ex.Message);
                return Content("Faild");
            }

        }

        [HttpPost]
        public IActionResult UpdateComment(CommentViewModel commentView)
        {
            if(!ModelState.IsValid)
            {
                return View(commentView);
            }
            try
            {
                var oldComment = commentAppService.GetComment_ByModelId(commentView.Id);
                oldComment.Body = commentView.Body;
                commentAppService.UpdateComment_ByModel(oldComment);
                return RedirectToAction("Search", "Journey");

            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", ex.Message);
                return View(commentView);
            }
        }

      
        public IActionResult DeleteComment(int id)
        {
            commentAppService.DeleteComment(id);
            return Content("deleted");

        }
    }
}
