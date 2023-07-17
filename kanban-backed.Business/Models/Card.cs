using System;
namespace kanban_backed.Business.Models
{
	public class Card
	{
        public Card(int id, string titulo, string conteudo, string lista)
        {
            Id = id;
            Titulo = titulo;
            Conteudo = conteudo;
            Lista = lista;
        }

        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Conteudo { get; set; }
        public string Lista { get; set; }
	}
}

