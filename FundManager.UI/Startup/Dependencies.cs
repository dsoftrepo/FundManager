using Autofac;
using FundManager.UI.ViewModel;
using FundManager.Repository;
using FundManager.Model;
using FundManager.BusinessLogic;
using System.Collections.ObjectModel;

namespace FundManager.UI.Startup
{
    public class Dependencies
    {
        public IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<MainWindow>().AsSelf();
            builder.RegisterType<MainWindowViewModel>().AsSelf();

            builder.RegisterType<AddStockViewModel>().As<IAddStockViewModel>();
            builder.RegisterType<StockListViewModel>().As<IStockListViewModel>();
            builder.RegisterType<StockSummaryViewModel>().As<IStockSummaryViewModel>();

            builder.RegisterType<BusinessLogic.FundManager>().As<IFundManager<StockModel, StockSummaryItemModel>>();

            builder.RegisterType<StockRepository>().As<IRepository<StockModel>>();
            builder.RegisterType<StockSummaryRepository>().As<IRepository<StockSummaryItemModel>>();

            builder.RegisterType<ObservableCollection<StockSummaryItemModel>>().AsSelf();
            builder.RegisterType<ObservableCollection<StockModel>>().AsSelf();


            return builder.Build();
        }
    }
}
