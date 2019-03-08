using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiTech.DataAccess;

namespace HiTech.Business
{
    public class Employee
    {
        //Employee class fields
        private int empId;
        private string firstName;
        private string lastName;
        private int jobTitle;   //0 = Employee; - no access to the system
                                // 1 = MIS Manager
                                // 2 = Sales Manager
                                // 3 = Inventory controller
        private bool empStatus; // 0=Inactive; 1=Active;
        private string empUserName; //user name
        private string empPassword;
        private string statComment;
        private string empContact; // all inclusive: email, address, extra phones
        private string empPhone; //temp for primary phone only
        private string empEmail; //temp for primary phone only
        private string pictPath; //a path to saved employee picture


        public int EmpId { get => empId; set => empId = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public int JobTitle { get => jobTitle; set => jobTitle = value; }
        public bool EmpStatus { get => empStatus; set => empStatus = value; }
        public string EmpPassword { get => empPassword; set => empPassword = value; }
        public string EmpUserName { get => empUserName; set => empUserName = value; }
        public string StatComment { get => statComment; set => statComment = value; }
        public string EmpPhone { get => empPhone; set => empPhone = value; }
        public string EmpContact { get => empContact; set => empContact = value; }
        public string PictPath { get => pictPath; set => pictPath = value; }
        public string EmpEmail { get => empEmail; set => empEmail = value; }

        public void SaveEmployee(Employee anEmployee)
        {
            EmployeeDA.SaveRecord(anEmployee);
        }
        public static void UpdateRecord(Employee employee)
        {
            EmployeeDA.UpdateRecord(employee);
        }
        public static bool isDuplicate(int id)
        {
            return EmployeeDA.isDuplicateId(id);
        }

        public static bool isDuplicateUser(string userName)
        {
            return EmployeeDA.isDuplicateUser(userName);
        }

        public static Employee SearchEmployee(int eId)
        {
            return EmployeeDA.SearchRecord(eId);
        }

        public static List<Employee> SearchRecord(string name, string searchBy)
        {
            return EmployeeDA.SearchRecord(name, searchBy);
        }


        public static List<Employee> ListAllRecords()
        {

            return EmployeeDA.ListAllRecords();
        }

        public static bool isLoginPwOfEmp(string name, string pass)
        {
            return EmployeeDA.isLoginPwOfEmp(name, pass);
        }

        public static int isPowerEmp(string name)
        {
            return EmployeeDA.isPowerEmp(name);
        }

        public static Employee getEmp(string name, string pass)
        {
            return EmployeeDA.getEmp(name, pass);
        }

        public static bool isValidId(string valueID, int num)
        {
            return EmployeeDA.isValidId(valueID, num);
        }

        public static bool isValidUser(string valueUser)
        {
            return EmployeeDA.isValidUser(valueUser);
        }
        public static bool isValidName(string name)
        {
            return EmployeeDA.isValidName(name);
        }
        public static string setNameStr(string str)
        {
            return EmployeeDA.setNameStr(str);
        }

        public static int NextEmpId(List<Employee> employees)
        {
            return EmployeeDA.NextEmpId(employees);
        }


        public Employee() { }

        public Employee(string name, string pass)
        {
            Employee emp = EmployeeDA.getEmp(name, pass);
            this.empId = emp.EmpId;
            this.firstName = emp.FirstName;
            this.lastName = emp.LastName;
            this.jobTitle = emp.JobTitle;
            this.empStatus = emp.EmpStatus; // 0=Inactive; 1=Active;
            this.empUserName = emp.EmpUserName; //user name
            this.empPassword = emp.EmpPassword;
            this.statComment = emp.StatComment;
            this.empContact = emp.EmpContact; // all inclusive: email, address, extra phones
            this.empPhone = emp.EmpPhone; //temp for primary phone only
            this.empEmail = emp.EmpEmail; //Email address
            this.pictPath = emp.PictPath;
        }

        public static string DecodeEmpJobCode(int code) // function to decode JobTitles
        {
            return EmployeeDA.DecodeEmpJobCode(code); //to return the description of the JobCode
        }
        public virtual int JobCode()
        {
            return this.JobTitle;
        }

        //public Employee(int empId, string firstName, string lastName, int jobTitle, bool empStatus,
        //    string empUserName, string empPassword, string statComment)
        //{
        //    EmpId = empId;
        //    FirstName = firstName;
        //    LastName = lastName;
        //    JobTitle = jobTitle;
        //    EmpStatus = empStatus;
        //    EmpUserName = empUserName;
        //    EmpPassword = empPassword;
        //    StatComment = statComment;
        //    EmpId = empId;
        //    FirstName = firstName;
        //    LastName = lastName;
        //    JobTitle = jobTitle;
        //    EmpStatus = empStatus;
        //    EmpPassword = empPassword;
        //    EmpUserName = empUserName;
        //    StatComment = statComment;
        //}
    }
}
