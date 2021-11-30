using JG_Domain.Entities.NotMapped;
using System.Collections.Generic;

namespace JG_Domain.Interface
{
    public interface IGeneric<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        T Get(long id);
        IEnumerable<T> List(GenericFilter filter);
    }
}
