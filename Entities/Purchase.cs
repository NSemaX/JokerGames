using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public  class Purchase
    {
        public virtual int Id { get; set; }
        public virtual decimal Amount { get; set; }
        public virtual Card Card { get; set; }
        public virtual Player Player { get; set; }
    }
}
