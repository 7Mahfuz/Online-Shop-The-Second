using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using OnlineShopping_Application.BLL;
using OnlineShopping_Application.Models;

namespace OnlineShopping_Application.Controllers
{
    public class FeedBackController : Controller
    {
        FeedBackManager aFeedBackManager=new FeedBackManager();
        CustomUserManager aCustomUserManager=new CustomUserManager();
        // GET: FeedBack
        public ActionResult Index()
        {
            IEnumerable<FeedBack> feedBacks = aFeedBackManager.GetAllFeedBacks();
            foreach (FeedBack feed in feedBacks)
            {
                ApplicationUser user = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(feed.UserId);
                feed.UserId = user.UserName;

            }
            return View(feedBacks);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(FeedBack aFeedBack)
        {
            aFeedBack.Date=DateTime.Now;
            string curentUser = User.Identity.GetUserId();
            aFeedBack.UserId = curentUser;
            aFeedBackManager.Save(aFeedBack);
            return View();
        }

        public ActionResult Details(int id)
        {
            FeedBack aFeedBack = aFeedBackManager.GetAFeedBack(id);
            ApplicationUser user = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(aFeedBack.UserId);
            aFeedBack.UserId = user.UserName;
            return View(aFeedBack);
        }
    }
}