using Entities;
using System;
using FluentNHibernate.Mapping;

namespace Mapping
{
    public class PlayerMap :ClassMap<Player>
    {
        public PlayerMap()
        {
            Table("Players");
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Username).Length(50).Not.Nullable();
            //HasMany(x => x.Cards).Cascade.All().KeyColumn("CardId");
        }
    }
}
