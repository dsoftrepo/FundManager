namespace FundManager.Model
{
    public class StockSummaryItemModel : ModelBase
    {
        public string Type { get; set; }

        private int totalNumber;
        public int TotalNumber
        {
            get { return totalNumber; }
            set { SetProperty(ref totalNumber, value); }
        }

        private decimal totalMarketValue;
        public decimal TotalMarketValue
        {
            get { return totalMarketValue; }
            set { SetProperty(ref totalMarketValue, value); }
        }

        private decimal totalStockWeight;
        public decimal TotalStockWeight
        {
            get { return totalStockWeight; }
            set { SetProperty(ref totalStockWeight, value); }
        }
    }
}
