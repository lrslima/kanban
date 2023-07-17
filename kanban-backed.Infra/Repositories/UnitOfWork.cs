using System;
using kanban_backed.Bs.Interfaces;
using kanban_backed.Business.Interfaces;

namespace kanban_backed.Infra.Repositories
{
	public class UnitOfWork : IUnitOfWork
    {
		private ApiContext context;

        public UnitOfWork(ApiContext context)
        {
            this.context = context;
            Cards = new CardRepository(this.context);
        }
        public ICardRepository Cards
        {
            get;
            private set;
        }

        public void Dispose()
        {
            context.Dispose();
        }
        public int Save()
        {
            return context.SaveChanges();
        }
    }
}

