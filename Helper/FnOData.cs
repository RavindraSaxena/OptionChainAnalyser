using FetchOptionChain.Model;
using LumenWorks.Framework.IO.Csv;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
                    .OrderBy(s=>s.Name)
                    .ToList();
        }

        public static FnOMetadata GetFnOStockInfo(string symbol)
        {
            return JsonConvert.DeserializeObject<List<FnOMetadata>>(GetFnoString())
                    .Where(s => s.Symbol == symbol)
                    .FirstOrDefault();
        }


        private static string GetFnoString()
        {
            if (FnOstringData==string.Empty)
            {
                var filename = Path.Combine(Environment.CurrentDirectory, "FnoData.json");
                FnOstringData = File.ReadAllText(filename);
            }
            return FnOstringData;
        }
    }
}
