using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using HiTech.Business;

namespace WinFrmFProj.GUI
{

    public partial class FrmProdBook : Form
    {
        int frmWidth = 0;
        int frmHeight = 0;
        DateTime dt = DateTime.Now;
        Book _Book; //local object type Book
        List<Product> _globProdList; //local copy of the Global List of Products
        public FrmProdBook(Book book, List<Product> _productsList)
        {
            InitializeComponent();
            _Book = book;
            _globProdList = _productsList; //passing a global list of products to a local list
        }
        private void FrmProdBook_Load(object sender, EventArgs e)
        {
            //Loading form elements and items data to the fields
            this.TopMost = true;
            frmWidth = this.Width;
            frmHeight = this.Height;
            LoadItemsListView();
            txtProdID.Text = _Book.ProdId.ToString();
            txtbookTitle.Text = _Book.BookTitle;
            txtbookISBN.Text = _Book.BookISBN;
            txtProdQoH.Text = _Book.QtyOnHand.ToString();
            txtProdSupId.Text = _Book.SupplId.ToString();
            txtProdUPrc.Text = _Book.UnitPrice.ToString();
            txtyearReleased.Text = _Book.YearReleased.ToString();
            if (_Book.ProdId == 0)
            {
                int nextBookId = Book.NextObjId(Product.XMLLoadAllProducts()); //to generate new client ID
                if (nextBookId == 1)
                {
                    nextBookId = 1000; //we restart numbers to follow 4 digits id standards
                }
                txtProdID.Text = nextBookId.ToString();
                txtbookTitle.Text = "";
                txtbookISBN.Text = "";
                txtProdQoH.Text = "";
                txtProdSupId.Text = "";
                txtProdUPrc.Text = "";
                txtyearReleased.Text = "";
            }
            //loading books category
            chkBookAct.Checked = _Book.ProdStatus;
            string catStr = _Book.BookCat.ToString().ToLower();
                for (int i = 0; i < cmbBookCat.Items.Count; i++)
                {
                    if (cmbBookCat.Items[i].ToString().ToLower() == catStr)
                    {
                        cmbBookCat.Text = _Book.BookCat.ToString();
                    }
                }
            //loading cmbProdAuth with Author.ListAllRecords()
            List<Author> listAuth = new List<Author>();
            listAuth = Author.ListAllRecords();
                foreach (Author anAuthor in listAuth)
                {
                    cmbProdAuth.Items.Add(anAuthor.AuthId + ", " + anAuthor.AuthFirstName + ", " + anAuthor.AuthLastName);
                }
            //adding list of authors of the current item
                listBoxBookAuth.Items.Clear();
            if (_Book.ProdId != 0)
            {
                foreach (Author anAuthor in _Book.ListAuthors)
                {
                    listBoxBookAuth.Items.Add(anAuthor.AuthId + ", " + anAuthor.AuthFirstName + ", " + anAuthor.AuthLastName);
                }
            }

            //loading suppliers list to cmbSuppId.Items.Clear();
            Supplier aSupp = new Supplier();
            List<Supplier> suppList = HiTech.Business.Supplier.ListAllRecords();
                foreach (Supplier supp in suppList)
                {
                    cmbSuppId.Items.Add(supp.SuppId + ", " + supp.SuppName);
                }
            if (_Book.ProdId != 0)
            {
                for (int i = 0; i < cmbSuppId.Items.Count; i++)
                {
                    string[] fields = cmbSuppId.Items[i].ToString().Split(',');
                    if (Convert.ToInt32(fields[0]) == _Book.SupplId)
                    {
                        cmbSuppId.Text = cmbSuppId.Items[i].ToString();
                    }
                }
            }
                

        }
        private void btnBookFrmCancel_Click(object sender, EventArgs e)
        {
            //Exit with dialog box
            DialogResult answer = MessageBox.Show("Close this window?", "Confirmation.",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (answer == DialogResult.Yes)
            {
                FrmProdBook.ActiveForm.Close();
            }
        }

        private void btnBookFrmOk_Click(object sender, EventArgs e)
        {
            //time to create a new object
            //========================================================
            string valueID, valueTitle, valueUnitPrice, valueSupplId, valueQOH;
            string valueISBN, valueYRelease;
            double unitPrice = 0;
            int valueProdCat;
            bool isDuplicate = false;
            valueID = txtProdID.Text.Trim();
            valueTitle = txtbookTitle.Text.Trim();
            valueISBN = txtbookISBN.Text.Trim().ToUpper();
            valueProdCat = cmbBookCat.SelectedIndex;
            valueYRelease = txtyearReleased.Text.Trim();
            valueUnitPrice = txtProdUPrc.Text.Trim();
            //valueSupplId = txtProdSupId.Text.Trim();
            valueQOH = txtProdQoH.Text.Trim();

            Book prod = new Book();
            if (!Product.isValidId(valueID, 4))
            {
                MessageBox.Show("Product ID is not correct! \n" +
                        "\n\nPlease provide valid id number...",
                    "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtProdID.Focus();
                return;
            }

            if (valueTitle == "")
            {
                MessageBox.Show("Client Name could not be empty! \nPlease provide valid client name...",
                    "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtbookTitle.Focus();
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
            BookCateg bookCat = BookCateg.Other;
            switch (cmbBookCat.SelectedIndex)
            {
                case 0:
                    bookCat = BookCateg.Text_Book;
                    break;
                case 1:
                    bookCat = BookCateg.Science_Fiction;
                    break;
                case 2:
                    bookCat = BookCateg.Satire;
                    break;
                case 3:
                    bookCat = BookCateg.Drama;
                    break;
                case 4:
                    bookCat = BookCateg.Action_Adventure;
                    break;
                case 5:
                    bookCat = BookCateg.Romance;
                    break;
                case 6:
                    bookCat = BookCateg.Mystery;
                    break;
                case 7:
                    bookCat = BookCateg.Horror;
                    break;
                case 8:
                    bookCat = BookCateg.Horror;
                    break;
                default:
                    bookCat = BookCateg.Self_help;
                    break;
            }
            int supplId, qtyOH, yearRel;

            //creating an Authors
            Author myAuthor;
            List<Author> myListAuth = new List<Author>();
            if (listBoxBookAuth.Items.Count > 0)
            {
                for (int i = 0; i < listBoxBookAuth.Items.Count; i++)
                {
                    myAuthor = new Author();
                    string[] fields = listBoxBookAuth.Items[i].ToString().Split(',');
                    myAuthor.AuthId = Convert.ToInt32(fields[0].Trim());
                    myAuthor.AuthFirstName = fields[1].ToString().Trim();
                    myAuthor.AuthLastName = fields[2].ToString().Trim();
                    myListAuth.Add(myAuthor);
                }
                prod.ListAuthors = myListAuth;
            }
            if (!(int.TryParse(valueYRelease, out yearRel)) || yearRel < dt.Year-100 || yearRel > dt.Year)
            {
                MessageBox.Show("Wrong data in Release year! \n Please fix this value...");
                return;
            }
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
                prod.ProdName = valueTitle;
                prod.BookCat = bookCat;
                prod.UnitPrice = unitPrice;
                prod.SupplId = supplId;
                prod.QtyOnHand = qtyOH;
                prod.ProdCat = ProdCat.Book;
                prod.ProdStatus = chkBookAct.Checked;
                prod.BookISBN = valueISBN;
                prod.BookTitle = valueTitle;
                prod.YearReleased = (Convert.ToInt32(valueYRelease));
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
                            +" \nfor: " + prodItem.ProdName + "\n"
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
                }
                //Product.SaveAllProducts(products);
                LoadItemsListView();
                MessageBox.Show("Update successfull!",
                    "Success!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnBookAuthAdd_Click(object sender, EventArgs e)
        {
            if ((listBoxBookAuth.Items.Count == 0) && (cmbProdAuth.Text !=""))
            {
                listBoxBookAuth.Items.Add(cmbProdAuth.Text);
            }
            else
            {
                for (int i = 0; i < listBoxBookAuth.Items.Count; i++)
                {
                    if (!listBoxBookAuth.Items.Contains(cmbProdAuth.Text))
                    {
                        listBoxBookAuth.Items.Add(cmbProdAuth.Text);
                    }
                    //listBoxBookAuth.Items.RemoveAt(i);
                }
            }
                

        }

        private void btnBookAuthRem_Click(object sender, EventArgs e)
        {
            listBoxBookAuth.Items.Remove(listBoxBookAuth.SelectedItem);
        }

        private void btnBookAuthClr_Click(object sender, EventArgs e)
        {
            listBoxBookAuth.Items.Clear();
        }

        private void FrmProdBook_Resize(object sender, EventArgs e)
        {//change viewlist respectively and control form size
            if ((this.Width > 565) && (this.Height > 443))
            {
                listViewBooks.Size = new Size(this.Width - 30, this.Height - 310);
                btnBookFrmOk.Location = new Point(this.Width - 285, this.Height - 85);
                btnBookFrmCancel.Location = new Point(this.Width - 135, this.Height - 85);
            }
            else
            {
                //if the form size is too small - set it back to start up values
                this.Width = frmWidth;
                this.Height = frmHeight;
            }

        }

        public void ChangeSize(int width, int height)
        {            
            if ((this.Width > 565) && (this.Height > 443))
            {
                this.Size = new Size(width, height);
            }
        }

        public bool LoadItemsListView()
        {
            try
            {
                List<Product> products = Product.XMLLoadAllProducts();
                List<Book> listBooks = new List<Book>();
                Book aBook;
                foreach (Product prod in products)
                {
                    if (prod.ProdCat == ProdCat.Book)
                    {
                        aBook = new Book();
                        try
                        {
                            aBook = (Book)prod;
                            listBooks.Add(aBook);
                        }
                        catch (Exception)
                        {  /* skip; */  }
                    }
                }
                listViewBooks.Items.Clear();
                foreach (Book prod in listBooks)
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = prod.ProdId.ToString();
                    item.SubItems.Add(prod.ProdName);
                    item.SubItems.Add(prod.BookISBN);
                    item.SubItems.Add(prod.UnitPrice.ToString());
                    item.SubItems.Add(prod.QtyOnHand.ToString());
                    item.SubItems.Add(prod.BookCat.ToString());
                    item.SubItems.Add(prod.GetAuthorsString());
                    item.SubItems.Add(prod.YearReleased.ToString());
                    item.SubItems.Add(prod.SupplId.ToString());
                    item.SubItems.Add(prod.ProdStatus.ToString());
                    listViewBooks.Items.Add(item);
                }
                return true;
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Error loading books to the list! \n\n" + Ex.Message, "Error loading books", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void btnBookActiv_Click(object sender, EventArgs e)
        {
            ////activate deactivate
        }

        private void listViewBooks_SelectedIndexChanged(object sender, EventArgs e)
        {
            //select an item in the list
            if (listViewBooks.SelectedItems.Count > 0)
            {
                int prodId = 0;
                string prodIdString = listViewBooks.SelectedItems[0].Text.ToString();
                if (int.TryParse(prodIdString, out prodId))
                {
                    //Product prod = Product.SearchRecord(prodId);
                    Book prod = (Book) Product.SearchXMLRecordProd(prodId);
                    if (prod != null)
                    {
                        _Book = prod;
                        txtProdID.Text = _Book.ProdId.ToString();
                        txtbookTitle.Text = _Book.BookTitle;
                        txtbookISBN.Text = _Book.BookISBN;
                        txtProdQoH.Text = _Book.QtyOnHand.ToString();
                        txtProdSupId.Text = _Book.SupplId.ToString();
                        txtProdUPrc.Text = _Book.UnitPrice.ToString();
                        txtyearReleased.Text = _Book.YearReleased.ToString();
                        chkBookAct.Checked = _Book.ProdStatus;
                        string catStr = _Book.BookCat.ToString().ToLower();
                            for (int i = 0; i < cmbBookCat.Items.Count; i++)
                            {
                                if (cmbBookCat.Items[i].ToString().ToLower() == catStr)
                                {
                                    cmbBookCat.Text = _Book.BookCat.ToString();
                                }
                            }
                        //adding list of authors
                        listBoxBookAuth.Items.Clear();
                        foreach (Author anAuthor in prod.ListAuthors)
                        {
                            listBoxBookAuth.Items.Add(anAuthor.AuthId + ", " + anAuthor.AuthFirstName + ", " + anAuthor.AuthLastName);
                        }
                        //loading correct supplier info
                        Supplier aSupp = new Supplier();
                        aSupp = HiTech.Business.Supplier.SearchRecord(_Book.SupplId);
                        for (int i = 0; i < cmbSuppId.Items.Count; i++)
                        {
                            string[] fields = cmbSuppId.Items[i].ToString().Split(',');
                            if (Convert.ToInt32(fields[0]) == _Book.SupplId)
                            {
                                cmbSuppId.Text = cmbSuppId.Items[i].ToString();
                            }
                        }
                    }
                }
            }
        }

        private bool UpdateGlobalProdList (List<Product> listBooks)
        {
            //_productsList - global list
            //_globProdList = _productsList;
            List<Product> tempList = new List<Product>();
            bool itemFound = false;
            foreach (Product aGlobProd in _globProdList)
            {
                foreach (Product alocalProd in listBooks)
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

            foreach (Product alocalProd in listBooks)
            {
                tempList.Add(alocalProd);
            }
            _globProdList = tempList;
            return true;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            //new book
            int nextBookId = Book.NextObjId(Product.XMLLoadAllProducts()); //to generate new client ID
            if (nextBookId == 1)
            {
                nextBookId = 1000; //we restart numbers to follow 4 digits id standards
            }
            txtProdID.Text = nextBookId.ToString();
            txtbookTitle.Text = "";
            txtbookISBN.Text = "";
            txtProdQoH.Text = "";
            txtProdSupId.Text = "";
            txtProdUPrc.Text = "";
            txtyearReleased.Text = "";
        }


    }
}
