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

        public string SaveToCart(ProductDetailViewModel aProductDetailViewModel,string UserId)
        {
            Cart aCart = new Cart();
            aCart.ProductId = aProductDetailViewModel.Id;aCart.Quantity = aProductDetailViewModel.Qunatity;aCart.UserId = UserId;
            aCart.IsActive = true;
            bool flag = aUnitOfWork.Repository<Cart>().InsertModel(aCart);
            aUnitOfWork.Save();
            if(flag)
            {
                return "Added";
            }
            else { return "Failed"; }
            
        }
        
        public string Delete(Cart aCart)
        {
            aCart.IsActive = true;
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
        public IEnumerable<UserCartListShowViewModel> GetUserCartList(string userId)
        {
            IEnumerable<Cart> carts = aUnitOfWork.Repository<Cart>().GetList(x => x.UserId == userId && x.IsActive==true).ToList();
            List<UserCartListShowViewModel>userCart=new List<UserCartListShowViewModel>();

            foreach (Cart cart in carts)
            {
                UserCartListShowViewModel newCart=new UserCartListShowViewModel();
                newCart.CartId = cart.Id;
                newCart.ProductId = cart.ProductId;
                newCart.UserId = userId;
                newCart.Quantity = cart.Quantity;
                Product aProduct = aUnitOfWork.Repository<Product>().GetModelById(cart.ProductId);
                newCart.ProductName = aProduct.Name;
                newCart.ImageUrl = aProduct.ImageUrl;
                newCart.Cost = "" + cart.Quantity + " X " + aProduct.Price + " = " +
                               (cart.Quantity*aProduct.Price);

                userCart.Add(newCart);
            }

            return userCart;
        }
    }
}