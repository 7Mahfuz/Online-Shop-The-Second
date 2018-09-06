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

            Stock aStock = new Stock();
            aStock.ProductId = aStockViewModel.ProductId;
            aStock.Id = aStockViewModel.StockId;
            aStock.Quantity = aStockViewModel.Quantity+aStockViewModel.AvailableQuantity;

            if (IsExist(aStock.Id))
            {
                string msg = Update(aStock);

                return msg;
            }
            else
            {


                bool flag = aUnitOfWork.Repository<Stock>().InsertModel(aStock);
                aUnitOfWork.Save();
                if (flag) return "Ok";
                else return "Failed";

            }
        }
        public bool IsExist(int stockId)
        {
            Stock aStock = new Stock();
            aStock = aUnitOfWork.Repository<Stock>().GetModelById(stockId);
            if (aStock == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public string Delete(Stock aStock)
        {
            bool flag = aUnitOfWork.Repository<Stock>().DeleteModel(aStock);
            aUnitOfWork.Save();
            if (flag) return "Deleted";
            else return "Failed";
        }
        public string Update(StockViewModel aStockViewModel)
        {
            Stock aStock = aUnitOfWork.Repository<Stock>().GetModelById(aStockViewModel.StockId);
            aStock.ProductId = aStockViewModel.ProductId;
            aStock.Quantity = aStockViewModel.Quantity;
            bool flag = aUnitOfWork.Repository<Stock>().UpdateModel(aStock);
            aUnitOfWork.Save();
            if (flag) return "Updated";
            else return "Failed";

        }
        public IEnumerable<StockViewModel> GetList()
        {
           List<StockViewModel> stocks = new List<StockViewModel>();
               // stocks = aUnitOfWork.Repository<StockViewModel>().GetList();
            IEnumerable<Product> products = aUnitOfWork.Repository<Product>().GetList();
            foreach(Product aProduct in products)
            {
                StockViewModel stockViewModel = new StockViewModel();
                stockViewModel.ProductId = aProduct.Id;
                stockViewModel.ProductName = aProduct.Name;

                Category category = aUnitOfWork.Repository<Category>().GetModelById(aProduct.CategoryId);
                stockViewModel.CategoryId = category.Id;
                stockViewModel.CategoryName = category.Name;

                Stock aStock = aUnitOfWork.Repository<Stock>().GetModel(x => x.ProductId == aProduct.Id);
                if(aStock==null)
                {
                    stockViewModel.StockId = 0;
                    stockViewModel.AvailableQuantity = 0;
                }
                else
                {
                    stockViewModel.StockId = aStock.Id;
                    stockViewModel.AvailableQuantity = aStock.Quantity;
                }

                stocks.Add(stockViewModel);
            }


            return stocks;
        }

        public StockViewModel GetAStockViewModel(int ProductId)
        {
            StockViewModel aStockViewModel = new StockViewModel();
            Product aProduct = aUnitOfWork.Repository<Product>().GetModelById(ProductId);
            Category aCategory = aUnitOfWork.Repository<Category>().GetModelById(aProduct.CategoryId);
            Stock aStock = aUnitOfWork.Repository<Stock>().GetModel(x => x.ProductId == aProduct.Id);

            aStockViewModel.CategoryId = aCategory.Id;
            aStockViewModel.CategoryName = aCategory.Name;
            aStockViewModel.ProductId = aProduct.Id;
            aStockViewModel.ProductName = aProduct.Name;
            aStockViewModel.StockId = aStock.Id;
            aStockViewModel.AvailableQuantity = aStock.Quantity;

            return aStockViewModel;
        }
    }
}