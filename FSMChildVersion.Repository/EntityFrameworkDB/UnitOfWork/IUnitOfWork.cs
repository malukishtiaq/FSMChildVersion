using FSMChildVersion.Repository.EntityFramework.Database;
using FSMChildVersion.Repository.EntityFramework.GenericHandler;

namespace FSMChildVersion.Repository.EntityFramework.UnitOfWork
{
    public interface IUnitOfWork
    {
        SFMDatabaseContext Context { get; set; }
        IGenericHandler<T> GenericHandler<T>() where T : class;
        object Save();
        void Dispose();

    }
}
