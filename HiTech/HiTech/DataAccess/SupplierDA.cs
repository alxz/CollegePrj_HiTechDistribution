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
    public class SupplierDA
    {
        //initial file path
        static string filePath = Application.StartupPath + @"\Suppliers.dat";
        static string tempFilePath = Application.StartupPath + @"\Suppliers.tmp";

        public static bool SaveRecord(Supplier supplier, string workFilePath)
        {
            //create streamWriter
            if (workFilePath == "")
            {
                workFilePath = filePath;
            }
            try
            {
                using (StreamWriter sw = new StreamWriter(workFilePath, true))
                {
                    string recordStr = "";
                    recordStr = (supplier.SuppId + "|" +
                        supplier.SuppName + "|" +
                        supplier.SuppEmail);
                    sw.WriteLine(recordStr);
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving a file:!\n" + workFilePath + "\n"
                    + ex + "\nPlease verify input...", "Error found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public static bool isDuplicateId(int id)
        {
            try
            {   //create object of type StreamReader
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
                        return true;
                    }
                    //read the next line if no duplicate found
                    line = sr.ReadLine();
                }
                sr.Close();
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("The file is not found!" + "\n" + ex.Message, "Error!");
            }
            return false;
        }

        public static bool isValidId(string valueID, int num)
        {
            return Validator.isValidId(valueID, num);
        }

        public static Supplier SearchRecord(int id)
        {
            if (File.Exists(filePath))
            {// create object of type StreamReader
                StreamReader sr = new StreamReader(filePath);
                //read the first line
                string line = sr.ReadLine();
                Supplier aSupp;
                while (line != null)
                {
                    //we split the line and then put it into the array
                    string[] fields = line.Split('|');
                    aSupp = new Supplier();
                    if (Convert.ToInt32(fields[0]) == id)
                    {
                        aSupp.SuppId = Convert.ToInt32(fields[0]);
                        aSupp.SuppName = fields[1];
                        aSupp.SuppEmail = fields[2];
                        sr.Close();
                        return aSupp;
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

        public static List<Supplier> SearchRecord(string name, string searchBy)
        { //Searching a Supplier(s) - return the list
            int foundCount = 0;
            List<Supplier> supList = new List<Supplier>(); //we need to return a list, so lets create it now
            if (File.Exists(filePath))
            {
                StreamReader sr = new StreamReader(filePath);
                string line = sr.ReadLine();
                Supplier obj; //declaring new object for an Supplier
                while (line != null)
                {
                    string str = "";
                    string[] fields = line.Split('|');
                    obj = new Supplier();//creating new object - must be empty obj earch iteration
                    switch (searchBy)
                    {
                        case "name":
                            str = fields[1].ToUpper();
                            if (str.IndexOf(name.ToUpper()) > -1)
                            {
                                foundCount++;
                                obj.SuppId = Convert.ToInt32(fields[0]);
                                obj.SuppName = fields[1];
                                obj.SuppEmail = fields[2];
                                supList.Add(obj);
                            }
                            break;
                        case "email":
                            str = fields[5].ToUpper();
                            if (str.IndexOf(name.ToUpper()) > -1)
                            {
                                foundCount++;
                                obj.SuppId = Convert.ToInt32(fields[0]);
                                obj.SuppName = fields[1];
                                obj.SuppEmail = fields[2];
                                supList.Add(obj);
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
            if (foundCount == 0) //if no objects found we have to return nothing
            {
                MessageBox.Show("Sorry, nothing found!", "Search failed!");
                //return null;
            }
            return supList;
        }

        public static List<Supplier> ListAllRecords()
        {
            //Here we have to return the list of objects:
            List<Supplier> supList = new List<Supplier>();
            if (File.Exists(filePath))
            {
                StreamReader sr = new StreamReader(filePath);
                string line = sr.ReadLine();
                Supplier obj;
                while (line != null)
                {
                    try
                    {
                        string[] fields = line.Split('|');
                        obj = new Supplier
                        {
                            SuppId = Convert.ToInt32(fields[0]),
                            SuppName = fields[1],
                            SuppEmail = fields[2]
                        };
                        supList.Add(obj); //adding next record to the list
                    }
                    catch (Exception Ex)
                    {  //in case of any errors reading file;
                        MessageBox.Show("Error reading suppliers data from file! \nSkipping a author record\n\n" + Ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    line = sr.ReadLine();
                }
                sr.Close();
            }
            return supList;
        }

        public static bool UpdateRecord(Supplier objUpdate)
        {
            if (File.Exists(filePath))
            {
                StreamReader sr = new StreamReader(filePath);
                string line = sr.ReadLine();
                Supplier obj;
                while (line != null)
                {
                    string[] fields = line.Split('|');
                    obj = new Supplier()
                    {
                        SuppId = Convert.ToInt32(fields[0]),
                        SuppName = fields[1],
                        SuppEmail = fields[2]
                    };
                    if (obj.SuppId == objUpdate.SuppId) //This is existing record
                    {
                        //save updated data of the record to the temp file if no errors:
                        SaveRecord(objUpdate, tempFilePath);
                    }
                    else
                    {
                        //save new record to the temp file if no errors:
                        SaveRecord(obj, tempFilePath);
                    }
                    line = sr.ReadLine();
                }
                sr.Close();
                if (File.Exists(tempFilePath) && File.Exists(filePath))
                {
                    File.Delete(filePath);
                    File.Move(tempFilePath, filePath);
                    return true;
                }
            }
            return false;
        }

        public static bool DeleteRecord(Supplier objDelete)
        {
            if (File.Exists(filePath))
            {
                StreamReader sr = new StreamReader(filePath);
                string line = sr.ReadLine();
                Supplier obj;
                while (line != null)
                {
                    string[] fields = line.Split('|');
                    obj = new Supplier()
                    {
                        SuppId = Convert.ToInt32(fields[0]),
                        SuppName = fields[1],
                        SuppEmail = fields[2]
                    };
                    if (obj.SuppId == objDelete.SuppId) //This is existing record
                    {
                        //Skip the record to be deleted and go to the next record
                        // SaveRecord(objDelete, tempFilePath);
                    }
                    else
                    {
                        //save new record to the temp file if no errors:
                        SaveRecord(obj, tempFilePath);
                    }
                    line = sr.ReadLine();
                }
                sr.Close();
                if (File.Exists(tempFilePath) && File.Exists(filePath))
                {
                    File.Delete(filePath);
                    File.Move(tempFilePath, filePath);
                    return true;
                }
            }
            return false;
        }
        public static int NextObjId(List<Supplier> objList)
        {
            int maxId = 0;
            foreach (Supplier obj in objList)
            {
                if (obj.SuppId > maxId)
                {
                    maxId = obj.SuppId;
                }
            }
            if (maxId > 0)
            {
                return maxId + 1;
            }
            return 1;
        }

        public static bool isDigit(string input)
        {
            return Validator.isDigit(input);
        }
    }
}
