using Xunit;
using FundManager.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace FundManager.UI.Tests.Model
{
    public class StockSummaryItemModelTests
    {
        [Fact]
        void ShouldInvokePropertyChangedEvenet()
        {
            List<string> receivedEvents = new List<string>();
            var stockSummaryItemModel = new StockSummaryItemModel();

            stockSummaryItemModel.PropertyChanged += delegate (object sender, PropertyChangedEventArgs e)
            {
                receivedEvents.Add(e.PropertyName);
            };

            stockSummaryItemModel.TotalNumber = 1;
            stockSummaryItemModel.TotalMarketValue = (decimal)1.33;
            stockSummaryItemModel.TotalStockWeight = (decimal)1.11;

            Assert.Equal(3, receivedEvents.Count);
            Assert.Equal("TotalNumber", receivedEvents[0]);
            Assert.Equal("TotalMarketValue", receivedEvents[1]);
            Assert.Equal("TotalStockWeight", receivedEvents[2]);
        }
    }
}
