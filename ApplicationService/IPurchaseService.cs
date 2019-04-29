using Entities;

namespace DomainService
{
    public interface IPurchaseService
    {
        bool AddPurchase(Purchase item);
        bool DeletePurchase(Purchase item);
        Purchase GetPurchaseByPlayerId(int playerId);
    }
}