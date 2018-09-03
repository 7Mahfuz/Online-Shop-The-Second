using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineShopping_Application.DLL;
using OnlineShopping_Application.Models;

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

        public void Save(Cart aCart)
        {

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