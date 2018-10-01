using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(FeedBack aFeedBack)
        {
            
            return View();
        }
    }
}