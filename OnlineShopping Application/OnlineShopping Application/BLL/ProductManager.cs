using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineShopping_Application.DLL;
using OnlineShopping_Application.Models;

namespace OnlineShopping_Application.BLL
{
    public class ProductManager
    {
        private UnitOfWork aUnitOfWork = null;

        public ProductManager()
        {
            aUnitOfWork = new UnitOfWork();
        }
        public ProductManager(UnitOfWork _uow)
        {
            this.aUnitOfWork = _uow;
        }

        public string Save(Product aProduct)
        {
            if (IsExist(aProduct.Id))
            {
                return "Exist";
            }
            else
            {
                bool flag = aUnitOfWork.Repository<Product>().InsertModel(aProduct);                             
                
                aUnitOfWork.Save();
                if (flag) return "Ok";
                else return "Failed";

            }
        }
        public bool IsExist(int ProductId)
        {
            Product aProduct = new Product();
            aProduct = aUnitOfWork.Repository<Product>().GetModelById(ProductId);
            if (aProduct == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public string Delete(Product aProduct)
        {
            bool flag = aUnitOfWork.Repository<Product>().DeleteModel(aProduct);
            aUnitOfWork.Save();
            if (flag) return "Deleted";
            else return "Failed";
        }
        public string Update(Product aProduct)
        {
            bool flag = aUnitOfWork.Repository<Product>().UpdateModel(aProduct);
            aUnitOfWork.Save();
            if (flag) return "Updated";
            else return "Failed";
        }
        public IEnumerable<Product> GetList()
        {
            IEnumerable<Product> products = new List<Product>();//
            products = aUnitOfWork.Repository<Product>().GetList();
            return products;
        }
        public Product GetAProduct(int id)
        {
            Product aProduct = new Product();
            aProduct = aUnitOfWork.Repository<Product>().GetModelById(id);
            return aProduct;
        }
    }
}