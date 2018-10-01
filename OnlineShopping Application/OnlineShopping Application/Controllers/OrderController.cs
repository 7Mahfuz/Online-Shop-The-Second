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
    public class OrderController : Controller
    {
        CustomUserManager aCustomUserManager=new CustomUserManager();
        OrderManager aOrderManager=new OrderManager();
        CartToDeliverManager aCartToDeliverManager=new CartToDeliverManager();
        PaymentManager aPaymentManager=new PaymentManager();
        // GET: Order
        public ActionResult Index()
        {
            IEnumerable<OrderListViewModel> list = aOrderManager.GetUnDoneOrders();
            foreach (OrderListViewModel orderList in list)
            {
                ApplicationUser user = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(orderList.UserId);
                
                    orderList.UserName = user.UserName;
            }

            return View(list);
        }

        // GET: Order/Details/5
        public ActionResult Details(int paymentId ,string what)
        {
           
            IEnumerable<CartToDeliver> carts = aCartToDeliverManager.GetCartListForAdmin(paymentId);
           OrderDetailViewModel aOrderDetailViewModel =new OrderDetailViewModel();
            Order aOrder = aOrderManager.GetaOrder(paymentId);
            Payment aPayment = aPaymentManager.GetAPayment(paymentId);
            ApplicationUser user = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(aPayment.UserId);
            User aUser = aCustomUserManager.GetUser(user.UserName);

            aOrderDetailViewModel.CustomerName = user.UserName;
            aOrderDetailViewModel.CustomerAddress = aUser.Address;
            aOrderDetailViewModel.CustomerPhn = aUser.Number;
            aOrderDetailViewModel.OrderId = aOrder.Id;
            aOrderDetailViewModel.OrderDate = aOrder.Date;
            aOrderDetailViewModel.PaymentDate = aPayment.Date;
            aOrderDetailViewModel.PaymentId = aPayment.Id;
            if (aPayment.CashOnDelivery == true)
            {
                aOrderDetailViewModel.PaymentType = "Cash on delivery";
            }
            else if (aPayment.CreditCardNumber != null)
            {
                aOrderDetailViewModel.PaymentType = "By Credit Card = " + aPayment.CreditCardNumber;
            }
            else
            {
                aOrderDetailViewModel.PaymentType = "By Bkash number = " + aPayment.BkashNumber + " and TrxNo is = " +
                                                    aPayment.TrxNo;
            }
                return View(aOrderDetailViewModel);
        }


        public string OrderDone(int paymentId)
        {
            aOrderManager.OrderDone(paymentId);
            return "OK";
        }

        public ActionResult IndexDone()
        {
            IEnumerable<OrderListViewModel> list = aOrderManager.GetDoneOrders();
            foreach (OrderListViewModel orderList in list)
            {
                ApplicationUser user = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(orderList.UserId);

                orderList.UserName = user.UserName;
            }

            return View(list);
        }

        // GET: Order/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Order/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
