using Entities;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mapping
{
    public class CardMap : ClassMap<Card>
    {
        public CardMap()
        {
            Table("Cards");
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Number);
            References(x => x.Player).Column("PlayerId").Not.Nullable();
        }
    }
}
