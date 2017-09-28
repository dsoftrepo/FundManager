using FundManager.Repository;
using FundManager.Model;
using FundManager.BusinessLogic;

namespace FundManager.UI.ViewModel
{
    public class MainWindowViewModel
    {        
        public AddStockViewModel AddStockViewModel { get; private set; }
        public StockListViewModel StockListViewModel { get; private set; }
        public StockSummaryViewModel StockSummaryViewModel { get; private set; }

        public MainWindowViewModel(
            IRepository<StockModel> stockRepository, 
            IRepository<StockSummaryItemModel> stockSummaryRepository, 
            IFundManager<StockModel, StockSummaryItemModel> manager)
        {
            AddStockViewModel = new AddStockViewModel(manager, stockRepository, stockSummaryRepository);
            StockListViewModel = new StockListViewModel(stockRepository);
            StockSummaryViewModel = new StockSummaryViewModel(stockSummaryRepository);
        }
    }
}
