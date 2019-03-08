namespace WinFrmFProj.GUI
{
    partial class FrmProdSoft
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
            this.btnSoftFrmCancel = new System.Windows.Forms.Button();
            this.btnSoftFrmOk = new System.Windows.Forms.Button();
            this.grpBook = new System.Windows.Forms.GroupBox();
            this.btnNew = new System.Windows.Forms.Button();
            this.chkSoftAct = new System.Windows.Forms.CheckBox();
            this.cmbSwOS = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtProdID = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.txtProdUPrc = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.txtProdSupId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.txtSwName = new System.Windows.Forms.TextBox();
            this.txtProdQoH = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.cmbSwCat = new System.Windows.Forms.ComboBox();
            this.listViewSoft = new System.Windows.Forms.ListView();
            this.ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.softTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Price = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.QtyOH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.OsCat = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.softCateg = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SpplID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.prodStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmbSuppId = new System.Windows.Forms.ComboBox();
            this.grpBook.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSoftFrmCancel
            // 
            this.btnSoftFrmCancel.Location = new System.Drawing.Point(389, 324);
            this.btnSoftFrmCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnSoftFrmCancel.Name = "btnSoftFrmCancel";
            this.btnSoftFrmCancel.Size = new System.Drawing.Size(112, 25);
            this.btnSoftFrmCancel.TabIndex = 73;
            this.btnSoftFrmCancel.Text = "&Close";
            this.btnSoftFrmCancel.UseVisualStyleBackColor = true;
            this.btnSoftFrmCancel.Click += new System.EventHandler(this.btnBookFrmCancel_Click);
            // 
            // btnSoftFrmOk
            // 
            this.btnSoftFrmOk.Location = new System.Drawing.Point(250, 324);
            this.btnSoftFrmOk.Margin = new System.Windows.Forms.Padding(2);
            this.btnSoftFrmOk.Name = "btnSoftFrmOk";
            this.btnSoftFrmOk.Size = new System.Drawing.Size(112, 25);
            this.btnSoftFrmOk.TabIndex = 72;
            this.btnSoftFrmOk.Text = "&Save";
            this.btnSoftFrmOk.UseVisualStyleBackColor = true;
            this.btnSoftFrmOk.Click += new System.EventHandler(this.btnSoftFrmOk_Click);
            // 
            // grpBook
            // 
            this.grpBook.Controls.Add(this.cmbSuppId);
            this.grpBook.Controls.Add(this.btnNew);
            this.grpBook.Controls.Add(this.chkSoftAct);
            this.grpBook.Controls.Add(this.cmbSwOS);
            this.grpBook.Controls.Add(this.label11);
            this.grpBook.Controls.Add(this.txtProdID);
            this.grpBook.Controls.Add(this.label26);
            this.grpBook.Controls.Add(this.txtProdUPrc);
            this.grpBook.Controls.Add(this.label1);
            this.grpBook.Controls.Add(this.label27);
            this.grpBook.Controls.Add(this.txtProdSupId);
            this.grpBook.Controls.Add(this.label2);
            this.grpBook.Controls.Add(this.label28);
            this.grpBook.Controls.Add(this.txtSwName);
            this.grpBook.Controls.Add(this.txtProdQoH);
            this.grpBook.Controls.Add(this.label29);
            this.grpBook.Controls.Add(this.cmbSwCat);
            this.grpBook.Location = new System.Drawing.Point(6, 6);
            this.grpBook.Margin = new System.Windows.Forms.Padding(2);
            this.grpBook.Name = "grpBook";
            this.grpBook.Padding = new System.Windows.Forms.Padding(2);
            this.grpBook.Size = new System.Drawing.Size(495, 179);
            this.grpBook.TabIndex = 71;
            this.grpBook.TabStop = false;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(369, 16);
            this.btnNew.Margin = new System.Windows.Forms.Padding(2);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(112, 25);
            this.btnNew.TabIndex = 76;
            this.btnNew.Text = "&New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // chkSoftAct
            // 
            this.chkSoftAct.AutoSize = true;
            this.chkSoftAct.Location = new System.Drawing.Point(300, 139);
            this.chkSoftAct.Name = "chkSoftAct";
            this.chkSoftAct.Size = new System.Drawing.Size(56, 17);
            this.chkSoftAct.TabIndex = 75;
            this.chkSoftAct.Text = "Active";
            this.chkSoftAct.UseVisualStyleBackColor = true;
            // 
            // cmbSwOS
            // 
            this.cmbSwOS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSwOS.FormattingEnabled = true;
            this.cmbSwOS.Items.AddRange(new object[] {
            "Windows",
            "MacOS",
            "Linux",
            "iOS",
            "Android"});
            this.cmbSwOS.Location = new System.Drawing.Point(300, 99);
            this.cmbSwOS.Name = "cmbSwOS";
            this.cmbSwOS.Size = new System.Drawing.Size(181, 21);
            this.cmbSwOS.TabIndex = 74;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(8, 45);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(61, 13);
            this.label11.TabIndex = 46;
            this.label11.Text = "Product ID:";
            // 
            // txtProdID
            // 
            this.txtProdID.Location = new System.Drawing.Point(88, 45);
            this.txtProdID.Margin = new System.Windows.Forms.Padding(2);
            this.txtProdID.Name = "txtProdID";
            this.txtProdID.Size = new System.Drawing.Size(132, 20);
            this.txtProdID.TabIndex = 45;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(244, 70);
            this.label26.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(52, 13);
            this.label26.TabIndex = 49;
            this.label26.Text = "Category:";
            // 
            // txtProdUPrc
            // 
            this.txtProdUPrc.Location = new System.Drawing.Point(88, 107);
            this.txtProdUPrc.Margin = new System.Windows.Forms.Padding(2);
            this.txtProdUPrc.Name = "txtProdUPrc";
            this.txtProdUPrc.Size = new System.Drawing.Size(132, 20);
            this.txtProdUPrc.TabIndex = 50;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(244, 99);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 62;
            this.label1.Text = "OS Type";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(8, 107);
            this.label27.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(56, 13);
            this.label27.TabIndex = 51;
            this.label27.Text = "Unit Price:";
            // 
            // txtProdSupId
            // 
            this.txtProdSupId.Location = new System.Drawing.Point(88, 76);
            this.txtProdSupId.Margin = new System.Windows.Forms.Padding(2);
            this.txtProdSupId.Name = "txtProdSupId";
            this.txtProdSupId.Size = new System.Drawing.Size(21, 20);
            this.txtProdSupId.TabIndex = 52;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 16);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 60;
            this.label2.Text = "Product Name:";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(8, 76);
            this.label28.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(48, 13);
            this.label28.TabIndex = 53;
            this.label28.Text = "Supplier:";
            // 
            // txtSwName
            // 
            this.txtSwName.Location = new System.Drawing.Point(88, 16);
            this.txtSwName.Margin = new System.Windows.Forms.Padding(2);
            this.txtSwName.Name = "txtSwName";
            this.txtSwName.Size = new System.Drawing.Size(217, 20);
            this.txtSwName.TabIndex = 59;
            // 
            // txtProdQoH
            // 
            this.txtProdQoH.Location = new System.Drawing.Point(88, 137);
            this.txtProdQoH.Margin = new System.Windows.Forms.Padding(2);
            this.txtProdQoH.Name = "txtProdQoH";
            this.txtProdQoH.Size = new System.Drawing.Size(132, 20);
            this.txtProdQoH.TabIndex = 54;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(8, 137);
            this.label29.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(72, 13);
            this.label29.TabIndex = 55;
            this.label29.Text = "Qty On Hand:";
            // 
            // cmbSwCat
            // 
            this.cmbSwCat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSwCat.FormattingEnabled = true;
            this.cmbSwCat.Items.AddRange(new object[] {
            "OperationSystem",
            "GraphicsDesign",
            "TextEditor",
            "AudioVideoPlay",
            "AudioVedeoEdit",
            "Other"});
            this.cmbSwCat.Location = new System.Drawing.Point(300, 69);
            this.cmbSwCat.Name = "cmbSwCat";
            this.cmbSwCat.Size = new System.Drawing.Size(181, 21);
            this.cmbSwCat.TabIndex = 56;
            // 
            // listViewSoft
            // 
            this.listViewSoft.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ID,
            this.softTitle,
            this.Price,
            this.QtyOH,
            this.OsCat,
            this.softCateg,
            this.SpplID,
            this.prodStatus});
            this.listViewSoft.FullRowSelect = true;
            this.listViewSoft.Location = new System.Drawing.Point(6, 190);
            this.listViewSoft.Name = "listViewSoft";
            this.listViewSoft.Size = new System.Drawing.Size(495, 129);
            this.listViewSoft.TabIndex = 74;
            this.listViewSoft.UseCompatibleStateImageBehavior = false;
            this.listViewSoft.View = System.Windows.Forms.View.Details;
            this.listViewSoft.SelectedIndexChanged += new System.EventHandler(this.listViewSoft_SelectedIndexChanged);
            // 
            // ID
            // 
            this.ID.Text = "ID";
            // 
            // softTitle
            // 
            this.softTitle.Text = "Software Title";
            // 
            // Price
            // 
            this.Price.Text = "Price";
            // 
            // QtyOH
            // 
            this.QtyOH.Text = "Qty On Hand";
            // 
            // OsCat
            // 
            this.OsCat.Text = "Operating System";
            // 
            // softCateg
            // 
            this.softCateg.Text = "Software Category";
            // 
            // SpplID
            // 
            this.SpplID.Text = "Supplier ID";
            // 
            // prodStatus
            // 
            this.prodStatus.Text = "Prod Active";
            // 
            // cmbSuppId
            // 
            this.cmbSuppId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSuppId.FormattingEnabled = true;
            this.cmbSuppId.Location = new System.Drawing.Point(88, 76);
            this.cmbSuppId.Name = "cmbSuppId";
            this.cmbSuppId.Size = new System.Drawing.Size(132, 21);
            this.cmbSuppId.TabIndex = 75;
            // 
            // FrmProdSoft
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 360);
            this.Controls.Add(this.listViewSoft);
            this.Controls.Add(this.btnSoftFrmCancel);
            this.Controls.Add(this.btnSoftFrmOk);
            this.Controls.Add(this.grpBook);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmProdSoft";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmProdSoft";
            this.Load += new System.EventHandler(this.FrmProdSoft_Load);
            this.Resize += new System.EventHandler(this.FrmProdSoft_Resize);
            this.grpBook.ResumeLayout(false);
            this.grpBook.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSoftFrmCancel;
        private System.Windows.Forms.Button btnSoftFrmOk;
        private System.Windows.Forms.GroupBox grpBook;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtProdID;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox txtProdUPrc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox txtProdSupId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TextBox txtSwName;
        private System.Windows.Forms.TextBox txtProdQoH;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.ComboBox cmbSwCat;
        private System.Windows.Forms.ComboBox cmbSwOS;
        private System.Windows.Forms.ListView listViewSoft;
        private System.Windows.Forms.CheckBox chkSoftAct;
        private System.Windows.Forms.ColumnHeader ID;
        private System.Windows.Forms.ColumnHeader softTitle;
        private System.Windows.Forms.ColumnHeader Price;
        private System.Windows.Forms.ColumnHeader QtyOH;
        private System.Windows.Forms.ColumnHeader OsCat;
        private System.Windows.Forms.ColumnHeader softCateg;
        private System.Windows.Forms.ColumnHeader SpplID;
        private System.Windows.Forms.ColumnHeader prodStatus;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.ComboBox cmbSuppId;
    }
}