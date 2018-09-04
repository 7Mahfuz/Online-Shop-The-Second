using OnlineShopping_Application.BLL;
using OnlineShopping_Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace OnlineShopping_Application.Controllers
{
    public class CategoryController : Controller
    {
        CategoryManager aCategoryManager = new CategoryManager();

        // GET: Category
        public ActionResult Index()
        {
            IEnumerable<Category> categories = aCategoryManager.GetList();
            return View(categories);
        }
       
        // GET: Category/Create
        public ActionResult Add()
        {
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        public ActionResult Add(Category aCategory)
        {
            try
            {
                string msg = aCategoryManager.Save(aCategory);

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
            Category aCategory = new Category();
            aCategory = aCategoryManager.GetACategory(id);
            return View(aCategory);
        }

        // POST: Category/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Category aCategory)
        {
            try
            {
                String msg = aCategoryManager.Update(aCategory);

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
            Category aCategory = new Category();
            aCategory = aCategoryManager.GetACategory(id);
            return View(aCategory);
            
        }

        // POST: Category/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Category aCategory)
        {
            try
            {
                string msg = aCategoryManager.Delete(aCategory);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
