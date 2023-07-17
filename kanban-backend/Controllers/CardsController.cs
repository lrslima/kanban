using System;
using kanban_backed.Business.Interfaces;
using kanban_backend.DTOs;
using kanban_backend.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace kanban_backend.Controllers
{
	[AuthorizeAttribute]
    [ApiController]
    [Route("[controller]")]
    public class CardsController : ControllerBase
	{
        private readonly ICardService _cardService;
        private readonly ILogger _logger;

        public CardsController(ICardService cardService, ILogger<CardsController> logger)
		{
            _cardService = cardService;
            _logger = logger;
		}

        [HttpGet]
        public IActionResult Get()  
        {
            var cards = _cardService.GetAll();

            return Ok(cards);
        }

        [HttpPost]
        public IActionResult Post([FromBody] CardDTO card)
        {
            var model = card.MapFromDto(card);
            var inserted = _cardService.Insert(model);

            return Ok(inserted);
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] CardDTO card)
        {
            var model = _cardService.GetById(id);

            if(model != null)
            {
                card.Id = model.Id;
                var updated = card.MapFromDto(card);
                var inserted = _cardService.Update(updated);

                _logger.LogInformation($"{DateTime.Now.ToShortDateString()} - Card {id} - {model.Titulo} - Alterado");

                return Ok(inserted);
            }

            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var model = _cardService.GetById(id);

            if (model != null)
            {
                var inserted = _cardService.Delete(model);
                _logger.LogInformation($"{DateTime.Now.ToShortDateString()} - Card {id} - {model.Titulo} - Removido");
                return Ok(_cardService.GetAll());
            }

            return NotFound();
        }
    }
}

