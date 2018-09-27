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
                ApplicationUser user = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(User.Identity.GetUserId());
                User aUser = aCustomUserManager.GetUser(user.UserName);
                orderList.UserName = aUser.UserName;
            }

            return View(list);
        }

        // GET: Order/Details/5
        public ActionResult Details(int paymentId)
        {
            IEnumerable<CartToDeliver> carts = aCartToDeliverManager.GetCartListForAdmin(paymentId);
            Order aOrder = aOrderManager.GetaOrder(paymentId);
            Payment aPayment = aPaymentManager.GetAPayment(paymentId);
            return View();
        }


        public ActionResult OrderDone(int paymentId)
        {
            return View();
        }
        // GET: Order/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Order/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Order/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Order/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
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
