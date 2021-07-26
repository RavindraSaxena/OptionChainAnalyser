using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FetchOptionChain.Model
{
    public class FnOSupportResistance
    {
        public string Symbol { get; set; }
        public double LTP { get; set; }
        public double Resistance1 { get; set; }
        public double Resistance2 { get; set; }
        public double Resistance3 { get; set; }

        public double Support1 { get; set; }
        public double Support2 { get; set; }
        public double Support3 { get; set; }

    }
}
