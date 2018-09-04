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

        public string Save(Category category)
        {
            if (IsExist(category.Id))
            {
                return "Exist";
            }
            else
            {
                bool flag = aUnitOfWork.Repository<Category>().InsertModel(category);
                aUnitOfWork.Save();
                if (flag) return "Ok";
                else return "Failed";
                
            }
        }
        public bool IsExist(int CategoryId)
        {
            Category aCategory = new Category();
            aCategory = aUnitOfWork.Repository<Category>().GetModelById(CategoryId);
            if(aCategory==null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public string Delete(Category aCategory)
        {
            bool flag = aUnitOfWork.Repository<Category>().DeleteModel(aCategory);
            aUnitOfWork.Save();
            if (flag) return "Deleted";
            else return "Failed";
        }
        public string Update(Category aCategory)
        {
            bool flag = aUnitOfWork.Repository<Category>().UpdateModel(aCategory);
            aUnitOfWork.Save();
            if (flag) return "Updated";
            else return "Failed";

        }
        public IEnumerable<Category> GetList()
        {
            IEnumerable<Category> categories = new List<Category>();//
            categories = aUnitOfWork.Repository<Category>().GetList();
            return categories;
        }

        public Category GetACategory(int id)
        {
            Category aCategory = new Category();
            aCategory = aUnitOfWork.Repository<Category>().GetModelById(id);
            return aCategory;
        }
    }
}