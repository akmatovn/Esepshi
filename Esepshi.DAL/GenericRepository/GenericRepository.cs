using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Esepshi.DAL.GenericRepository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private IDbTransaction _transaction;
        private IDbConnection Connection => _transaction.Connection;
        public GenericRepository(IDbTransaction transaction)
        {
            _transaction = transaction;
        }
        public virtual int Add(TEntity entity, string into, string values)
        {
            return Connection.Execute(
                $"insert into {typeof(TEntity).Name}({into}) values({values})",
                param: entity,
                transaction: _transaction);
        }

        public IEnumerable<TEntity> All()
        {
            return Connection.Query<TEntity>(
                $"select * from {typeof(TEntity).Name}",
                transaction: _transaction)
                .AsList();
        }

        public virtual int RemoveById(int id)
        {
            return Connection.Execute(
                $"delete from {typeof(TEntity).Name} where Id = @Id",
                param: new { Id = id },
                transaction: _transaction);
        }

        public virtual int RemoveByIin(string iin)
        {
            return Connection.Execute(
                $"delete from {typeof(TEntity).Name} where Iin = @Iin",
                param: new { Iin = iin },
                transaction: _transaction);
        }

        public virtual int Update(TEntity entity, string set)
        {
            return Connection.Execute(
                $"update {typeof(TEntity).Name} set {set} where Id = @Id",
                param: entity,
                transaction: _transaction);
        }

        public TEntity FindById(int id)
        {
            return Connection.Query<TEntity>(
                $"select * from {typeof(TEntity).Name} where Id = @Id",
                param: new { Id = id },
                transaction: _transaction)
                .FirstOrDefault();
        }

        public TEntity FindByIin(string iin)
        {
            return Connection.Query<TEntity>(
                $"select * from {typeof(TEntity).Name} where Iin = @Iin",
                param: new { Iin = iin },
                transaction: _transaction)
                .FirstOrDefault();
        }
    }
}
