using System;
using kanban_backed.Bs.Interfaces;
using kanban_backed.Business.Models;

namespace kanban_backed.Infra.Repositories
{
	public class CardRepository : BaseRepository<Card>, ICardRepository
	{
        public CardRepository(ApiContext context) : base(context) { }
    }
}

