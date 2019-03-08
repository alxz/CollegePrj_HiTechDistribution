namespace WinFrmFProj.GUI
{
    partial class FrmSupplier
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
            this.btnSuppDel = new System.Windows.Forms.Button();
            this.btnSuppNew = new System.Windows.Forms.Button();
            this.btnSuppFrmClose = new System.Windows.Forms.Button();
            this.btnSuppUpd = new System.Windows.Forms.Button();
            this.listViewSupp = new System.Windows.Forms.ListView();
            this.ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FirstName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LastName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label11 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSuppID = new System.Windows.Forms.TextBox();
            this.txtSuppName = new System.Windows.Forms.TextBox();
            this.txtSuppEmail = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnSuppDel
            // 
            this.btnSuppDel.Location = new System.Drawing.Point(304, 40);
            this.btnSuppDel.Name = "btnSuppDel";
            this.btnSuppDel.Size = new System.Drawing.Size(112, 24);
            this.btnSuppDel.TabIndex = 87;
            this.btnSuppDel.Text = "Delete";
            this.btnSuppDel.UseVisualStyleBackColor = true;
            this.btnSuppDel.Click += new System.EventHandler(this.btnSuppDel_Click);
            // 
            // btnSuppNew
            // 
            this.btnSuppNew.Location = new System.Drawing.Point(304, 10);
            this.btnSuppNew.Name = "btnSuppNew";
            this.btnSuppNew.Size = new System.Drawing.Size(112, 24);
            this.btnSuppNew.TabIndex = 86;
            this.btnSuppNew.Text = "&New";
            this.btnSuppNew.UseVisualStyleBackColor = true;
            this.btnSuppNew.Click += new System.EventHandler(this.btnSuppNew_Click);
            // 
            // btnSuppFrmClose
            // 
            this.btnSuppFrmClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSuppFrmClose.Location = new System.Drawing.Point(313, 281);
            this.btnSuppFrmClose.Margin = new System.Windows.Forms.Padding(2);
            this.btnSuppFrmClose.Name = "btnSuppFrmClose";
            this.btnSuppFrmClose.Size = new System.Drawing.Size(112, 25);
            this.btnSuppFrmClose.TabIndex = 85;
            this.btnSuppFrmClose.Text = "&Close";
            this.btnSuppFrmClose.UseVisualStyleBackColor = true;
            this.btnSuppFrmClose.Click += new System.EventHandler(this.btnSuppFrmClose_Click);
            // 
            // btnSuppUpd
            // 
            this.btnSuppUpd.Location = new System.Drawing.Point(305, 69);
            this.btnSuppUpd.Margin = new System.Windows.Forms.Padding(2);
            this.btnSuppUpd.Name = "btnSuppUpd";
            this.btnSuppUpd.Size = new System.Drawing.Size(112, 25);
            this.btnSuppUpd.TabIndex = 84;
            this.btnSuppUpd.Text = "&Save";
            this.btnSuppUpd.UseVisualStyleBackColor = true;
            this.btnSuppUpd.Click += new System.EventHandler(this.btnSuppUpd_Click);
            // 
            // listViewSupp
            // 
            this.listViewSupp.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ID,
            this.FirstName,
            this.LastName});
            this.listViewSupp.FullRowSelect = true;
            this.listViewSupp.Location = new System.Drawing.Point(11, 109);
            this.listViewSupp.Margin = new System.Windows.Forms.Padding(2);
            this.listViewSupp.Name = "listViewSupp";
            this.listViewSupp.Size = new System.Drawing.Size(414, 158);
            this.listViewSupp.TabIndex = 83;
            this.listViewSupp.UseCompatibleStateImageBehavior = false;
            this.listViewSupp.View = System.Windows.Forms.View.Details;
            this.listViewSupp.SelectedIndexChanged += new System.EventHandler(this.listViewSupp_SelectedIndexChanged);
            // 
            // ID
            // 
            this.ID.Text = "Item ID";
            // 
            // FirstName
            // 
            this.FirstName.Text = "First Name";
            this.FirstName.Width = 100;
            // 
            // LastName
            // 
            this.LastName.Text = "Last Name";
            this.LastName.Width = 120;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(18, 9);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(62, 13);
            this.label11.TabIndex = 80;
            this.label11.Text = "Supplier ID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 33);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 82;
            this.label2.Text = "Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 60);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 81;
            this.label3.Text = "Email:";
            // 
            // txtSuppID
            // 
            this.txtSuppID.Location = new System.Drawing.Point(80, 9);
            this.txtSuppID.Margin = new System.Windows.Forms.Padding(2);
            this.txtSuppID.Name = "txtSuppID";
            this.txtSuppID.Size = new System.Drawing.Size(132, 20);
            this.txtSuppID.TabIndex = 77;
            // 
            // txtSuppName
            // 
            this.txtSuppName.Location = new System.Drawing.Point(80, 33);
            this.txtSuppName.Margin = new System.Windows.Forms.Padding(2);
            this.txtSuppName.Name = "txtSuppName";
            this.txtSuppName.Size = new System.Drawing.Size(132, 20);
            this.txtSuppName.TabIndex = 78;
            // 
            // txtSuppEmail
            // 
            this.txtSuppEmail.Location = new System.Drawing.Point(80, 60);
            this.txtSuppEmail.Margin = new System.Windows.Forms.Padding(2);
            this.txtSuppEmail.Name = "txtSuppEmail";
            this.txtSuppEmail.Size = new System.Drawing.Size(132, 20);
            this.txtSuppEmail.TabIndex = 79;
            // 
            // FrmSupplier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 320);
            this.Controls.Add(this.btnSuppDel);
            this.Controls.Add(this.btnSuppNew);
            this.Controls.Add(this.btnSuppFrmClose);
            this.Controls.Add(this.btnSuppUpd);
            this.Controls.Add(this.listViewSupp);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSuppID);
            this.Controls.Add(this.txtSuppName);
            this.Controls.Add(this.txtSuppEmail);
            this.Name = "FrmSupplier";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage Suppliers List";
            this.Load += new System.EventHandler(this.FrmSupplier_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSuppDel;
        private System.Windows.Forms.Button btnSuppNew;
        private System.Windows.Forms.Button btnSuppFrmClose;
        private System.Windows.Forms.Button btnSuppUpd;
        private System.Windows.Forms.ListView listViewSupp;
        private System.Windows.Forms.ColumnHeader ID;
        private System.Windows.Forms.ColumnHeader FirstName;
        private System.Windows.Forms.ColumnHeader LastName;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSuppID;
        private System.Windows.Forms.TextBox txtSuppName;
        private System.Windows.Forms.TextBox txtSuppEmail;
    }
}