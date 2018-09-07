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
    }
}