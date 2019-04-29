using Entities;
using System.Collections.Generic;

namespace DomainService
{
    public interface ICardService
    {
        bool AddCard (Card item);
        bool DeleteCard(Card item);
        Card GetCard(int id);
        List<Card> GetCardsByPlayerId(int playerId);
    }
}
