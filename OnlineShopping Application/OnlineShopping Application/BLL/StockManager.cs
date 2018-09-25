using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineShopping_Application.DLL;
using OnlineShopping_Application.Models;

namespace OnlineShopping_Application.BLL
{
    public class StockManager
    {
        private UnitOfWork aUnitOfWork = null;

        public StockManager()
        {
            aUnitOfWork = new UnitOfWork();
        }
        public StockManager(UnitOfWork _uow)
        {
            this.aUnitOfWork = _uow;
        }

        public string Save(StockViewModel aStockViewModel)
        {
            Stock aStock =new Stock();
            if (IsExist(aStockViewModel.ProductId))
            {
               aStock = aUnitOfWork.Repository<Stock>().GetModel(x => x.ProductId == aStockViewModel.ProductId);
                aStock.Quantity += aStockViewModel.Quantity;
                aUnitOfWork.Repository<Stock>().UpdateModel(aStock);
                aUnitOfWork.Save();
            }
            aStock.ProductId = aStockViewModel.ProductId;
            aStock.Quantity = aStockViewModel.Quantity;
            aUnitOfWork.Repository<Stock>().InsertModel(aStock);
            aUnitOfWork.Save();
            return "Updated";
        }


        public bool IsExist(int productId)
        {
            Stock aStock = aUnitOfWork.Repository<Stock>().GetModel(x => x.ProductId == productId);
            if (aStock == null)
            {
                return false;
            }
            else return true;
        }

        public Stock GetAProductStock(int productId)
        {
            Stock aStock = aUnitOfWork.Repository<Stock>().GetModel(x => x.ProductId == productId);
            if (aStock == null)
            {
                aStock=new Stock();
                aStock.Quantity = 0;
                aStock.ProductId = productId;
            }
            return aStock;
        }
        
    }
}