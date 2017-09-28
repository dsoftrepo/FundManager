using FundManager.BusinessLogic;
using FundManager.Model;
using FundManager.Repository;
using FundManager.UI.ViewModel;
using Moq;
using Xunit;

namespace FundManager.UI.Tests.UI
{
    public class AddStockViewModelTests
    {
        [Fact]
        public void ShouldNotDoAnythingOnAddCommandIfStockHasErrors()
        {
            var managerMock = new Mock<IFundManager<StockModel, StockSummaryItemModel>>();
            var stockRepoMock = new Mock<IRepository<StockModel>>();
            var summaryRepoMock = new Mock<IRepository<StockSummaryItemModel>>();

            var addStockViewModel = new AddStockViewModel(managerMock.Object, stockRepoMock.Object, summaryRepoMock.Object);

            addStockViewModel.AddStockCommand.Execute(new object());

            stockRepoMock.Verify(m => m.AddItem(It.IsAny<StockModel>()),Times.Never);
            managerMock.Verify(m => m.DefaultNewEntry(It.IsAny<StockModel>(), It.IsAny<IRepository<StockModel>>()), Times.Never);
            managerMock.Verify(m => m.RecalculateCollection(It.IsAny<IRepository<StockModel>>()),Times.Never);
            managerMock.Verify(m => m.RecalculateSummary(It.IsAny<IRepository<StockModel>>(), It.IsAny<IRepository<StockSummaryItemModel>>()),Times.Never);
        }

        [Fact]
        public void ShouldDefaultStockOnAddCommand()
        {
            var managerMock = new Mock<IFundManager<StockModel, StockSummaryItemModel>>();
            var stockRepoMock = new Mock<IRepository<StockModel>>();
            var summaryRepoMock = new Mock<IRepository<StockSummaryItemModel>>();

            var addStockViewModel = new AddStockViewModel(managerMock.Object, stockRepoMock.Object, summaryRepoMock.Object);
            addStockViewModel.StockModel = new StockModel() { Price = (decimal)1.22, Quantity = 1};

            addStockViewModel.AddStockCommand.Execute(new object());

            managerMock.Verify(m => m.DefaultNewEntry(It.IsAny<StockModel>(), It.IsAny<IRepository<StockModel>>()), Times.Once);
        }

        [Fact]
        public void ShouldRecalculateCollectionOnAddCommand()
        {
            var managerMock = new Mock<IFundManager<StockModel, StockSummaryItemModel>>();
            var stockRepoMock = new Mock<IRepository<StockModel>>();
            var summaryRepoMock = new Mock<IRepository<StockSummaryItemModel>>();

            var addStockViewModel = new AddStockViewModel(managerMock.Object, stockRepoMock.Object, summaryRepoMock.Object);
            addStockViewModel.StockModel = new StockModel() { Price = (decimal)1.22, Quantity = 1 };

            addStockViewModel.AddStockCommand.Execute(new object());

            managerMock.Verify(m => m.RecalculateCollection(It.IsAny<IRepository<StockModel>>()), Times.Once);
        }

        [Fact]
        public void ShouldRecalculateSummaryOnAddCommand()
        {
            var managerMock = new Mock<IFundManager<StockModel, StockSummaryItemModel>>();
            var stockRepoMock = new Mock<IRepository<StockModel>>();
            var summaryRepoMock = new Mock<IRepository<StockSummaryItemModel>>();

            var addStockViewModel = new AddStockViewModel(managerMock.Object, stockRepoMock.Object, summaryRepoMock.Object);
            addStockViewModel.StockModel = new StockModel() { Price = (decimal)1.22, Quantity = 1 };

            addStockViewModel.AddStockCommand.Execute(new object());

            managerMock.Verify(m => m.RecalculateSummary(It.IsAny<IRepository<StockModel>>(), It.IsAny<IRepository<StockSummaryItemModel>>()), Times.Once);
        }

        public void ShouldAddNewStockToRepositoryOnAddCommand()
        {
            var managerMock = new Mock<IFundManager<StockModel, StockSummaryItemModel>>();
            var stockRepoMock = new Mock<IRepository<StockModel>>();
            var summaryRepoMock = new Mock<IRepository<StockSummaryItemModel>>();

            var addStockViewModel = new AddStockViewModel(managerMock.Object, stockRepoMock.Object, summaryRepoMock.Object);
            addStockViewModel.StockModel = new StockModel() { Price = (decimal)1.22, Quantity = 1 };

            addStockViewModel.AddStockCommand.Execute(new object());

            stockRepoMock.Verify(m => m.AddItem(It.IsAny<StockModel>()), Times.Once);
        }
    }
}
