using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineShopping_Application.DLL;
using OnlineShopping_Application.Models;
using Microsoft.AspNet.Identity;

namespace OnlineShopping_Application.BLL
{
    public class CustomUserManager
    {
        private UnitOfWork aUnitOfWork = null;

        public CustomUserManager()
        {
            aUnitOfWork = new UnitOfWork();
        }
        public CustomUserManager(UnitOfWork _uow)
        {
            this.aUnitOfWork = _uow;
        }

        public void SaveUser(User aUser)
        {
            aUnitOfWork.Repository<User>().InsertModel(aUser);
            aUnitOfWork.Save();
        }
        public User GetUser(string UserName)
        {
            User aUser = aUnitOfWork.Repository<User>().GetModel(x => x.UserName == UserName);
            return aUser;
        }
       
        public void UpdateUser(User aUser)
        {
            aUnitOfWork.Repository<User>().UpdateModel(aUser);
            aUnitOfWork.Save();
        }
    }
}