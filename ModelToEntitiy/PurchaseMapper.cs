using Contract;

namespace Mapper
{
    public static class PurchaseMapper
    {
        public static Entities.Purchase ToEntity(this PurchaseModel request)
        {
            var s = new Entities.Purchase();

            s.Amount = request.Amount;

            return s;
        }
    }
}
