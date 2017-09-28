using Xunit;
using FundManager.Model;
using System;
using FundManager.Repository;
using System.Linq;

namespace FundManager.UI.Tests.BusinessLogic
{
    public class FundManagerTests
    {
        [Fact]
        public void ShouoldDeaultBondName()
        {
            var stockModel = GetStockModel(StockType.Bond);
            var manager = new FundManager.BusinessLogic.FundManager();
            var repoMock = GetStockRepositoryMock();

            manager.DefaultNewEntry(stockModel, repoMock);

            Assert.Equal("Bond4", stockModel.Name);
        }

        [Fact]
        public void ShouoldDeaultEquityName()
        {
            var stockModel = GetStockModel(StockType.Equity);
            var manager = new FundManager.BusinessLogic.FundManager();
            var repoMock = GetStockRepositoryMock();

            manager.DefaultNewEntry(stockModel, repoMock);

            Assert.Equal("Equity2", stockModel.Name);
        }

        [Fact]
        public void ShouoldDeaultMarketValueBasedOnPriceAndQty()
        {
            var stockModel = GetStockModel(StockType.Bond);
            var manager = new FundManager.BusinessLogic.FundManager();
            var repoMock = GetStockRepositoryMock();

            manager.DefaultNewEntry(stockModel, repoMock);

            Assert.Equal(Convert.ToDecimal(2.00*2), stockModel.MarketValue);
        }

        [Fact]
        public void ShouoldDeaultBondTransactionCost()
        {
            var stockModel = GetStockModel(StockType.Bond);
            var manager = new FundManager.BusinessLogic.FundManager();
            var repoMock = GetStockRepositoryMock();

            manager.DefaultNewEntry(stockModel, repoMock);

            Assert.Equal(stockModel.MarketValue * (decimal)0.02, stockModel.TransactionCost);
        }

        [Fact]
        public void ShouoldDeaultEquityTransactionCost()
        {
            var stockModel = GetStockModel(StockType.Equity);
            var manager = new FundManager.BusinessLogic.FundManager();
            var repoMock = GetStockRepositoryMock();

            manager.DefaultNewEntry(stockModel, repoMock);

            Assert.Equal(stockModel.MarketValue * (decimal)0.005, stockModel.TransactionCost);
        }

        [Fact]
        public void ShouoldRecalculateCollection()
        {
            var stockModel = GetStockModel(StockType.Equity);
            var manager = new FundManager.BusinessLogic.FundManager();
            var repoMock = GetStockRepositoryMock();

            manager.RecalculateCollection(repoMock);

            foreach (var item in repoMock.Collection)
            {
                Assert.Equal((decimal)0.25, item.StockWeight);
            }
        }

        [Fact]
        public void ShouoldRecalculateSummary()
        {
            var stockModel = GetStockModel(StockType.Equity);
            var manager = new FundManager.BusinessLogic.FundManager();
            var repoMock = GetStockRepositoryMock();
            var summaryMock = new StockSummaryRepository();

            manager.RecalculateSummary(repoMock, summaryMock);

            Assert.Equal(3, summaryMock.Collection.Count);
        }

        [Fact]
        public void ShouoldCorrectlyRecalculateSummaryForAllFunds()
        {
            var stockModel = GetStockModel(StockType.Equity);
            var manager = new FundManager.BusinessLogic.FundManager();
            var repoMock = GetStockRepositoryMock();
            var summaryMock = new StockSummaryRepository();

            manager.RecalculateSummary(repoMock, summaryMock);

            var all = summaryMock.GetItems().Single(x => x.Type == "All");
            Assert.Equal(4, all.TotalNumber);
            Assert.Equal(16, all.TotalMarketValue);
            Assert.Equal(4, all.TotalStockWeight);
        }

        [Fact]
        public void ShouoldCorrectlyRecalculateSummaryForBondFunds()
        {
            var stockModel = GetStockModel(StockType.Equity);
            var manager = new FundManager.BusinessLogic.FundManager();
            var repoMock = GetStockRepositoryMock();
            var summaryMock = new StockSummaryRepository();

            manager.RecalculateSummary(repoMock, summaryMock);

            var all = summaryMock.GetItems().Single(x => x.Type == StockType.Bond.ToString());
            Assert.Equal(3, all.TotalNumber);
            Assert.Equal(12, all.TotalMarketValue);
            Assert.Equal(3, all.TotalStockWeight);
        }

        [Fact]
        public void ShouoldCorrectlyRecalculateSummaryForEquityFunds()
        {
            var stockModel = GetStockModel(StockType.Equity);
            var manager = new FundManager.BusinessLogic.FundManager();
            var repoMock = GetStockRepositoryMock();
            var summaryMock = new StockSummaryRepository();

            manager.RecalculateSummary(repoMock, summaryMock);

            var all = summaryMock.GetItems().Single(x => x.Type == StockType.Bond.ToString());
            Assert.Equal(3, all.TotalNumber);
            Assert.Equal(12, all.TotalMarketValue);
            Assert.Equal(3, all.TotalStockWeight);
        }

        private StockModel GetStockModel(StockType type)
        {
            return new StockModel()
            {
                Type = type,
                Price = Convert.ToDecimal(2.00),
                Quantity = 2
            };
        }

        private IRepository<StockModel> GetStockRepositoryMock()
        {
            var repo = new StockRepository();

            repo.AddItem(new StockModel() { Type = StockType.Bond, MarketValue = Convert.ToDecimal(2.00 * 2), Price = Convert.ToDecimal(2.00), Quantity = 2, StockWeight = 1 });
            repo.AddItem(new StockModel() { Type = StockType.Bond, MarketValue = Convert.ToDecimal(2.00 * 2), Price = Convert.ToDecimal(2.00), Quantity = 2, StockWeight = 1 });
            repo.AddItem(new StockModel() { Type = StockType.Bond, MarketValue = Convert.ToDecimal(2.00 * 2), Price = Convert.ToDecimal(2.00), Quantity = 2, StockWeight = 1 });
            repo.AddItem(new StockModel() { Type = StockType.Equity, MarketValue = Convert.ToDecimal(2.00 * 2), Price = Convert.ToDecimal(2.00), Quantity = 2, StockWeight = 1 });

            return repo;
        }
    }
}
