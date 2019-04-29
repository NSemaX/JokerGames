using System;
using System.Collections.Generic;
using System.Text;

namespace Contract
{
    public class PurchaseModel
    {
        public decimal Amount { get; set; }
        public List<DDLCategory> PlayerList { get; set; }
        public int Selected_PlayerId { get; set; }
        public List<DDLCategory> CardList { get; set; }
        public int Selected_CardId { get; set; }
    }
}
