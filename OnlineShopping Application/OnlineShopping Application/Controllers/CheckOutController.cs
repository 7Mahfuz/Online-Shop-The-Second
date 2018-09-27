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
        PaymentManager aPaymentManager = new PaymentManager();
        CartToDeliverManager aCartToDeliverManager = new CartToDeliverManager();
        CustomUserManager aCustomUserManager = new CustomUserManager();

        // GET: CheckOut
        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult OrderCheckOut()
        {
            string currentUserId = User.Identity.GetUserId();
           // ApplicationUser currentUser = aCustomUserManager.GetUser(currentUserId);
           // string address = currentUser.Address;
            return View();
        }
        [HttpPost]
        public ActionResult OrderCheckOut(Payment aPayment)
        {
            string currentUserId = User.Identity.GetUserId();
            int paymentId = aPaymentManager.Save(aPayment, currentUserId);
            aCartToDeliverManager.TransferCart(currentUserId);
            
            return View();
        }
    }
}