using System;
using System.ComponentModel.DataAnnotations;
using kanban_backed.Business.Models;

namespace kanban_backend.DTOs
{
	public class CardDTO
	{
        public int Id { get; set; }

        [Required]
        public string Titulo { get; set; }

        [Required]
        public string Conteudo { get; set; }

        [Required]
        public string Lista { get; set; }

        public Card MapFromDto(CardDTO dto)
        {
            var model = new Card(dto.Id, dto.Titulo, dto.Conteudo, dto.Lista);

            return model;
        }
    }
}

