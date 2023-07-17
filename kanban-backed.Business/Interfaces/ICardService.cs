using System;
using kanban_backed.Business.Models;

namespace kanban_backed.Business.Interfaces
{
	public interface ICardService
	{
		public IEnumerable<Card> GetAll();
		public Card Insert(Card model);
		public Card GetById(int id);
		public Card Update(Card card);
		public bool Delete(Card card);
	}
}

