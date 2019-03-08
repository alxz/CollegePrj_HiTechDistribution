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
    public partial class FrmManageAuthor : Form
    {
        public FrmManageAuthor()
        {
            InitializeComponent();
        }

        private void btnAuthNew_Click(object sender, EventArgs e)
        {
            int nextAuth = Author.NextObjId(Author.ListAllRecords()); //to generate new client ID
            if (nextAuth == 1)
            {
                nextAuth = 1000; //we restart numbers to follow 4 digits id standards
            }
            txtAuthorID.Text = nextAuth.ToString();
            txtAuthorFName.Text = "";
            txtAuthorLName.Text = "";
            MessageBox.Show("Please enter new Author data and click <<Update>> to save the changes", "Help",
                 MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnAuthFrmClose_Click(object sender, EventArgs e)
        {
            //Exit with dialog box
            //DialogResult answer = MessageBox.Show("Close this window?", "Confirmation.",
            //            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            //if (answer == DialogResult.Yes)
            //{
            //    FrmProdSoft.ActiveForm.Close();
            //}
            FrmManageAuthor.ActiveForm.Close();
        }

        private void btnAuthUpd_Click(object sender, EventArgs e)
        {
            int authId = 0;
            string strId, strFName, strLName;
            Author newAuth = new Author();
            strId = txtAuthorID.Text.Trim();
            strFName = txtAuthorFName.Text.Trim();
            strLName = txtAuthorLName.Text.Trim();
            if ((strFName == "") || (strLName == ""))
            {
                MessageBox.Show("Missing enter authors data! \nPlease enter valid data", "No data",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (Author.isValidId(strId, 4))
            {
                try
                {
                    authId = Convert.ToInt32(strId);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Author ID is not correct! \n" + ex.Message +
                        "\n\nPlease provide valid client id number...",
                    "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtAuthorID.Focus();
                    return;
                }
            }
            newAuth.AuthId = authId;
            newAuth.AuthFirstName = strFName;
            newAuth.AuthLastName = strLName;

            if (Author.isDuplicateId(authId))
            {
                DialogResult answer = MessageBox.Show("This ID is already in use: " + authId + "\n"
                    + "Do you want to update this account information?", "Confirmation on Update",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (answer == DialogResult.Yes)
                {
                    //update process:
                    Author.UpdateRecord(newAuth);
                    fillInListViewAuth(Author.ListAllRecords());
                    MessageBox.Show("Information Updated!");
                    return;
                }
                txtAuthorID.Focus();
                return;
            }
            Author.SaveRecord(newAuth);
            fillInListViewAuth(Author.ListAllRecords());

        }

        public void fillInListViewAuth(List<Author> authors)
        { //populate a list view with the list of authors
            listViewAuthors.Items.Clear();
            foreach (Author auth in authors)
            {
                ListViewItem item = new ListViewItem();
                item.Text = auth.AuthId.ToString();
                item.SubItems.Add(auth.AuthFirstName);
                item.SubItems.Add(auth.AuthLastName);
                listViewAuthors.Items.Add(item);
            }
        }

        private void FrmManageAuthor_Load(object sender, EventArgs e)
        {
            //update form on load
            fillInListViewAuth(Author.ListAllRecords());
        }

        private void listViewAuthors_SelectedIndexChanged(object sender, EventArgs e)
        {
            //select an item in the list
            if (listViewAuthors.SelectedItems.Count > 0)
            {
                int authId = 0;
                //getting currently selected object id:
                string authIdString = listViewAuthors.SelectedItems[0].Text.ToString();
                if (int.TryParse(authIdString, out authId))
                {
                    Author auth = Author.SearchRecord(authId);
                    if (auth != null)
                    {
                        txtAuthorID.Text = auth.AuthId.ToString();
                        txtAuthorFName.Text = auth.AuthFirstName;
                        txtAuthorLName.Text = auth.AuthLastName;
                    }
                }
            }
        }

        private void btnAuthDel_Click(object sender, EventArgs e)
        {
            //DeleteRecord(Author objDelete)
            if (listViewAuthors.SelectedItems.Count > 0)
            {
                int authId = 0;
                //getting currently selected object id:
                string authIdString = listViewAuthors.SelectedItems[0].Text.ToString();
                if (int.TryParse(authIdString, out authId))
                {
                    Author auth = Author.SearchRecord(authId);
                    if (auth != null)
                    {
                        DialogResult answer = MessageBox.Show("Are you sure to delete record: " + authId + 
                        "\nFirst Name:\t" + auth.AuthFirstName + "\nLast Name:\t" + auth.AuthLastName, "Confirmation on Delete",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                        if (answer == DialogResult.Yes)
                        {
                            if (Author.DeleteRecord(auth)) { MessageBox.Show("Record deleted!"); }                            
                            fillInListViewAuth(Author.ListAllRecords());                            
                            return;
                        }
                    }
                }
            }
        }
    }
}
