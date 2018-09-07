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

        public ApplicationUser GetUser(string UserId)
        {
            ApplicationUser user = aUnitOfWork.Repository<ApplicationUser>().GetModel(x => x.Id == UserId);
            return user;
        }
    }
}