using Contract;

namespace Mapper
{
    public static class CardMapper
    {
        public static Entities.Card ToEntity(this CardModel request)
        {
            var s = new Entities.Card();

            s.Number = request.CardNumber;

            return s;
        }
    }
}
