using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FetchOptionChain.Model
{
    public class DeliveryReport
    {
        public string Name { get; set; }
        public  string Symbol{ get; set; }
        public bool IsFNO { get; set; }
        public bool IsNifty50 { get; set; }
        public decimal PrevClosePrice { get; set; }
        public decimal ClosePrice { get; set; }
        public decimal ChangePercent { get; set; }
        public decimal DeliveryPercent { get; set; }
    }
}
