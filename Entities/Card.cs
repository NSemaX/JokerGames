using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Card
    {
        public virtual int Id { get; set; }
        public virtual string Number { get; set; }
        public virtual Player Player { get; set; }
    }
}
