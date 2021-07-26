using FetchOptionChain.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FetchOptionChain.Helper
{
    public static class OptionChainHelper
    {
        public static string GetNSEOptionChainUrl(string symbol)
        {
            return $"https://www.nseindia.com/api/option-chain-equities?symbol={symbol}";
        }

        public async static Task<Tuple<StockInfo,DataTable>> GetOptionChain(string symbol, string expiry)
        {
            var url = GetNSEOptionChainUrl(symbol);
            var optiondatastring = await HttpHelper.GetNSEResult(url);
            var optiondata = JsonConvert.DeserializeObject<NSEOptionChainData>(optiondatastring);
            var table = ConvertToDataTable(expiry, optiondata);
            var info = GetStockInfo(symbol,expiry, optiondata, table);
            return new Tuple<StockInfo, DataTable>(info, table);
        }
        public async static Task<FnOSupportResistance> GetSupportnResistance(string symbol, string expiry)
        {
            var url = GetNSEOptionChainUrl(symbol);
            var optiondatastring = await HttpHelper.GetNSEResult(url);
            var optiondata = JsonConvert.DeserializeObject<NSEOptionChainData>(optiondatastring);
            return GetDataFromOptionChain(symbol, expiry, optiondata);
        }

        public async static Task<List<FnOHighIV>> GetHighIV(string symbol, string expiry, int IV)
        {
            var url = GetNSEOptionChainUrl(symbol);
            var optiondatastring = await HttpHelper.GetNSEResult(url);
            var optiondata = JsonConvert.DeserializeObject<NSEOptionChainData>(optiondatastring);
            return GetHighIVDataFromOptionChain(symbol, expiry, optiondata,IV);
        }

        private static List<FnOHighIV> GetHighIVDataFromOptionChain(string symbol, string expiry, NSEOptionChainData source, int IV)
        {
            var results = new List<FnOHighIV>();
            var cedata = source.records.data
                                        .Where(d => d.expiryDate == expiry &&
                                                d.CE != null &&
                                                d.strikePrice >= source.records.underlyingValue &&
                                                d.CE.impliedVolatility>IV);

            var pedata = source.records.data
                                        .Where(d => d.expiryDate == expiry &&
                                               d.PE != null &&
                                                d.strikePrice <= source.records.underlyingValue && 
                                                d.PE.impliedVolatility>IV);

            var stockInfo = FnOData.GetFnOStockInfo(symbol);

            foreach (var d in cedata)
            {
                var r = new FnOHighIV();
                r.Symbol = symbol;
                r.LTP = source.records.underlyingValue;
                r.Strike = d.CE.strikePrice;
                r.Option_LTP = d.CE.lastPrice;
                r.Option = "CE";
                r.IV = d.CE.impliedVolatility;
                r.OI = d.CE.openInterest;
                r.Bid = d.CE.bidprice;
                r.Ask = d.CE.askPrice;
                r.Volume = d.CE.totalTradedVolume;

                r.LotSize = stockInfo != null ? stockInfo.Size : 0;
                r.TotalLotCost = r.LotSize * r.LTP;
                r.TotalPremium = r.LotSize * d.CE.lastPrice;
                r.StrikeTotalLotCost = r.LotSize * r.Strike;

                results.Add(r);
            }

            foreach (var d in pedata)
            {
                var r = new FnOHighIV();
                r.Symbol = symbol;
                r.LTP = source.records.underlyingValue;
                r.Strike = d.PE.strikePrice;
                r.Option_LTP = d.PE.lastPrice;
                r.Option = "PE";
                r.IV = d.PE.impliedVolatility;
                r.OI = d.PE.openInterest;
                r.Bid = d.PE.bidprice;
                r.Ask = d.PE.askPrice;
                r.Volume = d.PE.totalTradedVolume;

                r.LotSize = stockInfo != null ? stockInfo.Size : 0;
                r.TotalLotCost = r.LotSize * r.LTP;
                r.TotalPremium = r.LotSize * d.PE.lastPrice;
                r.StrikeTotalLotCost = r.LotSize * r.Strike;

                results.Add(r);
            }

            return results;
        }

        public async static Task<double> GetFutureOptionPremium(string symbol,
                                                         string stockPrice,
                                                            string strike,
                                                            string iv,
                                                            string roi,
                                                            string dot ,
                                                            string doe ,
                                                            string option)
        {

            var pairs = new List<KeyValuePair<string, string>>
                                {
                                    new KeyValuePair<string, string>("stk_name",symbol),
                                    new KeyValuePair<string, string>("stock_price",stockPrice),
                                    new KeyValuePair<string, string>("exercise_price",strike),
                                    new KeyValuePair<string, string>("transaction_date",dot),
                                    new KeyValuePair<string, string>("expiration_date",doe),
                                    new KeyValuePair<string, string>("interest_rate",roi),
                                    new KeyValuePair<string, string>("volatility",iv),
                                    new KeyValuePair<string, string>("option_type",option)
                                };

            var optiondatastring = await HttpHelper.GetFuturePremium(pairs);
            return ParseOptionString(optiondatastring);

        }

        private static double ParseOptionString(string optiondatastring)
        {
            if (string.IsNullOrEmpty(optiondatastring))
                return 0;
            string search= @"font-size:36px;"">";
            var start = optiondatastring.IndexOf(search);
            if (start>0)
            {
                var end = optiondatastring.IndexOf("</td>", start);
                var extract = optiondatastring.Substring(start + search.Length, end-(start + search.Length));
                double r = 0;
                if (double.TryParse(extract,out r))
                {
                    return r;
                }
            }
            return 0;
        }

        private static DataTable ConvertToDataTable(string expiry, NSEOptionChainData optiondata)
        {
            if (optiondata == null)
                return null;
            var stockLTP = optiondata.records.underlyingValue;
            var data = optiondata.records.data
                                        .Where(d => d.expiryDate == expiry).OrderBy(d => d.strikePrice).ToList();

            var cedata = optiondata.records.data
                                       .Where(d => d.expiryDate == expiry &&
                                               d.CE != null &&
                                               d.strikePrice >= optiondata.records.underlyingValue).ToList();

            var pedata = optiondata.records.data
                                        .Where(d => d.expiryDate == expiry &&
                                               d.PE != null &&
                                                d.strikePrice <= optiondata.records.underlyingValue).ToList();

            var resistance1 = cedata.OrderByDescending(d => d.CE.openInterest).FirstOrDefault().strikePrice;
            var support1 = pedata.OrderByDescending(d => d.PE.openInterest).FirstOrDefault().strikePrice;

            var table = GetDataTable();
            foreach (var d in data)
            {
                var row = table.NewRow();
                row["Strike"] = d.strikePrice;
                row["CE_ITM"] = d.strikePrice < stockLTP ? true : false;
                row["PE_ITM"] = d.strikePrice > stockLTP ? true : false;
                row["RESISTANCE"] = false;
                row["SUPPORT"] = false;
                row["CE_INTRINSICPCT"] = string.Empty;
                row["CE_TIMEVALUE"] = string.Empty;
                row["CE_INTRINSIC"] = string.Empty;
                row["PE_INTRINSICPCT"] = string.Empty;
                row["PE_TIMEVALUE"] = string.Empty;
                row["PE_INTRINSIC"] = string.Empty;
                if (d.strikePrice== support1)
                {
                    row["SUPPORT"] = true;
                }
                if (d.strikePrice == resistance1)
                {
                    row["RESISTANCE"] = true;
                }
                if (d.CE != null)
                {
                    //row["CE_ITM"] = d.CE.underlyingValue > d.CE.strikePrice ? true : false;
                    row["CE_OI"] = d.CE.openInterest > 0 ? d.CE.openInterest.ToString() : string.Empty;
                    row["CE_OIChange"] = d.CE.changeinOpenInterest != 0 ? d.CE.changeinOpenInterest.ToString() : string.Empty;
                    row["CE_LTP"] = d.CE.lastPrice > 0 ? d.CE.lastPrice.ToString() : string.Empty;
                    row["CE_IV"] = d.CE.impliedVolatility > 0 ? d.CE.impliedVolatility.ToString() : string.Empty;
                    row["CE_ASK"] = d.CE.askPrice > 0 ? d.CE.askPrice.ToString() : string.Empty;
                    row["CE_BID"] = d.CE.bidprice > 0 ? d.CE.bidprice.ToString() : string.Empty;

                    if (d.strikePrice > stockLTP)
                    {
                        row["CE_INTRINSICPCT"] = string.Empty;
                        row["CE_TIMEVALUE"] = d.CE.lastPrice > 0 ? d.CE.lastPrice.ToString() : string.Empty;
                        row["CE_INTRINSIC"] = string.Empty;
                    }
                    else
                    {
                        var intrinsic = stockLTP - d.strikePrice;
                        var timevalue = d.CE.lastPrice - intrinsic;
                        if (timevalue > 0)
                        {
                            var pct = 0.0;
                            if (d.CE.lastPrice > 0)
                            {
                                pct = (intrinsic / d.CE.lastPrice) * 100;
                            }
                            row["CE_INTRINSICPCT"] = pct.ToString("#.00");
                            row["CE_TIMEVALUE"] = timevalue.ToString("#.00");
                        }
                        row["CE_INTRINSIC"] = intrinsic.ToString("#.00");
                    }
                    
                }
                if (d.PE != null)
                {
                    //row["PE_ITM"] = d.PE.underlyingValue < d.PE.strikePrice ? true : false;
                    row["PE_OI"] = d.PE.openInterest > 0 ? d.PE.openInterest.ToString() : string.Empty;
                    row["PE_OIChange"] = d.PE.changeinOpenInterest != 0 ? d.PE.changeinOpenInterest.ToString() : string.Empty;
                    row["PE_LTP"] = d.PE.lastPrice > 0 ? d.PE.lastPrice.ToString() : string.Empty;
                    row["PE_IV"] = d.PE.impliedVolatility > 0 ? d.PE.impliedVolatility.ToString() : string.Empty;
                    row["PE_ASK"] = d.PE.askPrice > 0 ? d.PE.askPrice.ToString() : string.Empty;
                    row["PE_BID"] = d.PE.bidprice > 0 ? d.PE.bidprice.ToString() : string.Empty;


                    if (d.strikePrice < stockLTP)
                    {
                        row["PE_INTRINSICPCT"] = string.Empty;
                        row["PE_TIMEVALUE"] = d.PE.lastPrice > 0 ? d.PE.lastPrice.ToString() : string.Empty;
                        row["PE_INTRINSIC"] = string.Empty;
                    }
                    else
                    {
                        var intrinsic =  d.strikePrice- stockLTP;
                        var timevalue = d.PE.lastPrice - intrinsic;
                        if (timevalue > 0)
                        {
                            var pct = 0.0;
                            if (d.PE.lastPrice > 0)
                            {
                                pct = (intrinsic / d.PE.lastPrice) * 100;
                            }
                            row["PE_INTRINSICPCT"] = pct.ToString("#.00");
                            row["PE_TIMEVALUE"] = timevalue.ToString("#.00");
                        }
                        row["PE_INTRINSIC"] = intrinsic.ToString("#.00");
                    }
                }

                table.Rows.Add(row);
            }
            return table;

        }
        private static DataTable GetDataTable()
        {
            var table = new DataTable();
            table.Columns.Add("CE_ITM", typeof(bool));
            table.Columns.Add("PE_ITM", typeof(bool));
            table.Columns.Add("RESISTANCE", typeof(bool));
            table.Columns.Add("SUPPORT", typeof(bool));
            //table.Columns.Add("CE_OI", typeof(int));
            //table.Columns.Add("CE_OIChange", typeof(int));
            //table.Columns.Add("CE_LTP", typeof(double));
            //table.Columns.Add("Strike", typeof(double));
            //table.Columns.Add("PE_LTP", typeof(double));
            //table.Columns.Add("PE_OIChange", typeof(int));
            //table.Columns.Add("PE_OI", typeof(int));
            table.Columns.Add("CE_INTRINSICPCT", typeof(string));
            table.Columns.Add("CE_TIMEVALUE", typeof(string));
            table.Columns.Add("CE_INTRINSIC", typeof(string));
            table.Columns.Add("CE_OI", typeof(string));
            table.Columns.Add("CE_OIChange", typeof(string));
            table.Columns.Add("CE_IV", typeof(string));
            table.Columns.Add("CE_LTP", typeof(string));
            table.Columns.Add("CE_ASK", typeof(string));
            table.Columns.Add("CE_BID", typeof(string));
            table.Columns.Add("Strike", typeof(string));
            table.Columns.Add("PE_BID", typeof(string));
            table.Columns.Add("PE_ASK", typeof(string));
            table.Columns.Add("PE_LTP", typeof(string));
            table.Columns.Add("PE_IV", typeof(string));
            table.Columns.Add("PE_OIChange", typeof(string));
            table.Columns.Add("PE_OI", typeof(string));
            table.Columns.Add("PE_INTRINSIC", typeof(string));
            table.Columns.Add("PE_TIMEVALUE", typeof(string));
            table.Columns.Add("PE_INTRINSICPCT", typeof(string));
            
            
            return table;
        }
        private static FnOSupportResistance GetDataFromOptionChain(string symbol, string expiry, NSEOptionChainData source)
        {
            var result = new FnOSupportResistance();
            result.Symbol = symbol;
            result.LTP = source.records.underlyingValue;
            var cedata = source.records.data
                                        .Where(d => d.expiryDate == expiry && 
                                                d.CE != null && 
                                                d.strikePrice>=source.records.underlyingValue).ToList();

            var pedata = source.records.data
                                        .Where(d => d.expiryDate == expiry && 
                                               d.PE != null &&
                                                d.strikePrice <= source.records.underlyingValue).ToList();

            result.Resistance1 = cedata.OrderByDescending(d => d.CE.openInterest).FirstOrDefault().strikePrice;
            result.Support1 = pedata.OrderByDescending(d => d.PE.openInterest).FirstOrDefault().strikePrice;

            result.Resistance2 = cedata.OrderByDescending(d => d.CE.openInterest).Skip(1).FirstOrDefault().strikePrice;
            result.Support2 = pedata.OrderByDescending(d => d.PE.openInterest).Skip(1).FirstOrDefault().strikePrice;

            result.Resistance3 = cedata.OrderByDescending(d => d.CE.openInterest).Skip(2).FirstOrDefault().strikePrice;
            result.Support3 = pedata.OrderByDescending(d => d.PE.openInterest).Skip(2).FirstOrDefault().strikePrice;
            //result.Resistance1 = source.records.data.Where(d => d.expiryDate == expiry).Max(d => d.CE.openInterest);

            return result;
        }

        private static StockInfo GetStockInfo(string symbol,string expiry,NSEOptionChainData optiondata, DataTable table)
        {
            var info = new StockInfo();
            double ltp = 0;
            if (optiondata != null)
            {
                CultureInfo hindi = new CultureInfo("hi-IN");
                ltp = optiondata.records.underlyingValue;
                info.LTP = optiondata.records.underlyingValue;
                info.LotSize = FnOData.GetFnOStockInfo(symbol)?.Size;

                var cm = optiondata.records.underlyingValue * Convert.ToDouble(info.LotSize);
                info.CurrentValue = cm;
            }

            //DataRow[] drsCE = table.Select("CE_ITM=True", "Strike DESC");
            //DataRow[] drsPE = table.Select("PE_ITM=True", "Strike ASC");
            //DataRow drCE = null, drPE = null;
            //if (drsCE.Length > 0)
            //{
            //    drCE = drsCE[0];
            //}
            //if (drsPE.Length > 0)
            //{
            //    drPE = drsPE[0];
            //}
            //var noofdays = DateTime.Parse(expiry).Subtract(DateTime.Now).Days;

            //if (drCE != null && drPE != null)
            //{
            //    double iv = GetIVValue(drCE["CE_IV"]) +
            //                GetIVValue(drCE["PE_IV"]) +
            //               GetIVValue(drPE["CE_IV"]) +
            //                GetIVValue(drPE["PE_IV"]);

            //    var variance = (iv / 4) * Math.Sqrt((double)noofdays / 365.0);
            //    info.AvgIV = iv;
            //    info.LowerRange = ltp - variance;
            //    info.UpperRange = ltp + variance;
            //}


            return info;

        }

        private static double GetIVValue(object o)
        {
            if (o!=null)
            {
                if (Convert.ToString(o)!=string.Empty)
                {
                    return Convert.ToDouble(o);
                }
            }
            return 0;
        }
    }
}
