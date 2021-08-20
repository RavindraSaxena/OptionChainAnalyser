namespace FetchOptionChain
{
    partial class OptionChainTool
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionChainTool));
            this.label1 = new System.Windows.Forms.Label();
            this.cmdSymbol = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmdExpiry = new System.Windows.Forms.ComboBox();
            this.grdOptionChain = new System.Windows.Forms.DataGridView();
            this.btnGetOptionChain = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.prgPremium = new System.Windows.Forms.ProgressBar();
            this.dtDOE = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.dtDOT = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPremium = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnCalculatePremium = new System.Windows.Forms.Button();
            this.txtROI = new System.Windows.Forms.TextBox();
            this.txtIV = new System.Windows.Forms.TextBox();
            this.txtStrikePrice = new System.Windows.Forms.TextBox();
            this.txtStockPrice = new System.Windows.Forms.TextBox();
            this.rdPut = new System.Windows.Forms.RadioButton();
            this.rdCall = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblOptionChainResult = new System.Windows.Forms.Label();
            this.prgOptionChainProgress = new System.Windows.Forms.ProgressBar();
            this.Information = new System.Windows.Forms.GroupBox();
            this.lblMonthlyRange = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtTargetStrikePercent = new System.Windows.Forms.TextBox();
            this.txtTargetLotPrice = new System.Windows.Forms.TextBox();
            this.txtTargetStrike = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.lblCalcPremium = new System.Windows.Forms.Label();
            this.txtPremiumCalc = new System.Windows.Forms.TextBox();
            this.txtNoOfDays = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtCurrentMarketPrice = new System.Windows.Forms.TextBox();
            this.txtLotSize = new System.Windows.Forms.TextBox();
            this.txtLTP = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.chkIsNifty50 = new System.Windows.Forms.CheckBox();
            this.btnHighIV = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnOpenSensibull = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkShowNifty50 = new System.Windows.Forms.CheckBox();
            this.numHighIV = new System.Windows.Forms.NumericUpDown();
            this.btnDownloadPrice = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.btnOpenInTradingview = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnOpenInterest = new System.Windows.Forms.Button();
            this.btnUpdateFnOStock = new System.Windows.Forms.Button();
            this.btnDeliveryVolumeRpt = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdOptionChain)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.Information.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numHighIV)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Symbol";
            // 
            // cmdSymbol
            // 
            this.cmdSymbol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmdSymbol.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSymbol.FormattingEnabled = true;
            this.cmdSymbol.Location = new System.Drawing.Point(116, 15);
            this.cmdSymbol.Margin = new System.Windows.Forms.Padding(4);
            this.cmdSymbol.Name = "cmdSymbol";
            this.cmdSymbol.Size = new System.Drawing.Size(321, 28);
            this.cmdSymbol.TabIndex = 1;
            this.cmdSymbol.SelectedIndexChanged += new System.EventHandler(this.CmdSymbol_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 58);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Expiry";
            // 
            // cmdExpiry
            // 
            this.cmdExpiry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmdExpiry.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdExpiry.FormattingEnabled = true;
            this.cmdExpiry.Location = new System.Drawing.Point(116, 54);
            this.cmdExpiry.Margin = new System.Windows.Forms.Padding(4);
            this.cmdExpiry.Name = "cmdExpiry";
            this.cmdExpiry.Size = new System.Drawing.Size(321, 28);
            this.cmdExpiry.TabIndex = 4;
            this.cmdExpiry.SelectedIndexChanged += new System.EventHandler(this.CmdExpiry_SelectedIndexChanged);
            // 
            // grdOptionChain
            // 
            this.grdOptionChain.AllowUserToAddRows = false;
            this.grdOptionChain.AllowUserToDeleteRows = false;
            this.grdOptionChain.AllowUserToResizeColumns = false;
            this.grdOptionChain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdOptionChain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grdOptionChain.ColumnHeadersHeight = 29;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdOptionChain.DefaultCellStyle = dataGridViewCellStyle1;
            this.grdOptionChain.Location = new System.Drawing.Point(32, 368);
            this.grdOptionChain.Margin = new System.Windows.Forms.Padding(4);
            this.grdOptionChain.Name = "grdOptionChain";
            this.grdOptionChain.ReadOnly = true;
            this.grdOptionChain.RowHeadersWidth = 51;
            this.grdOptionChain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.grdOptionChain.Size = new System.Drawing.Size(1384, 409);
            this.grdOptionChain.TabIndex = 6;
            this.grdOptionChain.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.GrdOptionChain_CellFormatting);
            this.grdOptionChain.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.GrdOptionChain_CellMouseDoubleClick);
            // 
            // btnGetOptionChain
            // 
            this.btnGetOptionChain.Location = new System.Drawing.Point(447, 15);
            this.btnGetOptionChain.Margin = new System.Windows.Forms.Padding(4);
            this.btnGetOptionChain.Name = "btnGetOptionChain";
            this.btnGetOptionChain.Size = new System.Drawing.Size(160, 30);
            this.btnGetOptionChain.TabIndex = 7;
            this.btnGetOptionChain.Text = "Get Option Chain";
            this.btnGetOptionChain.UseVisualStyleBackColor = true;
            this.btnGetOptionChain.Click += new System.EventHandler(this.BtnGetOptionChain_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(1268, 17);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(100, 30);
            this.btnExit.TabIndex = 8;
            this.btnExit.Text = "Close";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.prgPremium);
            this.groupBox1.Controls.Add(this.dtDOE);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.dtDOT);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtPremium);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.btnCalculatePremium);
            this.groupBox1.Controls.Add(this.txtROI);
            this.groupBox1.Controls.Add(this.txtIV);
            this.groupBox1.Controls.Add(this.txtStrikePrice);
            this.groupBox1.Controls.Add(this.txtStockPrice);
            this.groupBox1.Controls.Add(this.rdPut);
            this.groupBox1.Controls.Add(this.rdCall);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(513, 94);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(555, 235);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Calculate Fair Option Value";
            // 
            // prgPremium
            // 
            this.prgPremium.Location = new System.Drawing.Point(295, 182);
            this.prgPremium.Margin = new System.Windows.Forms.Padding(4);
            this.prgPremium.Name = "prgPremium";
            this.prgPremium.Size = new System.Drawing.Size(99, 28);
            this.prgPremium.TabIndex = 17;
            // 
            // dtDOE
            // 
            this.dtDOE.CustomFormat = "dd/MM/yyyy";
            this.dtDOE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDOE.Location = new System.Drawing.Point(413, 84);
            this.dtDOE.Margin = new System.Windows.Forms.Padding(4);
            this.dtDOE.Name = "dtDOE";
            this.dtDOE.Size = new System.Drawing.Size(116, 22);
            this.dtDOE.TabIndex = 16;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(293, 86);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(99, 17);
            this.label9.TabIndex = 15;
            this.label9.Text = "Date Of Expiry";
            // 
            // dtDOT
            // 
            this.dtDOT.CustomFormat = "dd/MM/yyyy";
            this.dtDOT.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDOT.Location = new System.Drawing.Point(408, 44);
            this.dtDOT.Margin = new System.Windows.Forms.Padding(4);
            this.dtDOT.Name = "dtDOT";
            this.dtDOT.Size = new System.Drawing.Size(124, 22);
            this.dtDOT.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(293, 48);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(98, 17);
            this.label8.TabIndex = 13;
            this.label8.Text = "Date Of Trans";
            // 
            // txtPremium
            // 
            this.txtPremium.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPremium.ForeColor = System.Drawing.Color.Red;
            this.txtPremium.Location = new System.Drawing.Point(295, 182);
            this.txtPremium.Margin = new System.Windows.Forms.Padding(4);
            this.txtPremium.Name = "txtPremium";
            this.txtPremium.Size = new System.Drawing.Size(97, 26);
            this.txtPremium.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(293, 162);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(137, 17);
            this.label7.TabIndex = 11;
            this.label7.Text = "Estimate Premium";
            // 
            // btnCalculatePremium
            // 
            this.btnCalculatePremium.Location = new System.Drawing.Point(107, 180);
            this.btnCalculatePremium.Margin = new System.Windows.Forms.Padding(4);
            this.btnCalculatePremium.Name = "btnCalculatePremium";
            this.btnCalculatePremium.Size = new System.Drawing.Size(149, 32);
            this.btnCalculatePremium.TabIndex = 10;
            this.btnCalculatePremium.Text = "Calculate Premium";
            this.btnCalculatePremium.UseVisualStyleBackColor = true;
            this.btnCalculatePremium.Click += new System.EventHandler(this.BtnCalculatePremium_Click);
            // 
            // txtROI
            // 
            this.txtROI.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtROI.Location = new System.Drawing.Point(124, 144);
            this.txtROI.Margin = new System.Windows.Forms.Padding(4);
            this.txtROI.Name = "txtROI";
            this.txtROI.Size = new System.Drawing.Size(132, 26);
            this.txtROI.TabIndex = 9;
            this.txtROI.Text = "10.01";
            // 
            // txtIV
            // 
            this.txtIV.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIV.Location = new System.Drawing.Point(123, 110);
            this.txtIV.Margin = new System.Windows.Forms.Padding(4);
            this.txtIV.Name = "txtIV";
            this.txtIV.Size = new System.Drawing.Size(132, 26);
            this.txtIV.TabIndex = 8;
            // 
            // txtStrikePrice
            // 
            this.txtStrikePrice.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStrikePrice.Location = new System.Drawing.Point(123, 75);
            this.txtStrikePrice.Margin = new System.Windows.Forms.Padding(4);
            this.txtStrikePrice.Name = "txtStrikePrice";
            this.txtStrikePrice.Size = new System.Drawing.Size(132, 26);
            this.txtStrikePrice.TabIndex = 7;
            // 
            // txtStockPrice
            // 
            this.txtStockPrice.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStockPrice.Location = new System.Drawing.Point(124, 42);
            this.txtStockPrice.Margin = new System.Windows.Forms.Padding(4);
            this.txtStockPrice.Name = "txtStockPrice";
            this.txtStockPrice.Size = new System.Drawing.Size(132, 26);
            this.txtStockPrice.TabIndex = 6;
            // 
            // rdPut
            // 
            this.rdPut.AutoSize = true;
            this.rdPut.Checked = true;
            this.rdPut.Location = new System.Drawing.Point(396, 126);
            this.rdPut.Margin = new System.Windows.Forms.Padding(4);
            this.rdPut.Name = "rdPut";
            this.rdPut.Size = new System.Drawing.Size(50, 21);
            this.rdPut.TabIndex = 5;
            this.rdPut.TabStop = true;
            this.rdPut.Text = "Put";
            this.rdPut.UseVisualStyleBackColor = true;
            // 
            // rdCall
            // 
            this.rdCall.AutoSize = true;
            this.rdCall.Location = new System.Drawing.Point(297, 126);
            this.rdCall.Margin = new System.Windows.Forms.Padding(4);
            this.rdCall.Name = "rdCall";
            this.rdCall.Size = new System.Drawing.Size(52, 21);
            this.rdCall.TabIndex = 4;
            this.rdCall.Text = "Call";
            this.rdCall.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 110);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(20, 17);
            this.label6.TabIndex = 3;
            this.label6.Text = "IV";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 144);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 17);
            this.label5.TabIndex = 2;
            this.label5.Text = "ROI";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 75);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 17);
            this.label4.TabIndex = 1;
            this.label4.Text = "Stike Price";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 42);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Stock Price";
            // 
            // lblOptionChainResult
            // 
            this.lblOptionChainResult.AutoSize = true;
            this.lblOptionChainResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOptionChainResult.ForeColor = System.Drawing.Color.Red;
            this.lblOptionChainResult.Location = new System.Drawing.Point(40, 341);
            this.lblOptionChainResult.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOptionChainResult.Name = "lblOptionChainResult";
            this.lblOptionChainResult.Size = new System.Drawing.Size(13, 20);
            this.lblOptionChainResult.TabIndex = 10;
            this.lblOptionChainResult.Text = ".";
            // 
            // prgOptionChainProgress
            // 
            this.prgOptionChainProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.prgOptionChainProgress.Location = new System.Drawing.Point(620, 570);
            this.prgOptionChainProgress.Margin = new System.Windows.Forms.Padding(4);
            this.prgOptionChainProgress.Name = "prgOptionChainProgress";
            this.prgOptionChainProgress.Size = new System.Drawing.Size(204, 28);
            this.prgOptionChainProgress.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.prgOptionChainProgress.TabIndex = 11;
            // 
            // Information
            // 
            this.Information.Controls.Add(this.lblMonthlyRange);
            this.Information.Controls.Add(this.label16);
            this.Information.Controls.Add(this.txtTargetStrikePercent);
            this.Information.Controls.Add(this.txtTargetLotPrice);
            this.Information.Controls.Add(this.txtTargetStrike);
            this.Information.Controls.Add(this.label14);
            this.Information.Controls.Add(this.lblCalcPremium);
            this.Information.Controls.Add(this.txtPremiumCalc);
            this.Information.Controls.Add(this.txtNoOfDays);
            this.Information.Controls.Add(this.label13);
            this.Information.Controls.Add(this.txtCurrentMarketPrice);
            this.Information.Controls.Add(this.txtLotSize);
            this.Information.Controls.Add(this.txtLTP);
            this.Information.Controls.Add(this.label12);
            this.Information.Controls.Add(this.label11);
            this.Information.Controls.Add(this.label10);
            this.Information.Location = new System.Drawing.Point(32, 95);
            this.Information.Margin = new System.Windows.Forms.Padding(4);
            this.Information.Name = "Information";
            this.Information.Padding = new System.Windows.Forms.Padding(4);
            this.Information.Size = new System.Drawing.Size(473, 234);
            this.Information.TabIndex = 12;
            this.Information.TabStop = false;
            this.Information.Text = "Information";
            // 
            // lblMonthlyRange
            // 
            this.lblMonthlyRange.AutoSize = true;
            this.lblMonthlyRange.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMonthlyRange.Location = new System.Drawing.Point(117, 130);
            this.lblMonthlyRange.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMonthlyRange.Name = "lblMonthlyRange";
            this.lblMonthlyRange.Size = new System.Drawing.Size(15, 22);
            this.lblMonthlyRange.TabIndex = 15;
            this.lblMonthlyRange.Text = ".";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(17, 130);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(85, 17);
            this.label16.TabIndex = 14;
            this.label16.Text = "Mon. Range";
            // 
            // txtTargetStrikePercent
            // 
            this.txtTargetStrikePercent.Location = new System.Drawing.Point(287, 55);
            this.txtTargetStrikePercent.Margin = new System.Windows.Forms.Padding(4);
            this.txtTargetStrikePercent.Name = "txtTargetStrikePercent";
            this.txtTargetStrikePercent.Size = new System.Drawing.Size(159, 22);
            this.txtTargetStrikePercent.TabIndex = 13;
            // 
            // txtTargetLotPrice
            // 
            this.txtTargetLotPrice.Location = new System.Drawing.Point(287, 92);
            this.txtTargetLotPrice.Margin = new System.Windows.Forms.Padding(4);
            this.txtTargetLotPrice.Name = "txtTargetLotPrice";
            this.txtTargetLotPrice.Size = new System.Drawing.Size(159, 22);
            this.txtTargetLotPrice.TabIndex = 12;
            // 
            // txtTargetStrike
            // 
            this.txtTargetStrike.Location = new System.Drawing.Point(287, 23);
            this.txtTargetStrike.Margin = new System.Windows.Forms.Padding(4);
            this.txtTargetStrike.Name = "txtTargetStrike";
            this.txtTargetStrike.Size = new System.Drawing.Size(159, 22);
            this.txtTargetStrike.TabIndex = 11;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(17, 197);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(63, 17);
            this.label14.TabIndex = 10;
            this.label14.Text = "Premium";
            // 
            // lblCalcPremium
            // 
            this.lblCalcPremium.AutoSize = true;
            this.lblCalcPremium.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCalcPremium.ForeColor = System.Drawing.Color.Red;
            this.lblCalcPremium.Location = new System.Drawing.Point(283, 199);
            this.lblCalcPremium.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCalcPremium.Name = "lblCalcPremium";
            this.lblCalcPremium.Size = new System.Drawing.Size(16, 23);
            this.lblCalcPremium.TabIndex = 9;
            this.lblCalcPremium.Text = ".";
            // 
            // txtPremiumCalc
            // 
            this.txtPremiumCalc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPremiumCalc.Location = new System.Drawing.Point(115, 193);
            this.txtPremiumCalc.Margin = new System.Windows.Forms.Padding(4);
            this.txtPremiumCalc.Name = "txtPremiumCalc";
            this.txtPremiumCalc.Size = new System.Drawing.Size(159, 24);
            this.txtPremiumCalc.TabIndex = 8;
            this.txtPremiumCalc.TextChanged += new System.EventHandler(this.TxtPremiumCalc_TextChanged);
            this.txtPremiumCalc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtPremiumCalc_KeyPress);
            this.txtPremiumCalc.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxtPremiumCalc_KeyUp);
            // 
            // txtNoOfDays
            // 
            this.txtNoOfDays.Location = new System.Drawing.Point(115, 158);
            this.txtNoOfDays.Margin = new System.Windows.Forms.Padding(4);
            this.txtNoOfDays.Name = "txtNoOfDays";
            this.txtNoOfDays.Size = new System.Drawing.Size(159, 22);
            this.txtNoOfDays.TabIndex = 7;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(17, 164);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(98, 17);
            this.label13.TabIndex = 6;
            this.label13.Text = "Days to Expiry";
            // 
            // txtCurrentMarketPrice
            // 
            this.txtCurrentMarketPrice.Location = new System.Drawing.Point(115, 92);
            this.txtCurrentMarketPrice.Margin = new System.Windows.Forms.Padding(4);
            this.txtCurrentMarketPrice.Name = "txtCurrentMarketPrice";
            this.txtCurrentMarketPrice.Size = new System.Drawing.Size(159, 22);
            this.txtCurrentMarketPrice.TabIndex = 5;
            // 
            // txtLotSize
            // 
            this.txtLotSize.Location = new System.Drawing.Point(115, 55);
            this.txtLotSize.Margin = new System.Windows.Forms.Padding(4);
            this.txtLotSize.Name = "txtLotSize";
            this.txtLotSize.Size = new System.Drawing.Size(159, 22);
            this.txtLotSize.TabIndex = 4;
            // 
            // txtLTP
            // 
            this.txtLTP.Location = new System.Drawing.Point(115, 23);
            this.txtLTP.Margin = new System.Windows.Forms.Padding(4);
            this.txtLTP.Name = "txtLTP";
            this.txtLTP.Size = new System.Drawing.Size(159, 22);
            this.txtLTP.TabIndex = 3;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(17, 97);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(79, 17);
            this.label12.TabIndex = 2;
            this.label12.Text = "Cost Of Lot";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(17, 64);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(59, 17);
            this.label11.TabIndex = 1;
            this.label11.Text = "Lot Size";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(17, 31);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(34, 17);
            this.label10.TabIndex = 0;
            this.label10.Text = "LTP";
            // 
            // chkIsNifty50
            // 
            this.chkIsNifty50.AutoSize = true;
            this.chkIsNifty50.Location = new System.Drawing.Point(447, 57);
            this.chkIsNifty50.Margin = new System.Windows.Forms.Padding(4);
            this.chkIsNifty50.Name = "chkIsNifty50";
            this.chkIsNifty50.Size = new System.Drawing.Size(92, 21);
            this.chkIsNifty50.TabIndex = 14;
            this.chkIsNifty50.Text = "Is Nifty 50";
            this.chkIsNifty50.UseVisualStyleBackColor = true;
            // 
            // btnHighIV
            // 
            this.btnHighIV.Location = new System.Drawing.Point(200, 33);
            this.btnHighIV.Margin = new System.Windows.Forms.Padding(4);
            this.btnHighIV.Name = "btnHighIV";
            this.btnHighIV.Size = new System.Drawing.Size(115, 25);
            this.btnHighIV.TabIndex = 13;
            this.btnHighIV.Text = "Get High IV";
            this.btnHighIV.UseVisualStyleBackColor = true;
            this.btnHighIV.Click += new System.EventHandler(this.BtnHighIV_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(1268, 65);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(4);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(100, 28);
            this.btnRefresh.TabIndex = 14;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.BtnRefresh_Click);
            // 
            // btnOpenSensibull
            // 
            this.btnOpenSensibull.Location = new System.Drawing.Point(615, 15);
            this.btnOpenSensibull.Margin = new System.Windows.Forms.Padding(4);
            this.btnOpenSensibull.Name = "btnOpenSensibull";
            this.btnOpenSensibull.Size = new System.Drawing.Size(155, 28);
            this.btnOpenSensibull.TabIndex = 15;
            this.btnOpenSensibull.Text = "Open Sensibull";
            this.btnOpenSensibull.UseVisualStyleBackColor = true;
            this.btnOpenSensibull.Click += new System.EventHandler(this.BtnOpenSensibull_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnUpdateFnOStock);
            this.groupBox2.Controls.Add(this.btnDeliveryVolumeRpt);
            this.groupBox2.Controls.Add(this.chkShowNifty50);
            this.groupBox2.Controls.Add(this.numHighIV);
            this.groupBox2.Controls.Add(this.btnDownloadPrice);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.btnHighIV);
            this.groupBox2.Location = new System.Drawing.Point(1076, 101);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(339, 228);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Scans && Settings";
            // 
            // chkShowNifty50
            // 
            this.chkShowNifty50.AutoSize = true;
            this.chkShowNifty50.Location = new System.Drawing.Point(215, 184);
            this.chkShowNifty50.Margin = new System.Windows.Forms.Padding(4);
            this.chkShowNifty50.Name = "chkShowNifty50";
            this.chkShowNifty50.Size = new System.Drawing.Size(116, 21);
            this.chkShowNifty50.TabIndex = 20;
            this.chkShowNifty50.Text = "Show Nifty 50";
            this.chkShowNifty50.UseVisualStyleBackColor = true;
            this.chkShowNifty50.CheckedChanged += new System.EventHandler(this.ChkShowNifty50_CheckedChanged);
            // 
            // numHighIV
            // 
            this.numHighIV.Location = new System.Drawing.Point(73, 33);
            this.numHighIV.Margin = new System.Windows.Forms.Padding(4);
            this.numHighIV.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numHighIV.Name = "numHighIV";
            this.numHighIV.Size = new System.Drawing.Size(100, 22);
            this.numHighIV.TabIndex = 15;
            this.numHighIV.Value = new decimal(new int[] {
            40,
            0,
            0,
            0});
            // 
            // btnDownloadPrice
            // 
            this.btnDownloadPrice.Location = new System.Drawing.Point(27, 179);
            this.btnDownloadPrice.Margin = new System.Windows.Forms.Padding(4);
            this.btnDownloadPrice.Name = "btnDownloadPrice";
            this.btnDownloadPrice.Size = new System.Drawing.Size(163, 28);
            this.btnDownloadPrice.TabIndex = 17;
            this.btnDownloadPrice.Text = "Download Bhavcopy";
            this.btnDownloadPrice.UseVisualStyleBackColor = true;
            this.btnDownloadPrice.Click += new System.EventHandler(this.BtnDownloadPrice_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(24, 36);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(20, 17);
            this.label15.TabIndex = 14;
            this.label15.Text = "IV";
            // 
            // btnOpenInTradingview
            // 
            this.btnOpenInTradingview.Location = new System.Drawing.Point(777, 16);
            this.btnOpenInTradingview.Margin = new System.Windows.Forms.Padding(4);
            this.btnOpenInTradingview.Name = "btnOpenInTradingview";
            this.btnOpenInTradingview.Size = new System.Drawing.Size(155, 28);
            this.btnOpenInTradingview.TabIndex = 18;
            this.btnOpenInTradingview.Text = "Open Tradingview";
            this.btnOpenInTradingview.UseVisualStyleBackColor = true;
            this.btnOpenInTradingview.Click += new System.EventHandler(this.BtnOpenInTradingview_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 785);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1432, 22);
            this.statusStrip1.TabIndex = 19;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 16);
            // 
            // btnOpenInterest
            // 
            this.btnOpenInterest.Location = new System.Drawing.Point(616, 50);
            this.btnOpenInterest.Margin = new System.Windows.Forms.Padding(4);
            this.btnOpenInterest.Name = "btnOpenInterest";
            this.btnOpenInterest.Size = new System.Drawing.Size(155, 28);
            this.btnOpenInterest.TabIndex = 20;
            this.btnOpenInterest.Text = "OI Charts";
            this.btnOpenInterest.UseVisualStyleBackColor = true;
            this.btnOpenInterest.Click += new System.EventHandler(this.BtnOpenInterest_Click);
            // 
            // btnUpdateFnOStock
            // 
            this.btnUpdateFnOStock.Location = new System.Drawing.Point(27, 147);
            this.btnUpdateFnOStock.Name = "btnUpdateFnOStock";
            this.btnUpdateFnOStock.Size = new System.Drawing.Size(163, 25);
            this.btnUpdateFnOStock.TabIndex = 21;
            this.btnUpdateFnOStock.Text = "FnO List Update";
            this.btnUpdateFnOStock.UseVisualStyleBackColor = true;
            this.btnUpdateFnOStock.Click += new System.EventHandler(this.btnUpdateFnOStock_Click);
            // 
            // btnDeliveryVolumeRpt
            // 
            this.btnDeliveryVolumeRpt.Location = new System.Drawing.Point(27, 63);
            this.btnDeliveryVolumeRpt.Margin = new System.Windows.Forms.Padding(4);
            this.btnDeliveryVolumeRpt.Name = "btnDeliveryVolumeRpt";
            this.btnDeliveryVolumeRpt.Size = new System.Drawing.Size(163, 28);
            this.btnDeliveryVolumeRpt.TabIndex = 21;
            this.btnDeliveryVolumeRpt.Text = "Volume Report";
            this.btnDeliveryVolumeRpt.UseVisualStyleBackColor = true;
            this.btnDeliveryVolumeRpt.Click += new System.EventHandler(this.btnDeliveryVolumeRpt_Click);
            // 
            // OptionChainTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1432, 807);
            this.Controls.Add(this.chkIsNifty50);
            this.Controls.Add(this.btnOpenInterest);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnOpenInTradingview);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnOpenSensibull);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.Information);
            this.Controls.Add(this.prgOptionChainProgress);
            this.Controls.Add(this.lblOptionChainResult);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnGetOptionChain);
            this.Controls.Add(this.grdOptionChain);
            this.Controls.Add(this.cmdExpiry);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmdSymbol);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "OptionChainTool";
            this.Text = "OptionChainTool";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.OptionChainTool_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdOptionChain)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.Information.ResumeLayout(false);
            this.Information.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numHighIV)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmdSymbol;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmdExpiry;
        private System.Windows.Forms.DataGridView grdOptionChain;
        private System.Windows.Forms.Button btnGetOptionChain;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtROI;
        private System.Windows.Forms.TextBox txtIV;
        private System.Windows.Forms.TextBox txtStrikePrice;
        private System.Windows.Forms.TextBox txtStockPrice;
        private System.Windows.Forms.RadioButton rdPut;
        private System.Windows.Forms.RadioButton rdCall;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPremium;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnCalculatePremium;
        private System.Windows.Forms.DateTimePicker dtDOE;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtDOT;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblOptionChainResult;
        private System.Windows.Forms.ProgressBar prgOptionChainProgress;
        private System.Windows.Forms.GroupBox Information;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtCurrentMarketPrice;
        private System.Windows.Forms.TextBox txtLotSize;
        private System.Windows.Forms.TextBox txtLTP;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ProgressBar prgPremium;
        private System.Windows.Forms.TextBox txtNoOfDays;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtPremiumCalc;
        private System.Windows.Forms.Label lblCalcPremium;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtTargetStrikePercent;
        private System.Windows.Forms.TextBox txtTargetLotPrice;
        private System.Windows.Forms.TextBox txtTargetStrike;
        private System.Windows.Forms.Button btnHighIV;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnOpenSensibull;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown numHighIV;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnDownloadPrice;
        private System.Windows.Forms.Button btnOpenInTradingview;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.CheckBox chkIsNifty50;
        private System.Windows.Forms.CheckBox chkShowNifty50;
        private System.Windows.Forms.Button btnOpenInterest;
        private System.Windows.Forms.Label lblMonthlyRange;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button btnUpdateFnOStock;
        private System.Windows.Forms.Button btnDeliveryVolumeRpt;
    }
}