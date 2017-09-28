using System.Windows.Input;
using FundManager.UI.Command;
using FundManager.Model;
using FundManager.BusinessLogic;
using FundManager.Repository;

namespace FundManager.UI.ViewModel
{
    public class AddStockViewModel : ValidateableModelBase, IAddStockViewModel
    {
        public ICommand AddStockCommand { get; private set; }

        private IFundManager<StockModel, StockSummaryItemModel> _manager;

        private IRepository<StockModel> _stockRepository;

        private IRepository<StockSummaryItemModel> _summaryRepository;

        private StockModel _stockModel;
        public StockModel StockModel
        {
            get { return _stockModel; }
            set { SetProperty(ref _stockModel, value); }
        }

        public AddStockViewModel(
            IFundManager<StockModel,StockSummaryItemModel> manager,
            IRepository<StockModel> stockRepository, 
            IRepository<StockSummaryItemModel> summaryRepository)
        {
            AddStockCommand = new DelegateCommand(OnAddStockExecute);
            StockModel = new StockModel();
            _manager = manager;
            _stockRepository = stockRepository;
            _summaryRepository = summaryRepository;
        }

        private void OnAddStockExecute(object obj)
        {
            if (_stockModel.Price == null)
            {
                _stockModel.Price = null;
            }

            if (_stockModel.Quantity == null)
            {
                _stockModel.Quantity = null;
            }

            if (!_stockModel.HasErrors)
            {                
                _manager.DefaultNewEntry(_stockModel, _stockRepository);
                _stockRepository.AddItem(_stockModel);
                _manager.RecalculateCollection(_stockRepository);
                _manager.RecalculateSummary(_stockRepository, _summaryRepository);
            }
        }
    }
}
