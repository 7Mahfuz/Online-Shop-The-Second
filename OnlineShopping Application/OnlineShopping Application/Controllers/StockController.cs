using System;
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
        CategoryManager aCategoryManager=new CategoryManager();
        ProductManager aProductManager=new ProductManager();

        // GET: Stock
        public ActionResult Index()
        {
            //IEnumerable<StockViewModel> stockViewModels = aStockManager.GetList();
            return View();
        }

        // GET: Stock/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Stock/Create
        public ActionResult Add()
        {
            IEnumerable<Category> categories = aCategoryManager.GetList();
            ViewBag.CategoryList = new SelectList(categories, "Id", "Name");

            List<Product>products=new List<Product>();
            ViewBag.ProductList=new SelectList(products, "Id", "Name");
            return View();
        }

        public JsonResult GetProductList(int categoryId)
        {
            IEnumerable<Product> products = aProductManager.GetProductListCategoryId(categoryId);
            return Json(products, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetStock(int productId)
        {
            Stock aStock = aStockManager.GetAProductStock(productId);
            return Json(aStock, JsonRequestBehavior.AllowGet);
        }
        // POST: Stock/Create
        [HttpPost]
        public ActionResult Add(StockViewModel stockViewModel)
        {
            try
            {
                IEnumerable<Category> categories = aCategoryManager.GetList();
                ViewBag.CategoryList = new SelectList(categories, "Id", "Name");

                List<Product> products = new List<Product>();
                ViewBag.ProductList = new SelectList(products, "Id", "Name");
                string msg = aStockManager.Save(stockViewModel);

                ModelState.Clear();
                return View(new StockViewModel());
            }
            catch
            {
                return View();
            }
        }

        // GET: Stock/Edit/5
        public ActionResult Edit(int ProductId)
        {
           
           //StockViewModel stockViewModel = aStockManager.GetAStockViewModel(ProductId);
            return View();
            
        }

        // POST: Stock/Edit/5
        [HttpPost]
        public ActionResult Edit(int StockId, StockViewModel stockViewModel)
        {
            try
            {
                //string msg = aStockManager.Update(stockViewModel);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        
    }
}
