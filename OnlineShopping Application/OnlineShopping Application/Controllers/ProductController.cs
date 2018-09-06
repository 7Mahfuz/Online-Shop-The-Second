using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineShopping_Application.BLL;
using OnlineShopping_Application.Models;

namespace OnlineShopping_Application.Controllers
{
    public class ProductController : Controller
    {
        CategoryManager aCategoryManager = new CategoryManager();
        ProductManager aProductManager = new ProductManager();

        // GET: Category
        public ActionResult Index()
        {
            IEnumerable<Product> products = aProductManager.GetList();
            return View(products);
        }

        // GET: Category/Create
        public ActionResult Add()
        {
            IEnumerable<Category> categories = new List<Category>();
            ViewBag.categoryList = new SelectList(categories, "Id", "Name");

            return View();
        }

        // POST: Category/Create
        [HttpPost]
        public ActionResult Add(Product aProduct)
        {
            try
            {
                string msg = aProductManager.Save(aProduct);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int id)
        {
            IEnumerable<Category> categories = new List<Category>();
            ViewBag.categoryList = new SelectList(categories, "Id", "Name");

            Product aProduct = new Product();
           aProduct = aProductManager.GetAProduct(id);
            return View(aProduct);
        }

        // POST: Category/Edit/5
        [HttpPost]
        public ActionResult Edit(int id,Product aProduct)
        {
            try
            {
                String msg = aProductManager.Update(aProduct);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Category/Delete/5
        public ActionResult Delete(int id)
        {
            Product aProduct = new Product();
            aProduct = aProductManager.GetAProduct(id);
            return View(aProduct);

        }

        // POST: Category/Delete/5
        [HttpPost]
        public ActionResult Delete(int id,Product aProduct)
        {
            try
            {
                string msg = aProductManager.Delete(aProduct);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
