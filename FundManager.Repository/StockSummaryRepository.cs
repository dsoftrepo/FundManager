using System;
using FundManager.Model;
using System.Linq;
using System.Collections.ObjectModel;

namespace FundManager.Repository
{
    public class StockSummaryRepository : IRepository<StockSummaryItemModel>
    {
        private ObservableCollection<StockSummaryItemModel> _stockSummaryCollection;

        public StockSummaryRepository()
        {
            _stockSummaryCollection = new ObservableCollection<StockSummaryItemModel>();
        }

        public ObservableCollection<StockSummaryItemModel> Collection
        {
            get { return _stockSummaryCollection; }
            set { _stockSummaryCollection = value; }
        }

        public void AddItem(StockSummaryItemModel item)
        {
            _stockSummaryCollection.Add(item);
        }

        public IQueryable<StockSummaryItemModel> GetItems()
        {
            return _stockSummaryCollection.AsQueryable();
        }
    }
}
