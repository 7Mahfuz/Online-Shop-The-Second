using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineShopping_Application.DLL;
using OnlineShopping_Application.Models;
using Microsoft.AspNet.Identity;


namespace OnlineShopping_Application.BLL
{
    public class CartManager
    {
        private UnitOfWork aUnitOfWork = null;

        public CartManager()
        {
            aUnitOfWork = new UnitOfWork();
        }
        public CartManager(UnitOfWork _uow)
        {
            this.aUnitOfWork = _uow;
        }

        public string Save(int ProductId,int Quantity,string UserId)
        {
            Cart aCart = new Cart();
            aCart.ProductId = ProductId;aCart.Quantity = Quantity;aCart.UserId = UserId;
            aCart.IsActive = true;
            bool flag = aUnitOfWork.Repository<Cart>().InsertModel(aCart);
            if(flag)
            {
                return "Added";
            }
            else { return "Failed"; }
            
        }
        
        public string Delete(Cart aCart)
        {
            bool flag = aUnitOfWork.Repository<Cart>().DeleteModel(aCart);
            aUnitOfWork.Save();
            if (flag) return "Deleted";
            else return "Failed";
        }
        public string Update(Cart aCart)
        {
            bool flag = aUnitOfWork.Repository<Cart>().UpdateModel(aCart);
            aUnitOfWork.Save();
            if (flag) return "Updated";
            else return "Failed";

        }
        public void Get()
        {

        }
    }
}