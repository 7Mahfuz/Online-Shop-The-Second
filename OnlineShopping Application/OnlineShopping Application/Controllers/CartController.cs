﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineShopping_Application.BLL;
using OnlineShopping_Application.Models;
using Microsoft.AspNet.Identity;

namespace OnlineShopping_Application.Controllers
{
    public class CartController : Controller
    {
        CartManager aCartManager=new CartManager();
        // GET: Cart
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UserCartList()
        {
            string currentUserId = User.Identity.GetUserId();
           IEnumerable<UserCartListShowViewModel>carts=  aCartManager.GetUserCartList(currentUserId);
            return View(carts);
        }

        public ActionResult GoToPayment()
        {
            return RedirectToAction("Index", "CheckOut");
        }
        // GET: Cart/Details/5
        public ActionResult Details(int id)
        {
            
           
            return View();
        }

        // GET: Cart/Create
        public ActionResult Create()
        {
            string currentUserId = User.Identity.GetUserId();
            return View();
        }

        // POST: Cart/Create
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

        // GET: Cart/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Cart/Edit/5
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

        // GET: Cart/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Cart/Delete/5
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
