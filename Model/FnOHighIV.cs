using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FetchOptionChain.Model
{
    public class FnOHighIV
    {
        public string Symbol { get; set; }
        public double LTP { get; set; }
        public string Option { get; set; }
        public double Strike { get; set; }
        public double IV { get; set; }
        public double Option_LTP { get; set; }
        public double OI { get; set; }
        public double Bid { get; set; }
        public double Ask { get; set; }
        public int Volume { get; set; }

        public int LotSize { get; set; }
        public double TotalLotCost { get; set; }
        public double TotalPremium { get; set; }
        public double StrikeTotalLotCost { get; set; }
    }
}
