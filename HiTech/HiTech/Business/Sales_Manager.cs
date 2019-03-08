using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiTech.Business
{
    public class Sales_Manager : Employee
    {
        private string jobTitle;
       // private int jobCode;

        //public int JobCode { get => jobCode; set => jobCode = value; }

        public Sales_Manager() : base() { }

        public Sales_Manager(int empJobCode, string empUserName, string empPassword)
            : base(empUserName, empPassword)
        {
            jobTitle = Employee.DecodeEmpJobCode(empJobCode);
        }


        public override string ToString()
        {
            return base.ToString();
        }
        public bool ManageClient() { return true; }
    }
}
