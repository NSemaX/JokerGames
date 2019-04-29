using System.Linq;
using Entities;
using Repository;

namespace DomainService
{
    public class PurchaseService:IPurchaseService
    {
        private readonly IGenericRepository<Purchase> _repository;

        public PurchaseService(IGenericRepository<Purchase> repository)
        {
            _repository = repository;
        }

        public bool AddPurchase(Purchase item)
        {
            return _repository.Add(item);
        }

        public bool DeletePurchase(Purchase item)
        {
            return _repository.Delete(item);
        }

        public Purchase GetPurchaseByPlayerId(int playerId)
        {
            return _repository.FilterBy(x=>x.Player.Id==playerId).FirstOrDefault();
        }
    }
}
