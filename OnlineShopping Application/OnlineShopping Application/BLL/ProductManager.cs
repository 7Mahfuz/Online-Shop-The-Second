using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineShopping_Application.DLL;
using OnlineShopping_Application.Models;

namespace OnlineShopping_Application.BLL
{
    public class ProductManager
    {
        private UnitOfWork aUnitOfWork = null;

        public ProductManager()
        {
            aUnitOfWork = new UnitOfWork();
        }
        public ProductManager(UnitOfWork _uow)
        {
            this.aUnitOfWork = _uow;
        }

        public void Save()
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