using FetchOptionChain.Model;
using LumenWorks.Framework.IO.Csv;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FetchOptionChain.Helper
{
    public class FnOData
    {
        private static string FnOstringData = string.Empty;
        public static List<FnOMetadata> GetFnOMetadata()
        {
            return JsonConvert.DeserializeObject<List<FnOMetadata>>(GetFnoString())
                    .OrderBy(s => s.Name)
                    .ToList();
        }

        public static void Refresh()
        {
            FnOstringData = string.Empty;
        }
        public static FnOMetadata GetFnOStockInfo(string symbol)
        {
            return JsonConvert.DeserializeObject<List<FnOMetadata>>(GetFnoString())
                    .Where(s => s.Symbol == symbol)
                    .FirstOrDefault();
        }
        private static string GetFnoString()
        {
            if (FnOstringData == string.Empty)
            {
                var filename = Path.Combine(Environment.CurrentDirectory, "FnoData.json");
                FnOstringData = File.ReadAllText(filename);
            }
            return FnOstringData;
        }

        public static List<string> GetNifty50List()
        {
            var filename = Path.Combine(Environment.CurrentDirectory, "Nifty50List.json");
            var liststring = File.ReadAllText(filename);
            return JsonConvert.DeserializeObject<List<string>>(liststring);
        }

        public static List<string> GetPreferredList()
        {
            var filename = Path.Combine(Environment.CurrentDirectory, "PreferedList.json");
            var liststring = File.ReadAllText(filename);
            return JsonConvert.DeserializeObject<List<string>>(liststring);
        }

        private static List<FnOMetadata> GenerateJsonData(DataTable table, List<string> Nifty50, List<string> PreferredList)
        {
            string[] ignore = new string[] { "SYMBOL", "BANKNIFTY", "FINNIFTY", "NIFTY", "Symbol" };
            string col = $"{DateTime.Now.ToString("MMM-yy")}";
            List<FnOMetadata> list = new List<FnOMetadata>();
            foreach(DataRow row in table.Rows)
            {
                string s = Convert.ToString(row["SYMBOL"]);
                if (!ignore.Contains(s))
                {
                    var stock = new FnOMetadata();
                    stock.Name = Convert.ToString(row["UNDERLYING"]);
                    stock.Symbol = s;
                    stock.Size = Convert.ToInt32(row[col]);
                    if (Nifty50.Contains(s))
                    {
                        stock.IsNifty50 = true;
                    }
                    if (PreferredList.Contains(s))
                    {
                        stock.IsPreferred = true;
                    }
                    list.Add(stock);
                }
            }
            return list;
        }

        private static bool SaveFnOListData(List<FnOMetadata> data)
        {
            var stringData = JsonConvert.SerializeObject(data);
            var filename = Path.Combine(Environment.CurrentDirectory, "FnoData.json");
            var backup= Path.Combine(Environment.CurrentDirectory, "FnoData_backup.json");
            if (File.Exists(filename))
            {
                if (File.Exists(backup))
                {
                    File.Delete(backup);
                }
                File.Copy(filename, backup);
                File.WriteAllText(filename, stringData);
            }
            return true;
        }



        public async static Task<bool> UpdateFnOListAsync()
        {
            try
            {
                var result = await HttpHelper.DownloadCSV(UrlHelper.FnOSecuritiesOnNSE);
                var list50 = GetNifty50List();
                var prefered = GetPreferredList();
                DataTable table = CSVHelper.GetDataTableFromCSV(result);
                var result1 = GenerateJsonData(table, list50, prefered);
                SaveFnOListData(result1);
                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
