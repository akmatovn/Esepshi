using Esepshi.DAL.GenericRepository;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Concurrent;
using System.Data;

namespace Esepshi.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private IDbTransaction _transaction;
        private IDbConnection _connection;
        private readonly ConcurrentDictionary<Type, object> _repositories;
        private bool _disposed;

        public UnitOfWork(string connectionString)
        {
            _connection = new SqlConnection(connectionString);
            _connection.Open();
            _transaction = _connection.BeginTransaction();
            _repositories = new ConcurrentDictionary<Type, object>();
            _disposed = false;
        }

        public IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            return _repositories.GetOrAdd(typeof(TEntity),
                x => new GenericRepository<TEntity>(_transaction)) as IGenericRepository<TEntity>;
        }

        public void SaveChanges()
        {
            try
            {
                _transaction.Commit();
            }
            catch
            {
                _transaction.Rollback();
            }
            finally
            {
                _transaction.Dispose();
                _transaction = _connection.BeginTransaction();
            }
        }

        public void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (_transaction != null)
                    {
                        _transaction.Dispose();
                        _transaction = null;
                    }
                    if (_connection != null)
                    {
                        _connection.Dispose();
                        _connection = null;
                    }
                }
                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
