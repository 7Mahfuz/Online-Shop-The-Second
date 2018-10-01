using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Ajax.Utilities;
using OnlineShopping_Application.DLL;
using OnlineShopping_Application.Models;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

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

        private CustomUserManager aCustomUserManager = new CustomUserManager();

        public void Save(IEnumerable<CartToDeliver> cartToDelivers, int paymentId, string userId, string address)
        {


            foreach (CartToDeliver aCart in cartToDelivers)
            {
                Order aOrder = new Order();
                aOrder.CartToDeliverId = aCart.Id;
                aOrder.PaymentId = paymentId;
                aOrder.UserId = userId;
                aOrder.DeliveryAddress = address;
                aOrder.IsActive = true;
                aOrder.IsDone = false;
                aOrder.Date=DateTime.Today;

                bool flag = aUnitOfWork.Repository<Order>().InsertModel(aOrder);
            }
            aUnitOfWork.Save();
        }

        public IEnumerable<OrderListViewModel> GetUnDoneOrders()
        {
            IEnumerable<Order> orders =
                aUnitOfWork.Repository<Order>().GetList(x => x.IsDone == false && x.IsActive == true);
            List<Order> tempOrder = orders.DistinctBy(x => x.PaymentId).ToList();
            List<OrderListViewModel> newOrder = new List<OrderListViewModel>();
            int sl = 0;
            foreach (Order order in tempOrder)
            {
                OrderListViewModel aOrder = new OrderListViewModel();
                aOrder.SL = ++sl;
                aOrder.Address = order.DeliveryAddress;
                aOrder.OrderId = order.Id;
                aOrder.UserId = order.UserId;
                aOrder.PaymentId = order.PaymentId;
                aOrder.Date = order.Date;
                newOrder.Add(aOrder);
            }

            return newOrder;
        }
        public IEnumerable<OrderListViewModel> GetDoneOrders()
        {
            IEnumerable<Order> orders =
                aUnitOfWork.Repository<Order>().GetList(x => x.IsDone == true && x.IsActive == false);
            List<Order> tempOrder = orders.DistinctBy(x => x.PaymentId).ToList();
            List<OrderListViewModel> newOrder = new List<OrderListViewModel>();
            int sl = 0;
            foreach (Order order in tempOrder)
            {
                OrderListViewModel aOrder = new OrderListViewModel();
                aOrder.SL = ++sl;
                aOrder.Address = order.DeliveryAddress;
                aOrder.OrderId = order.Id;
                aOrder.UserId = order.UserId;
                aOrder.PaymentId = order.PaymentId;
                aOrder.Date = order.Date;
                newOrder.Add(aOrder);
            }

            return newOrder;
        }
        public Order GetaOrder(int paymentId)
        {
            Order aOrder = aUnitOfWork.Repository<Order>().GetModel(x => x.PaymentId == paymentId && x.IsDone == false);
            return aOrder;
        }

        public void OrderDone(int paymentId)
        {
            IEnumerable<Order> orders =
                aUnitOfWork.Repository<Order>().GetList(x => x.PaymentId == paymentId && x.IsDone == false);

            foreach (Order order in orders)
            {
                order.IsActive = false;
                order.IsDone = true;
                aUnitOfWork.Repository<Order>().UpdateModel(order);
            }
            aUnitOfWork.Save();
            
        }
    }
}