using System;
using System.Collections;
using FSMChildVersion.Repository.EntityFramework.Database;
using FSMChildVersion.Repository.EntityFramework.GenericHandler;

namespace FSMChildVersion.Repository.EntityFramework.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public SFMDatabaseContext Context { get; set; }
        private bool disposed = false;
        public UnitOfWork(SFMDatabaseContext context)
        {
            Context = context;
        }
        private Hashtable _repositories;
        public IGenericHandler<T> GenericHandler<T>() where T : class
        {
            if (_repositories == null)
                _repositories = new Hashtable();

            var type = typeof(T).Name;

            if (!_repositories.ContainsKey(type))
            {
                Type repositoryType = typeof(GenericHandler<>);

                var repositoryInstance =
                    Activator.CreateInstance(repositoryType
                            .MakeGenericType(typeof(T)), Context);

                _repositories.Add(type, repositoryInstance);
            }

            return (IGenericHandler<T>)_repositories[type];
        }
        public dynamic Save()
        {
            try
            {
                Context.SaveChanges();
                return "data has been saved in db";
            }

            catch (Exception)
            {
                return "exce3ption occurred in unit of work";
            }
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
