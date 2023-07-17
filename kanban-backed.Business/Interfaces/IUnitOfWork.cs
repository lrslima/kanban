using kanban_backed.Bs.Interfaces;

namespace kanban_backed.Business.Interfaces
{
	public interface IUnitOfWork : IDisposable
	{
		ICardRepository Cards { get; }
		int Save();
	}
}

