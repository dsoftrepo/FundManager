using System.ComponentModel.DataAnnotations;

namespace FundManager.Model
{
    public class StockModel : ValidateableModelBase
    {
        [Required]
        public StockType Type { get; set; }
        public string Name { get; set; }

        private decimal? _price;
        [Required]
        public decimal? Price
        {
            get { return _price; }
            set
            {
                SetProperty(ref _price, value);
            }
        }

        private int? quantity;
        [Required]
        public int? Quantity
        {
            get { return quantity; }
            set
            {
                SetProperty(ref quantity, value);
            }
        }
        public decimal MarketValue { get; set; }
        public decimal TransactionCost { get; set; }

        private decimal stockWeight;
        public decimal StockWeight
        {
            get { return stockWeight; }
            set
            {
                SetProperty(ref stockWeight, value);
            }
        }
    }
}
