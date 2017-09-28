
using FundManager.Repository;

namespace FundManager.BusinessLogic
{
    public interface IFundManager<T, S>
    {
        void DefaultNewEntry(T model, IRepository<T> repository);
        void RecalculateCollection(IRepository<T> repositoryT);
        void RecalculateSummary(IRepository<T> repositoryT, IRepository<S> epositoryS);
    }
}