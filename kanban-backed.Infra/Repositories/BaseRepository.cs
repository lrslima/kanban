using System;
using kanban_backed.Business.Interfaces;

namespace kanban_backed.Infra.Repositories
{
	public class BaseRepository<T> : IBaseRepository<T> where T: class
	{
        protected readonly ApiContext context;

		public BaseRepository(ApiContext context)
		{
            this.context = context;
		}

        public void Add(T entity)
        {
            context.Set<T>().Add(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
             return context.Set<T>().Find(id);
        }

        public void Remove(T entity)
        {
            context.Set<T>().Remove(entity);
        }

        public void Update(T entity)
        {
            context.Set<T>().Update(entity);
        }
    }
}

