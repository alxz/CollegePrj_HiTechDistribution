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
    public partial class FrmProdSoft : Form
    {
        int frmWidth = 0;
        int frmHeight = 0;
        Software _Soft; //local object type Software
        List<Product> _globProdList;
        public FrmProdSoft(Software soft, List<Product> _productsList)
        {
            InitializeComponent();
            _Soft = soft;
            _globProdList = _productsList; //passing a global list of products to a local list
        }
        private void FrmProdSoft_Load(object sender, EventArgs e)
        {
            //setup form behaviour listViewSoft
            this.TopMost = true;
            frmWidth = this.Width;
            frmHeight = this.Height;
            //Loading form elements and items data to the fields
            LoadItemsListView();
            txtProdID.Text = _Soft.ProdId.ToString();
            txtSwName.Text = _Soft.SoftName;
            txtProdQoH.Text = _Soft.QtyOnHand.ToString();
            txtProdSupId.Text = _Soft.SupplId.ToString();
            txtProdUPrc.Text = _Soft.UnitPrice.ToString();
            chkSoftAct.Checked = _Soft.ProdStatus;
            string catStr = _Soft.SoftCateg.ToString().ToLower();
            for (int i = 0; i < cmbSwCat.Items.Count; i++)
            {
                if (cmbSwCat.Items[i].ToString().ToLower() == catStr)
                {
                    cmbSwCat.Text = _Soft.SoftCateg.ToString();
                }
            }

            string swOsStr = _Soft.OsCateg.ToString().ToLower();
            for (int i = 0; i < cmbSwOS.Items.Count; i++)
            {
                if (cmbSwOS.Items[i].ToString().ToLower() == swOsStr)
                {
                    cmbSwOS.Text = _Soft.OsCateg.ToString();
                }
            }

            //loading suppliers list to cmbSuppId.Items.Clear();
            Supplier aSupp = new Supplier();
            List<Supplier> suppList = HiTech.Business.Supplier.ListAllRecords();
            foreach (Supplier supp in suppList)
            {
                cmbSuppId.Items.Add(supp.SuppId + ", " + supp.SuppName);
            }
            if (_Soft.ProdId != 0)
            {
                for (int i = 0; i < cmbSuppId.Items.Count; i++)
                {
                    string[] fields = cmbSuppId.Items[i].ToString().Split(',');
                    if (Convert.ToInt32(fields[0]) == _Soft.SupplId)
                    {
                        cmbSuppId.Text = cmbSuppId.Items[i].ToString();
                    }
                }
            }

        }

        public bool LoadItemsListView()
        {
            try
            {
                List<Product> products = Product.XMLLoadAllProducts();
                List<Software> listSoft = new List<Software>();
                Software aSoft;
                foreach (Product prod in products)
                {
                    if (prod.ProdCat == ProdCat.Software)
                    {
                        aSoft = new Software();
                        try
                        {
                            aSoft = (Software)prod;
                            listSoft.Add(aSoft);
                        }
                        catch (Exception)
                        {  /* skip; */  }
                    }
                }
                listViewSoft.Items.Clear();
                foreach (Software prod in listSoft)
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = prod.ProdId.ToString();
                    //item.SubItems.Add(prod.ProdName);
                    item.SubItems.Add(prod.SoftName);
                    item.SubItems.Add(prod.UnitPrice.ToString());
                    item.SubItems.Add(prod.QtyOnHand.ToString());
                    item.SubItems.Add(prod.OsCateg.ToString());
                    item.SubItems.Add(prod.SoftCateg.ToString());
                    item.SubItems.Add(prod.SupplId.ToString());
                    item.SubItems.Add(prod.ProdStatus.ToString());
                    listViewSoft.Items.Add(item);
                }
                return true;
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Error loading software to the list! \n\n" + Ex.Message, "Error loading software items",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void btnBookFrmCancel_Click(object sender, EventArgs e)
        {
            //Exit with dialog box
            DialogResult answer = MessageBox.Show("Close this window?", "Confirmation.",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (answer == DialogResult.Yes)
            {
                FrmProdSoft.ActiveForm.Close();
            }
        }

        private void btnSoftFrmOk_Click(object sender, EventArgs e)
        {
            //time to create a new object
            //========================================================
            string valueID, valueSwName, valueUnitPrice, valueSupplId, valueQOH;
            //string valueSwCat, valueSwOS;
            double unitPrice = 0;
            int valueSwCat, valueSwOS;
            //bool prodStatus = true;
            bool isDuplicate = false;
            valueID = txtProdID.Text.Trim();
            valueSwName = txtSwName.Text.Trim();
            valueSwCat = cmbSwCat.SelectedIndex;
            valueSwOS = cmbSwOS.SelectedIndex;
            valueUnitPrice = txtProdUPrc.Text.Trim();
            valueSupplId = txtProdSupId.Text.Trim();
            valueQOH = txtProdQoH.Text.Trim();

            Software prod = new Software();
            if (!Product.isValidId(valueID, 4))
            {
                MessageBox.Show("Product ID is not correct! \n" +
                        "\n\nPlease provide valid client id number...",
                    "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtProdID.Focus();
                return;
            }

            if (valueSwName == "")
            {
                MessageBox.Show("Client Name could not be empty! \nPlease provide valid client name...",
                    "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSwName.Focus();
                return;
            }

            try
            {
                unitPrice = Convert.ToDouble(valueUnitPrice);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unit Price is not correct! \n" + ex.Message +
                       "\n\nPlease provide valid number...",
                   "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                unitPrice = 0;
                txtProdUPrc.Focus();
                return;
            }

            //valueProdCat - set correct
            SoftCat softCat = SoftCat.Other;
            switch (cmbSwCat.SelectedIndex)
            {
                case 0:
                    softCat = SoftCat.OperationSystem;
                    break;
                case 1:
                    softCat = SoftCat.GraphicsDesign;
                    break;
                case 2:
                    softCat = SoftCat.TextEditor;
                    break;
                case 3:
                    softCat = SoftCat.AudioVideoPlay;
                    break;
                case 4:
                    softCat = SoftCat.AudioVedeoEdit;
                    break;
                default:
                    softCat = SoftCat.Other;
                    break;
            }

            OSTypeCat osType = OSTypeCat.Windows;
            switch (cmbSwOS.SelectedIndex)
            {
                case 0:
                    osType = OSTypeCat.Windows;
                    break;
                case 1:
                    osType = OSTypeCat.MacOS;
                    break;
                case 2:
                    osType = OSTypeCat.Linux;
                    break;
                case 3:
                    osType = OSTypeCat.iOS;
                    break;
                case 4:
                    osType = OSTypeCat.Android;
                    break;
                default:
                    osType = OSTypeCat.Windows; //default choise
                    break;
            }
            int supplId, qtyOH;
            //valueSupplId -- loading correct supplier info
            try
            {
                string[] fields = cmbSuppId.Text.Split(',');
                valueSupplId = fields[0];
                supplId = Convert.ToInt32(valueSupplId);
            }
            catch (Exception)
            {                
                valueSupplId = "0";
                supplId = Convert.ToInt32(valueSupplId);
            }

            //checking all cases and go for an object creation:
            if ((prod != null) && (int.TryParse(valueSupplId, out supplId))
                && (int.TryParse(valueQOH, out qtyOH)))
            {
                //all ok so go ahead and assign the values to the object fields
                prod.ProdId = Convert.ToInt32(valueID);
                prod.ProdName = valueSwName;
                prod.SoftName = valueSwName;
                prod.SoftCateg = softCat;
                prod.OsCateg = osType;
                prod.UnitPrice = unitPrice;
                prod.SupplId = supplId;
                prod.QtyOnHand = qtyOH;
                prod.ProdCat = ProdCat.Software;
                prod.ProdStatus = chkSoftAct.Checked;
                List<Product> products = Product.XMLLoadAllProducts();
                if (products == null)
                {
                    products = new List<Product>();
                }
                
                Product prodDup = new Product();
                foreach (Product prodItem in products)
                {
                    if (prodItem.ProdId == prod.ProdId)
                    {
                        isDuplicate = true;
                        //if id is already in use - return true = id duplicate found!      
                        // so may be we want to update the account information?
                        DialogResult answer = MessageBox.Show("This ID is already in use: " + valueID
                            + " \nfor: " + prodItem.ProdName + "\n"
                            + "\nDo you want to update this item information?", "Confirmation on Update",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                        if (answer == DialogResult.Yes)
                        {
                            //continuing update process:
                            prodDup = prodItem;
                            isDuplicate = true;
                        }
                        else
                        {
                            isDuplicate = false;
                            return;
                        }

                    }
                }
                if (isDuplicate)
                {
                    products.Remove(prodDup);//removing old version of updated product from the local list
                }
                products.Add(prod); //adding updated product to the local list
                if (UpdateGlobalProdList(products))
                {
                    //_globProdList.Sort();
                    _globProdList = _globProdList.OrderBy(o => o.ProdId).ToList();
                    Product.SaveAllProducts(_globProdList);
                    MessageBox.Show("Update successfull!",
                        "Success!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                LoadItemsListView();
            }
        }

        private void FrmProdSoft_Resize(object sender, EventArgs e)
        {
            //change viewlist respectively and control form size
            if ((this.Width >= frmWidth) && (this.Height >= frmHeight))
            {
                listViewSoft.Size = new Size(this.Width - 30, this.Height - 310);
                btnSoftFrmOk.Location = new Point(this.Width - 285, this.Height - 85);
                btnSoftFrmCancel.Location = new Point(this.Width - 135, this.Height - 85);
            }
            else
            {
                //if the form size is too small - set it back to start up values
                this.Width = frmWidth;
                this.Height = frmHeight;
            }
        }

        private void listViewSoft_SelectedIndexChanged(object sender, EventArgs e)
        {
            //select an item in the list
            if (listViewSoft.SelectedItems.Count > 0)
            {
                int prodId = 0;
                string prodIdString = listViewSoft.SelectedItems[0].Text.ToString();
                if (int.TryParse(prodIdString, out prodId))
                {
                    //Software prod = Product.SearchRecord(prodId);
                    Software prod = (Software)Product.SearchXMLRecordProd(prodId);
                    if (prod != null)
                    {
                        _Soft = prod;
                        txtProdID.Text = _Soft.ProdId.ToString();
                        txtSwName.Text = _Soft.SoftName;
                        txtProdQoH.Text = _Soft.QtyOnHand.ToString();
                        txtProdSupId.Text = _Soft.SupplId.ToString();
                        txtProdUPrc.Text = _Soft.UnitPrice.ToString();
                        chkSoftAct.Checked = _Soft.ProdStatus;
                        string catStr = _Soft.SoftCateg.ToString().ToLower();
                        for (int i = 0; i < cmbSwCat.Items.Count; i++)
                        {
                            if (cmbSwCat.Items[i].ToString().ToLower() == catStr)
                            {
                                cmbSwCat.Text = _Soft.SoftCateg.ToString();
                            }
                        }

                        string swOsStr = _Soft.OsCateg.ToString().ToLower();
                        for (int i = 0; i < cmbSwOS.Items.Count; i++)
                        {
                            if (cmbSwOS.Items[i].ToString().ToLower() == swOsStr)
                            {
                                cmbSwOS.Text = _Soft.OsCateg.ToString();
                            }
                        }

                        //loading correct supplier info
                        Supplier aSupp = new Supplier();
                        aSupp = HiTech.Business.Supplier.SearchRecord(_Soft.SupplId);
                        for (int i = 0; i < cmbSuppId.Items.Count; i++)
                        {
                            string[] fields = cmbSuppId.Items[i].ToString().Split(',');
                            if (Convert.ToInt32(fields[0]) == _Soft.SupplId)
                            {
                                cmbSuppId.Text = cmbSuppId.Items[i].ToString();
                            }
                        }

                    }
                }
            }
        }


        private bool UpdateGlobalProdList(List<Product> listSoft)
        {
            //_productsList - global list
            //_globProdList = _productsList;
            List<Product> tempList = new List<Product>();
            bool itemFound = false;
            foreach (Product aGlobProd in _globProdList)
            {
                foreach (Product alocalProd in listSoft)
                {
                    if (alocalProd.ProdId != aGlobProd.ProdId) //if a product found
                    {
                        itemFound = true;
                    }
                }
                if (!itemFound)
                {
                    tempList.Add(aGlobProd);
                    itemFound = false;
                }
            }

            foreach (Product alocalProd in listSoft)
            {
                tempList.Add(alocalProd);
            }
            _globProdList = tempList;
            return true;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            //new book
            int nextProdId = Software.NextObjId(Product.XMLLoadAllProducts()); //to generate new client ID
            if (nextProdId == 1)
            {
                nextProdId = 1000; //we restart numbers to follow 4 digits id standards
            }
            txtProdID.Text = nextProdId.ToString();
            txtSwName.Text = "";;
            txtProdQoH.Text = "";
            txtProdSupId.Text = "";
            txtProdUPrc.Text = "";
        }
    }
}
