using System;
using System.Reflection;
using kanban_backed.Bs.Interfaces;
using kanban_backed.Business.Interfaces;
using kanban_backed.Business.Models;

namespace kanban_backed.Business.Services
{
	public class CardService : ICardService
	{
        private readonly ICardRepository _cardRepository;
        private readonly IUnitOfWork _unitOfWork;

		public CardService(ICardRepository cardRepository, IUnitOfWork unitOfWork)
		{
            _cardRepository = cardRepository;
            _unitOfWork = unitOfWork;
        }

        public bool Delete(Card card)
        {
            _unitOfWork.Cards.Remove(card);
            _unitOfWork.Save();
            return true;
        }

        public IEnumerable<Card> GetAll()
        {
            var cards = _unitOfWork.Cards.GetAll();
            cards = cards.OrderBy(x => x.Id);
            return cards;
        }

        public Card GetById(int id)
        {
            return _cardRepository.GetById(id);
        }

        public Card Insert(Card model)
        {
            _unitOfWork.Cards.Add(model);
            _unitOfWork.Save();
            return model;
        }

        public Card Update(Card model)
        {
            _unitOfWork.Cards.Update(model);
            _unitOfWork.Save();
            return model;
        }
    }
}

