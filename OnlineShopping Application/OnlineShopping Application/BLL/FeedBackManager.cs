using OnlineShopping_Application.DLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineShopping_Application.Models;
using Microsoft.AspNet.Identity;

namespace OnlineShopping_Application.BLL
{
    public class FeedBackManager
    {
        private UnitOfWork aUnitOfWork = null;

        public FeedBackManager()
        {
            aUnitOfWork = new UnitOfWork();
        }
        public FeedBackManager(UnitOfWork _uow)
        {
            this.aUnitOfWork = _uow;
        }

        public void Save(FeedBack aFeedBack)
        {
            aFeedBack.Date=DateTime.Today;
            aUnitOfWork.Repository<FeedBack>().InsertModel(aFeedBack);
            aUnitOfWork.Save();
        }

        public IEnumerable<FeedBack> GetAllFeedBacks()
        {
            IEnumerable<FeedBack> feedBacks = aUnitOfWork.Repository<FeedBack>().GetList();
            return feedBacks;
        }

        public FeedBack GetAFeedBack(int feedBackId)
        {
            FeedBack aFeedBack = aUnitOfWork.Repository<FeedBack>().GetModelById(feedBackId);
            return aFeedBack;
        }
    }
}