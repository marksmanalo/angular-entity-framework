using System.Collections.Generic;

namespace PG1Products.BLL.Repositories
{
    public interface IRepository <T>
    {
        T GetById(int id);
        IEnumerable<T> GetAll();
        void Add(T t);
        void Remove(int id);
        void Update(T t);
        void Save(T t);
    }
}
