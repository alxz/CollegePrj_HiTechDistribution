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
    public partial class FrmOrder : Form
    {
        int frmWidth = 0;
        int frmHeight = 0;
        Employee _myEmployee = new Employee();
        DateTime dt = DateTime.Now;
        Product _prod; //current product
        Order _currOrder = new Order();
        List<Product> _globProdList = new List<Product>(); //local copy of the Global List of Products
        List<Product> _basketList = new List<Product>(); //Basket (or Cart) products
        List<OrderItem> _orderItemList = new List<OrderItem>();
        double _totalAmount = 0; //total amount for a products in the cart
        public FrmOrder(Employee employee, Order editOrder, List<Product> productsList)
        {
            InitializeComponent();
            _myEmployee = employee;
            _currOrder = editOrder;
            _globProdList = productsList; //passing a global list of products to a local list
            fillInListViewProd(_globProdList);
        }

        private void FrmOrder_Load(object sender, EventArgs e)
        {
            //Loading form elements and items data to the fields
            this.TopMost = true;
            frmWidth = this.Width;
            frmHeight = this.Height;
            txtCreatedBy.Text = _myEmployee.EmpId + ", " + _myEmployee.FirstName + ", " + _myEmployee.LastName;
            //loading cmbOrdClient
            Product aProduct = new Product();
            Client aClient = new Client();
            Supplier aSupp = new Supplier();
            List<Client> clientList = Client.ListAllRecords();
            List<OrderItem> editOrder = new List<OrderItem>();
            foreach (Client client in clientList)
            {
                cmbOrdClient.Items.Add(client.ClientId + ", " + client.ClientName);
            }
            dtCreatedTime.Value = DateTime.Now; //set the value of data form control
            if (_currOrder == null) //if we pass empty order - then we want to create new order
            {
                _currOrder = new Order();
                _currOrder.CreatedTime = DateTime.Now; //set current time for the order
                btnNew_Click(sender, e);
            }
            else //we want to edit existing order!
            {
                txtOrderID.Text = _currOrder.OrdId.ToString();
                //loading order client name to: cmbOrdClient.SelectedText
                foreach (Client client in clientList)
                {
                    if (_currOrder.ClientId == client.ClientId)
                        cmbOrdClient.Text = (client.ClientId + ", " + client.ClientName);                    
                }

                //loading cmbStatus status
                string ordStatus = _currOrder.OrdState.ToString().ToLower();
                for (int i = 0; i < cmbStatus.Items.Count; i++)
                {
                    if (cmbStatus.Items[i].ToString().ToLower() == ordStatus)
                        cmbStatus.Text = ordStatus;
                }

                //loading cmbTakenBy values
                string ordtakeBy = _currOrder.OrdTakeBy.ToString().ToLower();
                for (int i = 0; i < cmbTakenBy.Items.Count; i++)
                {
                    if (cmbTakenBy.Items[i].ToString().ToLower() == ordtakeBy)
                        cmbTakenBy.Text = ordtakeBy;
                }
                //loading date 
                dtCreatedTime.Value = _currOrder.CreatedTime.Date;
                dtShippingTime.Value = _currOrder.ShippingTime.Date;
                dtrequiredTime.Value = _currOrder.RequiredTime.Date;

                // finding created by:
                Employee emp = Employee.SearchEmployee(_currOrder.CreatedByEmpId);
                    txtCreatedBy.Text = emp.FirstName + ", " + emp.LastName + "  [ EmpID: " + emp.EmpId + " ]";
                    this.Text = "Order created by " + emp.FirstName + ", " + emp.LastName + "  [ EmpID: " + emp.EmpId + " ]";
                //listViewOrdrProd - list of products for existing order
                //editOrder = _currOrder.ProductsList;
                Order ordTemp = Order.SearchXMLRecordProd(_currOrder.OrdId);
                editOrder = ordTemp.ProductsList.ToList();
                foreach (OrderItem orderItem in editOrder)
                {
                    aProduct = Product.SearchXMLRecordProd(orderItem.ItemId);
                    ListViewItem item = new ListViewItem();
                    item.Text = aProduct.ProdId.ToString();  
                    item.SubItems.Add(aProduct.ProdName);
                    item.SubItems.Add(orderItem.ItemVol.ToString()); //how many items of the same kind - QTY/VOL ?
                    item.SubItems.Add(aProduct.ProdCat.ToString());
                    if (aProduct.ProdStatus)
                    {
                        item.SubItems.Add("Active");
                    }
                    else
                    {
                        item.SubItems.Add("Inactive");
                    }

                    item.SubItems.Add(aProduct.UnitPrice.ToString());
                    try
                    {
                        aSupp = Supplier.SearchRecord(aProduct.SupplId);
                        item.SubItems.Add(aSupp.SuppName);
                    }
                    catch (Exception)
                    {
                        item.SubItems.Add("Supplier: Error");
                    }
                    item.SubItems.Add(aProduct.QtyOnHand.ToString());
                    listViewOrdrProd.Items.Add(item);
                    _basketList.Add(aProduct);
                    _orderItemList.Add(orderItem);
                    _totalAmount = _totalAmount + (aProduct.UnitPrice * orderItem.ItemVol);
                    txtAmount.Text = _totalAmount.ToString();
                }             
            }
        }


        private void AddProdToBasketListView(Product aProduct, int itemVol)
        {
            List<Product> prodList = _basketList;
            int prodId = aProduct.ProdId;
            if ((aProduct != null) && (aProduct.ProdId != 0))
            {
                OrderItem orderItem = new OrderItem();
                Supplier aSupp = new Supplier();

                OrderItem orderItemExists = (_orderItemList.Find(x => x.ItemId == prodId));

                if (orderItemExists != null) //if (prodList.Find( x=>x.ProdId == prodId) == null)
                {
                    itemVol = itemVol + orderItemExists.ItemVol;
                    _orderItemList.Remove(new OrderItem() { ItemId = prodId });
                }
                if (prodList.Find(x => x.ProdId == prodId) != null)
                {
                    foreach (ListViewItem itemListView in listViewOrdrProd.Items)
                    {
                        if (itemListView.Text == prodId.ToString())
                        {
                            listViewOrdrProd.Items.Remove(itemListView);
                        }                        
                    }                    
                    _basketList.Remove(new Product() { ProdId = prodId });
                }
                ListViewItem item = new ListViewItem();
                item.Text = aProduct.ProdId.ToString();
                item.SubItems.Add(aProduct.ProdName);
                item.SubItems.Add(itemVol.ToString()); //how many items of the same kind - QTY/VOL ?
                item.SubItems.Add(aProduct.ProdCat.ToString());
                if (aProduct.ProdStatus)
                {
                    item.SubItems.Add("Active");
                }
                else
                {
                    item.SubItems.Add("Inactive");
                }

                item.SubItems.Add(aProduct.UnitPrice.ToString());
                try
                {
                    aSupp = Supplier.SearchRecord(aProduct.SupplId);
                    item.SubItems.Add(aSupp.SuppName);
                }
                catch (Exception)
                {
                    item.SubItems.Add("Supplier: Error");
                }
                item.SubItems.Add(aProduct.QtyOnHand.ToString());
                listViewOrdrProd.Items.Add(item);
                _basketList.Add(aProduct); //Products in the cart sits here
                //adding an item with vol to the global list "_orderItemList"
                orderItem.ItemId = aProduct.ProdId;
                orderItem.UnitPrice = aProduct.UnitPrice;
                orderItem.ItemVol = itemVol;
                _orderItemList.Add(orderItem);                
                _totalAmount = _totalAmount + (aProduct.UnitPrice * itemVol);
                txtAmount.Text = _totalAmount.ToString();               

            }
        }

        private void btnBookFrmCancel_Click(object sender, EventArgs e)
        {
            //Exit with dialog box
            DialogResult answer = MessageBox.Show("Close this window?", "Confirmation.",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (answer == DialogResult.Yes)
            {
                ActiveForm.Close();
            }
        }

        public void LoadAllProductsList()
        {//lstAllProdView - all products

            lstAllProdView.Items.Clear();
            //loading the list of products into a global list
            try
            {
                _globProdList = Product.XMLLoadAllProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data from XML file!!!\n" + ex.Message, "Error!");
                List<Product> _globProdList = new List<Product>();
            }

            //sending the list to the listView
            fillInListViewProd(_globProdList);
        }

        public void fillInListViewProd(List<Product> products)
        {
            //int suppId;
            Supplier aSupp = new Supplier();
            lstAllProdView.Items.Clear();
            foreach (Product prod in products)
            {
                ListViewItem item = new ListViewItem();
                item.Text = prod.ProdId.ToString();
                item.SubItems.Add(prod.ProdName);
                item.SubItems.Add(prod.ProdCat.ToString());
                if (prod.ProdStatus)
                {
                    item.SubItems.Add("Active");
                }
                else
                {
                    item.SubItems.Add("Inactive");
                }
                
                item.SubItems.Add(prod.UnitPrice.ToString());
                try
                {
                    aSupp = Supplier.SearchRecord(prod.SupplId);
                    item.SubItems.Add(aSupp.SuppName);
                }
                catch (Exception)
                {
                    item.SubItems.Add("Supplier: Error");
                }

                item.SubItems.Add(prod.QtyOnHand.ToString());
                lstAllProdView.Items.Add(item);
            }
        }

        private void lstAllProdView_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (lstAllProdView.SelectedItems.Count > 0)
                {
                    int prodId = 0;
                    string prodIdString = lstAllProdView.SelectedItems[0].Text.ToString();
                    if (int.TryParse(prodIdString, out prodId))
                    {
                        //Product prod = Product.SearchRecord(prodId);
                        _prod = Product.SearchXMLRecordProd(prodId);
                        txtProdSelected.Text = _prod.ProdId + " _:_ " + _prod.ProdName + " _:_ " + _prod.ProdCat;
                        numItemsVol.Value = 1;
                    }
                }
            }
            catch (Exception)
            {
                //exit
            }
        }

        private void lstAllProdView_DoubleClick(object sender, EventArgs e)
        {
            int itemVol = 1;
            if ((_prod != null) && (_prod.ProdId != 0))
            {
                if (numItemsVol.Value > 0)
                {
                    itemVol = Convert.ToInt32(numItemsVol.Value);
                }
                AddProdToBasketListView(_prod, itemVol);
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            int itemVol = 1;
            if ((_prod != null) && (_prod.ProdId != 0))
            {
                if (numItemsVol.Value > 0)
                {
                    itemVol = Convert.ToInt32(numItemsVol.Value);
                }
                AddProdToBasketListView(_prod, itemVol);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            //new book
            int nextOrderId = Order.NextObjId(Order.XMLLoadAllProducts()); //to generate new client ID
            if (nextOrderId == 1)
            {
                nextOrderId = 1000; //we restart numbers to follow 4 digits id standards
            }
            txtOrderID.Text = nextOrderId.ToString();
            txtAmount.Text = "";
            dtCreatedTime.Value = DateTime.Now;
            dtShippingTime.Value = DateTime.Now;
            dtrequiredTime.Value = DateTime.Now;
            _currOrder.CreatedTime = DateTime.Now; //set current time for the order

            //txtReqTime.Text = "";
            //txtShipTime.Text = "";
            cmbOrdClient.Text = "";
            cmbTakenBy.Text = "";
            cmbStatus.Text = "";
        }

        private void cmbOrdClient_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnOrderFrmOk_Click(object sender, EventArgs e)
        {// SAVE ORDER BUTTON =============================================
            
            List<Order> ordersList = new List<Order>();
            //List<Order> ordersListTemp = new List<Order>();
            string valClIdStr;
            DateTime dtCreated, dtShip, dtReq;
            int ordrId, clientId, createdBy;
            int takenByIdx, stateIdx;
            bool isDuplicate = false;
            ordrId = Convert.ToInt32(txtOrderID.Text.Trim());
            
            ordersList = Order.XMLLoadAllProducts(); //loading orders information from file into memory

            if (Order.isDuplicate(ordrId))
            {
                //if id is already in use - return true = id duplicate found!      
                // so may be we want to update the account information?
                DialogResult answer = MessageBox.Show("This ID is already in use: " + ordrId.ToString() + "\n"
                    + "\nDo you want to update this Order information?", "Confirmation on Update",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (answer == DialogResult.Yes)
                {
                    isDuplicate = true;
                }
                else
                {
                    isDuplicate = false;
                    return;
                }
            }
            
            if (cmbStatus.Text == "")
            {
                MessageBox.Show("Order Status is not correct! \n\nPlease provide valid order status...",
                    "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbStatus.Focus();
                return;
            }
            stateIdx = cmbStatus.SelectedIndex;
            if (cmbTakenBy.Text == "")
            {
                MessageBox.Show("Order Taken By value is not correct! \n" +
                        "\n\nPlease provide how this order is taken (Phone/Fax/Email) ...",
                    "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbTakenBy.Focus();
                return;
            }
            takenByIdx = cmbTakenBy.SelectedIndex;
            createdBy = _myEmployee.EmpId;
            //clientId  -- loading correct supplier info
            try
            {
                string[] fields = cmbOrdClient.Text.Split(',');
                valClIdStr = fields[0];
                clientId = Convert.ToInt32(valClIdStr);
            }
            catch (Exception)
            {
                valClIdStr = "0";
                clientId = Convert.ToInt32(valClIdStr);
            }
            _currOrder.TotalAmount = _totalAmount;
            _currOrder.OrdId = ordrId;

            //dtCreated, dtShip, dtReq
            dtCreated = dtCreatedTime.Value;
            dtShip = dtShippingTime.Value;
            dtReq = dtrequiredTime.Value;

            if ((dtReq - dtShip).TotalDays > 1)
            {
                MessageBox.Show("The order shipping date should be based on the required date!" + 
                    "\n(e.g. one day before tje required date!)");
                dtShippingTime.Focus();
                return;
            }

            if ((dtShip - dtCreated).TotalDays < 0)
            {
                MessageBox.Show("The order shipping date must be greater than order created date!" +
                    "\nPlease fix order dates!");
                dtShippingTime.Focus();
                return;
            }
            if ((dtReq - dtShip).TotalDays <= 0)
            {
                MessageBox.Show("The order required date must be greater than or similar to the order shipping date!" +
                    "\nPlease fix order dates!");
                dtShippingTime.Focus();
                return;
            }
            _currOrder.CreatedTime = dtCreatedTime.Value;
            _currOrder.RequiredTime = dtrequiredTime.Value;
            _currOrder.ShippingTime = dtShippingTime.Value;
            _currOrder.CreatedByEmpId = createdBy;
            _currOrder.ClientId = clientId;           

            switch (stateIdx)
            {
                case 0:
                    _currOrder.OrdState = OrderState.New;
                    break;
                case 1:
                    _currOrder.OrdState = OrderState.Hold;
                    break;
                case 2:
                    _currOrder.OrdState = OrderState.Shipped;
                    break;
                case 3:
                    _currOrder.OrdState = OrderState.Delivered;
                    break;
                case 4:
                    _currOrder.OrdState = OrderState.Closed;
                    break;
                default:
                    _currOrder.OrdState = OrderState.New;
                    break;
            }

            switch (takenByIdx) //_currOrder.OrdTakeBy = valTakenBy;
            {
                case 0:
                    _currOrder.OrdTakeBy = OrderTakeBy.Phone;
                    break;
                case 1:
                    _currOrder.OrdTakeBy = OrderTakeBy.Fax;
                    break;
                case 2:
                    _currOrder.OrdTakeBy = OrderTakeBy.Email;
                    break;
                default:
                    _currOrder.OrdTakeBy = OrderTakeBy.Phone;
                    break;
            }

            _currOrder.ProductsList = _orderItemList; //adding a list of items to the currentProduct            
            
            //lets review our basket and copy only required parameters:
            //there is no sense to create an order if there is no items in the order (empty)
            if ((_currOrder.ProductsList.Count ==0) || (_basketList == null))
            {
                MessageBox.Show("Orders Product List Cannot be Empty! \n" +
                        "\n\nPlease review the list ...",
                    "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtOrderID.Focus();
                return;
            }

            if (isDuplicate)
            {
                Order ordTemp = new Order();
                ordTemp = Order.SearchXMLRecordProd(ordrId);
                //ordersList.Remove(ordTemp);//removing old version of updated order from the local list
                List<Order> tempOrdList = new List<Order>();
                foreach (Order ordItem in ordersList)
                {
                    if (ordItem.OrdId != ordTemp.OrdId)
                    {
                        tempOrdList.Add(ordItem);
                    }
                }
                ordersList = tempOrdList;
            }
            ordersList.Add(_currOrder);
            List<Order> SortedList = ordersList.OrderBy(o => o.OrdId).ToList();
            Order.SaveAllProducts(SortedList);
            //Order.SaveAllProducts(ordersList);
            MessageBox.Show("Operation completed!", "Notification");
            this.Close();
        }

        private void btnDelItemCart_Click(object sender, EventArgs e)
        {
            int itemToRem = 0;
            string prodIdString = listViewOrdrProd.SelectedItems[0].Text;
            if (int.TryParse(prodIdString, out itemToRem))
            {
                listViewOrdrProd.Items.Remove(listViewOrdrProd.SelectedItems[0]);
                OrderItem ordrItemRem = _orderItemList.Find(o => o.ItemId == itemToRem);
                Product prodItemRem = _basketList.Find(o => o.ProdId == itemToRem);
                _orderItemList.Remove(ordrItemRem);
                _basketList.Remove(prodItemRem);
                _currOrder.ProductsList = _orderItemList.ToList();
            }
        }
    }
}
