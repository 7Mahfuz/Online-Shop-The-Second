using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using OnlineShopping_Application.BLL;
using OnlineShopping_Application.Models;

namespace OnlineShopping_Application.Controllers
{
    public class ProductController : Controller
    {
        CategoryManager aCategoryManager = new CategoryManager();
        ProductManager aProductManager = new ProductManager();
        CartManager aCartManager=new CartManager();
        // GET: Category
        public ActionResult Index()
        {
            IEnumerable<Product> products = aProductManager.GetList();
            return View(products);
        }
       
        // GET: Category/Create
        public ActionResult Add()
        {
            IEnumerable<Category> categories = aCategoryManager.GetList();
            ViewBag.categoryList = new SelectList(categories, "Id", "Name");

            return View();
        }

        // POST: Category/Create
        [HttpPost]
        public ActionResult Add(Product aProduct)
        {
            try
            {
                string fileName = Path.GetFileNameWithoutExtension(aProduct.ImageFile.FileName);
                string extention = Path.GetExtension(aProduct.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extention;
                aProduct.ImageUrl = "~/Image/Product/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Image/Product/"), fileName);
                aProduct.ImageFile.SaveAs(fileName);
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

        public ActionResult Details(int id)
        {
            Product aProduct = aProductManager.GetAProduct(Convert.ToInt32(id));
            ProductDetailViewModel aProductDetailViewModel = new ProductDetailViewModel();
            aProductDetailViewModel.Id = aProduct.Id;
            aProductDetailViewModel.Name = aProduct.Name;
            aProductDetailViewModel.Description = aProduct.Description;
            aProductDetailViewModel.ImageUrl = aProduct.ImageUrl;
            aProductDetailViewModel.Price = aProduct.Price;
            aProductDetailViewModel.Qunatity = 0;

            return View(aProductDetailViewModel);
        }
        [HttpPost]
        public ActionResult Details(ProductDetailViewModel aProductDetailViewModel)
        {
            string currentUserId = User.Identity.GetUserId();
            aCartManager.SaveToCart(aProductDetailViewModel, currentUserId);

            return View(aProductDetailViewModel);
        }
    }
}
