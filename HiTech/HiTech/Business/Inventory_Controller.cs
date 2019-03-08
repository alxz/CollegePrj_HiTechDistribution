using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiTech.Business
{
    public class Inventory_Controller : Employee
    {
        private string jobTitle;
        //private int jobCode;
        public Inventory_Controller() : base()
        { }

        public Inventory_Controller(int empJobCode, string empUserName, string empPassword)
            : base(empUserName, empPassword)
        {
            this.jobTitle = Employee.DecodeEmpJobCode(empJobCode);
        }

        //public string JobTitle { get => jobTitle; set => jobTitle = value; }
        //public int JobCode { get => jobCode; set => jobCode = value; }

        public override string ToString()
        {
            return base.ToString();
        }

        public bool ManageProduct() { return true; }
    }
}
