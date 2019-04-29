using Entities;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mapping
{
    public class PurchaseMap:ClassMap<Purchase>
    {
        public PurchaseMap()
        {
            Table("Purchases");
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Amount);
            References(x => x.Player).Column("PlayerId").Not.Nullable();
            References(x => x.Card).Column("CardId").Not.Nullable();
        }
    }
}
