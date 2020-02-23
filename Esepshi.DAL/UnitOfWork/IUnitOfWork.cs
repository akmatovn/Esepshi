using Esepshi.DAL.GenericRepository;
using System;

namespace Esepshi.DAL.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<T> GetRepository<T>() where T : class;

        void SaveChanges();

        void Dispose(bool disposing);
    }
}
