using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainService
{
    public interface IPlayerService
    {
        bool AddPlayer(Player item);
        bool DeletePlayer(Player item);
        List<Player> GetPlayers();
        Player GetPlayer(int id);
    }
}
