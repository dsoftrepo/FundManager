using FundManager.Model;
using System.Linq;
using System.Collections.ObjectModel;

namespace FundManager.Repository
{
    public class StockRepository : IRepository<StockModel>
    {
        private ObservableCollection<StockModel> _stockCollection;

        public StockRepository()
        {
            _stockCollection = new ObservableCollection<StockModel>();
        }

        public ObservableCollection<StockModel> Collection
        {
            get { return _stockCollection; }
            set { _stockCollection = value; }
        }

        public void AddItem(StockModel item)
        {
            _stockCollection.Add(new StockModel()
            {
                Name = item.Name,
                Price = item.Price,
                Quantity = item.Quantity,
                Type = item.Type,
                MarketValue = item.MarketValue,
                StockWeight = item.StockWeight,
                TransactionCost = item.TransactionCost
            });
        }

        public IQueryable<StockModel> GetItems()
        {
            return _stockCollection.AsQueryable();
        }
    }
}
