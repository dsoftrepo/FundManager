using System.Collections.ObjectModel;
using System.Linq;

namespace FundManager.Repository
{
    public interface IRepository<T> 
    {
        ObservableCollection<T> Collection { get; set; }

        IQueryable<T> GetItems();
        void AddItem(T item);
    }
}
