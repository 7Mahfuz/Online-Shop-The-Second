using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using OnlineShopping_Application.BLL;
using OnlineShopping_Application.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace OnlineShopping_Application.Controllers
{
    public class CheckOutController : Controller
    {
        PaymentManager aPaymentManager = new PaymentManager();
        CartToDeliverManager aCartToDeliverManager = new CartToDeliverManager();
        CustomUserManager aCustomUserManager = new CustomUserManager();
        CartManager aCartManager=new CartManager();
        OrderManager aOrderManager=new OrderManager();

        // GET: CheckOut
        public ActionResult Index()
        {
            string currentUserId = User.Identity.GetUserId();
            IEnumerable<UserCartListShowViewModel> carts = aCartManager.GetUserCartList(currentUserId);
            ApplicationUser user = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(User.Identity.GetUserId());
            User aUser = aCustomUserManager.GetUser(user.UserName);
            PaymentPageViewModel aPageViewModel=new PaymentPageViewModel();
            aPageViewModel.Address = aUser.Address;
            aPageViewModel.Bkash = aUser.Number;
            return View(aPageViewModel);
        }

        [HttpPost]
        public ActionResult Index(PaymentPageViewModel aPageViewModel)
        {
            string curentUser = User.Identity.GetUserId();
           int paymentId= aPaymentManager.Save(aPageViewModel,curentUser);
            aCartToDeliverManager.TransferCart(curentUser,paymentId);

            IEnumerable<CartToDeliver> cartToDelivers = aCartToDeliverManager.GetCartList(curentUser, paymentId);
            aOrderManager.Save(cartToDelivers,paymentId,curentUser,aPageViewModel.Address);

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
            
            
            return View();
        }
    }
}