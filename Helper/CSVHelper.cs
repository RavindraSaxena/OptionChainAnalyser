using LumenWorks.Framework.IO.Csv;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FetchOptionChain.Helper
{
    public class CSVHelper
    {
        public static DataTable GetDataTableFromCSV(string data)
        {
            StreamReader reader = new StreamReader(GenerateStreamFromString(data));
            var table = new DataTable();
            using (var csvReader = new CsvReader(reader, true))
            {
                table.Load(csvReader);
            }
            return table;
        }

        private static Stream GenerateStreamFromString(string data)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(data);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }
    }
}
