using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using HiTech.Business;
using WinFrmFProj.GUI;

namespace HiTech.GUI
{
    public partial class FrmManageAccount : Form
    {
        List<Product> _productsList;
        Employee _employee = new Employee();
        static string filePath = Application.StartupPath + @"\";
        public FrmManageAccount(Employee empLoggedIn)
        {
            InitializeComponent();
            _employee = empLoggedIn; //let get employee who logged in credentials
            Version version = Assembly.GetExecutingAssembly().GetName().Version;
            try
            {
                this.Text = "ID: " + empLoggedIn.EmpId + ",\t Name: " + empLoggedIn.FirstName + ",\t " + empLoggedIn.LastName +
                "; JobCode: " + empLoggedIn.JobTitle +
                "; Dev v4.5";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sorry, there is an error while login!\n" + ex.Message, "login Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error );
                Application.Exit();
                ;
            }
                   
            // set initial size of the form:
            this.Size = new Size(800, 550);
            btnListAll_Click(null, null);
            // Set the view to show details.
            listViewEE.View = View.Details;
            // Select the item and subitems when selection is made.
            listViewEE.FullRowSelect = true;
            // Display grid lines.
            listViewEE.GridLines = true;
            // Sort the items in the list in ascending order.
            listViewEE.Sorting = SortOrder.Ascending;
            try
            {
                switch (empLoggedIn.JobTitle)
                {
                    case 0:
                        {
                            tabCtrl1.TabPages.Remove(tabMngEmp);
                            tabCtrl1.TabPages.Remove(tabMngClient);
                            tabCtrl1.TabPages.Remove(tabMngProduct);
                            tabCtrl1.TabPages.Remove(tabMngOrder);
                            noAccessUserWarn.BringToFront();
                            break;
                        }
                    case 1:
                        {
                            //MIS Manager - Manage Employees
                            //tabCtrl1.TabPages.Remove(tabMngEmp);
                            tabCtrl1.TabPages.Remove(tabMngClient);
                            tabCtrl1.TabPages.Remove(tabMngProduct);
                            tabCtrl1.TabPages.Remove(tabMngOrder);
                            if (listViewEE.Items.Count > 0)
                            {
                                listViewEE.Items[0].Selected = true;
                                listViewEE.Select();
                            }
                            break;
                        }
                    case 2:
                        {
                            tabCtrl1.TabPages.Remove(tabMngEmp);
                            //tabCtrl1.TabPages.Remove(tabMngClient);
                            tabCtrl1.TabPages.Remove(tabMngProduct);
                            tabCtrl1.TabPages.Remove(tabMngOrder);
                            break;
                        }

                    case 3:
                        {
                            tabCtrl1.TabPages.Remove(tabMngEmp);
                            tabCtrl1.TabPages.Remove(tabMngClient);
                            //tabCtrl1.TabPages.Remove(tabMngProduct);
                            tabCtrl1.TabPages.Remove(tabMngOrder);
                            break;
                        }
                    case 4:
                        {
                            tabCtrl1.TabPages.Remove(tabMngEmp);
                            tabCtrl1.TabPages.Remove(tabMngClient);
                            tabCtrl1.TabPages.Remove(tabMngProduct);
                            //tabCtrl1.TabPages.Remove(tabMngOrder);
                            break;
                        }
                    case 5:
                        {
                            //tabCtrl1.TabPages.Remove(tabMngEmp);
                            //tabCtrl1.TabPages.Remove(tabMngClient);
                            //tabCtrl1.TabPages.Remove(tabMngProduct);
                            //tabCtrl1.TabPages.Remove(tabMngOrder);
                            break;
                        }
                    default:
                        {// Application will exit if a user is not registerd and has invalid job-title
                            Application.Exit();
                            break;
                        }
                }
            }
            catch (Exception)
            {
                Application.Exit();
            }
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //Exit with dialog box
            DialogResult answer = MessageBox.Show("Close this window?", "Confirmation.",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (answer == DialogResult.Yes)
            {
                FrmManageAccount.ActiveForm.Close();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //Saving the changes to Employee list            
            string valueID, valueUser, valueFName, valueLName, valuePhone, empPass1, empPass2;
            string picFilePath;
            int valueJob;
            bool flagStatus = true;
            Employee employee = new Employee();
            valueID = txtBoxEmpId.Text.Trim();
            valueUser = txtUser.Text.Trim();
            valueFName = txtBoxFName.Text.Trim();
            valueLName = txtBoxLName.Text.Trim();
            valueJob = cmbBoxTitle.SelectedIndex;
            empPass1 = txtPass1.Text.Trim();
            empPass2 = txtPass2.Text.Trim();
            valuePhone = txtBoxPhone.Text.Trim();
            picFilePath = lblPic.Text;
            // Using different validtions methods to check if all ok:
            if ((Employee.isValidId(valueID, 4)) &&                
                (Employee.isValidUser(valueUser)) &&                
                (Employee.isValidName(valueFName)) &&
                (Employee.isValidName(valueLName)))
            {
                //checking password
                if (empPass1 == "")
                {
                    MessageBox.Show("Password could not be empty! \nPlease verify and correct password!", "Warning!");
                    return;
                }
                if (empPass1 != empPass2)
                {
                    MessageBox.Show("Password string does not match! \nPlease verify and correct password!", "Warning!");
                    return; //something went wrong so we are interrupting this action
                }
                //all ok so go ahead and assign the values to the object fields
                employee.EmpId = Convert.ToInt32(valueID.ToString());
                employee.FirstName = valueFName;
                employee.LastName = valueLName;
                employee.JobTitle = valueJob;
                employee.EmpStatus = flagStatus;
                employee.EmpUserName = valueUser.ToLower();
                employee.EmpPassword = empPass1;
                employee.EmpPhone = valuePhone;
                employee.PictPath = picFilePath;
            }
            else
            {
                return; //something went wrong so we are interrupting this action
            }

            if ((!Employee.isDuplicateUser(valueUser)) &&
                (!Employee.isDuplicate(Convert.ToInt32(valueID))))
            {
                //if all ok we will save the changes and show confirmation
                employee.SaveEmployee(employee);
                MessageBox.Show("Employee Data Saved successfully", "Confirmation",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                //if id is already in use - return true = id duplicate found!      
                // so may be we want to update the account information?
                DialogResult answer = MessageBox.Show("This ID is already in use: " + valueID + "\n"
                    + "Do you want to update this user account information?", "Confirmation on Update",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (answer == DialogResult.Yes)
                {
                    //continuing update process:

                    if (employee.EmpStatus)
                    {
                        employee.StatComment = "updated since " + DateTime.Now.ToString("M/d/yyyy");
                    }
                    else
                    {
                        employee.StatComment = "updated since " + DateTime.Now.ToString("M/d/yyyy");
                    }                    
                    Employee.UpdateRecord(employee);
                    btnListAll_Click(sender, e);
                }
                else
                {
                    return;
                }
            }
            
        }

        private void btnListAll_Click(object sender, EventArgs e)
        {
            listViewEE.Items.Clear();
            
            List<Employee> employees = Employee.ListAllRecords();

            foreach (Employee emp in employees)
            {
                if (emp.EmpStatus)
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = emp.EmpId.ToString(); //Employee  ID
                    item.SubItems.Add(emp.FirstName.ToString()); // EE Fname
                    item.SubItems.Add(emp.LastName.ToString()); // EE Lname
                    item.SubItems.Add(decodeEmpJobCode(emp.JobTitle)); // EE Job Title
                    item.SubItems.Add(decodeEmpStatus(emp.EmpStatus)); // EE Status
                    item.SubItems.Add(emp.StatComment); // EE Status Comments
                    item.SubItems.Add(emp.PictPath);
                    item.SubItems.Add(emp.EmpPhone);
                    listViewEE.Items.Add(item);
                }
                else if (chkBoxShowInAct.Checked)
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = emp.EmpId.ToString(); //Employee  ID
                    item.SubItems.Add(emp.FirstName.ToString()); // EE Fname
                    item.SubItems.Add(emp.LastName.ToString()); // EE Lname
                    item.SubItems.Add(decodeEmpJobCode(emp.JobTitle)); // EE Job Title
                    item.SubItems.Add(decodeEmpStatus(emp.EmpStatus)); // EE Status
                    item.SubItems.Add(emp.StatComment); // EE Status Comments
                    item.SubItems.Add(emp.PictPath);
                    item.SubItems.Add(emp.EmpPhone);
                    listViewEE.Items.Add(item);
                }
            }
        }

        private string decodeEmpJobCode (int code) // function to decode JobTitles
        {
            string jobTitle = "Employee";
            switch (code)
            {
                case 0:
                    jobTitle = "Employee"; //Employee withour any access to the system (we display only message)
                    break;
                case 1:
                    jobTitle = "MIS Manager";
                    break;
                case 2:
                    jobTitle = "Sales Manager";
                    break;
                case 3:
                    jobTitle = "Inventory Controller";
                    break;
                case 4:
                    jobTitle = "Order Clerk";
                    break;
                default:
                    jobTitle = "Others";
                    break;
            }
            return jobTitle;
        }

        private string decodeEmpStatus(bool code) // function to decode Emp Status
        {
            string empStatus = "Inactive";
            switch (code)
            {
                case false:
                    empStatus = "Inactive";
                    break;
                case true:
                    empStatus = "Active";
                    break;
                default:
                    break;
            }
            return empStatus;
        }

        private void FrmManageAccount_Load(object sender, EventArgs e)
        {
            //activate default values when on-load of the form happens
            
            cmbBoxTitle.SelectedIndex = 0;
            cmbSearchBy.SelectedIndex = 0;

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // search an employee by...
            switch (cmbSearchBy.SelectedIndex)
            {
                case 0: //Search by Employee ID:
                    {
                        int empId = 0;
                        string empIdString = txtSearchString.Text.Trim();
                        if (int.TryParse(empIdString, out empId))
                        {
                            empId = Convert.ToInt32(empIdString);
                            Employee emp = Employee.SearchEmployee(empId);
                            if (emp != null)
                            {
                                listViewEE.Items.Clear();
                                ListViewItem item = new ListViewItem();
                                item.Text = emp.EmpId.ToString(); //Employee  ID
                                item.SubItems.Add(emp.FirstName.ToString()); // EE Fname
                                item.SubItems.Add(emp.LastName.ToString()); // EE Lname
                                item.SubItems.Add(decodeEmpJobCode(emp.JobTitle)); // EE Job Title
                                item.SubItems.Add(decodeEmpStatus(emp.EmpStatus)); // EE Status
                                item.SubItems.Add(emp.StatComment); // EE Status Comments
                                listViewEE.Items.Add(item);
                            }
                        }
                        break;
                    }                    
                    
                case 1: //Search by Employee First Name:
                    {
                        string empName = txtSearchString.Text.Trim();
                        List<Employee> employees = Employee.SearchRecord(empName, "firstName");

                        fillInListView(employees);
                        break;
                    }
                case 2: //Search by Employee Last Name:
                    {
                        string empName = txtSearchString.Text.Trim();
                        List<Employee> employees = Employee.SearchRecord(empName, "lastName");
                        fillInListView(employees);
                        break;
                    }
                case 3: //Search by Employee First and Last Name:
                    {
                        string empName = txtSearchString.Text.Trim();
                        string[] EENames = empName.Split(','); // An array with First (,) Last names
                        List<Employee> employees = Employee.SearchRecord(empName, "firstlast");
                        fillInListView(employees);
                        break;
                    }
                default:
                    MessageBox.Show("Please select an option!", "Message");
                    break;
            }
        }

        public void fillInListView (List<Employee> employees)
        {
            listViewEE.Items.Clear();
            foreach (Employee emp in employees)
            {
                ListViewItem item = new ListViewItem();
                item.Text = emp.EmpId.ToString(); //Employee  ID
                item.SubItems.Add(emp.FirstName.ToString()); // EE Fname
                item.SubItems.Add(emp.LastName.ToString()); // EE Lname
                item.SubItems.Add(decodeEmpJobCode(emp.JobTitle)); // EE Job Title
                item.SubItems.Add(decodeEmpStatus(emp.EmpStatus)); // EE Status
                item.SubItems.Add(emp.StatComment); // EE Status Comments
                listViewEE.Items.Add(item);
            }
        }

        public void fillInListViewCLI(List<Client> clients)
        {
            listViewCLI.Items.Clear();
            foreach (Client cli in clients)
            {                
                ListViewItem item = new ListViewItem();
                item.Text = cli.ClientId.ToString();
                item.SubItems.Add(cli.ClientName);
                item.SubItems.Add(decodeEmpStatus(cli.ClientStatus));
                item.SubItems.Add(cli.StatComment);
                item.SubItems.Add(cli.ClientStreet);
                item.SubItems.Add(cli.ClientCity);
                item.SubItems.Add(cli.ClientPCode);
                item.SubItems.Add(cli.ClientPhone);
                item.SubItems.Add(cli.ClientFax);
                item.SubItems.Add(cli.ClientEmail);
                item.SubItems.Add(cli.CredLimit.ToString());
                listViewCLI.Items.Add(item);
            }
        }

        public void fillInListViewProd(List<Product> products)
        {
            //int suppId;
            Supplier aSupp = new Supplier();
            lstProdView.Items.Clear();
            foreach (Product prod in products)
            {
                ListViewItem item = new ListViewItem();
                item.Text = prod.ProdId.ToString();
                item.SubItems.Add(prod.ProdName);
                item.SubItems.Add(prod.ProdCat.ToString());
                item.SubItems.Add(decodeEmpStatus(prod.ProdStatus));
                item.SubItems.Add(prod.UnitPrice.ToString());
                //item.SubItems.Add(prod.SupplId.ToString());
                //suppId = prod.SupplId; Supplier aSupp = new Supplier();
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
                lstProdView.Items.Add(item);
            }
        }

        //listViewAllOrders
        public void fillInListViewOrdr(List<Order> orders)
        {
            //int suppId;
            Supplier aSupp = new Supplier();
            Employee anEmp = new Employee();
            Client aClient = new Client();
            listViewAllOrders.Items.Clear();
            string strProdList = "";
            foreach (Order order in orders)
            {
                ListViewItem item = new ListViewItem();
                item.Text = order.OrdId.ToString();
                item.SubItems.Add(order.CreatedTime.ToShortDateString());
                item.SubItems.Add(order.ShippingTime.ToShortDateString());
                item.SubItems.Add(order.RequiredTime.ToShortDateString());
                item.SubItems.Add(order.OrdState.ToString());
                try
                {
                    anEmp = Employee.SearchEmployee(order.CreatedByEmpId);
                    item.SubItems.Add(anEmp.FirstName + ", " + anEmp.LastName);
                }
                catch (Exception)
                {
                    item.SubItems.Add("EmpID unknown"); ;
                }
                try
                {
                    aClient = Client.SearchRecord(order.ClientId);
                    item.SubItems.Add(aClient.ClientName);
                }
                catch (Exception)
                {
                    item.SubItems.Add("ClientID unknown"); ;
                }                
                item.SubItems.Add(order.TotalAmount.ToString());                
                item.SubItems.Add(order.OrdTakeBy.ToString());
                try
                {
                    item.SubItems.Add(order.ProductsList.Count.ToString());
                }
                catch (Exception)
                {
                    item.SubItems.Add("Unknown");
                }
                
                item.SubItems.Add(strProdList);
                listViewAllOrders.Items.Add(item);
            }
        }

        private void listViewEE_SelectedIndexChanged(object sender, EventArgs e)
        {
           // When clicked to the list of Employees
            try
            {
                if (listViewEE.SelectedItems.Count > 0)
                {
                    int empId = 0;
                    string empIdString = listViewEE.SelectedItems[0].Text.ToString();
                    if (int.TryParse(empIdString, out empId))
                    {
                        empId = Convert.ToInt32(empIdString);
                        Employee emp = Employee.SearchEmployee(empId);
                        if (emp != null)
                        {
                            txtBoxEmpId.Text = emp.EmpId.ToString();
                            txtUser.Text = emp.EmpUserName.ToString();
                            txtBoxFName.Text = emp.FirstName.ToString();
                            txtBoxLName.Text = emp.LastName.ToString();
                            cmbBoxTitle.SelectedIndex = emp.JobTitle;
                            txtPass1.Text = emp.EmpPassword.ToString();
                            txtPass2.Text = emp.EmpPassword.ToString();
                            txtBoxPhone.Text = emp.EmpPhone.ToString();
                            //picture box here
                            if (emp.PictPath != "")
                            {
                                ShowMyImage(filePath + emp.PictPath.ToString(), 90, 100);
                                lblPic.Text = emp.PictPath;
                            }
                            else
                            {
                                ShowMyImage(filePath + emp.EmpId.ToString() + ".jpg", 90, 100);
                                lblPic.Text = emp.PictPath;
                            }
                        }
                    }
                }


            }
            catch { }
        }

        private void listViewEE_DoubleClick(object sender, EventArgs e)
        {
            //when double-click to the list view show the content of selected item
            //string text;
            try
            {
                
                if (listViewEE.SelectedItems.Count > 0)
                {
                    int empId = 0;
                    string empIdString = listViewEE.SelectedItems[0].Text.ToString();
                    if (int.TryParse(empIdString, out empId))
                    {
                        empId = Convert.ToInt32(empIdString);
                        Employee emp = Employee.SearchEmployee(empId);
                        if (emp != null)
                        {
                            txtBoxEmpId.Text = emp.EmpId.ToString();
                            txtUser.Text = emp.EmpUserName.ToString();
                            txtBoxFName.Text = emp.FirstName.ToString();
                            txtBoxLName.Text = emp.LastName.ToString();
                            cmbBoxTitle.SelectedIndex = emp.JobTitle;
                            txtPass1.Text = emp.EmpPassword.ToString();
                            txtPass2.Text = emp.EmpPassword.ToString();
                            txtBoxPhone.Text = emp.EmpPhone.ToString();
                            //picture box here
                            if (emp.PictPath != "")
                            {
                                ShowMyImage(filePath + emp.PictPath.ToString(), 90, 100);
                                lblPic.Text = emp.PictPath;
                            }
                            else
                            {
                                ShowMyImage(filePath + emp.EmpId.ToString() + ".jpg", 90, 100);
                                lblPic.Text = emp.PictPath;
                            }
                        }
                    }
                }          
            }
            catch { }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //to delete a record from the file?
            int empId = 0;
            string msgString = "";
            string empIdString = txtBoxEmpId.Text.Trim();
            if (int.TryParse(empIdString, out empId))
            {
                empId = Convert.ToInt32(empIdString);
                Employee emp = Employee.SearchEmployee(empId);
                if (emp != null) //if emp is found
                {
                    //call remove record function
                    if (emp.EmpStatus)
                    {
                        msgString = "deactivated since " + DateTime.Now.ToString("M/d/yyyy"); 
                    }
                    else
                    {
                        msgString = "activated since " + DateTime.Now.ToString("M/d/yyyy");
                    }
                    DialogResult answer = MessageBox.Show("The user account wil be " + msgString + "\n Are you sure?", "Confirmation",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    if (answer == DialogResult.Yes)
                    {
                        emp.EmpStatus = (!emp.EmpStatus);
                        emp.StatComment = msgString;
                        Employee.UpdateRecord(emp);
                        btnListAll_Click(sender, e);
                    }
                }
            }
        }

        private void Label7_DlbClick(object sender, EventArgs e)
        {
            //to verigy the content of the field Password1
            MessageBox.Show(txtPass1.Text.ToString(), "Password field content", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void label8_DblClick(object sender, EventArgs e)
        {
            //to verigy the content of the field Password2
            MessageBox.Show(txtPass2.Text.ToString(), "Password field content", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private Bitmap MyImage;
        public void ShowMyImage(String fileToDisplay, int xSize, int ySize)
        {
            // Sets up an image object to be displayed.
            if (MyImage != null)
            {
                MyImage.Dispose();
            }

            // Stretches the image to fit the pictureBox.
            picBoxEMP.SizeMode = PictureBoxSizeMode.Zoom;
            MyImage = new Bitmap(fileToDisplay);
            picBoxEMP.ClientSize = new Size(xSize, ySize);
            picBoxEMP.Image = (Image)MyImage;
        }

        private void btnImgSet_Click(object sender, EventArgs e)
        {
            Bitmap image; //Bitmap class for an image to open
            OpenFileDialog open_dialog = new OpenFileDialog(); //creating file dialog window
            open_dialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*"; //file format filter
            if (open_dialog.ShowDialog() == DialogResult.OK) //if OK pressed
            {
                try
                {
                    image = new Bitmap(open_dialog.FileName);
                    //this.picBoxEMP.Size = image.Size;
                    picBoxEMP.Image = image;
                    picBoxEMP.Invalidate();
                    //lblPic.Text = open_dialog.FileName;
                    lblPic.Text = open_dialog.SafeFileName;
                }
                catch
                {
                    DialogResult rezult = MessageBox.Show("Can not open file",
                    "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }            
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            //clean all fields
            int nextEmpId = Employee.NextEmpId(Employee.ListAllRecords());
            if (nextEmpId == 1)
            {
                nextEmpId = 1000; //we restart numbers to follow 4 digits id standards
            }
            txtBoxEmpId.Text = nextEmpId.ToString();
            txtUser.Text = "";
            txtBoxFName.Text = "";
            txtBoxLName.Text = "";
            cmbBoxTitle.SelectedIndex = 0;
            txtPass1.Text = "";
            txtPass2.Text = "";
            txtBoxPhone.Text = "";
            lblPic.Text = "";
        }

        private void btnNewCli_Click(object sender, EventArgs e)
        {
            int nextCliId = Client.NextCliId(Client.ListAllRecords()); //to generate new client ID
            if (nextCliId == 1)
            {
                nextCliId = 1000; //we restart numbers to follow 4 digits id standards
            }
            textBoxClientId.Text = nextCliId.ToString();
            txtCliName.Text = "";
            txtCliCity.Text = "";
            txtCliEmail.Text = "";
            txtCliFax.Text = "";
            txtCliPhone.Text = "";
            txtCliStreet.Text = "";
            txtCliPCode.Text = "";
            txtCliSearchStr.Text = "";
            txtCredLimit.Text = "";
        }

        private void btnProdNew_Click(object sender, EventArgs e)
        {
            Book book = new Book();
            Software soft = new Software();
            switch (cmbProdCat.SelectedIndex)
                {
                    case 0:
                        FrmProdBook bookFrm = new FrmProdBook(book, _productsList);
                        bookFrm.Show();
                        break;
                    case 1:
                        FrmProdSoft softFrm = new FrmProdSoft(soft, _productsList);
                        softFrm.Show();
                        break;
                    default:
                        break;
                }
        }

        private void btnLstCln_Click(object sender, EventArgs e)
        {
            listViewCLI.Items.Clear();
            List<Client> clients = Client.ListAllRecords();
            foreach (Client cli in clients)
            {
                if (cli.ClientStatus)
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = cli.ClientId.ToString(); 
                    item.SubItems.Add(cli.ClientName); 
                    item.SubItems.Add(decodeEmpStatus(cli.ClientStatus)); 
                    item.SubItems.Add(cli.StatComment); 
                    item.SubItems.Add(cli.ClientStreet); 
                    item.SubItems.Add(cli.ClientCity); 
                    item.SubItems.Add(cli.ClientPCode);
                    item.SubItems.Add(cli.ClientPhone);
                    item.SubItems.Add(cli.ClientFax);
                    item.SubItems.Add(cli.ClientEmail);
                    item.SubItems.Add(cli.CredLimit.ToString());
                    listViewCLI.Items.Add(item);
                }
                else if (checkBoxShowActCli.Checked)
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = cli.ClientId.ToString();
                    item.SubItems.Add(cli.ClientName);
                    item.SubItems.Add(decodeEmpStatus(cli.ClientStatus));
                    item.SubItems.Add(cli.StatComment);
                    item.SubItems.Add(cli.ClientStreet);
                    item.SubItems.Add(cli.ClientCity);
                    item.SubItems.Add(cli.ClientPCode);
                    item.SubItems.Add(cli.ClientPhone);
                    item.SubItems.Add(cli.ClientFax);
                    item.SubItems.Add(cli.ClientEmail);
                    item.SubItems.Add(cli.CredLimit.ToString());
                    listViewCLI.Items.Add(item);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {        }

        private void btnSaveClient_Click(object sender, EventArgs e)
        {
            //Save a client information
            string valueID, valueName, valueCredLimit, valueEmail, valuePhone, valueFax;
            string valueStreet, valueCity, valuePCode;
            int clientId;
            double credLimit = 0;
            bool flagStatus = true;
            Client client = new Client();
            valueID = textBoxClientId.Text.Trim();
            valueName = txtCliName.Text.Trim();
            valueCredLimit = txtCredLimit.Text.Trim();
            valueEmail = txtCliEmail.Text.Trim();
            valuePhone = txtCliPhone.Text.Trim();
            valueFax = txtCliFax.Text.Trim();
            valueStreet = txtCliStreet.Text.Trim();
            valueCity = txtCliCity.Text.Trim();
            valuePCode = txtCliPCode.Text.Trim();

            if (Client.isValidId(valueID, 4))
            {
                try
                {
                    clientId = Convert.ToInt32(valueID);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Client ID is not correct! \n" + ex.Message + 
                        "\n\nPlease provide valid client id number...",
                    "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxClientId.Focus();
                    return;
                }
            }

            if (valueName == "")
            {
                MessageBox.Show("Client Name could not be empty! \nPlease provide valid client name...",
                    "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCliName.Focus();
                return;
            }
            else
            {
                valueName = Employee.setNameStr(valueName); //set name to use Upper + lower case letters
            }
            try
            {
                credLimit = Convert.ToDouble(valueCredLimit);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Credit Limit is not correct! \n" + ex.Message +
                       "\n\nPlease provide valid number...",
                   "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                credLimit = 0;
                txtCredLimit.Focus();
                return;
            }
            if (Client.isPhoneNumber(valuePhone))
            { //CHECKING PHONE NUMBER
                valuePhone = Client.setPhoneNumber(valuePhone); //setting it with standards
            }
            else
            {
                txtCliPhone.Focus();
                return;
            }

            if (Client.isPhoneNumber(valueFax))
            { //CHECKING FAX NUMBER
                valueFax = Client.setPhoneNumber(valueFax); //setting it with standards
            }
            else
            {
                txtCliFax.Focus();
                return;
            }
            if (!Client.isCanPostCode(valuePCode))
            {
                MessageBox.Show("Postal code is not correct! \n" + 
                       "\n\nPlease provide valid code...",
                   "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                valuePCode = "";
                txtCliPCode.Focus();
                return;
            }

            // Using different validtions methods to check if all ok:
            if ((Client.isValidId(valueID, 4)) && (valueEmail != "") 
                && (valueStreet !="") && (valueCity != "")) 
            {
                //all ok so go ahead and assign the values to the object fields
                client.ClientId = Convert.ToInt32(valueID);
                client.ClientName = valueName;
                client.ClientStatus = flagStatus;
                client.StatComment = "Changed " + DateTime.Now.ToString("M/d/yyyy");
                client.ClientStreet = valueStreet;
                client.ClientCity = valueCity;
                client.ClientPCode = valuePCode;
                client.ClientPhone = valuePhone;
                client.ClientFax = valueFax;
                client.ClientEmail = valueEmail;
                client.CredLimit = credLimit;

                if (Client.isDuplicateId(Convert.ToInt32(valueID)))
                {
                    //if id is already in use - return true = id duplicate found!      
                    // so may be we want to update the account information?
                    DialogResult answer = MessageBox.Show("This ID is already in use: " + valueID + "\n"
                        + "Do you want to update this account information?", "Confirmation on Update",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    if (answer == DialogResult.Yes)
                    {
                        //continuing update process:
                        Client.UpdateRecord(client);
                        btnLstCln_Click(sender, e);
                        MessageBox.Show("Information Updated!");
                        return;
                    }
                    textBoxClientId.Focus();
                    return;
                }
                Client.SaveRecord(client);
                btnLstCln_Click(sender, e);
            }
            else
            {
                MessageBox.Show("Client data is not correct! \nPlease provide valid client data...",
                    "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxClientId.Focus();
                return; //something went wrong so we are interrupting this action
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {        }

        private void btnSearchCln_Click(object sender, EventArgs e)
        {
            switch (cmbBoxSearchClBy.SelectedIndex)
            {
                case 0: //Search by Client ID:
                    {
                        int cliId = 0;
                        string cliIdString = txtCliSearchStr.Text.Trim();
                        if (int.TryParse(cliIdString, out cliId))
                        {
                            cliId = Convert.ToInt32(cliIdString);
                            Client cli = Client.SearchRecord(cliId);
                            if (cli != null)
                            {
                                listViewCLI.Items.Clear();
                                ListViewItem item = new ListViewItem();
                                item.Text = cli.ClientId.ToString();
                                item.SubItems.Add(cli.ClientName);
                                item.SubItems.Add(decodeEmpStatus(cli.ClientStatus));
                                item.SubItems.Add(cli.StatComment);
                                item.SubItems.Add(cli.ClientStreet);
                                item.SubItems.Add(cli.ClientCity);
                                item.SubItems.Add(cli.ClientPCode);
                                item.SubItems.Add(cli.ClientPhone);
                                item.SubItems.Add(cli.ClientFax);
                                item.SubItems.Add(cli.ClientEmail);
                                item.SubItems.Add(cli.CredLimit.ToString());
                                listViewCLI.Items.Add(item);
                            }
                        }                        
                        break;
                    }

                case 1: //Search by Client Name:
                    {
                        string cliName = txtCliSearchStr.Text.Trim();
                        List<Client> clients = Client.SearchRecord(cliName, "name");
                        fillInListViewCLI(clients);
                        break;
                    }
                case 2: //Search by City:
                    {
                        string cliName = txtCliSearchStr.Text.Trim();
                        List<Client> clients = Client.SearchRecord(cliName, "city");
                        fillInListViewCLI(clients);
                        break;
                    }
                case 3: //Search by Postal Code:
                    {
                        string cliName = txtCliSearchStr.Text.Trim();
                        List<Client> clients = Client.SearchRecord(cliName, "pcode");
                        fillInListViewCLI(clients);
                        break;
                    }
                default:
                    MessageBox.Show("Please select an option!", "Message");
                    break;
            }
        }

        private void listViewCLI_SelectedIndexChanged(object sender, EventArgs e)
        {
            // When clicked to the list of Clients
            try
            {
                if (listViewCLI.SelectedItems.Count > 0)
                {
                    int cliId = 0;
                    string cliIdString = listViewCLI.SelectedItems[0].Text.ToString();
                    if (int.TryParse(cliIdString, out cliId))
                    {
                        cliId = Convert.ToInt32(cliIdString);
                        Client cli = Client.SearchRecord(cliId);
                        if (cli != null)
                        {
                            putCliFrmValues(cli);
                        }
                    }
                }
            }
            catch { //failure
            }
        }


        public void putCliFrmValues(Client aClient)
        {
            textBoxClientId.Text = aClient.ClientId.ToString(); //client ID
            txtCliName.Text = aClient.ClientName.ToString(); //client Name
            txtCredLimit.Text = aClient.CredLimit.ToString(); //client credit limit
            txtCliEmail.Text = aClient.ClientEmail.ToString();  //client email 
            txtCliPhone.Text = aClient.ClientPhone.ToString(); //client Phone
            txtCliFax.Text = aClient.ClientFax.ToString(); //client Fax
            txtCliStreet.Text = aClient.ClientStreet.ToString(); //Client street address
            txtCliCity.Text = aClient.ClientCity.ToString(); //Client City
            txtCliPCode.Text = aClient.ClientPCode.ToString(); // client postal code
        }

        private void tabCtrl1_SelectedIndexChanged(object sender, EventArgs e)
        { //refresh the list when switched to this tab
            if (tabCtrl1.SelectedIndex == 1)
            {
                // MessageBox.Show("tabCtrl1_SelectedIndexChanged: " + tabCtrl1.SelectedIndex);
                btnLstCln_Click(sender, e);
            }
            if (tabCtrl1.SelectedIndex == 2)
            {
                btnProdListAll_Click(sender, e);
            }
            if (tabCtrl1.SelectedIndex == 3)
            {
                fillInListViewOrdr(Order.XMLLoadAllProducts());
            }
        }

        private void btnProdSave_Click(object sender, EventArgs e)
        {
            ////Save a Product information
            //string valueID, valueName, valueProdCat, valueUnitPrice, valueSupplId, valueQOH;           
            //double unitPrice = 0;
            //bool prodStatus = true;
            
        }

        private void btnProdListAll_Click(object sender, EventArgs e)
        {
            lstProdView.Items.Clear();
            //loading the list of products into a global list
            try
            {
                _productsList = Product.XMLLoadAllProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data from XML file!!!\n" + ex.Message,"Error!");
                List<Product> _productsList = new List<Product>();
            }
           
            //sending the list to the listView
            fillInListViewProd(_productsList);

        }

        private void btnProdSearch_Click(object sender, EventArgs e)
        {
            switch (cmbProdSrchBy.SelectedIndex)
            {
                case 0: //Search by Product ID:
                    {
                        int prodId = 0;
                        string prodIdString = txtProdSearch.Text.Trim();
                        if (int.TryParse(prodIdString, out prodId))
                        {
                            //Product prod = Product.SearchRecord(prodId);
                            Product prod = Product.SearchXMLRecordProd(prodId);
                            if (prod != null)
                            {
                                lstProdView.Items.Clear();
                                ListViewItem item = new ListViewItem();
                                item.Text = prod.ProdId.ToString();
                                item.SubItems.Add(prod.ProdName);
                                item.SubItems.Add(prod.ProdCat.ToString());
                                item.SubItems.Add(decodeEmpStatus(prod.ProdStatus));
                                item.SubItems.Add(prod.UnitPrice.ToString());
                                item.SubItems.Add(prod.SupplId.ToString());
                                item.SubItems.Add(prod.QtyOnHand.ToString());
                                lstProdView.Items.Add(item);
                            }
                        }
                        break;
                    }

                case 1: //Search by Prod Name:
                    {
                        string prodName = txtProdSearch.Text.Trim();
                        //List<Product> products = Product.SearchRecord(prodName, "title");
                        List<Product> products = Product.SearchXMLRecordProd(prodName, "name");
                        fillInListViewProd(products);
                        break;
                    }
                case 2: //Search by Supplier:
                    {
                        string prodName = txtProdSearch.Text.Trim();
                        List<Product> products = Product.SearchXMLRecordProd(prodName, "supplier");
                        fillInListViewProd(products);
                        break;
                    }
                default:
                    MessageBox.Show("Please select an option!", "Message");
                    break;
            }
        }

        private void btnProdAct_Click(object sender, EventArgs e)
        {
            ////EDIT THE LIST OF ITEMS
            Book book = new Book();
            Software soft = new Software();
            if (lstProdView.SelectedItems.Count > 0)
            {
                int prodId = 0;
                string prodIdString = lstProdView.SelectedItems[0].Text.ToString();
                if (int.TryParse(prodIdString, out prodId))
                {
                    Product prod = Product.SearchXMLRecordProd(prodId);
                    if (prod != null)
                    {
                        txtProdID.Text = prod.ProdId.ToString();
                        txtProdName.Text = prod.ProdName;
                        switch (prod.ProdCat)
                        {
                            case ProdCat.Book:
                                cmbProdCat.SelectedIndex = 0;
                                book = (Book)Product.SearchXMLRecordProd(prodId);
                                //MessageBox.Show("Book attributes: \nISBN: " + book.BookISBN
                                //    + "\nTitle: " + book.BookTitle + "\nReleased: " + book.YearReleased);
                                FrmProdBook bookFrm = new FrmProdBook(book, _productsList);
                                bookFrm.Show();
                                break;
                            case ProdCat.Software:
                                cmbProdCat.SelectedIndex = 1;
                                soft = (Software)Product.SearchXMLRecordProd(prodId);
                                //MessageBox.Show("Software attributes: \nOS: \t\t" + soft.OsCateg
                                //    + "\nSoftware Name: \t" + soft.ProdName + "\nCategory: " + soft.SoftCateg);
                                FrmProdSoft softFrm = new FrmProdSoft(soft, _productsList);
                                softFrm.Show();
                                break;
                            default:
                                cmbProdCat.SelectedIndex = 2;
                                break;
                        }
                    }
                }
            }
        }

        private void lstProdView_SelectedIndexChanged(object sender, EventArgs e)
        {
            // When clicked to the list of Items
            //Product.XMLLoadAllProducts()
            try
            {
                if (lstProdView.SelectedItems.Count > 0)
                {
                    int prodId = 0;
                    string prodIdString = lstProdView.SelectedItems[0].Text.ToString();
                    if (int.TryParse(prodIdString, out prodId))
                    {
                        //Product prod = Product.SearchRecord(prodId);
                        Product prod = Product.SearchXMLRecordProd(prodId);
                        Book book;
                        Software soft;
                        if (prod != null)
                        {
                            txtProdID.Text = prod.ProdId.ToString();
                            txtProdName.Text = prod.ProdName;
                            //cmbProdCat.SelectedIndex = 0;
                            switch (prod.ProdCat)
                            {
                                case ProdCat.Book:
                                    cmbProdCat.SelectedIndex = 0;
                                    //book = (Book) Product.SearchXMLRecordProd(prodId);
                                    //MessageBox.Show("Book attributes: \nISBN: " + book.BookISBN 
                                    //    + "\nTitle: " + book.BookTitle + "\nReleased: " + book.YearReleased);
                                    break;
                                case ProdCat.Software:
                                    cmbProdCat.SelectedIndex = 1;
                                    //soft = (Software) Product.SearchXMLRecordProd(prodId);
                                    break;
                                default:
                                    cmbProdCat.SelectedIndex = 2;
                                    break;
                            }

                            txtProdUPrc.Text = prod.UnitPrice.ToString();
                            txtProdSupId.Text = prod.SupplId.ToString();
                            txtProdQoH.Text = prod.QtyOnHand.ToString();
                        }
                    }
                }
            }
            catch { }
        }

        private void btnProdSaveAllXML_Click(object sender, EventArgs e)
        {
            Product.SaveAllProducts(Product.ListAllRecords());
        }

        private void btnProdReadAllXML_Click(object sender, EventArgs e)
        {
            fillInListViewProd(Product.XMLLoadAllProducts());
        }

        private void lstProdView_DoubleClick(object sender, EventArgs e)
        {
            //double click in listview
            btnProdAct_Click(sender, e);
        }

        private void btnManageAuth_Click(object sender, EventArgs e)
        {
            FrmManageAuthor authFrm = new FrmManageAuthor();
            authFrm.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            FrmSupplier suppFrm = new FrmSupplier();
            suppFrm.Show();
        }

        private void btnOrdrNew_Click(object sender, EventArgs e)
        {
            List<Product> productsList = new List<Product>();
            try
            {
                productsList = Product.XMLLoadAllProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data from XML file!!!\n" + ex.Message, "Error!");
                List<Product> _productsList = new List<Product>();
            }

            FrmOrder orderFrm = new FrmOrder(_employee, null,productsList);
            orderFrm.Show();
        }

        private void listViewAllOrders_SelectedIndexChanged(object sender, EventArgs e)
        {
            //listViewAllOrders
        }

        private void btnOrdListAll_Click(object sender, EventArgs e)
        {
        //    List<Order> listOrders = new List<Order>();
        //    listOrders = Order.XMLLoadAllProducts;
            fillInListViewOrdr(Order.XMLLoadAllProducts());

        }

        private void FrmManageAccount_FormClosed(object sender, FormClosedEventArgs e)
        {
            //this.Owner.Dispose(); //closing parent form
            Application.Exit();
        }

        private void btnOrdActDeact_Click(object sender, EventArgs e)
        {

        }

        private void btnOrdEdit_Click(object sender, EventArgs e)
        {
            ////EDIT THE LIST OF ORDERS ==========================
            if (listViewAllOrders.SelectedItems.Count > 0)
            {
                int ordrId = 0; string ordClientId;
                string ordIdString = listViewAllOrders.SelectedItems[0].Text.ToString();
                if (int.TryParse(ordIdString, out ordrId))
                {
                    Order order = Order.SearchXMLRecordProd(ordrId);
                    List<Product> productsList = new List<Product>();
                    if (order != null)
                    {
                        ordrId = order.OrdId;
                        
                        try
                        {
                            ordClientId = Client.SearchRecord(order.ClientId).ClientName;
                        }
                        catch (Exception)
                        {
                            ordClientId = order.ClientId.ToString();
                        }
                        try
                        {
                            productsList = Product.XMLLoadAllProducts();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error loading data from XML file!!!\n" + ex.Message, "Error!");
                            List<Product> _productsList = new List<Product>();
                        }
                        //MessageBox.Show("An order number: " + ordrId.ToString() + "\nClient ID#: " + ordClientId.ToString());
                        FrmOrder orderFrm = new FrmOrder(_employee, order, productsList);
                        orderFrm.Show();
                    }
                }
            }
        }

        private void btnOrdFilter_Click(object sender, EventArgs e)
        { //filtering list of orders by...
            List<Order> listAllProducts = new List<Order>();
            List<Order> listFilteredDate = new List<Order>();
            List<Order> listFilteredStatus = new List<Order>();
            List<Order> listFilteredTaken = new List<Order>();
            listAllProducts = Order.XMLLoadAllProducts();
            //Order ordItem = new Order();

            //listFiltered = listAllProducts.FindAll(x => x.OrdState == OrderState.New);

            switch (cmbboxFilterByRdrDate.SelectedIndex)
            {
                case 0://No filter - All records
                    foreach (Order item in listAllProducts)
                    {
                        listFilteredDate.Add(item);
                    }
                    break;
                case 1:
                    //Created
                    foreach (Order item in listAllProducts)
                    {
                        if ((dtOrdrFromFilter.Value.Date <= item.CreatedTime.Date) &&
                                (dtOrdrToFilter.Value.Date >= item.CreatedTime.Date))
                        {
                            listFilteredDate.Add(item);
                        }
                    }
                    break;
                case 2:
                    //Shipped
                    foreach (Order item in listAllProducts)
                    {
                        if ((dtOrdrFromFilter.Value.Date <= item.ShippingTime.Date) &&
                                (dtOrdrToFilter.Value.Date >= item.ShippingTime.Date))
                        {
                            listFilteredDate.Add(item);
                        }
                    }
                    break;
                case 3:
                    //Required
                    foreach (Order item in listAllProducts)
                    {//(item.CreatedTime.ToShortDateString() == dtCreatedTime.Value.ToShortDateString())
                        if ((dtOrdrFromFilter.Value.Date <= item.RequiredTime.Date) &&
                                (dtOrdrToFilter.Value.Date >= item.RequiredTime.Date))
                        {
                            listFilteredDate.Add(item);
                        }
                    }
                    break;
                default:
                    foreach (Order item in listAllProducts)
                    {
                        listFilteredDate.Add(item);
                    }
                    break;
            }

            switch (cmbOrdStatus.SelectedIndex)
            {                
                case 0:   //No filter - All records
                    foreach (Order item in listFilteredDate)
                    {
                        listFilteredStatus.Add(item);
                    }
                    break;
                case 1: //New OrderState
                    listFilteredStatus = listFilteredDate.FindAll(x => x.OrdState == OrderState.New);
                    break;
                case 2: // Hold
                    listFilteredStatus = listFilteredDate.FindAll(x => x.OrdState == OrderState.Hold);
                    break;
                case 3: // Shipped
                    listFilteredStatus = listFilteredDate.FindAll(x => x.OrdState == OrderState.Shipped);
                    break;
                case 4: // Delivered
                    listFilteredStatus = listFilteredDate.FindAll(x => x.OrdState == OrderState.Delivered);
                    break;
                case 5: // Closed
                    listFilteredStatus = listFilteredDate.FindAll(x => x.OrdState == OrderState.Closed);
                    break;
                default:
                    foreach (Order item in listFilteredDate)
                    {
                        listFilteredStatus.Add(item);
                    }
                    break;
            }

            switch (cmbOrdTakenBy.SelectedIndex)
            { //OrderTakeBy
                case 0://No filter - All records                    
                    foreach (Order item in listFilteredStatus)
                    {
                        listFilteredTaken.Add(item);
                    }
                    break;
                case 1: //Phone
                    listFilteredTaken = listFilteredStatus.FindAll(x => x.OrdTakeBy == OrderTakeBy.Phone);
                    break;
                case 2: // Fax
                    listFilteredTaken = listFilteredStatus.FindAll(x => x.OrdTakeBy == OrderTakeBy.Fax);
                    break;
                case 3: //Email
                    listFilteredTaken = listFilteredStatus.FindAll(x => x.OrdTakeBy == OrderTakeBy.Email);
                    break;
                default:
                    foreach (Order item in listFilteredStatus)
                    {
                        listFilteredTaken.Add(item);
                    }
                    break;
            }
            fillInListViewOrdr(listFilteredTaken);
        }

        private void listViewAllOrders_DoubleClick(object sender, EventArgs e)
        {
            //double click on the list
            btnOrdEdit_Click(sender, e);
        }

        private void btnOrdSearch_Click(object sender, EventArgs e)
        {
            /*  Id number(*exact)
                Client Name (* substring)
                Created By       (* substring) */
            switch (comboBox1.SelectedIndex)
            {
                case 0: //Search by Product ID:
                    {
                        int orderId = 0;
                        string orderIdString = txtOrdSearchStr.Text.Trim();
                        if (int.TryParse(orderIdString, out orderId))
                        {
                            //Product prod = Product.SearchRecord(prodId);
                            Order order = Order.SearchXMLRecordProd(orderId);
                            if (order != null)
                            {
                                listViewAllOrders.Items.Clear();
                                ListViewItem item = new ListViewItem();
                                item.Text = order.OrdId.ToString();
                                item.SubItems.Add(order.OrdId.ToString());
                                item.SubItems.Add(order.CreatedTime.ToString());
                                item.SubItems.Add(order.ShippingTime.ToString());
                                item.SubItems.Add(order.RequiredTime.ToString());
                                item.SubItems.Add(order.OrdState.ToString());
                                item.SubItems.Add(order.CreatedByEmpId.ToString());
                                item.SubItems.Add(order.CreatedByEmpId.ToString());
                                item.SubItems.Add(order.CreatedByEmpId.ToString());
                                listViewAllOrders.Items.Add(item);
                            }
                        }
                        break;
                    }

                case 1: //Search by Prod Name:
                    {
                        string orderIdString = txtOrdSearchStr.Text.Trim();
                        List<Order> ordersList = Order.SearchXMLRecordProd(orderIdString, "cname");
                        fillInListViewOrdr(ordersList);
                        break;
                    }
                case 2: //Search by Supplier:
                    {
                        string orderIdString = txtOrdSearchStr.Text.Trim();
                        List<Order> ordersList = Order.SearchXMLRecordProd(orderIdString, "createdby");
                        fillInListViewOrdr(ordersList);
                        break;
                    }
                default:
                    MessageBox.Show("Please select an option!", "Message");
                    break;
            }
        }
    }

    //end of class
}//end of namespace
