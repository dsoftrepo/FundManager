using Xunit;
using FundManager.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace FundManager.UI.Tests.Model
{
    public class StockModelTests
    {
        [Fact]
        void ShouldInvokePropertyChangedEvenet()
        {
            List<string> receivedEvents = new List<string>();
            var stockModel = new StockModel();

            stockModel.PropertyChanged += delegate (object sender, PropertyChangedEventArgs e)
            {
                receivedEvents.Add(e.PropertyName);
            };

            stockModel.Price = Convert.ToDecimal(1.11);
            stockModel.Quantity = 1;
            stockModel.StockWeight = Convert.ToDecimal(1.11);

            Assert.Equal(3, receivedEvents.Count);
            Assert.Equal("Price", receivedEvents[0]);
            Assert.Equal("Quantity", receivedEvents[1]);
            Assert.Equal("StockWeight", receivedEvents[2]);
        }

        [Fact]
        void ShouldInvokeErrorsChangedEvent()
        {
            List<string> receivedEvents = new List<string>();
            var stockModel = new StockModel();

            stockModel.ErrorsChanged += delegate (object sender, DataErrorsChangedEventArgs e)
            {
                receivedEvents.Add(e.PropertyName);
            };

            stockModel.Price = Convert.ToDecimal(1.11);
            stockModel.Quantity = 1;

            Assert.Equal(2, receivedEvents.Count);
            Assert.Equal("Price", receivedEvents[0]);
            Assert.Equal("Quantity", receivedEvents[1]);
        }

        [Fact]
        public void ShouldSetValidationErrorWhenPriceSetNull()
        {
            var stockModel = new StockModel() { Quantity = 1 };

            stockModel.Price = null;

            Assert.Equal(stockModel.HasErrors, true);
        }

        [Fact]
        public void ShouldSetValidationErrorWhenQtySetNull()
        {
            var stockModel = new StockModel() { Price = Convert.ToDecimal(1.11) };

            stockModel.Quantity = null;

            Assert.Equal(stockModel.HasErrors, true);
        }

        [Fact]
        public void ShouldSetValidationErrorWhenQtyAndPriceSetNull()
        {
            var stockModel = new StockModel();

            stockModel.Quantity = null;
            stockModel.Price = null;

            Assert.Equal(stockModel.HasErrors, true);
        }

        [Fact]
        public void ShouldClearValidationErrorWhenQtyAndPriceSetNotNull()
        {
            var stockModel = new StockModel();

            stockModel.Quantity = null;
            stockModel.Price = null;

            Assert.Equal(stockModel.HasErrors, true);

            stockModel.Quantity = 1;
            stockModel.Price = Convert.ToDecimal(1.11);

            Assert.Equal(stockModel.HasErrors, false);
        }
    }
}
