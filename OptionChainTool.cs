using FetchOptionChain.Helper;
using FetchOptionChain.Model;
using LumenWorks.Framework.IO.Csv;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FetchOptionChain
{
    public partial class OptionChainTool : Form
    {
        private StockInfo _info;
        private CultureInfo hindi = new CultureInfo("hi-IN");
        private DataTable priceData = new DataTable();
        public OptionChainTool()
        {
            InitializeComponent();
        }

        private void OptionChainTool_Load(object sender, EventArgs e)
        {
            prgOptionChainProgress.Visible = false;
            prgPremium.Visible = false;
            LoadPriceData();
            LoadSymbols();
            LoadExpiryData(true);
        }

        private void LoadSymbols()
        {
            try
            {
                bool isNifty50 = chkShowNifty50.Checked;
                cmdSymbol.Items.Clear();
                cmdSymbol.Items.Add("NIFTY");
                cmdSymbol.Items.Add("BANKNIFTY");
                cmdSymbol.Items.Add("----");
                foreach (var d in FnOData.GetFnOMetadata().Where(s => s.IsPreferred == true))
                {
                    cmdSymbol.Items.Add(d.Symbol);
                }
                cmdSymbol.Items.Add("----");

                foreach (var d in FnOData.GetFnOMetadata())
                {
                    if (isNifty50)
                    {
                        if (d.IsNifty50)
                        {
                            cmdSymbol.Items.Add(d.Symbol);
                        }
                    }
                    else
                    {
                        cmdSymbol.Items.Add(d.Symbol);
                    }
                }
                cmdSymbol.SelectedIndex = 0;
            }
            catch(Exception ex)
            {
                statusStrip1.Items[0].Text = $"{ex.Message} on {DateTime.Now.ToShortTimeString()}";
            }
        }

        private void LoadExpiryData(bool IsIndex)
        {
            cmdExpiry.Items.Clear();
            if (IsIndex)
            {
                //Index expiry
                cmdExpiry.Items.Add("29-Jul-2021");
                cmdExpiry.Items.Add("05-Aug-2021");
                cmdExpiry.Items.Add("12-Aug-2021");
                cmdExpiry.Items.Add("18-Aug-2021");
                cmdExpiry.Items.Add("26-Aug-2021");
                cmdExpiry.Items.Add("02-Sep-2021");
                cmdExpiry.Items.Add("09-Sep-2021");
                cmdExpiry.Items.Add("16-Sep-2021");
                cmdExpiry.Items.Add("23-Sep-2021");
                cmdExpiry.Items.Add("30-Sep-2021");
                cmdExpiry.Items.Add("30-Dec-2021");
                cmdExpiry.Items.Add("31-Mar-2022");
                cmdExpiry.Items.Add("30-Jun-2022");
                cmdExpiry.Items.Add("29-Dec-2022");
                cmdExpiry.Items.Add("29-Jun-2023");
                cmdExpiry.Items.Add("28-Dec-2023");
                cmdExpiry.Items.Add("27-Jun-2024");
                cmdExpiry.Items.Add("26-Jun-2025");
            }
            else
            {
                //Stock Expiry
                cmdExpiry.Items.Add("26-Aug-2021");
                cmdExpiry.Items.Add("30-Sep-2021");
                cmdExpiry.Items.Add("28-Oct-2021");
            }
            cmdExpiry.SelectedIndex = 0;
        }

        private void LoadPriceData()
        {
            var files = Directory.GetFiles(Environment.CurrentDirectory, "baseprice*.csv");

            if (files != null && files.Length > 0)
            {
                var filename = files[0];
                this.Text = $"Bhavcopy: {Path.GetFileName(filename)}";
                priceData = new DataTable();
                using (var csvReader = new CsvReader(new StreamReader(System.IO.File.OpenRead(filename)), true))
                {
                    priceData.Load(csvReader);
                }
            }
            
        }

        private async void CmdSR_Click(object sender, EventArgs e)
        {
            if (cmdExpiry.SelectedIndex!=-1)
            {
                string expiry = cmdExpiry.Text;
                var fnolist = FnOData.GetFnOMetadata();
                var list = new List<FnOSupportResistance>();
                foreach (var s in fnolist)
                {
                    try
                    {
                        statusStrip1.Items[0].Text = s.Symbol;
                        var r = await OptionChainHelper.GetSupportnResistance(s.Symbol, expiry);
                        list.Add(r);
                    }
                    catch
                    { }
                }
                //MessageBox.Show(cmdExpiry.Text);
                ExcelHelper.GenerateExcelsheet(cmdExpiry.Text, list);

            }
            else
            {
                MessageBox.Show("Please select an expiry date");
            }
        }

        private async void BtnGetOptionChain_Click(object sender, EventArgs e)
        {
           
            if (cmdSymbol.SelectedIndex!=-1 && cmdExpiry.SelectedIndex != -1)
            {
                try
                {
                    grdOptionChain.DataSource = null;
                    prgOptionChainProgress.Visible = true;
                    string symbol = cmdSymbol.Text;
                    string expiry = cmdExpiry.Text;
                    SetInfomation(expiry);
                    var (info,data) = await OptionChainHelper.GetOptionChain(symbol, expiry);
                    _info = info;
                    txtLTP.Text = fs(info.LTP); 
                    txtLotSize.Text = info.LotSize.ToString();
                    txtCurrentMarketPrice.Text = fs(info.CurrentValue);
                    lblMonthlyRange.Text = $"[ {fs(info.LowerRange)} - {fs(info.UpperRange)} ]";
                    if (data == null)
                    {
                        MessageBox.Show("No option chain data.", "Option Chain", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        SetGridView(data);
                    }
                    lblOptionChainResult.Text = $"Option chain: {symbol} [Expiry: {expiry}]";
                }
                catch(Exception ex)
                {
                    statusStrip1.Items[0].Text = $"{ex.Message} on {DateTime.Now.ToShortTimeString()}";
                }
                finally
                {
                    prgOptionChainProgress.Visible = false;
                }
            }
        }

        private void SetInfomation(string expiry)
        {
            DateTime d = DateTime.Parse(expiry);
            txtNoOfDays.Text = d.Subtract(DateTime.Now).Days.ToString();
        }
        private void SetGridView(DataTable data)
        {
            grdOptionChain.DataSource = data;

            grdOptionChain.Columns["CE_ITM"].Visible = false;
            grdOptionChain.Columns["PE_ITM"].Visible = false;
            grdOptionChain.Columns["RESISTANCE"].Visible = false;
            grdOptionChain.Columns["SUPPORT"].Visible = false; 
            grdOptionChain.Columns["Strike"].DefaultCellStyle.BackColor = Color.LightPink;
            grdOptionChain.Columns["Strike"].DefaultCellStyle.Font = new Font("Calibri", 9, FontStyle.Bold);
            grdOptionChain.Columns["CE_IV"].DefaultCellStyle.BackColor = Color.LightGray;
            grdOptionChain.Columns["PE_IV"].DefaultCellStyle.BackColor = Color.LightGray;


            

            grdOptionChain.Columns["CE_INTRINSICPCT"].HeaderText = "CE INTRINSIC %";
            grdOptionChain.Columns["CE_TIMEVALUE"].HeaderText = "CE TIMEVALUE";
            grdOptionChain.Columns["CE_INTRINSIC"].HeaderText = "CE INTRINSIC";
            grdOptionChain.Columns["CE_OI"].HeaderText = "CE OI";
            grdOptionChain.Columns["CE_OIChange"].HeaderText = "CE OI CHANGE";
            grdOptionChain.Columns["CE_IV"].HeaderText = "CE IV";
            grdOptionChain.Columns["CE_LTP"].HeaderText = "CE LTP";
            grdOptionChain.Columns["CE_ASK"].HeaderText = "CE ASK";
            grdOptionChain.Columns["CE_BID"].HeaderText = "CE BID";
            grdOptionChain.Columns["Strike"].HeaderText = "STRIKE";
            grdOptionChain.Columns["PE_BID"].HeaderText = "PE BID";
            grdOptionChain.Columns["PE_ASK"].HeaderText = "PE ASK";
            grdOptionChain.Columns["PE_LTP"].HeaderText = "PE LTP";
            grdOptionChain.Columns["PE_IV"].HeaderText = "PE IV";
            grdOptionChain.Columns["PE_OIChange"].HeaderText = "PE OI Change";
            grdOptionChain.Columns["PE_OI"].HeaderText = "PE OI";
            grdOptionChain.Columns["PE_INTRINSIC"].HeaderText = "PE INTRINSIC";
            grdOptionChain.Columns["PE_TIMEVALUE"].HeaderText = "PE TIMEVALUE";
            grdOptionChain.Columns["PE_INTRINSICPCT"].HeaderText = "PE INTRINSIC %";





            grdOptionChain.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
        }

        private void GrdOptionChain_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataRowView dr = grdOptionChain.Rows[e.RowIndex].DataBoundItem as DataRowView;
            var i = new DataGridViewCellStyle();
            i.BackColor = Color.LightYellow;
            var s = new DataGridViewCellStyle();
            s.BackColor = Color.LightGreen;
            var r = new DataGridViewCellStyle();
            r.BackColor = Color.LightPink;

            if (Convert.ToBoolean(dr["CE_ITM"]))
            {
                grdOptionChain.Rows[e.RowIndex].Cells["CE_OI"].Style = i;
                grdOptionChain.Rows[e.RowIndex].Cells["CE_OIChange"].Style = i;
                grdOptionChain.Rows[e.RowIndex].Cells["CE_LTP"].Style = i;
                grdOptionChain.Rows[e.RowIndex].Cells["CE_ASK"].Style = i;
                grdOptionChain.Rows[e.RowIndex].Cells["CE_BID"].Style = i;
            }
            if (Convert.ToBoolean(dr["PE_ITM"]))
            {
                grdOptionChain.Rows[e.RowIndex].Cells["PE_OI"].Style = i;
                grdOptionChain.Rows[e.RowIndex].Cells["PE_OIChange"].Style = i;
                grdOptionChain.Rows[e.RowIndex].Cells["PE_LTP"].Style = i;
                grdOptionChain.Rows[e.RowIndex].Cells["PE_ASK"].Style = i;
                grdOptionChain.Rows[e.RowIndex].Cells["PE_BID"].Style = i;
            }
            if (Convert.ToBoolean(dr["RESISTANCE"]))
            {
                grdOptionChain.Rows[e.RowIndex].Cells["CE_OI"].Style = r;
                grdOptionChain.Rows[e.RowIndex].Cells["CE_OIChange"].Style = r;
                grdOptionChain.Rows[e.RowIndex].Cells["CE_LTP"].Style = r;
                grdOptionChain.Rows[e.RowIndex].Cells["CE_ASK"].Style = r;
                grdOptionChain.Rows[e.RowIndex].Cells["CE_BID"].Style = r;
            }
            if (Convert.ToBoolean(dr["SUPPORT"]))
            {
                grdOptionChain.Rows[e.RowIndex].Cells["PE_OI"].Style = s;
                grdOptionChain.Rows[e.RowIndex].Cells["PE_OIChange"].Style = s;
                grdOptionChain.Rows[e.RowIndex].Cells["PE_LTP"].Style = s;
                grdOptionChain.Rows[e.RowIndex].Cells["PE_ASK"].Style = s;
                grdOptionChain.Rows[e.RowIndex].Cells["PE_BID"].Style = s;
            }

            
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private async void BtnCalculatePremium_Click(object sender, EventArgs e)
        {
            try
            {
                
                
                string symbol = cmdSymbol.Text;
                string stockPrice = txtStockPrice.Text;
                string strike = txtStrikePrice.Text;
                string iv = txtIV.Text;
                string roi = txtROI.Text;
                string dot = dtDOT.Value.ToString("dd/MM/yyyy");
                string doe = dtDOE.Value.ToString("dd/MM/yyyy");
                string option = rdPut.Checked ? "put" : "call";

                if (string.IsNullOrEmpty(symbol) ||
                    string.IsNullOrEmpty(stockPrice) ||
                    string.IsNullOrEmpty(strike) ||
                    string.IsNullOrEmpty(roi))
                {
                    MessageBox.Show("Some input parameters are missing.", "Option Chain", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else if (dtDOT.Value>=dtDOE.Value)
                {
                    MessageBox.Show("Please check expiry date and transaction date.", "Option Chain", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }


                btnCalculatePremium.Enabled = false;
                prgPremium.Visible = true;
                txtPremium.Text = string.Empty;

                var data = await OptionChainHelper.GetFutureOptionPremium(symbol, stockPrice, strike, iv, roi, dot, doe, option);

                txtPremium.Text = data.ToString();
            }
            finally
            {
                prgPremium.Visible = false;
                btnCalculatePremium.Enabled = true;
                btnCalculatePremium.Focus();
            }
        }

        private void GrdOptionChain_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) //handle header double click
                    return;

                DataRowView dr = grdOptionChain.Rows[e.RowIndex].DataBoundItem as DataRowView;
                string iv = string.Empty, strike = string.Empty, ltp = string.Empty;
                strike = Convert.ToString(dr["Strike"]);

                if (!Convert.ToBoolean(dr["CE_ITM"]))
                {
                    iv = Convert.ToString(dr["CE_IV"]);
                    ltp = Convert.ToString(dr["CE_LTP"]);
                }
                if (!Convert.ToBoolean(dr["PE_ITM"]))
                {
                    iv = Convert.ToString(dr["PE_IV"]);
                    ltp = Convert.ToString(dr["PE_LTP"]);
                }
                if (!string.IsNullOrEmpty(strike) &&
                    !string.IsNullOrEmpty(txtLTP.Text) &&
                    !string.IsNullOrEmpty(txtLotSize.Text))
                {
                    double strikedouble = Convert.ToDouble(strike);
                    double ltpdouble = _info.LTP;
                    int? lotsizedouble = _info.LotSize;
                    var absolute = (Math.Abs(ltpdouble - strikedouble) / ltpdouble) * 100;
                    var futurelot = lotsizedouble * strikedouble;

                    txtTargetStrike.Text = string.Format(hindi, "{0:c}", strikedouble);
                    txtTargetStrikePercent.Text = string.Format("{0} %", absolute.ToString("0.##"));
                    txtTargetLotPrice.Text = string.Format(hindi, "{0:c}", futurelot);

                    if (!string.IsNullOrEmpty(ltp))
                    {
                        double ltpdbl = Convert.ToDouble(ltp);
                        txtPremiumCalc.Text = ltp;
                        lblCalcPremium.Text = string.Format(hindi, "{0:c}", Convert.ToDouble(ltpdbl) * lotsizedouble);
                    }
                }

                txtIV.Text = iv;
                txtStrikePrice.Text = strike;
            }
            catch(Exception ex)
            {
                statusStrip1.Items[0].Text = $"{ex.Message} on {DateTime.Now.ToShortTimeString()}";
            }

        }

        private void TxtPremiumCalc_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CultureInfo hindi = new CultureInfo("hi-IN");
                string t = txtPremiumCalc.Text;
                if (!string.IsNullOrEmpty(t))
                {
                    int lotsize = 0;
                    if (!string.IsNullOrEmpty(txtLotSize.Text))
                    {
                        lotsize = Convert.ToInt32(txtLotSize.Text);
                    }
                    lblCalcPremium.Text = string.Format(hindi, "{0:c}", Convert.ToDouble(t) * lotsize);
                }
            }
            catch (Exception ex){
                statusStrip1.Items[0].Text = $"{ex.Message} on {DateTime.Now.ToShortTimeString()}";
            }
        }

        private void TxtPremiumCalc_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Escape)
            {
                txtPremiumCalc.Text = string.Empty;
                lblCalcPremium.Text = string.Empty;
            }
        }

        private void TxtPremiumCalc_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar)
                        && !char.IsPunctuation(e.KeyChar)
                        && !char.IsControl(e.KeyChar); 
        }

        private async void BtnHighIV_Click(object sender, EventArgs e)
        {
            if (cmdExpiry.SelectedIndex != -1)
            {
                string expiry = cmdExpiry.Text;
                var fnolist = FnOData.GetFnOMetadata();
                var list = new List<FnOHighIV>();
                int count = 1;
                int total = fnolist.Count();
                int iv = Convert.ToInt32(numHighIV.Value);
                foreach (var s in fnolist)
                {
                    try
                    {
                        statusStrip1.Items[0].Text = string.Format("[{0}/{1}] {2}",count, total,s.Symbol);
                        var r = await OptionChainHelper.GetHighIV(s.Symbol, expiry,iv);
                        list.AddRange(r);
                       
                    }
                    catch
                    { }
                    count++;
                }
                var filename=ExcelHelper.GenerateExcelsheet(cmdExpiry.Text, list);
                statusStrip1.Items[0].Text = $"Report generated successfully on {DateTime.Now.ToShortTimeString()}";
                if (MessageBox.Show("Report generated successfully. Click yes to open file."
                                    ,"Option chain report"
                                    ,MessageBoxButtons.YesNo
                                    ,MessageBoxIcon.Information,MessageBoxDefaultButton.Button2)==DialogResult.Yes )
                {
                    System.Diagnostics.Process.Start(filename);
                }
            }
            else
            {
                MessageBox.Show("Please select an expiry date");
            }
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            LoadPriceData();
            LoadSymbols();
            LoadExpiryData(true);
            HttpHelper.Refresh();
            statusStrip1.Items[0].Text = $"Data refreshed and reloaded successfully on {DateTime.Now.ToShortTimeString()}";
        }

        private void BtnOpenSensibull_Click(object sender, EventArgs e)
        {
            if (cmdExpiry.SelectedIndex != -1 && cmdSymbol.SelectedIndex != -1)
            {
                var expiry = Convert.ToDateTime(cmdExpiry.Text);
                var url = $"https://web.sensibull.com/option-chain?expiry={expiry.ToString("yyyy-MM-dd")}&tradingsymbol={cmdSymbol.Text}";
                //System.Diagnostics.Process.Start("chrome.exe",url);
                System.Diagnostics.Process.Start(url);
            }
        }

        private async void BtnDownloadPrice_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure to download new price data?","Download prices",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2)==DialogResult.No)
                {
                    return;
                }
                btnDownloadPrice.Enabled = false;
                string result = string.Empty;
                string url = string.Empty;
                DateTime d = DateTime.Now;

                try
                {
                    url = $"https://archives.nseindia.com/products/content/sec_bhavdata_full_{d.ToString("ddMMyyyy")}.csv";
                    result=await HttpHelper.GetBhavCopy(url);
                }
                catch
                {
                    if (result == string.Empty)
                    {
                        d = DateTime.Now.AddDays(-1);
                        url = $"https://archives.nseindia.com/products/content/sec_bhavdata_full_{d.ToString("ddMMyyyy")}.csv";
                        result = await HttpHelper.GetBhavCopy(url);
                    }
                }
                if (result!=string.Empty)
                {
                    var filename = Path.Combine(Environment.CurrentDirectory, $"baseprices_{d.ToString("ddMMyyyy")}.csv");

                    var files=Directory.GetFiles(Environment.CurrentDirectory, "baseprice*.csv");

                    if (files!=null && files.Length>0)
                    {
                        foreach(var file in files)
                        {
                            File.Delete(file);
                        }
                    }
                    File.WriteAllText(filename, result);
                    statusStrip1.Items[0].Text = $"File downloaded successfully... {filename}";
                }
            }
            catch
            {

            }
            finally
            {
                btnDownloadPrice.Enabled = true;
            }
        }

        private void BtnOpenInTradingview_Click(object sender, EventArgs e)
        {
            if (cmdExpiry.SelectedIndex != -1 && cmdSymbol.SelectedIndex != -1)
            {
                var expiry = Convert.ToDateTime(cmdExpiry.Text);
                var url = $"https://www.tradingview.com/chart/?symbol=NSE:{cmdSymbol.Text}";
                //System.Diagnostics.Process.Start("chrome.exe",url);
                System.Diagnostics.Process.Start(url);
            }
        }

        private void CmdSymbol_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmdSymbol.SelectedIndex!=-1)
            {
                var symbol = cmdSymbol.Text;
                if (symbol != "----" 
                    && symbol!= "NIFTY"
                    && symbol!="BANKNIFTY")
                {
                    LoadExpiryData(false);

                    var stockdata = FnOData.GetFnOStockInfo(symbol);
                    chkIsNifty50.Checked = stockdata.IsNifty50;
                    if (priceData != null && priceData.Rows.Count > 0)
                    {
                        var row = priceData.Select($"SYMBOL='{symbol}'");
                        if (row != null)
                        {
                            var currentPrice = Convert.ToDouble(row[0]["LAST_PRICE"]);
                            txtLTP.Text = string.Format(hindi, "{0:c}", currentPrice); 
                            txtLotSize.Text = Convert.ToString(stockdata.Size);
                            txtCurrentMarketPrice.Text= string.Format(hindi, "{0:c}", currentPrice* stockdata.Size);
                        }
                    }
                }
                else if((symbol == "NIFTY" || symbol != "BANKNIFTY") && symbol != "----")
                {
                    LoadExpiryData(true);
                }
            }
        }

        private void CmdExpiry_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmdExpiry.SelectedIndex!=-1)
            {
                SetInfomation(cmdExpiry.Text);
            }
        }

        private void ChkShowNifty50_CheckedChanged(object sender, EventArgs e)
        {
            LoadSymbols();
        }

        private void BtnOpenInterest_Click(object sender, EventArgs e)
        {
            var url = $"https://opstra.definedge.com/openinterest";
            //System.Diagnostics.Process.Start("chrome.exe",url);
            System.Diagnostics.Process.Start(url);
        }

        private string fs(object m)
        {
            return string.Format(hindi, "{0:c}", m);
        }
    }
}
