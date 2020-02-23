using System.Collections.Generic;

namespace Esepshi.DAL.GenericRepository
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> All();
        T FindById(int id);
        T FindByIin(string iin);
        int Add(T entity, string into, string values);
        int Update(T entity, string set);
        int RemoveById(int id);
        int RemoveByIin(string iin);
    }
}
