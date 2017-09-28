using Autofac;
using FundManager.UI;
using FundManager.UI.Startup;
using System;
using System.Threading;
using Xunit;

namespace FundManager.Tests.UI
{
    public class MainWindowViewModelTests
    {     
        [Fact]
        public void ShouldCorrectlyResolveAllDependencies()
        {
            Exception exception = null;
            var thread = new Thread(()=>StartMainWindow(()=>Test(), out exception));

            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            thread.Join();

            Assert.True(exception==null, exception?.Message);
        }

        private void StartMainWindow(Action test, out Exception exception)
        {
            exception = null;

            try
            {
                test.Invoke();   
            }
            catch(Exception ex)
            {
                exception = ex;
            }
        }

        private void Test()
        {
            var dependencies = new Dependencies();
            var container = dependencies.BuildContainer();
            var mainWindow = container.Resolve<MainWindow>();
        }
    }
}
