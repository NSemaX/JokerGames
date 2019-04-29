using System;
using System.Collections.Generic;

namespace Entities
{
    public class Player
    {
        public Player()
        {
           // Cards = new HashSet<Card>();
        }
        public virtual int Id { get; set; }
        public virtual string Username { get; set; }
        //public virtual ISet<Card> Cards { get; set; }

    }
}
