using System;
using System.Linq.Expressions;

namespace kanban_backed.Business.Interfaces
{
	public interface IBaseRepository<T> where T: class
	{
        T GetById(int id);
        IEnumerable<T> GetAll();
        void Add(T entity);
        void Remove(T entity);
        void Update(T entity);
    }
}

