using System.Collections.Generic;
using System.Linq;
using Entities;
using NHibernate.Mapping;
using Repository;

namespace DomainService
{
    public class CardService:ICardService
    {
        private readonly IGenericRepository<Card> _repository;

        public CardService(IGenericRepository<Card> repository)
        {
            _repository = repository;
        }

        public bool AddCard(Card item)
        {
            return _repository.Add(item);
        }

        public bool DeleteCard(Card item)
        {
            return _repository.Delete(item);
        }

        public Card GetCard(int id)
        {
            return _repository.FindBy(id);
        }

        public List<Card> GetCardsByPlayerId(int playerId)
        {
            return _repository.FilterBy(x=>x.Player.Id==playerId).ToList<Card>();
        }
    }
}
