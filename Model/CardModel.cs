using System;
using System.Collections.Generic;
using System.Text;

namespace Contract
{
    public class CardModel
    {
        public string CardNumber { get; set; }
        public List<DDLCategory> PlayerList { get; set; }
        public int Selected_PlayerId { get; set; }
    }
}
