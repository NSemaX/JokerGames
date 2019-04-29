using Entities;
using NHibernate.Mapping;
using Repository;
using System.Collections.Generic;
using System.Linq;

namespace DomainService
{
    public class PlayerService: IPlayerService
    {
        private readonly IGenericRepository<Player> _repository;

        public PlayerService(IGenericRepository<Player> repository)
        {
            _repository = repository;
        }

        public bool AddPlayer(Player item)
        {
            return _repository.Add(item);
        }

        public bool DeletePlayer(Player item)
        {
            return _repository.Delete(item);
        }

        public List<Player> GetPlayers()
        {
            return _repository.All().ToList();
        }

        public Player GetPlayer(int id)
        {
            return _repository.FindBy(id);
        }
    }
}
