using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiTech.Business
{
    public class MIS_Manager : Employee
    {
        //Child Class for Employee
        private string jobTitle;
        //private int jobCode;

        //public int JobCode { get => jobCode; set => jobCode = value; }

        public MIS_Manager() : base()
        { }

        public MIS_Manager(int empJobCode, string empUserName, string empPassword)
             : base(empUserName, empPassword)
        {
            jobTitle = Employee.DecodeEmpJobCode(empJobCode);
        }


        public override string ToString()
        {
            return base.ToString();
        }

        public bool ManageEmployee() { return true; }
        public bool ManageClient() { return true; }
    }
}
