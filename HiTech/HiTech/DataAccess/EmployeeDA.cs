using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using HiTech.Business;
using HiTech.Validation;

namespace HiTech.DataAccess
{
    public class EmployeeDA
    {
        //initial file path
        static string filePath = Application.StartupPath + @"\Employees.dat";
        static string tempFilePath = Application.StartupPath + @"\Employees.tmp";

        public static void SaveRecord(Employee employee)
        {
            //create streamWriter
            using (StreamWriter sw = new StreamWriter(filePath, true))
            {
                string recordStr = "";
                recordStr = (employee.EmpId + "|" +
                    employee.FirstName + "|" +
                    employee.LastName + "|" +
                    employee.JobTitle + "|" +
                    employee.EmpStatus + "|" +
                    employee.EmpUserName + "|" +
                    System.Text.Encoding.UTF8.EncodeBase64(employee.EmpPassword) + "|" + /* ConvertTo base64 encryption */
                    employee.EmpPhone + "|" +
                    employee.StatComment);
                if (employee.PictPath !="")
                {
                    recordStr = recordStr + "|" + employee.PictPath;
                }
                else
                {
                    recordStr = recordStr + "|";
                }
                sw.WriteLine(recordStr);
            }
        }

        public static bool SaveRecord(Employee employee, string workFilePath)
        {
            //create streamWriter
            try
            {
                using (StreamWriter sw = new StreamWriter(workFilePath, true))
                {
                    string recordStr = "";
                    recordStr = (employee.EmpId + "|" +
                        employee.FirstName + "|" +
                        employee.LastName + "|" +
                        employee.JobTitle + "|" +
                        employee.EmpStatus + "|" +
                        employee.EmpUserName + "|" +
                        System.Text.Encoding.UTF8.EncodeBase64(employee.EmpPassword) + "|" + /* ConvertTo base64 encryption */
                        employee.EmpPhone + "|" +
                        employee.StatComment);
                    if (employee.PictPath != "")
                    {
                        recordStr = recordStr + "|" + employee.PictPath;
                    }
                    else
                    {
                        recordStr = recordStr + "|";
                    }
                    sw.WriteLine(recordStr);
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error accessing file:!\n" + workFilePath + "\n"
                    + ex + "\nPlease verify input...", "Error found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }

        public static bool isDuplicateId(int id)
        {
            //checking userId if already in use
            if (File.Exists(filePath))
            {
                //create object of type StreamReader
                StreamReader sr = new StreamReader(filePath);
                //read the first line
                string line = sr.ReadLine();
                while (line != null)
                {
                    //split the line into the fields and put it to the array
                    string[] fields = line.Split('|');

                    //check if the first column value is the same as id proposed
                    if (Convert.ToInt32(fields[0]) == id)
                    {
                        //if id is already in use - return true = id duplicate found!
                        sr.Close();
                        MessageBox.Show("Duplicate ID found!\n" + fields[0], "Warning!");
                        return true;
                    }
                    //read the next line if no duplicate found
                    line = sr.ReadLine();
                }
                sr.Close();
                return false;
            }
            else
            {
                MessageBox.Show("The file is not found!", "Error!");
            }
            return false;
        }

        public static bool isDuplicateUser(string userName)
        {
            //checking if user name is already in use
            if (File.Exists(filePath))
            {
                //create object of type StreamReader
                StreamReader sr = new StreamReader(filePath);
                //read the first line
                string line = sr.ReadLine();
                while (line != null)
                {
                    //split the line into the fields and put it to the array
                    string[] fields = line.Split('|');

                    //check if the first column value is the same as id proposed
                    if (fields[5].ToLower() == userName.ToLower())
                    {
                        //if id is already in use - return true = id duplicate found!
                        sr.Close();
                        MessageBox.Show("Duplicate User Name found!\n" + fields[5], "Warning!");
                        return true;
                    }
                    //read the next line if no duplicate found
                    line = sr.ReadLine();
                }
                sr.Close();
                return false;
            }
            else
            {
                MessageBox.Show("The file is not found!", "Error!");
            }
            return false;
        }

        public static Employee SearchRecord(int id)
        {

            if (File.Exists(filePath))
            {
                // create object of type StreamReader
                StreamReader sr = new StreamReader(filePath);
                //read the first line
                string line = sr.ReadLine();
                Employee employee;
                while (line != null)
                {
                    //we split the line and then put it into the array
                    string[] fields = line.Split('|');
                    employee = new Employee();
                    if (Convert.ToInt32(fields[0]) == id)
                    {
                        employee.EmpId = Convert.ToInt32(fields[0]);
                        employee.FirstName = fields[1];
                        employee.LastName = fields[2];
                        employee.JobTitle = Convert.ToInt32(fields[3]);
                        employee.EmpStatus = Convert.ToBoolean(fields[4]);
                        employee.EmpUserName = fields[5];
                        employee.EmpPassword = System.Text.Encoding.UTF8.DecodeBase64(fields[6]); //Decoding from Base64
                        employee.EmpPhone = fields[7];
                        employee.StatComment = fields[8];
                        try
                        {
                            employee.PictPath = fields[9];
                        }
                        catch (Exception ex)
                        {
                            employee.PictPath = "";
                        }
                        sr.Close();
                        return employee;
                    }
                    //read the next line to continue to check the file:
                    line = sr.ReadLine();
                }
                // id is NOT FOUND!
                MessageBox.Show("ID is not found!", "Search failed!");
                sr.Close();
            }
            return null;
        }

        public static bool isLoginPwOfEmp(string name, string pass)
        {
            //check if employee record exists
            if (File.Exists(filePath))
            {
                //create object of type StreamReader
                StreamReader sr = new StreamReader(filePath);
                //read the first line
                string line = sr.ReadLine();
                while (line != null)
                {
                    //split the line into the fields and put it to the array
                    string[] fields = line.Split('|');
                    //check if the user name column value is the same as login-name
                    ////if (fields[0].ToUpper() == name.ToUpper() &&
                    ////                         (fields[5] == pass))
                    try
                    {
                        // Checking if the login name and password are OK
                        if (fields[5] == name.ToLower() &&
                            (System.Text.Encoding.UTF8.DecodeBase64(fields[6]) == pass))
                        {
                            //if ok - employee account is existing and its correct password!
                            if (Convert.ToBoolean(fields[4]) == false) //account is in-active
                            {
                                MessageBox.Show("Employee account is Not in Active state\n" + "\nPlease verify input...", "Error found",
                                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false; //since its in-active we return false
                            }
                            sr.Close();
                            return true;
                        }
                        //read the next line 
                        line = sr.ReadLine();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error checking user name!\n" + ex + "\nPlease verify input...", "Error found",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                sr.Close();
                return false;
            }
            else
            {
                MessageBox.Show("The file is not found!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        public static int isPowerEmp(string name)
        {
            //check if employee is a user
            if (File.Exists(filePath))
            {
                //create object of type StreamReader
                StreamReader sr = new StreamReader(filePath);
                //read the first line
                string line = sr.ReadLine();
                int userPrivilege = -1;
                while (line != null)
                {
                    //split the line into the fields and put it to the array
                    string[] fields = line.Split('|');

                    //check if the user name column value is the same as login-name
                    try
                    {
                        userPrivilege = Convert.ToInt32(fields[3]);
                        //checking if a login name and jobTitle is not 0 (means is employee)
                        if ((fields[5] == name.ToLower())
                        && (userPrivilege > 0))
                        {
                            //if found - user exists and has eleveted privileges!
                            sr.Close();
                            return userPrivilege;
                        }
                        if ((fields[5] == name.ToLower())
                        && (userPrivilege == 0))
                        {
                            //if found - user exists and has 0 privileges!
                            sr.Close();
                            return userPrivilege;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error checking user name!\n" + ex + "\nPlease verify input...", "Error found",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return -1;
                    }

                    //read the next line 
                    line = sr.ReadLine();
                }
                sr.Close();
                return -1;
            }
            else
            {
                MessageBox.Show("The file is not found!", "Error!");
            }
            return -1;
        }

        public static Employee getEmp(string name, string pass)
        {
            //get employee object
            if (File.Exists(filePath))
            {
                //create object of type StreamReader
                StreamReader sr = new StreamReader(filePath);
                Employee employee; // initialize employee object
                //read the first line
                string line = sr.ReadLine();
                while (line != null)
                {
                    //split the line into the fields and put it to the array
                    string[] fields = line.Split('|');
                    try
                    {
                        if (fields[5] == name.ToLower() &&
                            //(Validation.EncryptDecrypt.EncrypDecryp(fields[6]) == pass))
                            (System.Text.Encoding.UTF8.DecodeBase64(fields[6]) == pass))
                        {
                            //if found - employee account is existing!
                            sr.Close();
                            employee = new Employee();
                            employee.EmpId = Convert.ToInt32(fields[0]);
                            employee.FirstName = fields[1];
                            employee.LastName = fields[2];
                            employee.JobTitle = Convert.ToInt32(fields[3]);
                            employee.EmpStatus = Convert.ToBoolean(fields[4]);
                            employee.EmpUserName = fields[5];
                            employee.EmpPassword = System.Text.Encoding.UTF8.DecodeBase64(fields[6]); //Decoding from Base64
                            employee.EmpPhone = fields[7];
                            employee.StatComment = fields[8];
                            try
                            {
                                employee.PictPath = fields[9];
                            }
                            catch (Exception ex)
                            {
                                employee.PictPath = "";
                            }
                            return employee;
                        }
                        //read the next line 
                        line = sr.ReadLine();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error checking user name!\n" + ex + "\nPlease verify input...", "Error found",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                sr.Close();
                return null;
            }
            else
            {
                MessageBox.Show("The file is not found!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null;
        }

        public static List<Employee> SearchRecord(string name, string searchBy)
        {
            int foundCount = 0;
            List<Employee> empList = new List<Employee>();
            if (File.Exists(filePath))
            {
                StreamReader sr = new StreamReader(filePath);
                string line = sr.ReadLine();
                Employee employee; //declaring new object

                while (line != null)
                {
                    string[] fields = line.Split('|');
                    employee = new Employee();//creating new employee object - must be empty obj earch iteration
                    switch (searchBy)
                    {
                        case "firstName":
                            string fName = fields[1].ToUpper();
                            if (fName.IndexOf(name.ToUpper()) > -1) //if substring is found in a string it is greater then -1
                            {
                                foundCount++;
                                employee.EmpId = Convert.ToInt32(fields[0]);
                                employee.FirstName = fields[1];
                                employee.LastName = fields[2];
                                employee.JobTitle = Convert.ToInt32(fields[3]);
                                employee.EmpStatus = Convert.ToBoolean(fields[4]);
                                employee.EmpUserName = fields[5];
                                employee.EmpPassword = System.Text.Encoding.UTF8.DecodeBase64(fields[6]); //Decoding from Base64
                                employee.EmpPhone = fields[7];
                                employee.StatComment = fields[8];
                                try
                                {
                                    employee.PictPath = fields[9];
                                }
                                catch (Exception ex)
                                {
                                    employee.PictPath = "";
                                }
                                empList.Add(employee); //adding next EE record to the list 
                            }
                            break;
                        case "lastName":
                            string lName = fields[2].ToUpper();
                            if (lName.IndexOf(name.ToUpper()) > -1) //if substring is found in a string it is greater then -1 
                            {
                                foundCount++;
                                employee.EmpId = Convert.ToInt32(fields[0]);
                                employee.FirstName = fields[1];
                                employee.LastName = fields[2];
                                employee.JobTitle = Convert.ToInt32(fields[3]);
                                employee.EmpStatus = Convert.ToBoolean(fields[4]);
                                employee.EmpUserName = fields[5];
                                employee.EmpPassword = System.Text.Encoding.UTF8.DecodeBase64(fields[6]); //Decoding from Base64
                                employee.StatComment = fields[7];
                                try
                                {
                                    employee.PictPath = fields[8];
                                }
                                catch (Exception ex)
                                {
                                    employee.PictPath = "";
                                }
                                empList.Add(employee); //adding next emp record to the list   
                            }
                            break;
                        case "firstlast":
                            {
                                foundCount++; //increase a count of found employees records
                                string[] EENames = name.Split(','); // An array with First (,) Last names
                                if (EENames.Length == 2)
                                {
                                    if ((fields[1].ToUpper() == EENames[0].Trim().ToUpper()) &&
                                                        (fields[2].ToUpper() == EENames[1].Trim().ToUpper()))
                                    {
                                        employee.EmpId = Convert.ToInt32(fields[0]);
                                        employee.FirstName = fields[1];
                                        employee.LastName = fields[2];
                                        employee.JobTitle = Convert.ToInt32(fields[3]);
                                        employee.EmpStatus = Convert.ToBoolean(fields[4]);
                                        employee.EmpUserName = fields[5];
                                        employee.EmpPassword = System.Text.Encoding.UTF8.DecodeBase64(fields[6]); //Decoding from Base64
                                        employee.EmpPhone = fields[7];
                                        employee.StatComment = fields[8];
                                        try
                                        {
                                            employee.PictPath = fields[9];
                                        }
                                        catch (Exception ex)
                                        {
                                            employee.PictPath = "";
                                        }
                                        empList.Add(employee); //adding next emp record to the list   
                                    }
                                }
                            }
                            break;
                        default:
                            break;
                    }
                    //read the next line to continue to check the file:
                    line = sr.ReadLine();
                }
                sr.Close();
            }
            if (foundCount == 0) //if no employees found we have to return nothing
            {
                MessageBox.Show("Nothing found!", "Search failed!");
                //return null;
            }
            return empList;
        }

        public static List<Employee> ListAllRecords()
        {
            //Here we have to return the list of Student objects:
            List<Employee> employeesList = new List<Employee>();
            if (File.Exists(filePath))
            {
                StreamReader sr = new StreamReader(filePath);
                string line = sr.ReadLine();
                Employee employee;
                while (line != null)
                {
                    string[] fields = line.Split('|');
                    employee = new Employee
                    {
                        EmpId = Convert.ToInt32(fields[0]),
                        FirstName = fields[1],
                        LastName = fields[2],
                        JobTitle = Convert.ToInt32(fields[3]),
                        EmpStatus = Convert.ToBoolean(fields[4]),
                        EmpUserName = fields[5],
                        EmpPassword = System.Text.Encoding.UTF8.DecodeBase64(fields[6]), //Decoding from Base64
                        EmpPhone = fields[7],
                        StatComment = fields[8]
                    };
                    try
                    {
                        employee.PictPath = fields[9];
                    }
                    catch (Exception ex)
                    {

                        employee.PictPath = "";
                    }
                    employeesList.Add(employee); //adding next EE record to the list
                    line = sr.ReadLine();
                }
                sr.Close();
            }
            return employeesList;
        }

        public static bool UpdateRecord(Employee empToUpdate)
        {
            List<Employee> employeesList = new List<Employee>();//in case if we have to return a list of Emps(for future versions)
            if (File.Exists(filePath))
            {
                StreamReader sr = new StreamReader(filePath);
                string line = sr.ReadLine();
                Employee employee;
                while (line != null)
                {
                    string[] fields = line.Split('|');
                    employee = new Employee
                    {
                        EmpId = Convert.ToInt32(fields[0]),
                        FirstName = fields[1],
                        LastName = fields[2],
                        JobTitle = Convert.ToInt32(fields[3]),
                        EmpStatus = Convert.ToBoolean(fields[4]),
                        EmpUserName = fields[5],
                        EmpPassword = System.Text.Encoding.UTF8.DecodeBase64(fields[6]), //Decoding from Base64
                        EmpPhone = fields[7],
                        StatComment = fields[8]
                    };
                    try
                    {
                        employee.PictPath = fields[9];
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: \n" + ex.Message, "Error!");
                        employee.PictPath = "";
                    }

                    if (employee.EmpId == empToUpdate.EmpId) //This is existing employee record
                    {
                        //save the record with updated empl data to the temp file if no errors:
                        if (SaveRecord(empToUpdate, tempFilePath))
                        {
                            employeesList.Add(empToUpdate); //adding next EE record to the list (Why?)
                        }
                    }
                    else
                    {
                       if (SaveRecord(employee, tempFilePath))  //save old record to the temp file if no errors:
                        {
                            employeesList.Add(employee); //adding next EE record to the list (Why?)
                        }
                    }
                    line = sr.ReadLine();
                }
                sr.Close();
                // move the content of the Temp file into the original file
                if (File.Exists(tempFilePath) && File.Exists(filePath))
                {
                    File.Delete(filePath);
                    File.Move(tempFilePath, filePath);
                    return true;
                }
            }
            return false;
        }

        public static string DecodeEmpJobCode(int code) // function to decode JobTitles
        {
            string jobTitle = "Employee";
            switch (code)
            {
                case 0:
                    jobTitle = "Employee";
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

        public static bool isValidId(string valueID, int num)
        {
            return Validator.isValidId(valueID, 4);
        }
        public static bool isValidUser(string valueUser)
        {
            return Validator.isValidUser(valueUser);
        }

        public static bool isValidName(string name)
        {
            return Validator.isValidName(name);
        }

        public static string setNameStr(string str)
        {
            return Validator.setNameStr(str);
        }
        public static int NextEmpId(List<Employee> employees)
        {
            //List<Employee> employees = Employee.ListAllRecords();
            int maxId = 0;
            foreach (Employee emp in employees)
            {
                if (emp.EmpId > maxId)
                {
                    maxId = emp.EmpId;
                }
            }
            if (maxId > 0)
            {
                return maxId + 1;
            }
            return 1;
        }
    }
}
