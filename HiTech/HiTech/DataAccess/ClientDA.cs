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
    public class ClientDA
    {
        //initial file path
        static string filePath = Application.StartupPath + @"\Clients.dat";
        static string tempFilePath = Application.StartupPath + @"\Clients.tmp";

        public static bool SaveRecord(Client client, string workFilePath)
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
                    recordStr = (client.ClientId + "|" +
                        client.ClientName + "|" +
                        client.ClientStatus + "|" +
                        client.StatComment + "|" +
                        client.ClientStreet + "|" +
                        client.ClientCity + "|" +
                        client.ClientPCode + "|" +
                        client.ClientPhone + "|" +
                        client.ClientFax + "|" +
                        client.ClientEmail + "|" +
                        client.CredLimit);
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
            return Validator.isValidId(valueID, 4);
        }
        public static Client SearchRecord(int id)
        {
            if (File.Exists(filePath))
            {// create object of type StreamReader
                StreamReader sr = new StreamReader(filePath);
                //read the first line
                string line = sr.ReadLine();
                Client client;
                while (line != null)
                {
                    //we split the line and then put it into the array
                    string[] fields = line.Split('|');
                    client = new Client();
                    if (Convert.ToInt32(fields[0]) == id)
                    {
                        client.ClientId = Convert.ToInt32(fields[0]);
                        client.ClientName = fields[1];
                        client.ClientStatus = Convert.ToBoolean(fields[2]);
                        client.StatComment = fields[3];

                        client.ClientStreet = fields[4];
                        client.ClientCity = fields[5];
                        client.ClientPCode = fields[6];

                        client.ClientPhone = fields[7];
                        client.ClientFax = fields[8];
                        client.ClientEmail = fields[9];
                        client.CredLimit = Convert.ToDouble(fields[10]);
                        sr.Close();
                        return client;
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

        public static bool UpdateRecord(Client cliToUpdate)
        {
            if (File.Exists(filePath))
            {
                StreamReader sr = new StreamReader(filePath);
                string line = sr.ReadLine();
                Client client;
                while (line != null)
                {
                    string[] fields = line.Split('|');
                    client = new Client()
                    {
                    ClientId = Convert.ToInt32(fields[0]),
                    ClientName = fields[1],
                    ClientStatus = Convert.ToBoolean(fields[2]),
                    StatComment = fields[3],
                    ClientStreet = fields[4],
                    ClientCity = fields[5],
                    ClientPCode = fields[6],
                    ClientPhone = fields[7],
                    ClientFax = fields[8],
                    ClientEmail = fields[9],
                    CredLimit = Convert.ToDouble(fields[10])
                };
                    if (client.ClientId == cliToUpdate.ClientId) //This is existing client record
                    {
                        //save updated data of the record to the temp file if no errors:
                        SaveRecord(cliToUpdate, tempFilePath);
                    }
                    else
                    {
                        //save new record to the temp file if no errors:
                        SaveRecord(client, tempFilePath);
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

        public static List<Client> SearchRecord(string name, string searchBy)
        { //Searching a client(s) - return the list
            int foundCount = 0;
            List<Client> cliList = new List<Client>(); //we need to return a list, so lets create it now
            if (File.Exists(filePath))
            {
                StreamReader sr = new StreamReader(filePath);
                string line = sr.ReadLine();
                Client client; //declaring new object for client
                while (line != null)
                {
                    string str = "";
                    string[] fields = line.Split('|');
                    client = new Client();//creating new object - must be empty obj earch iteration
                    switch (searchBy)
                    {
                        case "name":
                            str = fields[1].ToUpper();
                            if (str.IndexOf(name.ToUpper()) > -1)
                            {
                                foundCount++;
                                client.ClientId = Convert.ToInt32(fields[0]);
                                client.ClientName = fields[1];
                                client.ClientStatus = Convert.ToBoolean(fields[2]);
                                client.StatComment = fields[3];

                                client.ClientStreet = fields[4];
                                client.ClientCity = fields[5];
                                client.ClientPCode = fields[6];

                                client.ClientPhone = fields[7];
                                client.ClientFax = fields[8];
                                client.ClientEmail = fields[9];
                                client.CredLimit = Convert.ToDouble(fields[10]);
                                cliList.Add(client); //adding next Client record to the list   
                            }
                            break;
                        case "city":
                            str = fields[5].ToUpper();
                            if (str.IndexOf(name.ToUpper()) > -1)
                            {
                                foundCount++;
                                client.ClientId = Convert.ToInt32(fields[0]);
                                client.ClientName = fields[1];
                                client.ClientStatus = Convert.ToBoolean(fields[2]);
                                client.StatComment = fields[3];

                                client.ClientStreet = fields[4];
                                client.ClientCity = fields[5];
                                client.ClientPCode = fields[6];

                                client.ClientPhone = fields[7];
                                client.ClientFax = fields[8];
                                client.ClientEmail = fields[9];
                                client.CredLimit = Convert.ToDouble(fields[10]);
                                cliList.Add(client); //adding next Client record to the list   
                            }
                            break;
                        case "pcode":
                            str = fields[6].ToUpper();
                            if (str.IndexOf(name.ToUpper()) > -1)
                            {
                                foundCount++;
                                client.ClientId = Convert.ToInt32(fields[0]);
                                client.ClientName = fields[1];
                                client.ClientStatus = Convert.ToBoolean(fields[2]);
                                client.StatComment = fields[3];

                                client.ClientStreet = fields[4];
                                client.ClientCity = fields[5];
                                client.ClientPCode = fields[6];

                                client.ClientPhone = fields[7];
                                client.ClientFax = fields[8];
                                client.ClientEmail = fields[9];
                                client.CredLimit = Convert.ToDouble(fields[10]);
                                cliList.Add(client); //adding next Client record to the list    
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
            if (foundCount == 0) //if no clients found we have to return nothing
            {
                MessageBox.Show("Sorry, nothing found!", "Search failed!");
                //return null;
            }
            return cliList;
        }

        public static List<Client> ListAllRecords()
        {
            //Here we have to return the list of objects:
            List<Client> cliList = new List<Client>();
            if (File.Exists(filePath))
            {
                StreamReader sr = new StreamReader(filePath);
                string line = sr.ReadLine();
                Client client;
                while (line != null)
                {
                    
                    try
                    {
                        string[] fields = line.Split('|');
                        client = new Client
                        {
                            ClientId = Convert.ToInt32(fields[0]),
                            ClientName = fields[1],
                            ClientStatus = Convert.ToBoolean(fields[2]),
                            StatComment = fields[3],
                            ClientStreet = fields[4],
                            ClientCity = fields[5],
                            ClientPCode = fields[6],
                            ClientPhone = fields[7],
                            ClientFax = fields[8],
                            ClientEmail = fields[9],
                            CredLimit = Convert.ToDouble(fields[10])
                        };
                        cliList.Add(client); //adding next record to the list
                    }
                    catch (Exception Ex)
                    {
                        //error reading file;
                        MessageBox.Show("Error reading clients data from file! \nSkipping a client record\n\n" + Ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    
                    line = sr.ReadLine();
                }
                sr.Close();
            }
            return cliList;
        }

        public static int NextCliId(List<Client> clients)
        {
            int maxId = 0;
            foreach (Client cli in clients)
            {
                if (cli.ClientId > maxId)
                {
                    maxId = cli.ClientId;
                }
            }
            if (maxId > 0)
            {
                return maxId + 1;
            }
            return 1;
        }

        public static string setPhoneNumber(string phoneStr)
        {
            return Validator.setPhoneNumber(phoneStr);
        }

        public static bool isPhoneNumber(string phoneStr)
        {
            return Validator.isPhoneNumber(phoneStr);
        }

        public static bool isDigit(string input)
        {
            return Validator.isDigit(input);
        }
        public static bool isCanPostCode(string input)
        { //check if valid Canada Post Code
            return Validator.isCanPostCode(input);
        }


    }//end of class
}//end of namespace
