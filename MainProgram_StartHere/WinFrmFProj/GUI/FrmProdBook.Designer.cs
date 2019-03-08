namespace WinFrmFProj.GUI
{
    partial class FrmProdBook
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
            this.cmbBookCat = new System.Windows.Forms.ComboBox();
            this.label29 = new System.Windows.Forms.Label();
            this.txtProdQoH = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.txtProdSupId = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.txtProdUPrc = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtProdID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtyearReleased = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtbookTitle = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtbookISBN = new System.Windows.Forms.TextBox();
            this.listBoxBookAuth = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnBookAuthAdd = new System.Windows.Forms.Button();
            this.btnBookAuthRem = new System.Windows.Forms.Button();
            this.btnBookAuthClr = new System.Windows.Forms.Button();
            this.grpBook = new System.Windows.Forms.GroupBox();
            this.cmbSuppId = new System.Windows.Forms.ComboBox();
            this.btnNew = new System.Windows.Forms.Button();
            this.chkBookAct = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbProdAuth = new System.Windows.Forms.ComboBox();
            this.btnBookFrmOk = new System.Windows.Forms.Button();
            this.btnBookFrmCancel = new System.Windows.Forms.Button();
            this.listViewBooks = new System.Windows.Forms.ListView();
            this.ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Title = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ISBN = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.UnitPri = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.QtyOH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Category = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Authors = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.YearPub = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Supplier = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Active = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.grpBook.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbBookCat
            // 
            this.cmbBookCat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBookCat.FormattingEnabled = true;
            this.cmbBookCat.Items.AddRange(new object[] {
            "Text_Book",
            "Science_Fiction",
            "Satire",
            "Drama",
            "Action_Adventure",
            "Romace",
            "Mystery",
            "Horror",
            "Self_help",
            "Other"});
            this.cmbBookCat.Location = new System.Drawing.Point(301, 67);
            this.cmbBookCat.Name = "cmbBookCat";
            this.cmbBookCat.Size = new System.Drawing.Size(162, 21);
            this.cmbBookCat.TabIndex = 56;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(8, 181);
            this.label29.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(72, 13);
            this.label29.TabIndex = 55;
            this.label29.Text = "Qty On Hand:";
            // 
            // txtProdQoH
            // 
            this.txtProdQoH.Location = new System.Drawing.Point(88, 181);
            this.txtProdQoH.Margin = new System.Windows.Forms.Padding(2);
            this.txtProdQoH.Name = "txtProdQoH";
            this.txtProdQoH.Size = new System.Drawing.Size(132, 20);
            this.txtProdQoH.TabIndex = 7;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(8, 120);
            this.label28.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(48, 13);
            this.label28.TabIndex = 53;
            this.label28.Text = "Supplier:";
            // 
            // txtProdSupId
            // 
            this.txtProdSupId.Location = new System.Drawing.Point(88, 120);
            this.txtProdSupId.Margin = new System.Windows.Forms.Padding(2);
            this.txtProdSupId.Name = "txtProdSupId";
            this.txtProdSupId.Size = new System.Drawing.Size(31, 20);
            this.txtProdSupId.TabIndex = 5;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(8, 151);
            this.label27.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(56, 13);
            this.label27.TabIndex = 51;
            this.label27.Text = "Unit Price:";
            // 
            // txtProdUPrc
            // 
            this.txtProdUPrc.Location = new System.Drawing.Point(88, 151);
            this.txtProdUPrc.Margin = new System.Windows.Forms.Padding(2);
            this.txtProdUPrc.Name = "txtProdUPrc";
            this.txtProdUPrc.Size = new System.Drawing.Size(132, 20);
            this.txtProdUPrc.TabIndex = 6;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(244, 69);
            this.label26.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(52, 13);
            this.label26.TabIndex = 49;
            this.label26.Text = "Category:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(8, 16);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(60, 13);
            this.label11.TabIndex = 46;
            this.label11.Text = "product ID:";
            // 
            // txtProdID
            // 
            this.txtProdID.Location = new System.Drawing.Point(88, 16);
            this.txtProdID.Margin = new System.Windows.Forms.Padding(2);
            this.txtProdID.Name = "txtProdID";
            this.txtProdID.ReadOnly = true;
            this.txtProdID.Size = new System.Drawing.Size(132, 20);
            this.txtProdID.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 96);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 62;
            this.label1.Text = "Year released:";
            // 
            // txtyearReleased
            // 
            this.txtyearReleased.Location = new System.Drawing.Point(88, 94);
            this.txtyearReleased.Margin = new System.Windows.Forms.Padding(2);
            this.txtyearReleased.Name = "txtyearReleased";
            this.txtyearReleased.Size = new System.Drawing.Size(132, 20);
            this.txtyearReleased.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 40);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 60;
            this.label2.Text = "Book Title:";
            // 
            // txtbookTitle
            // 
            this.txtbookTitle.Location = new System.Drawing.Point(88, 40);
            this.txtbookTitle.Margin = new System.Windows.Forms.Padding(2);
            this.txtbookTitle.Name = "txtbookTitle";
            this.txtbookTitle.Size = new System.Drawing.Size(435, 20);
            this.txtbookTitle.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 67);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 58;
            this.label3.Text = "Book ISBN:";
            // 
            // txtbookISBN
            // 
            this.txtbookISBN.Location = new System.Drawing.Point(88, 67);
            this.txtbookISBN.Margin = new System.Windows.Forms.Padding(2);
            this.txtbookISBN.Name = "txtbookISBN";
            this.txtbookISBN.Size = new System.Drawing.Size(132, 20);
            this.txtbookISBN.TabIndex = 3;
            // 
            // listBoxBookAuth
            // 
            this.listBoxBookAuth.FormattingEnabled = true;
            this.listBoxBookAuth.Location = new System.Drawing.Point(301, 120);
            this.listBoxBookAuth.Margin = new System.Windows.Forms.Padding(2);
            this.listBoxBookAuth.Name = "listBoxBookAuth";
            this.listBoxBookAuth.Size = new System.Drawing.Size(162, 82);
            this.listBoxBookAuth.TabIndex = 63;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(245, 123);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 26);
            this.label4.TabIndex = 64;
            this.label4.Text = "Book\r\nAuthor(s):";
            // 
            // btnBookAuthAdd
            // 
            this.btnBookAuthAdd.Location = new System.Drawing.Point(465, 116);
            this.btnBookAuthAdd.Margin = new System.Windows.Forms.Padding(2);
            this.btnBookAuthAdd.Name = "btnBookAuthAdd";
            this.btnBookAuthAdd.Size = new System.Drawing.Size(55, 27);
            this.btnBookAuthAdd.TabIndex = 65;
            this.btnBookAuthAdd.Text = "Add";
            this.btnBookAuthAdd.UseVisualStyleBackColor = true;
            this.btnBookAuthAdd.Click += new System.EventHandler(this.btnBookAuthAdd_Click);
            // 
            // btnBookAuthRem
            // 
            this.btnBookAuthRem.Location = new System.Drawing.Point(465, 147);
            this.btnBookAuthRem.Margin = new System.Windows.Forms.Padding(2);
            this.btnBookAuthRem.Name = "btnBookAuthRem";
            this.btnBookAuthRem.Size = new System.Drawing.Size(55, 27);
            this.btnBookAuthRem.TabIndex = 66;
            this.btnBookAuthRem.Text = "Remove";
            this.btnBookAuthRem.UseVisualStyleBackColor = true;
            this.btnBookAuthRem.Click += new System.EventHandler(this.btnBookAuthRem_Click);
            // 
            // btnBookAuthClr
            // 
            this.btnBookAuthClr.Location = new System.Drawing.Point(465, 175);
            this.btnBookAuthClr.Margin = new System.Windows.Forms.Padding(2);
            this.btnBookAuthClr.Name = "btnBookAuthClr";
            this.btnBookAuthClr.Size = new System.Drawing.Size(55, 27);
            this.btnBookAuthClr.TabIndex = 67;
            this.btnBookAuthClr.Text = "Clear";
            this.btnBookAuthClr.UseVisualStyleBackColor = true;
            this.btnBookAuthClr.Click += new System.EventHandler(this.btnBookAuthClr_Click);
            // 
            // grpBook
            // 
            this.grpBook.Controls.Add(this.cmbSuppId);
            this.grpBook.Controls.Add(this.btnNew);
            this.grpBook.Controls.Add(this.chkBookAct);
            this.grpBook.Controls.Add(this.label5);
            this.grpBook.Controls.Add(this.cmbProdAuth);
            this.grpBook.Controls.Add(this.label11);
            this.grpBook.Controls.Add(this.btnBookAuthClr);
            this.grpBook.Controls.Add(this.txtProdID);
            this.grpBook.Controls.Add(this.btnBookAuthRem);
            this.grpBook.Controls.Add(this.btnBookAuthAdd);
            this.grpBook.Controls.Add(this.label4);
            this.grpBook.Controls.Add(this.label26);
            this.grpBook.Controls.Add(this.listBoxBookAuth);
            this.grpBook.Controls.Add(this.txtProdUPrc);
            this.grpBook.Controls.Add(this.label1);
            this.grpBook.Controls.Add(this.label27);
            this.grpBook.Controls.Add(this.txtyearReleased);
            this.grpBook.Controls.Add(this.txtProdSupId);
            this.grpBook.Controls.Add(this.label2);
            this.grpBook.Controls.Add(this.label28);
            this.grpBook.Controls.Add(this.txtbookTitle);
            this.grpBook.Controls.Add(this.txtProdQoH);
            this.grpBook.Controls.Add(this.label3);
            this.grpBook.Controls.Add(this.label29);
            this.grpBook.Controls.Add(this.txtbookISBN);
            this.grpBook.Controls.Add(this.cmbBookCat);
            this.grpBook.Location = new System.Drawing.Point(6, 6);
            this.grpBook.Margin = new System.Windows.Forms.Padding(2);
            this.grpBook.Name = "grpBook";
            this.grpBook.Padding = new System.Windows.Forms.Padding(2);
            this.grpBook.Size = new System.Drawing.Size(538, 214);
            this.grpBook.TabIndex = 68;
            this.grpBook.TabStop = false;
            // 
            // cmbSuppId
            // 
            this.cmbSuppId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSuppId.FormattingEnabled = true;
            this.cmbSuppId.Location = new System.Drawing.Point(88, 120);
            this.cmbSuppId.Name = "cmbSuppId";
            this.cmbSuppId.Size = new System.Drawing.Size(132, 21);
            this.cmbSuppId.TabIndex = 73;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(409, 11);
            this.btnNew.Margin = new System.Windows.Forms.Padding(2);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(112, 25);
            this.btnNew.TabIndex = 72;
            this.btnNew.Text = "&New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // chkBookAct
            // 
            this.chkBookAct.AutoSize = true;
            this.chkBookAct.Location = new System.Drawing.Point(301, 18);
            this.chkBookAct.Name = "chkBookAct";
            this.chkBookAct.Size = new System.Drawing.Size(56, 17);
            this.chkBookAct.TabIndex = 71;
            this.chkBookAct.Text = "Active";
            this.chkBookAct.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(244, 100);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 68;
            this.label5.Text = "Authors:";
            // 
            // cmbProdAuth
            // 
            this.cmbProdAuth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProdAuth.FormattingEnabled = true;
            this.cmbProdAuth.Location = new System.Drawing.Point(301, 98);
            this.cmbProdAuth.Name = "cmbProdAuth";
            this.cmbProdAuth.Size = new System.Drawing.Size(162, 21);
            this.cmbProdAuth.TabIndex = 69;
            // 
            // btnBookFrmOk
            // 
            this.btnBookFrmOk.Location = new System.Drawing.Point(276, 375);
            this.btnBookFrmOk.Margin = new System.Windows.Forms.Padding(2);
            this.btnBookFrmOk.Name = "btnBookFrmOk";
            this.btnBookFrmOk.Size = new System.Drawing.Size(112, 25);
            this.btnBookFrmOk.TabIndex = 69;
            this.btnBookFrmOk.Text = "&Save";
            this.btnBookFrmOk.UseVisualStyleBackColor = true;
            this.btnBookFrmOk.Click += new System.EventHandler(this.btnBookFrmOk_Click);
            // 
            // btnBookFrmCancel
            // 
            this.btnBookFrmCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnBookFrmCancel.Location = new System.Drawing.Point(415, 375);
            this.btnBookFrmCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnBookFrmCancel.Name = "btnBookFrmCancel";
            this.btnBookFrmCancel.Size = new System.Drawing.Size(112, 25);
            this.btnBookFrmCancel.TabIndex = 70;
            this.btnBookFrmCancel.Text = "&Close";
            this.btnBookFrmCancel.UseVisualStyleBackColor = true;
            this.btnBookFrmCancel.Click += new System.EventHandler(this.btnBookFrmCancel_Click);
            // 
            // listViewBooks
            // 
            this.listViewBooks.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ID,
            this.Title,
            this.ISBN,
            this.UnitPri,
            this.QtyOH,
            this.Category,
            this.Authors,
            this.YearPub,
            this.Supplier,
            this.Active});
            this.listViewBooks.FullRowSelect = true;
            this.listViewBooks.Location = new System.Drawing.Point(6, 224);
            this.listViewBooks.Margin = new System.Windows.Forms.Padding(2);
            this.listViewBooks.Name = "listViewBooks";
            this.listViewBooks.Size = new System.Drawing.Size(540, 150);
            this.listViewBooks.TabIndex = 71;
            this.listViewBooks.UseCompatibleStateImageBehavior = false;
            this.listViewBooks.View = System.Windows.Forms.View.Details;
            this.listViewBooks.SelectedIndexChanged += new System.EventHandler(this.listViewBooks_SelectedIndexChanged);
            // 
            // ID
            // 
            this.ID.Text = "Item ID";
            // 
            // Title
            // 
            this.Title.Text = "Title";
            this.Title.Width = 160;
            // 
            // ISBN
            // 
            this.ISBN.Text = "ISBN";
            // 
            // UnitPri
            // 
            this.UnitPri.Text = "Unit Price";
            // 
            // QtyOH
            // 
            this.QtyOH.Text = "Qty On Hand";
            // 
            // Category
            // 
            this.Category.Text = "Category";
            // 
            // Authors
            // 
            this.Authors.Text = "Authors";
            this.Authors.Width = 260;
            // 
            // YearPub
            // 
            this.YearPub.Text = "Year Pub";
            // 
            // Supplier
            // 
            this.Supplier.Text = "Supplier";
            // 
            // Active
            // 
            this.Active.Text = "Active";
            // 
            // FrmProdBook
            // 
            this.AcceptButton = this.btnBookFrmOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnBookFrmCancel;
            this.ClientSize = new System.Drawing.Size(550, 406);
            this.Controls.Add(this.listViewBooks);
            this.Controls.Add(this.btnBookFrmCancel);
            this.Controls.Add(this.btnBookFrmOk);
            this.Controls.Add(this.grpBook);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmProdBook";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add New Books";
            this.Load += new System.EventHandler(this.FrmProdBook_Load);
            this.Resize += new System.EventHandler(this.FrmProdBook_Resize);
            this.grpBook.ResumeLayout(false);
            this.grpBook.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbBookCat;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.TextBox txtProdQoH;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TextBox txtProdSupId;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox txtProdUPrc;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtProdID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtyearReleased;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtbookTitle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtbookISBN;
        private System.Windows.Forms.ListBox listBoxBookAuth;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnBookAuthAdd;
        private System.Windows.Forms.Button btnBookAuthRem;
        private System.Windows.Forms.Button btnBookAuthClr;
        private System.Windows.Forms.GroupBox grpBook;
        private System.Windows.Forms.Button btnBookFrmOk;
        private System.Windows.Forms.Button btnBookFrmCancel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbProdAuth;
        private System.Windows.Forms.ListView listViewBooks;
        private System.Windows.Forms.ColumnHeader ID;
        private System.Windows.Forms.ColumnHeader Title;
        private System.Windows.Forms.ColumnHeader ISBN;
        private System.Windows.Forms.ColumnHeader YearPub;
        private System.Windows.Forms.ColumnHeader Supplier;
        private System.Windows.Forms.ColumnHeader UnitPri;
        private System.Windows.Forms.ColumnHeader QtyOH;
        private System.Windows.Forms.ColumnHeader Category;
        private System.Windows.Forms.ColumnHeader Authors;
        private System.Windows.Forms.CheckBox chkBookAct;
        private System.Windows.Forms.ColumnHeader Active;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.ComboBox cmbSuppId;
    }
}