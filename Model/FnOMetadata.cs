using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FetchOptionChain.Model
{
    public class FnOMetadata
    {
        public string Name { get; set; }
        public string Symbol { get; set; }
        public int Size { get; set; }

        public bool IsPreferred { get; set; }
        public bool IsNifty50 { get; set; }
    }
}
