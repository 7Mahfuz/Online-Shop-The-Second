using OnlineShopping_Application.DLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineShopping_Application.Models;

namespace OnlineShopping_Application.BLL
{
    public class CategoryManager
    {
        private UnitOfWork aUnitOfWork = null;

        public CategoryManager()
        {
            aUnitOfWork = new UnitOfWork();
        }
        public CategoryManager(UnitOfWork _uow)
        {
            this.aUnitOfWork = _uow;
        }

        public void Save(Category category)
        {
           bool flag= aUnitOfWork.Repository<Category>().InsertModel(category);
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