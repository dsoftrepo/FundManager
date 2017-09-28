using System.Collections.ObjectModel;
using FundManager.Model;
using FundManager.Repository;

namespace FundManager.UI.ViewModel
{
    public class StockListViewModel : ValidateableModelBase, IStockListViewModel
    {
        public StockListViewModel(IRepository<StockModel> stockRepository)
        {
            StockList = stockRepository.Collection;
        }
        public ObservableCollection<StockModel> StockList { get; private set; }
    }
}
