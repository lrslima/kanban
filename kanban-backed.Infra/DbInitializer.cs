using System;
using System.Diagnostics;
using kanban_backed.Business.Models;

namespace kanban_backed.Infra
{
	public static class DbInitializer
	{
        public static void Initialize(ApiContext context)
        {
            if (context.Cards.Any())
            {
                return;
            }

            var cards = new Card[]
            {
                new Card(998, "card 1 teste", "lorem ipsum", "uma lista"),
                new Card(999, "card 2 teste", "algum conteudo", "uma lista 2")
            };

            context.Cards.AddRange(cards);
            context.SaveChanges();
        }
    }
}

