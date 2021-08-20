using FetchOptionChain.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FetchOptionChain.Helper
{
    public class ReportHelper
    {
        private static decimal DeliveryThreshold = 25;
        public async static Task<List<DeliveryReport>> GetDeliveryReportAsync()
        {
            var response = new List<DeliveryReport>();
            var url = $"{UrlHelper.BhavCopyUrl}{DateTime.Now.AddDays(-1).ToString("ddMMyyyy")}.csv";
            string result;
            try
            {
                result = await HttpHelper.DownloadCSV(url);
            }
            catch(Exception ex)
            {
                throw new Exception($"Bhavcopy not found on NSE for {DateTime.Now.ToString("ddMMyyyy")}.");
            }
            var list50 = FnOData.GetNifty50List();
            var fnolist = FnOData.GetFnOMetadata();
            DataTable table = CSVHelper.GetDataTableFromCSV(result);
            if (table!=null && table.Rows.Count>0)
            {
                //DataView dv = new DataView(table);
                //dv.RowFilter = "SERIES='EQ'";
                var rows = table.Select("SERIES='EQ'");
                foreach(var row in rows)
                {
                    decimal deliverypct = Convert.ToDecimal(row["DELIV_PER"]);
                    string symbol = Convert.ToString(row["SYMBOL"]);
                    if (deliverypct >= DeliveryThreshold &&
                        fnolist.Any(s => s.Symbol == symbol))
                    {
                        var d = new DeliveryReport();
                        
                        decimal close = Convert.ToDecimal(row["CLOSE_PRICE"]);
                        decimal prevclose = Convert.ToDecimal(row["PREV_CLOSE"]);
                        d.Symbol = symbol;
                        d.ClosePrice = close;
                        d.PrevClosePrice = prevclose;
                        d.ChangePercent = ((close - prevclose) / prevclose)*100;
                        d.DeliveryPercent = deliverypct;
                        if (list50.Contains(symbol))
                        {
                            d.IsNifty50 = true;
                        }
                        if (fnolist.Any(s => s.Symbol == symbol))
                        {
                            d.IsFNO = true;
                        }
                        response.Add(d);
                    }
                }
            }
            return response;
        }
    }
}
