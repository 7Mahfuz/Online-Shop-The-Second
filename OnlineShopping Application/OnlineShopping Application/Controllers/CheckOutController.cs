using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineShopping_Application.BLL;
using OnlineShopping_Application.Models;
using Microsoft.AspNet.Identity;

namespace OnlineShopping_Application.Controllers
{
    public class CheckOutController : Controller
    {
        // GET: CheckOut
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult OrderCheckOut()
        {
            return View();
        }
        [HttpPost]
        public ActionResult OrderCheckOut(Payment aPayment)
        {
            string currentUserId = User.Identity.GetUserId();

            return View();
        }
    }
}