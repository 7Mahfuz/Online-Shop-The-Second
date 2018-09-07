using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineShopping_Application.DLL;
using OnlineShopping_Application.Models;
using Microsoft.AspNet.Identity;

namespace OnlineShopping_Application.BLL
{
    public class CartToDeliverManager
    {
        private UnitOfWork aUnitOfWork = null;

        public CartToDeliverManager()
        {
            aUnitOfWork = new UnitOfWork();
        }
        public CartToDeliverManager(UnitOfWork _uow)
        {
            this.aUnitOfWork = _uow;
        }

        public void TransferCart(string UserId)
        {
            IEnumerable<Cart> carts = aUnitOfWork.Repository<Cart>().GetList(x => x.UserId == UserId);
            foreach(Cart aCart in carts)
            {
                CartToDeliver aCartToDeliver = new CartToDeliver();
                Cart oneCart = new Cart();

                oneCart = aCart;
                oneCart.IsActive = false;

                aCartToDeliver.ProductId = aCart.ProductId;
                aCartToDeliver.Quantity = aCart.Quantity;
                aCartToDeliver.UserId = UserId;

                bool flag1 = aUnitOfWork.Repository<CartToDeliver>().InsertModel(aCartToDeliver);
                bool flag2 = aUnitOfWork.Repository<Cart>().UpdateModel(oneCart);
            }
        }
    }
}