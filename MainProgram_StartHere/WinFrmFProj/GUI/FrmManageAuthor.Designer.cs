namespace WinFrmFProj.GUI
{
    partial class FrmManageAuthor
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
            this.txtAuthorID = new System.Windows.Forms.TextBox();
            this.txtAuthorFName = new System.Windows.Forms.TextBox();
            this.txtAuthorLName = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.listViewAuthors = new System.Windows.Forms.ListView();
            this.ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FirstName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LastName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnAuthFrmClose = new System.Windows.Forms.Button();
            this.btnAuthUpd = new System.Windows.Forms.Button();
            this.btnAuthNew = new System.Windows.Forms.Button();
            this.btnAuthDel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtAuthorID
            // 
            this.txtAuthorID.Location = new System.Drawing.Point(70, 11);
            this.txtAuthorID.Margin = new System.Windows.Forms.Padding(2);
            this.txtAuthorID.Name = "txtAuthorID";
            this.txtAuthorID.Size = new System.Drawing.Size(132, 20);
            this.txtAuthorID.TabIndex = 4;
            // 
            // txtAuthorFName
            // 
            this.txtAuthorFName.Location = new System.Drawing.Point(70, 35);
            this.txtAuthorFName.Margin = new System.Windows.Forms.Padding(2);
            this.txtAuthorFName.Name = "txtAuthorFName";
            this.txtAuthorFName.Size = new System.Drawing.Size(132, 20);
            this.txtAuthorFName.TabIndex = 5;
            // 
            // txtAuthorLName
            // 
            this.txtAuthorLName.Location = new System.Drawing.Point(70, 62);
            this.txtAuthorLName.Margin = new System.Windows.Forms.Padding(2);
            this.txtAuthorLName.Name = "txtAuthorLName";
            this.txtAuthorLName.Size = new System.Drawing.Size(132, 20);
            this.txtAuthorLName.TabIndex = 6;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(8, 11);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(55, 13);
            this.label11.TabIndex = 61;
            this.label11.Text = "Author ID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 35);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 63;
            this.label2.Text = "First Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 62);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 62;
            this.label3.Text = "Last Name:";
            // 
            // listViewAuthors
            // 
            this.listViewAuthors.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ID,
            this.FirstName,
            this.LastName});
            this.listViewAuthors.FullRowSelect = true;
            this.listViewAuthors.Location = new System.Drawing.Point(1, 111);
            this.listViewAuthors.Margin = new System.Windows.Forms.Padding(2);
            this.listViewAuthors.Name = "listViewAuthors";
            this.listViewAuthors.Size = new System.Drawing.Size(414, 158);
            this.listViewAuthors.TabIndex = 72;
            this.listViewAuthors.UseCompatibleStateImageBehavior = false;
            this.listViewAuthors.View = System.Windows.Forms.View.Details;
            this.listViewAuthors.SelectedIndexChanged += new System.EventHandler(this.listViewAuthors_SelectedIndexChanged);
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
            // btnAuthFrmClose
            // 
            this.btnAuthFrmClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAuthFrmClose.Location = new System.Drawing.Point(303, 283);
            this.btnAuthFrmClose.Margin = new System.Windows.Forms.Padding(2);
            this.btnAuthFrmClose.Name = "btnAuthFrmClose";
            this.btnAuthFrmClose.Size = new System.Drawing.Size(112, 25);
            this.btnAuthFrmClose.TabIndex = 74;
            this.btnAuthFrmClose.Text = "&Close";
            this.btnAuthFrmClose.UseVisualStyleBackColor = true;
            this.btnAuthFrmClose.Click += new System.EventHandler(this.btnAuthFrmClose_Click);
            // 
            // btnAuthUpd
            // 
            this.btnAuthUpd.Location = new System.Drawing.Point(295, 71);
            this.btnAuthUpd.Margin = new System.Windows.Forms.Padding(2);
            this.btnAuthUpd.Name = "btnAuthUpd";
            this.btnAuthUpd.Size = new System.Drawing.Size(112, 25);
            this.btnAuthUpd.TabIndex = 73;
            this.btnAuthUpd.Text = "&Save";
            this.btnAuthUpd.UseVisualStyleBackColor = true;
            this.btnAuthUpd.Click += new System.EventHandler(this.btnAuthUpd_Click);
            // 
            // btnAuthNew
            // 
            this.btnAuthNew.Location = new System.Drawing.Point(294, 12);
            this.btnAuthNew.Name = "btnAuthNew";
            this.btnAuthNew.Size = new System.Drawing.Size(112, 24);
            this.btnAuthNew.TabIndex = 75;
            this.btnAuthNew.Text = "&New";
            this.btnAuthNew.UseVisualStyleBackColor = true;
            this.btnAuthNew.Click += new System.EventHandler(this.btnAuthNew_Click);
            // 
            // btnAuthDel
            // 
            this.btnAuthDel.Location = new System.Drawing.Point(294, 42);
            this.btnAuthDel.Name = "btnAuthDel";
            this.btnAuthDel.Size = new System.Drawing.Size(112, 24);
            this.btnAuthDel.TabIndex = 76;
            this.btnAuthDel.Text = "Delete";
            this.btnAuthDel.UseVisualStyleBackColor = true;
            this.btnAuthDel.Click += new System.EventHandler(this.btnAuthDel_Click);
            // 
            // FrmManageAuthor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 319);
            this.Controls.Add(this.btnAuthDel);
            this.Controls.Add(this.btnAuthNew);
            this.Controls.Add(this.btnAuthFrmClose);
            this.Controls.Add(this.btnAuthUpd);
            this.Controls.Add(this.listViewAuthors);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtAuthorID);
            this.Controls.Add(this.txtAuthorFName);
            this.Controls.Add(this.txtAuthorLName);
            this.Name = "FrmManageAuthor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage Authors Data";
            this.Load += new System.EventHandler(this.FrmManageAuthor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtAuthorID;
        private System.Windows.Forms.TextBox txtAuthorFName;
        private System.Windows.Forms.TextBox txtAuthorLName;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView listViewAuthors;
        private System.Windows.Forms.ColumnHeader ID;
        private System.Windows.Forms.ColumnHeader FirstName;
        private System.Windows.Forms.ColumnHeader LastName;
        private System.Windows.Forms.Button btnAuthFrmClose;
        private System.Windows.Forms.Button btnAuthUpd;
        private System.Windows.Forms.Button btnAuthNew;
        private System.Windows.Forms.Button btnAuthDel;
    }
}