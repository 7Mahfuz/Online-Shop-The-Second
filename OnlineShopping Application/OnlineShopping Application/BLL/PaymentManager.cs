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

        public int Save(PaymentPageViewModel aPageViewModel,string UserId)
        {
            Payment aPayment=new Payment();
            aPayment.UserId = UserId;
            aPayment.BkashNumber = aPageViewModel.Bkash;
            aPayment.CreditCardNumber = aPageViewModel.CreditCardNumber;
            aPayment.IsActive = true;
            aPayment.TrxNo = aPageViewModel.TrxNo;
            aPayment.Date=DateTime.Today;
            aPayment.CashOnDelivery = aPageViewModel.CashOnDelivery;
            aUnitOfWork.Repository<Payment>().InsertModel(aPayment);
            aUnitOfWork.Save();

            IEnumerable<Payment> payments = aUnitOfWork.Repository<Payment>().GetList();
            int paymentId = 0;
            foreach (Payment pay in payments.Reverse())
            {
                paymentId = pay.Id;break;
                ;
            }
            return paymentId;
        }
       
        public Payment GetAPayment(string UserId)
        {
            Payment payment = aUnitOfWork.Repository<Payment>().GetModel(x => x.UserId == UserId && x.IsActive == true);
            return payment;
        }

        public Payment GetAPayment(int paymentId)
        {
            Payment payment = aUnitOfWork.Repository<Payment>().GetModel(x => x.Id ==paymentId  && x.IsActive == true);
            return payment;
        }
    }
}