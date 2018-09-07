using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineShopping_Application.DLL;
using OnlineShopping_Application.Models;

namespace OnlineShopping_Application.BLL
{
    public class OrderManager
    {
        private UnitOfWork aUnitOfWork = null;

        public OrderManager()
        {
            aUnitOfWork = new UnitOfWork();
        }
        public OrderManager(UnitOfWork _uow)
        {
            this.aUnitOfWork = _uow;
        }

        public void Save(int paymentId,string userId,string address)
        {
            IEnumerable<CartToDeliver> cartToDelivers = new List<CartToDeliver>();

            foreach(CartToDeliver aCart in cartToDelivers)
            {
                Order aOrder = new Order();
                aOrder.CartToDeliverId = aCart.Id;
                aOrder.PaymentId = paymentId;
                aOrder.UserId = userId;
                aOrder.DeliveryAddress = address;
                aOrder.IsActive = true;
                aOrder.IsDone = false;

                bool flag = aUnitOfWork.Repository<Order>().InsertModel(aOrder);
            }
        }
        public void IsExist()
        {

        }
        public void Delete()
        {

        }
        public void Update()
        {

        }
        public void Get()
        {

        }
    }
}