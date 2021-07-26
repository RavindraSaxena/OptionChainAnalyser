using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FetchOptionChain.Model
{
    public class StockInfo
    {
        public double LTP { get; set; }
        public int? LotSize { get; set; }
        public double CurrentValue { get; set; }

        public double AvgIV { get; set; }
        public double LowerRange { get; set; }
        public double UpperRange { get; set; }
    }
}
