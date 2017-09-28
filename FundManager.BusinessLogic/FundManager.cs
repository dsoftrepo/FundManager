using FundManager.Model;
using FundManager.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FundManager.BusinessLogic
{
    public class FundManager : IFundManager<StockModel, StockSummaryItemModel>
    {
        public void DefaultNewEntry(StockModel stockModel, IRepository<StockModel> stockRepository)
        {
            stockModel.MarketValue = stockModel.Price.Value * stockModel.Quantity.Value;
            stockModel.Name = GenerateName(stockModel.Type, stockRepository);
            stockModel.TransactionCost = GetTransactionCost(stockModel.Type, stockModel.MarketValue);
        }

        public void RecalculateCollection(IRepository<StockModel> stockRepository)
        {
            var totalMarketValue = GetTotalMarketValue(stockRepository);

            foreach (var stock in stockRepository.GetItems())
            {
                stock.StockWeight = stock.MarketValue / (totalMarketValue > 0 ? totalMarketValue : 1);
            }
        }

        public void RecalculateSummary(IRepository<StockModel> stockRepository, IRepository<StockSummaryItemModel> summaryRepository)
        {
            var types = new List<string>() { "All" };

            foreach(var type in Enum.GetValues(typeof(StockType)))
            {
                types.Add(type.ToString());
            }

            foreach (string type in types)
            {
                var filteredRepo = type != "All" ? stockRepository.GetItems().Where(x => x.Type.ToString() == type) : stockRepository.GetItems();

                if (!summaryRepository.Collection.Any(x => x.Type == type))
                {
                    summaryRepository.AddItem(new StockSummaryItemModel()
                    {
                        Type = type.ToString(),
                        TotalNumber = filteredRepo.Count(),
                        TotalMarketValue = filteredRepo.Sum(x => x.MarketValue),
                        TotalStockWeight = filteredRepo.Sum(x => x.StockWeight)
                    });
                }
                else
                {
                    var summaryItem = summaryRepository.GetItems().Where(x => x.Type == type).Single();
                    summaryItem.TotalMarketValue = filteredRepo.Sum(x => x.MarketValue);
                    summaryItem.TotalNumber = filteredRepo.Count();
                    summaryItem.TotalStockWeight = filteredRepo.Sum(x => x.StockWeight);
                }
            }
        }

        private decimal GetTotalMarketValue(IRepository<StockModel> stockRepository)
        {
            return stockRepository.GetItems().Sum(s=>s.MarketValue);
        }

        private decimal GetTransactionCost(StockType stockType, decimal marketValue)
        {
            switch (stockType)
            {
                case StockType.Equity: { return marketValue * (decimal) 0.005; }
                case StockType.Bond: { return marketValue * (decimal)0.02; }
                default: return 0;
            }
        }

        private string GenerateName(StockType type, IRepository<StockModel> stockRepository)
        {
            return string.Format("{0}{1}", type.ToString(), stockRepository.GetItems().Count(x => x.Type == type)+1);
        }
    }
}
