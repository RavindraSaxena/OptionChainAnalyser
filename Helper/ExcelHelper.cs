using FetchOptionChain.Model;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FetchOptionChain.Helper
{
    public class ExcelHelper
    {
        public static bool GenerateExcelsheet(string expiry, List<FnOSupportResistance> data)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (ExcelPackage excel = new ExcelPackage())
            {
               
                excel.Workbook.Worksheets.Add(expiry);

                // Target a worksheet
                var worksheet = excel.Workbook.Worksheets[expiry];

                //var objects = ConvertToObjectArray(data);

                //worksheet.Cells[2, 1].LoadFromArrays(objects);
                int count = 2;
                foreach(var d in data)
                {
                    worksheet.Cells[count, 1].Value = d.Symbol;
                    worksheet.Cells[count, 2].Value = d.LTP;
                    worksheet.Cells[count, 3].Value = d.Resistance1;
                    worksheet.Cells[count, 4].Value = d.Support1;
                    worksheet.Cells[count, 5].Value = d.Resistance2;
                    worksheet.Cells[count, 6].Value = d.Support2;
                    worksheet.Cells[count, 7].Value = d.Resistance3;
                    worksheet.Cells[count, 8].Value = d.Support3;
                    count++;
                }

                FileInfo excelFile = new FileInfo(@"C:\\test.xlsx");
                excel.SaveAs(excelFile);
            }

            return false;
        }

        public static string GenerateExcelsheet(string expiry, List<FnOHighIV> data)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (ExcelPackage excel = new ExcelPackage())
            {
                var expiryDate = Convert.ToDateTime(expiry);

                excel.Workbook.Worksheets.Add(expiry);

                // Target a worksheet
                var worksheet = excel.Workbook.Worksheets[expiry];

                //var objects = ConvertToObjectArray(data);
                int count = 1;
                worksheet.Cells[count, 1].Value = "Symbol";
                worksheet.Cells[count, 2].Value = "LTP";
                worksheet.Cells[count, 3].Value = "Strike";
                worksheet.Cells[count, 4].Value = "Option";
                worksheet.Cells[count, 5].Value = "Option_LTP";
                worksheet.Cells[count, 6].Value = "IV";
                worksheet.Cells[count, 7].Value = "OI";
                worksheet.Cells[count, 8].Value = "Bid";
                worksheet.Cells[count, 9].Value = "Ask";
                worksheet.Cells[count, 10].Value = "Volume";
                worksheet.Cells[count, 11].Value = "LotSize";
                worksheet.Cells[count, 12].Value = "TotalLotCost";
                worksheet.Cells[count, 13].Value = "StrikeLotCost";
                worksheet.Cells[count, 14].Value = "TotalPremium";
                worksheet.Cells[count, 15].Value = "Tradingview Link";
                worksheet.Cells[count, 16].Value = "Sensibull Option";


                //worksheet.Cells[2, 1].LoadFromArrays(objects);
                count = 2;
                foreach (var d in data)
                {
                    worksheet.Cells[count, 1].Value = d.Symbol;
                    worksheet.Cells[count, 2].Value = d.LTP;
                    worksheet.Cells[count, 3].Value = d.Strike;
                    worksheet.Cells[count, 4].Value = d.Option;
                    worksheet.Cells[count, 5].Value = d.Option_LTP;
                    worksheet.Cells[count, 6].Value = d.IV;
                    worksheet.Cells[count, 7].Value = d.OI;
                    worksheet.Cells[count, 8].Value = d.Bid;
                    worksheet.Cells[count, 9].Value = d.Ask;
                    worksheet.Cells[count, 10].Value = d.Volume;
                    worksheet.Cells[count, 11].Value = d.LotSize;
                    worksheet.Cells[count, 12].Value = d.TotalLotCost;
                    worksheet.Cells[count, 13].Value = d.StrikeTotalLotCost;
                    worksheet.Cells[count, 14].Value = d.TotalPremium;
                    worksheet.Cells[count, 15].Value = $"{d.Symbol}-Chart";
                    worksheet.Cells[count, 15].Hyperlink = new Uri($"https://www.tradingview.com/chart/?symbol=NSE:{d.Symbol}");
                    worksheet.Cells[count, 15].Style.Font.Color.SetColor(Color.Blue);

                    worksheet.Cells[count, 16].Value = $"{d.Symbol}-Option Chain";
                    worksheet.Cells[count, 16].Hyperlink = new Uri($"https://web.sensibull.com/option-chain?expiry={expiryDate.ToString("yyyy-MM-dd")}&tradingsymbol={d.Symbol}");
                    worksheet.Cells[count, 16].Style.Font.Color.SetColor(Color.Blue);

                    count++;
                }

                string filename = string.Format("C:\\IVReports\\OptionIVReport_{0}.xlsx", DateTime.Now.ToString("ddMMyyyy_HHmm"));
                FileInfo excelFile = new FileInfo(filename);
                excel.SaveAs(excelFile);
                return filename;
            }

            return string.Empty;
        }
        //private static object[] ConvertToObjectArray(List<FnOSupportResistance> data)
        //{
        //    List<List<object>> o = new List<List<object>>();
        //    foreach(var d in data)
        //    {
        //        o = new object[] {
        //            d.Symbol,
        //            d.LTP,
        //            d.Resistance1,
        //            d.Support1
        //        };
        //    }
        //    return o;
        //}
    }
}
