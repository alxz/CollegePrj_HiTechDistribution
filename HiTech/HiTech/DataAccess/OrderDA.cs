using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using HiTech.Business;
using HiTech.Validation;

using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;


namespace HiTech.DataAccess
{
    public class OrderDA
    {
        static string filePath = Application.StartupPath + @"\Orders.dat";
        static string tempFilePath = Application.StartupPath + @"\Orders.tmp";

        static string filePathXML = Application.StartupPath + @"\Orders.xml";
        static string tempFilePathXML = Application.StartupPath + @"\OrdersXML.tmp";


        public static void SaveAllProducts(List<Order> products)
        { //to save products to XML file
            FileStream outFile = File.Create(filePathXML);
            XmlSerializer formatter = new XmlSerializer(products.GetType());
            formatter.Serialize(outFile, products);
            outFile.Close();
        }

        public static List<Order> XMLLoadAllProducts()
        {
            if (!File.Exists(filePathXML))
            {
                List<Order> orderEmpty = new List<Order>();
                return orderEmpty;
            }
            try
            {
                XmlSerializer formatter = new XmlSerializer(typeof(List<Order>));
                FileStream aFile = new FileStream(filePathXML, FileMode.Open);
                byte[] buffer = new byte[aFile.Length];
                aFile.Read(buffer, 0, (int)aFile.Length);
                MemoryStream stream = new MemoryStream(buffer);

                List<Order> orders = (List<Order>)formatter.Deserialize(stream);
                aFile.Close();
                return orders;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error reading an XML file for Orders!\n" + "File:" + filePathXML + "\n\n"
                    + ex + "\nPlease verify input...", "Error found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                List<Order> orderEmpty = new List<Order>();
                return orderEmpty;
            }
        }

        
        public static bool isValidId(string valueID, int num)
        {
            return Validator.isValidId(valueID, num);
        }

        
        public static Order SearchXMLRecordProd(int id)
        {
            //Product.XMLLoadAllProducts()
            List<Order> orderList = Order.XMLLoadAllProducts();
            Order foundOrd = new Order();
            foreach (Order order in orderList)
            {
                if (order.OrdId == id)
                {
                    foundOrd = order;
                }
            }
            return foundOrd;
        }

        public static List<Order> SearchXMLRecordProd(string name, string searchBy)
        {//Searching a Product(s) - return the list
            int foundCount = 0;
            //we need to return a list, so lets create it now
            List<Order> allOrders = Order.XMLLoadAllProducts();
            List<Order> ordersList = new List<Order>();
            switch (searchBy)
            {
                case "cname": //searching by client name
                    Client aClient = new Client();                    
                    foreach (Order anOrder in allOrders)
                    {
                        aClient = Client.SearchRecord(anOrder.ClientId);
                        if (aClient.ClientName.ToLower().IndexOf(name.ToLower()) > -1)
                        {
                            ordersList.Add(anOrder);
                            foundCount++;
                        }
                    }
                    break;
                case "createdby": //created by an employee
                    Employee emp = new Employee();                    
                    foreach (Order anOrder in allOrders)
                    {
                        emp = Employee.SearchEmployee(anOrder.CreatedByEmpId);
                        if ((emp.FirstName.ToLower().IndexOf(name.ToLower()) > -1) ||
                            (emp.LastName.ToLower().IndexOf(name.ToLower()) > -1))
                        {
                            ordersList.Add(anOrder);
                            foundCount++;
                        }
                    }
                    break;
                default:
                    break;
            }

            if (foundCount == 0) //if no objects found we have to return nothing
            {
                MessageBox.Show("Sorry, nothing found!", "Search failed!");
                //return null;
            }
            return ordersList;



        }

        public static int NextObjId(List<Order> objList)
        {
            int maxId = 0;
            foreach (Order obj in objList)
            {
                if (obj.OrdId > maxId)
                {
                    maxId = obj.OrdId;
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

        public static bool isDuplicate(int orderId)
        {
            List<Order> orderList = Order.XMLLoadAllProducts();
            Order foundOrd = new Order();
            foreach (Order order in orderList)
            {
                if (order.OrdId == orderId)
                {
                    return true;
                }
            }
            return false;
        }

    }//class
}//namespace
