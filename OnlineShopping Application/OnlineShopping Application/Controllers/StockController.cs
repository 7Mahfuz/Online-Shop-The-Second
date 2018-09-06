﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineShopping_Application.BLL;
using OnlineShopping_Application.Models;

namespace OnlineShopping_Application.Controllers
{
    public class StockController : Controller
    {
        StockManager aStockManager = new StockManager();

        // GET: Stock
        public ActionResult Index()
        {
            IEnumerable<StockViewModel> stockViewModels = aStockManager.GetList();
            return View(stockViewModels);
        }

        // GET: Stock/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Stock/Create
        public ActionResult AddOrUpdate(int ProductId)
        {
           

            StockViewModel stockViewModel = aStockManager.GetAStockViewModel(ProductId);
            return View(stockViewModel);
        }

        // POST: Stock/Create
        [HttpPost]
        public ActionResult AddOrUpdate(StockViewModel stockViewModel)
        {
            try
            {
                string msg = aStockManager.Save(stockViewModel);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Stock/Edit/5
        public ActionResult Edit(int ProductId)
        {
           
           StockViewModel stockViewModel = aStockManager.GetAStockViewModel(ProductId);
            return View(stockViewModel);
            
        }

        // POST: Stock/Edit/5
        [HttpPost]
        public ActionResult Edit(int StockId, StockViewModel stockViewModel)
        {
            try
            {
                string msg = aStockManager.Update(stockViewModel);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        
    }
}
