using Contract;
using Entities;
using System;

namespace Mapper
{
    public static class PlayerMapper
    {
        public static Player ToEntity(this PlayerModel request)
        {
            var s = new Player();

            s.Username = request.Username;
            
            return s;
        }
    }
}
