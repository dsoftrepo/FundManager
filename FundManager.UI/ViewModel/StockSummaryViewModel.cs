using System.Collections.Generic;
using FundManager.Model;
using System.Collections.ObjectModel;
using FundManager.Repository;

namespace FundManager.UI.ViewModel
{
    public class StockSummaryViewModel : IStockSummaryViewModel
    {
        public StockSummaryViewModel(IRepository<StockSummaryItemModel> summaryRepository)
        {
            StockSummaryList = summaryRepository.Collection;
        }
        public ObservableCollection<StockSummaryItemModel> StockSummaryList { get; private set; }
    }
}
