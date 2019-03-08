using HiTech.Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFrmFProj.GUI
{
    public partial class FrmSupplier : Form
    {
        public FrmSupplier()
        {
            InitializeComponent();
        }

        private void btnSuppFrmClose_Click(object sender, EventArgs e)
        {
            //Exit with dialog box
            //DialogResult answer = MessageBox.Show("Close this window?", "Confirmation.",
            //            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            //if (answer == DialogResult.Yes)
            //{
            //    FrmProdSoft.ActiveForm.Close();
            //}
            ActiveForm.Close();
        }

        public void fillInListViewSupp(List<Supplier> suppliers)
        { //populate a list view with the list of authors
            listViewSupp.Items.Clear();
            foreach (Supplier supp in suppliers)
            {
                ListViewItem item = new ListViewItem();
                item.Text = supp.SuppId.ToString();
                item.SubItems.Add(supp.SuppName);
                item.SubItems.Add(supp.SuppEmail);
                listViewSupp.Items.Add(item);
            }
        }

        private void FrmSupplier_Load(object sender, EventArgs e)
        {
            //update form on load
            fillInListViewSupp(Supplier.ListAllRecords());
        }

        private void btnSuppNew_Click(object sender, EventArgs e)
        {
            int nextSupp = Supplier.NextObjId(Supplier.ListAllRecords()); //to generate new ID
            if (nextSupp == 1)
            {
                nextSupp = 1000; //we restart numbers to follow 4 digits id standards
            }
            txtSuppID.Text = nextSupp.ToString();
            txtSuppName.Text = "";
            txtSuppEmail.Text = "";
            MessageBox.Show("Please enter new Supplier data and click <<Update>> to save the changes", "Help",
                 MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSuppUpd_Click(object sender, EventArgs e)
        {
            int suppId = 0;
            string strId, strName, strEmail;
            Supplier newSupp = new Supplier();
            strId = txtSuppID.Text.Trim();
            strName = txtSuppName.Text.Trim();
            strEmail = txtSuppEmail.Text.Trim();
            if ((strName == "") || (strEmail == ""))
            {
                MessageBox.Show("Missing enter Supplier data! \nPlease enter valid data", "No data",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (Supplier.isValidId(strId, 4))
            {
                try
                {
                    suppId = Convert.ToInt32(strId);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Supplier ID is not correct! \n" + ex.Message +
                        "\n\nPlease provide valid Supplier id number...",
                    "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSuppID.Focus();
                    return;
                }
            }
            newSupp.SuppId = suppId;
            newSupp.SuppName = txtSuppName.Text;
            newSupp.SuppEmail = txtSuppEmail.Text;

            if (Supplier.isDuplicateId(suppId))
            {
                DialogResult answer = MessageBox.Show("This ID is already in use: " + suppId + "\n"
                    + "Do you want to update this account information?", "Confirmation on Update",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (answer == DialogResult.Yes)
                {
                    //update process:
                    Supplier.UpdateRecord(newSupp);
                    fillInListViewSupp(Supplier.ListAllRecords());
                    MessageBox.Show("Information Updated!");
                    return;
                }
                txtSuppID.Focus();
                return;
            }
            Supplier.SaveRecord(newSupp);
            fillInListViewSupp(Supplier.ListAllRecords());
        }

        private void listViewSupp_SelectedIndexChanged(object sender, EventArgs e)
        {
            //select an item in the list listViewSupp
            if (listViewSupp.SelectedItems.Count > 0)
            {
                int suppId = 0;
                //getting currently selected object id:
                string suppIdString = listViewSupp.SelectedItems[0].Text.ToString();
                if (int.TryParse(suppIdString, out suppId))
                {
                    Supplier supp = Supplier.SearchRecord(suppId);
                    if (supp != null)
                    {
                        txtSuppID.Text = supp.SuppId.ToString();
                        txtSuppName.Text = supp.SuppName;
                        txtSuppEmail.Text = supp.SuppEmail;
                    }
                }
            }
        }

        private void btnSuppDel_Click(object sender, EventArgs e)
        {
            //DeleteRecord(Supplier objDelete)
            if (listViewSupp.SelectedItems.Count > 0)
            {
                int suppId = 0;
                //getting currently selected object id:
                string suppIdString = listViewSupp.SelectedItems[0].Text.ToString();
                if (int.TryParse(suppIdString, out suppId))
                {
                    Supplier supp = Supplier.SearchRecord(suppId);
                    if (supp != null)
                    {
                        DialogResult answer = MessageBox.Show("Are you sure to delete record: " + suppId +
                        "\nName:\t" + supp.SuppName + "\nEmail:\t" + supp.SuppEmail, "Confirmation on Delete",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                        if (answer == DialogResult.Yes)
                        {
                            if (Supplier.DeleteRecord(supp)) { MessageBox.Show("Record deleted!"); }
                            fillInListViewSupp(Supplier.ListAllRecords());
                            return;
                        }
                    }
                }
            }
        }
    }
}
