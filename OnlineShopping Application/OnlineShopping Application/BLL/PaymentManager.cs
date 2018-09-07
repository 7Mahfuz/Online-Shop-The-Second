using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineShopping_Application.DLL;
using OnlineShopping_Application.Models;

namespace OnlineShopping_Application.BLL
{
    public class PaymentManager
    {
        private UnitOfWork aUnitOfWork = null;

        public PaymentManager()
        {
            aUnitOfWork = new UnitOfWork();
        }
        public PaymentManager(UnitOfWork _uow)
        {
            this.aUnitOfWork = _uow;
        }

        public int Save(Payment aPayment,string UserId)
        {
            aPayment.IsActive = true;aPayment.UserId = UserId;
            bool flag = aUnitOfWork.Repository<Payment>().InsertModel(aPayment);

            if(flag)
            {
                Payment aPayment2 = GetAPayment(UserId);
                return aPayment2.Id;
            }
            else
            {
                return 0;
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
        public Payment GetAPayment(string UserId)
        {
            Payment payment = aUnitOfWork.Repository<Payment>().GetModel(x => x.UserId == UserId && x.IsActive == true);
            return payment;
        }
    }
}