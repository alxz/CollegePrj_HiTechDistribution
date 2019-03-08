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
    public class AuthorDA
    {
        //initial file path
        static string filePath = Application.StartupPath + @"\Authors.dat";
        static string tempFilePath = Application.StartupPath + @"\Authors.tmp";

        public static bool SaveRecord(Author author, string workFilePath)
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
                    recordStr = (author.AuthId + "|" +
                        author.AuthFirstName + "|" +
                        author.AuthLastName);
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
                        //MessageBox.Show("Duplicate ID found!\n" + fields[0], "Warning!");
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

        public static Author SearchRecord(int id)
        {
            if (File.Exists(filePath))
            {// create object of type StreamReader
                StreamReader sr = new StreamReader(filePath);
                //read the first line
                string line = sr.ReadLine();
                Author anAuthor;
                while (line != null)
                {
                    //we split the line and then put it into the array
                    string[] fields = line.Split('|');
                    anAuthor = new Author();
                    if (Convert.ToInt32(fields[0]) == id)
                    {
                        anAuthor.AuthId = Convert.ToInt32(fields[0]);
                        anAuthor.AuthFirstName = fields[1];
                        anAuthor.AuthLastName = fields[2];
                        sr.Close();
                        return anAuthor;
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

        public static List<Author> SearchRecord(string name, string searchBy)
        { //Searching a Author(s) - return the list
            int foundCount = 0;
            List<Author> autList = new List<Author>(); //we need to return a list, so lets create it now
            if (File.Exists(filePath))
            {
                StreamReader sr = new StreamReader(filePath);
                string line = sr.ReadLine();
                Author obj; //declaring new object for an Author
                while (line != null)
                {
                    string str = "";
                    string[] fields = line.Split('|');
                    obj = new Author();//creating new object - must be empty obj earch iteration
                    switch (searchBy)
                    {
                        case "firstname":
                            str = fields[1].ToUpper();
                            if (str.IndexOf(name.ToUpper()) > -1)
                            {
                                foundCount++;
                                obj.AuthId = Convert.ToInt32(fields[0]);
                                obj.AuthFirstName = fields[1];
                                obj.AuthLastName = fields[2];
                                autList.Add(obj);
                            }
                            break;
                        case "lastname":
                            str = fields[2].ToUpper();
                            if (str.IndexOf(name.ToUpper()) > -1)
                            {
                                foundCount++;
                                obj.AuthId = Convert.ToInt32(fields[0]);
                                obj.AuthFirstName = fields[1];
                                obj.AuthLastName = fields[2];
                                autList.Add(obj);
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
            return autList;
        }

        public static List<Author> ListAllRecords()
        {
            //Here we have to return the list of objects:
            List<Author> authList = new List<Author>();
            if (File.Exists(filePath))
            {
                StreamReader sr = new StreamReader(filePath);
                string line = sr.ReadLine();
                Author obj;
                while (line != null)
                {
                    try
                    {
                        string[] fields = line.Split('|');
                        obj = new Author
                        {
                            AuthId = Convert.ToInt32(fields[0]),
                            AuthFirstName = fields[1],
                            AuthLastName = fields[2]
                        };
                        authList.Add(obj); //adding next record to the list
                    }
                    catch (Exception Ex)
                    {  //in case of any errors reading file;
                        MessageBox.Show("Error reading authors data from file! \nSkipping a author record\n\n" + Ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    line = sr.ReadLine();
                }
                sr.Close();
            }
            return authList;
        }

        public static bool UpdateRecord(Author objUpdate)
        {
            if (File.Exists(filePath))
            {
                StreamReader sr = new StreamReader(filePath);
                string line = sr.ReadLine();
                Author obj;
                while (line != null)
                {
                    string[] fields = line.Split('|');
                    obj = new Author()
                    {
                        AuthId = Convert.ToInt32(fields[0]),
                        AuthFirstName = fields[1],
                        AuthLastName = fields[2]
                    };
                    if (obj.AuthId == objUpdate.AuthId) //This is existing record
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


        public static bool DeleteRecord(Author objDelete)
        {
            if (File.Exists(filePath))
            {
                StreamReader sr = new StreamReader(filePath);
                string line = sr.ReadLine();
                Author obj;
                while (line != null)
                {
                    string[] fields = line.Split('|');
                    obj = new Author()
                    {
                        AuthId = Convert.ToInt32(fields[0]),
                        AuthFirstName = fields[1],
                        AuthLastName = fields[2]
                    };
                    if (obj.AuthId == objDelete.AuthId) //This is existing record
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


        public static int NextObjId(List<Author> objList)
        {
            int maxId = 0;
            foreach (Author obj in objList)
            {
                if (obj.AuthId > maxId)
                {
                    maxId = obj.AuthId;
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
