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

        public void TransferCart(string UserId,int paymentId)
        {
            IEnumerable<Cart> carts = aUnitOfWork.Repository<Cart>().GetList(x => x.UserId == UserId && x.IsActive==true);
            foreach(Cart aCart in carts)
            {
                CartToDeliver aCartToDeliver = new CartToDeliver();
                Cart oneCart = new Cart();

                oneCart = aCart;
                oneCart.IsActive = false;

                aCartToDeliver.ProductId = aCart.ProductId;
                aCartToDeliver.Quantity = aCart.Quantity;
                aCartToDeliver.UserId = UserId;
                aCartToDeliver.PaymentId = paymentId;

                bool flag1 = aUnitOfWork.Repository<CartToDeliver>().InsertModel(aCartToDeliver);
                bool flag2 = aUnitOfWork.Repository<Cart>().UpdateModel(oneCart);
            }
            aUnitOfWork.Save();
        }


        public IEnumerable<CartToDeliver> GetCartList(string userId, int paymentId)
        {
            IEnumerable<CartToDeliver> carts =
                aUnitOfWork.Repository<CartToDeliver>().GetList(x => x.UserId == userId && x.PaymentId == paymentId);

            return carts;
        }

        public IEnumerable<CartToDeliver> GetCartListForAdmin( int paymentId)
        {
            IEnumerable<CartToDeliver> carts =
                aUnitOfWork.Repository<CartToDeliver>().GetList(x =>x.PaymentId == paymentId);

            return carts;
        }
    }
}