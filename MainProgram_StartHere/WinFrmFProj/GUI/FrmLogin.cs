using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HiTech.Business;
using HiTech.GUI; //this is to be able to show windows form from another folder (GUI in this case)

namespace HiTech
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Text = this.Text + " user: test / 123";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //Exit with dialog box
            DialogResult answer = MessageBox.Show("Exit application now?", "Confirmation on Exit.",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (answer == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string loginUser, loginPass;
            int empJobCode;
            loginUser = txtBoxUName.Text.Trim().ToLower();
            loginPass = txtUPass.Text.Trim();
            //MessageBox.Show(System.Text.Encoding.UTF8.EncodeBase64(loginPass));
            //txtBoxUName.Text = System.Text.Encoding.UTF8.EncodeBase64(loginPass);

            if (loginUser == "")
            {
                MessageBox.Show("Can not login! \nUser name must be specified to login!","Warning!");
                return;
            }
            if (loginPass == "")
            {
                MessageBox.Show("Can not login! \nPassword must be specified to login!", "Warning!");
                return;
            }
            //verify employee and password
            
            if (Employee.isLoginPwOfEmp(loginUser, loginPass))
            {
               empJobCode = Employee.isPowerEmp(loginUser);
                Employee employee;
                switch (empJobCode)
                {
                    case 0:
                        {
                            //MessageBox.Show("The user has ReadOnly status!\n" +
                            //    "Access level: " + Employee.DecodeEmpJobCode(empJobCode), "Access granted!",
                            //    MessageBoxButtons.OK, MessageBoxIcon.Information);
                             employee = new ReadOnlyEmployee(empJobCode, loginUser, loginPass);
                            break;
                        }
                    case 1:
                        {
                          //  MessageBox.Show("The user is an Employee!\n" +
                          //    "Access level: " + Employee.DecodeEmpJobCode(empJobCode), "Access granted!",
                          //MessageBoxButtons.OK, MessageBoxIcon.Information);
                             employee = new MIS_Manager(empJobCode, loginUser, loginPass);
                            break;
                        }
                    case 2:
                        {
                            //MessageBox.Show("The user is an Employee!\n" +
                            //    "Access level: " + Employee.DecodeEmpJobCode(empJobCode), "Access granted!",
                            //    MessageBoxButtons.OK, MessageBoxIcon.Information);
                             employee = new Sales_Manager(empJobCode, loginUser, loginPass);
                            break;
                        }

                    case 3:
                        { 
                        //MessageBox.Show("The user is an Employee!\n" +
                        //    "Access level: " + Employee.DecodeEmpJobCode(empJobCode), "Access granted!",
                        //    MessageBoxButtons.OK, MessageBoxIcon.Information);
                            employee = new Inventory_Controller(empJobCode, loginUser, loginPass);
                            break;
                        }
                    case 4:
                        { 
                        //MessageBox.Show("The user is an Employee!\n" +
                        //    "Access level: " + Employee.DecodeEmpJobCode(empJobCode), "Access granted!",
                        //    MessageBoxButtons.OK, MessageBoxIcon.Information);
                            employee = new Order_Clerk(empJobCode, loginUser, loginPass);

                            break;
                        }
                    default:
                        { 
                            MessageBox.Show("The is not a user, account not found!\n" +
                            "Access level: " + Employee.DecodeEmpJobCode(empJobCode), "Access Denied!",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                            employee = null;
                            break;
                        }
                }
                //Employee employee = Employee.getEmp(loginUser, loginPass);
                //to show another windows form
                FrmManageAccount manageFrm = new FrmManageAccount(employee);
                manageFrm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Access denied! \nNo such user name or password incorrect!");
            }

            //exit
        }
    }
}
