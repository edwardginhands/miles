using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Miles.Repo
{
    public interface IRepo<T> : IDisposable where T : class
    {
        void Add(T entity);
        IEnumerable<T> All();
        T Single(int Id);
        void Update(T entity);
        void Delete(int Id);
    }
}
