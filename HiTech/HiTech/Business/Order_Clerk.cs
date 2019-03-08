using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiTech.Business
{
    public class Order_Clerk : Employee
    {
        private string jobTitle;
        //private int jobCode;
        public Order_Clerk() : base()
        { }
        public Order_Clerk(int empJobCode, string empUserName, string empPassword)
            : base(empUserName, empPassword)
        {
            jobTitle = Employee.DecodeEmpJobCode(empJobCode);
        }
        //public string JobTitle { get => jobTitle; set => jobTitle = value; }
        //public int JobCode { get => jobCode; set => jobCode = value; }

        public override string ToString()
        {
            return base.ToString();
        }

        public bool ManageOrder() { return true; }
    }
}
