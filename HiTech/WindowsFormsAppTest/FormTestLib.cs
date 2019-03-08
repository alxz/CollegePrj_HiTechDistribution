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

namespace WindowsFormsAppTest
{
    public partial class FormTestLib : Form
    {
        public FormTestLib()
        {
            InitializeComponent();
        }

        private void buttonDisplay_Click(object sender, EventArgs e)
        {
            Employee emp = new Employee();
            emp.EmployeeId = 1020;
            emp.FirstName = "Mary";
            emp.LastName = "Brown";

            MessageBox.Show("Employee:\n" + emp.EmployeeId + "\t" + 
                emp.FirstName + ", " + emp.LastName);
        }
    }
}
