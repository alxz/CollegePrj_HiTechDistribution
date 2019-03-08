namespace WinFrmFProj.GUI
{
    partial class FrmOrder
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
            this.btnNew = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.txtOrderID = new System.Windows.Forms.TextBox();
            this.btnOrderFrmCancel = new System.Windows.Forms.Button();
            this.btnOrderFrmOk = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtrequiredTime = new System.Windows.Forms.DateTimePicker();
            this.dtShippingTime = new System.Windows.Forms.DateTimePicker();
            this.dtCreatedTime = new System.Windows.Forms.DateTimePicker();
            this.txtCreatedBy = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cmbTakenBy = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnDelItemCart = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.listViewOrdrProd = new System.Windows.Forms.ListView();
            this.ProdID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ProdName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.HowMany = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ProdCateg = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ProdStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.UnitPrice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuppID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.QtyOH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lstAllProdView = new System.Windows.Forms.ListView();
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader16 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader17 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader18 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader31 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.numItemsVol = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtProdSelected = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnProdSearch = new System.Windows.Forms.Button();
            this.cmbProdSrchBy = new System.Windows.Forms.ComboBox();
            this.label24 = new System.Windows.Forms.Label();
            this.txtProdSearch = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.cmbOrdClient = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numItemsVol)).BeginInit();
            this.SuspendLayout();
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(660, 11);
            this.btnNew.Margin = new System.Windows.Forms.Padding(2);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(112, 25);
            this.btnNew.TabIndex = 77;
            this.btnNew.Text = "&New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(21, 11);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(50, 13);
            this.label11.TabIndex = 74;
            this.label11.Text = "Order ID:";
            // 
            // txtOrderID
            // 
            this.txtOrderID.Location = new System.Drawing.Point(101, 11);
            this.txtOrderID.Margin = new System.Windows.Forms.Padding(2);
            this.txtOrderID.Name = "txtOrderID";
            this.txtOrderID.ReadOnly = true;
            this.txtOrderID.Size = new System.Drawing.Size(132, 20);
            this.txtOrderID.TabIndex = 73;
            // 
            // btnOrderFrmCancel
            // 
            this.btnOrderFrmCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnOrderFrmCancel.Location = new System.Drawing.Point(409, 526);
            this.btnOrderFrmCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnOrderFrmCancel.Name = "btnOrderFrmCancel";
            this.btnOrderFrmCancel.Size = new System.Drawing.Size(112, 25);
            this.btnOrderFrmCancel.TabIndex = 76;
            this.btnOrderFrmCancel.Text = "&Close";
            this.btnOrderFrmCancel.UseVisualStyleBackColor = true;
            this.btnOrderFrmCancel.Click += new System.EventHandler(this.btnBookFrmCancel_Click);
            // 
            // btnOrderFrmOk
            // 
            this.btnOrderFrmOk.Location = new System.Drawing.Point(270, 526);
            this.btnOrderFrmOk.Margin = new System.Windows.Forms.Padding(2);
            this.btnOrderFrmOk.Name = "btnOrderFrmOk";
            this.btnOrderFrmOk.Size = new System.Drawing.Size(112, 25);
            this.btnOrderFrmOk.TabIndex = 75;
            this.btnOrderFrmOk.Text = "&Save";
            this.btnOrderFrmOk.UseVisualStyleBackColor = true;
            this.btnOrderFrmOk.Click += new System.EventHandler(this.btnOrderFrmOk_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtrequiredTime);
            this.groupBox1.Controls.Add(this.dtShippingTime);
            this.groupBox1.Controls.Add(this.dtCreatedTime);
            this.groupBox1.Controls.Add(this.txtCreatedBy);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.cmbTakenBy);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cmbStatus);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.btnDelItemCart);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.listViewOrdrProd);
            this.groupBox1.Controls.Add(this.txtAmount);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(2, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(781, 259);
            this.groupBox1.TabIndex = 78;
            this.groupBox1.TabStop = false;
            // 
            // dtrequiredTime
            // 
            this.dtrequiredTime.Location = new System.Drawing.Point(99, 66);
            this.dtrequiredTime.Name = "dtrequiredTime";
            this.dtrequiredTime.Size = new System.Drawing.Size(132, 20);
            this.dtrequiredTime.TabIndex = 94;
            // 
            // dtShippingTime
            // 
            this.dtShippingTime.Location = new System.Drawing.Point(99, 42);
            this.dtShippingTime.Name = "dtShippingTime";
            this.dtShippingTime.Size = new System.Drawing.Size(132, 20);
            this.dtShippingTime.TabIndex = 93;
            // 
            // dtCreatedTime
            // 
            this.dtCreatedTime.Location = new System.Drawing.Point(99, 17);
            this.dtCreatedTime.Name = "dtCreatedTime";
            this.dtCreatedTime.Size = new System.Drawing.Size(132, 20);
            this.dtCreatedTime.TabIndex = 92;
            // 
            // txtCreatedBy
            // 
            this.txtCreatedBy.Location = new System.Drawing.Point(387, 18);
            this.txtCreatedBy.Margin = new System.Windows.Forms.Padding(2);
            this.txtCreatedBy.Name = "txtCreatedBy";
            this.txtCreatedBy.ReadOnly = true;
            this.txtCreatedBy.Size = new System.Drawing.Size(261, 20);
            this.txtCreatedBy.TabIndex = 91;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label12.Location = new System.Drawing.Point(17, 110);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(126, 13);
            this.label12.TabIndex = 90;
            this.label12.Text = "Order Shopping Cart:";
            // 
            // cmbTakenBy
            // 
            this.cmbTakenBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTakenBy.FormattingEnabled = true;
            this.cmbTakenBy.Items.AddRange(new object[] {
            "Phone",
            "Fax",
            "Email"});
            this.cmbTakenBy.Location = new System.Drawing.Point(387, 69);
            this.cmbTakenBy.Name = "cmbTakenBy";
            this.cmbTakenBy.Size = new System.Drawing.Size(261, 21);
            this.cmbTakenBy.TabIndex = 89;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(307, 72);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 13);
            this.label7.TabIndex = 88;
            this.label7.Text = "Taken By:";
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "New",
            "Hold",
            "Shipped",
            "Delivered",
            "Closed"});
            this.cmbStatus.Location = new System.Drawing.Point(387, 42);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(261, 21);
            this.cmbStatus.TabIndex = 87;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(307, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 86;
            this.label6.Text = "Staus:";
            // 
            // btnDelItemCart
            // 
            this.btnDelItemCart.Location = new System.Drawing.Point(658, 228);
            this.btnDelItemCart.Name = "btnDelItemCart";
            this.btnDelItemCart.Size = new System.Drawing.Size(112, 25);
            this.btnDelItemCart.TabIndex = 87;
            this.btnDelItemCart.Text = "Remove";
            this.btnDelItemCart.UseVisualStyleBackColor = true;
            this.btnDelItemCart.Click += new System.EventHandler(this.btnDelItemCart_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(307, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 84;
            this.label5.Text = "Created By:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(673, 111);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 13);
            this.label8.TabIndex = 82;
            this.label8.Text = "Total Amount:";
            // 
            // listViewOrdrProd
            // 
            this.listViewOrdrProd.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ProdID,
            this.ProdName,
            this.HowMany,
            this.ProdCateg,
            this.ProdStatus,
            this.UnitPrice,
            this.SuppID,
            this.QtyOH});
            this.listViewOrdrProd.FullRowSelect = true;
            this.listViewOrdrProd.Location = new System.Drawing.Point(7, 126);
            this.listViewOrdrProd.Name = "listViewOrdrProd";
            this.listViewOrdrProd.Size = new System.Drawing.Size(641, 127);
            this.listViewOrdrProd.TabIndex = 85;
            this.listViewOrdrProd.UseCompatibleStateImageBehavior = false;
            this.listViewOrdrProd.View = System.Windows.Forms.View.Details;
            // 
            // ProdID
            // 
            this.ProdID.Text = "Prod ID";
            this.ProdID.Width = 50;
            // 
            // ProdName
            // 
            this.ProdName.Text = "Prod Name (Title)";
            this.ProdName.Width = 200;
            // 
            // HowMany
            // 
            this.HowMany.DisplayIndex = 3;
            this.HowMany.Text = "ItemQty";
            // 
            // ProdCateg
            // 
            this.ProdCateg.DisplayIndex = 2;
            this.ProdCateg.Text = "Prod Category";
            this.ProdCateg.Width = 100;
            // 
            // ProdStatus
            // 
            this.ProdStatus.Text = "Status";
            this.ProdStatus.Width = 80;
            // 
            // UnitPrice
            // 
            this.UnitPrice.Text = "Unit Price";
            this.UnitPrice.Width = 100;
            // 
            // SuppID
            // 
            this.SuppID.Text = "Supplier Id";
            this.SuppID.Width = 100;
            // 
            // QtyOH
            // 
            this.QtyOH.Text = "Qty On hand";
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(658, 126);
            this.txtAmount.Margin = new System.Windows.Forms.Padding(2);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.ReadOnly = true;
            this.txtAmount.Size = new System.Drawing.Size(112, 20);
            this.txtAmount.TabIndex = 81;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 66);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 80;
            this.label3.Text = "Required Time:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 42);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 78;
            this.label2.Text = "Shipping Time:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 76;
            this.label1.Text = "Created Time:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(309, 11);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 82;
            this.label4.Text = "For Client:";
            // 
            // lstAllProdView
            // 
            this.lstAllProdView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader13,
            this.columnHeader14,
            this.columnHeader15,
            this.columnHeader16,
            this.columnHeader17,
            this.columnHeader18,
            this.columnHeader31});
            this.lstAllProdView.FullRowSelect = true;
            this.lstAllProdView.Location = new System.Drawing.Point(7, 46);
            this.lstAllProdView.Name = "lstAllProdView";
            this.lstAllProdView.Size = new System.Drawing.Size(641, 143);
            this.lstAllProdView.TabIndex = 79;
            this.lstAllProdView.UseCompatibleStateImageBehavior = false;
            this.lstAllProdView.View = System.Windows.Forms.View.Details;
            this.lstAllProdView.SelectedIndexChanged += new System.EventHandler(this.lstAllProdView_SelectedIndexChanged);
            this.lstAllProdView.DoubleClick += new System.EventHandler(this.lstAllProdView_DoubleClick);
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "Prod ID";
            this.columnHeader13.Width = 50;
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "Prod Name (Title)";
            this.columnHeader14.Width = 200;
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "Prod Category";
            this.columnHeader15.Width = 100;
            // 
            // columnHeader16
            // 
            this.columnHeader16.Text = "Status";
            this.columnHeader16.Width = 80;
            // 
            // columnHeader17
            // 
            this.columnHeader17.Text = "Unit Price";
            this.columnHeader17.Width = 100;
            // 
            // columnHeader18
            // 
            this.columnHeader18.Text = "Supplier Id";
            this.columnHeader18.Width = 100;
            // 
            // columnHeader31
            // 
            this.columnHeader31.Text = "Qty On hand";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.numItemsVol);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtProdSelected);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.btnProdSearch);
            this.groupBox2.Controls.Add(this.cmbProdSrchBy);
            this.groupBox2.Controls.Add(this.label24);
            this.groupBox2.Controls.Add(this.txtProdSearch);
            this.groupBox2.Controls.Add(this.label23);
            this.groupBox2.Controls.Add(this.lstAllProdView);
            this.groupBox2.Location = new System.Drawing.Point(2, 301);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(781, 220);
            this.groupBox2.TabIndex = 80;
            this.groupBox2.TabStop = false;
            // 
            // numItemsVol
            // 
            this.numItemsVol.Location = new System.Drawing.Point(676, 194);
            this.numItemsVol.Name = "numItemsVol";
            this.numItemsVol.Size = new System.Drawing.Size(48, 20);
            this.numItemsVol.TabIndex = 91;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(658, 196);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(12, 13);
            this.label10.TabIndex = 90;
            this.label10.Text = "x";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 197);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(30, 13);
            this.label9.TabIndex = 89;
            this.label9.Text = "Item:";
            // 
            // txtProdSelected
            // 
            this.txtProdSelected.Location = new System.Drawing.Point(72, 194);
            this.txtProdSelected.Margin = new System.Windows.Forms.Padding(2);
            this.txtProdSelected.Name = "txtProdSelected";
            this.txtProdSelected.ReadOnly = true;
            this.txtProdSelected.Size = new System.Drawing.Size(576, 20);
            this.txtProdSelected.TabIndex = 88;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(658, 164);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 25);
            this.button1.TabIndex = 86;
            this.button1.Text = "Add to Cart";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnProdSearch
            // 
            this.btnProdSearch.Location = new System.Drawing.Point(659, 17);
            this.btnProdSearch.Name = "btnProdSearch";
            this.btnProdSearch.Size = new System.Drawing.Size(112, 25);
            this.btnProdSearch.TabIndex = 84;
            this.btnProdSearch.Text = "Search";
            this.btnProdSearch.UseVisualStyleBackColor = true;
            // 
            // cmbProdSrchBy
            // 
            this.cmbProdSrchBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProdSrchBy.FormattingEnabled = true;
            this.cmbProdSrchBy.Items.AddRange(new object[] {
            "Id number",
            "Prod Name",
            "Supplier"});
            this.cmbProdSrchBy.Location = new System.Drawing.Point(72, 19);
            this.cmbProdSrchBy.Name = "cmbProdSrchBy";
            this.cmbProdSrchBy.Size = new System.Drawing.Size(113, 21);
            this.cmbProdSrchBy.TabIndex = 83;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(7, 23);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(59, 13);
            this.label24.TabIndex = 82;
            this.label24.Text = "Search By:";
            // 
            // txtProdSearch
            // 
            this.txtProdSearch.Location = new System.Drawing.Point(297, 20);
            this.txtProdSearch.Name = "txtProdSearch";
            this.txtProdSearch.Size = new System.Drawing.Size(351, 20);
            this.txtProdSearch.TabIndex = 81;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(217, 23);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(74, 13);
            this.label23.TabIndex = 80;
            this.label23.Text = "Search String:";
            // 
            // cmbOrdClient
            // 
            this.cmbOrdClient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOrdClient.FormattingEnabled = true;
            this.cmbOrdClient.Location = new System.Drawing.Point(389, 8);
            this.cmbOrdClient.Name = "cmbOrdClient";
            this.cmbOrdClient.Size = new System.Drawing.Size(261, 21);
            this.cmbOrdClient.TabIndex = 86;
            this.cmbOrdClient.SelectedIndexChanged += new System.EventHandler(this.cmbOrdClient_SelectedIndexChanged);
            // 
            // FrmOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.cmbOrdClient);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtOrderID);
            this.Controls.Add(this.btnOrderFrmCancel);
            this.Controls.Add(this.btnOrderFrmOk);
            this.Controls.Add(this.label4);
            this.Name = "FrmOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Orders";
            this.Load += new System.EventHandler(this.FrmOrder_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numItemsVol)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtOrderID;
        private System.Windows.Forms.Button btnOrderFrmCancel;
        private System.Windows.Forms.Button btnOrderFrmOk;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView lstAllProdView;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.ColumnHeader columnHeader15;
        private System.Windows.Forms.ColumnHeader columnHeader16;
        private System.Windows.Forms.ColumnHeader columnHeader17;
        private System.Windows.Forms.ColumnHeader columnHeader18;
        private System.Windows.Forms.ColumnHeader columnHeader31;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtProdSearch;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.ComboBox cmbProdSrchBy;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Button btnProdSearch;
        private System.Windows.Forms.ComboBox cmbTakenBy;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.ListView listViewOrdrProd;
        private System.Windows.Forms.ColumnHeader ProdID;
        private System.Windows.Forms.ColumnHeader ProdName;
        private System.Windows.Forms.ColumnHeader ProdCateg;
        private System.Windows.Forms.ColumnHeader ProdStatus;
        private System.Windows.Forms.ColumnHeader UnitPrice;
        private System.Windows.Forms.ColumnHeader SuppID;
        private System.Windows.Forms.ColumnHeader QtyOH;
        private System.Windows.Forms.Button btnDelItemCart;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown numItemsVol;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtProdSelected;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cmbOrdClient;
        private System.Windows.Forms.TextBox txtCreatedBy;
        private System.Windows.Forms.DateTimePicker dtCreatedTime;
        private System.Windows.Forms.DateTimePicker dtrequiredTime;
        private System.Windows.Forms.DateTimePicker dtShippingTime;
        private System.Windows.Forms.ColumnHeader HowMany;
    }
}