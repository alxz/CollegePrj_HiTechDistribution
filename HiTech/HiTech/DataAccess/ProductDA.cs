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
    public class ProductDA
    {
        //initial file path
        static string filePath = Application.StartupPath + @"\Products.dat";
        static string tempFilePath = Application.StartupPath + @"\Products.tmp";
        static string filePathBin = Application.StartupPath + @"\Products.bin";
        static string tempFilePathBin = Application.StartupPath + @"\ProductsBin.tmp";

        static string filePathXML = Application.StartupPath + @"\Products.xml";
        static string tempFilePathXML = Application.StartupPath + @"\ProductsXML.tmp";

        public static bool SaveRecord(Product obj)
        {
            //create streamWriter
            using (StreamWriter sw = new StreamWriter(filePath, true))
            {
                string recordStr = "";
                recordStr = (obj.ProdId + "|" +
                        obj.ProdName + "|" +
                        obj.ProdCat + "|" +
                        obj.UnitPrice + "|" +
                        obj.SupplId + "|" +
                        obj.QtyOnHand + "|" +
                        obj.ProdStatus);
                sw.WriteLine(recordStr);
            }
            return true;
        }

        public static bool SaveRecord(Product obj, string workFilePath)
        {   //create streamWriter
            if (workFilePath == "")
            {
                workFilePath = filePath;
            }
            try
            {
                using (StreamWriter sw = new StreamWriter(workFilePath, true))
                {
                    string recordStr = "";
                    recordStr = (obj.ProdId + "|" +
                        obj.ProdName + "|" +
                        obj.ProdCat + "|" +
                        obj.UnitPrice + "|" +
                        obj.SupplId + "|" +
                        obj.QtyOnHand + "|" +
                        obj.ProdStatus);
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

        public static void SaveAllProducts(List<Product> products)
        { //to save products to XML file
            FileStream outFile = File.Create(filePathXML);
            XmlSerializer formatter = new XmlSerializer(products.GetType());
            formatter.Serialize(outFile, products);
            outFile.Close();
        }

        public static List<Product> XMLLoadAllProducts()
        {
            if (!File.Exists(filePathXML))
            {
                List<Product> prodEmpty = new List<Product>();
                return prodEmpty;
            }
            try
            {
                XmlSerializer formatter = new XmlSerializer(typeof(List<Product>));
                FileStream aFile = new FileStream(filePathXML, FileMode.Open);
                byte[] buffer = new byte[aFile.Length];
                aFile.Read(buffer, 0, (int)aFile.Length);
                MemoryStream stream = new MemoryStream(buffer);

                List<Product> products = (List<Product>)formatter.Deserialize(stream);
                aFile.Close();
                return products;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error reading an XML file!\n" + "File:" + filePathXML + "\n\n"
                    + ex + "\nPlease verify input...", "Error found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                List<Product> prodEmpty = new List<Product>();
                return prodEmpty;
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


        //public static Product SearchRecord(int id)
        //{
        //    if (File.Exists(filePath))
        //    {// create object of type StreamReader
        //        StreamReader sr = new StreamReader(filePath);
        //        //read the first line
        //        string line = sr.ReadLine();
        //        Product obj;
        //        while (line != null)
        //        {
        //            obj = ProductDA.getObjFromLine(line);
        //            if (obj.ProdId == id) { return obj; }                    
        //            //read the next line to continue to check the file:
        //            line = sr.ReadLine();
        //        }
        //        // id is NOT FOUND!
        //        MessageBox.Show("ID is not found!", "Search failed!");
        //        sr.Close();
        //    }
        //    return null;
        //}

        public static Product SearchXMLRecordProd(int id)
        {
            //Product.XMLLoadAllProducts()
            List<Product> prodList = Product.XMLLoadAllProducts();
            Product foundProd = new Product();
            foreach (Product prod in prodList)
            {
                if (prod.ProdId == id)
                {
                    foundProd = prod;
                }
            }
            return foundProd;
        }

        //public static List<Product> SearchRecord(string name, string searchBy)
        //{ //Searching a Product(s) - return the list

        //int foundCount = 0;
        //    List<Product> prodList = new List<Product>(); //we need to return a list, so lets create it now
        //    if (File.Exists(filePath))
        //    {
        //        StreamReader sr = new StreamReader(filePath);
        //        string line = sr.ReadLine();
        //        Product obj; //declaring new object for an Supplier
        //        while (line != null)
        //        {
        //            string str = "";
        //            string[] fields = line.Split('|');
        //            obj = new Product();//creating new object - must be empty obj earch iteration
        //            switch (searchBy)
        //            {
        //                case "title":
        //                    str = fields[1].ToUpper();
        //                    if (str.IndexOf(name.ToUpper()) > -1)
        //                    {
        //                        foundCount++;
        //                        obj.ProdId = Convert.ToInt32(fields[0]);
        //                        obj.ProdName = fields[1];
        //                        switch (fields[2])
        //                        {
        //                            case "Book":
        //                                obj.ProdCat = ProdCat.Book;
        //                                break;
        //                            case "Software":
        //                                obj.ProdCat = ProdCat.Software;
        //                                break;
        //                            default:
        //                                obj.ProdCat = ProdCat.Other;
        //                                break;
        //                        }
        //                        bool result;
        //                        double numDbl;
        //                        result = double.TryParse(fields[3], out numDbl); //check Unit Price
        //                            if (result == true)
        //                                //if success
        //                                obj.UnitPrice = numDbl;
        //                            else
        //                                //if failed
        //                                obj.UnitPrice = -1;
        //                        int numInt;
        //                        result = int.TryParse(fields[4], out numInt);//check Supplier Id
        //                            if (result == true)
        //                                //if success
        //                                obj.SupplId = numInt;
        //                            else
        //                                //if failed
        //                                obj.SupplId = -1;
        //                        result = int.TryParse(fields[5], out numInt);//check Qty On hand
        //                            if (result == true)
        //                                //if success
        //                                obj.QtyOnHand = numInt;
        //                            else
        //                                //if failed
        //                                obj.QtyOnHand = -1;
        //                        bool prodStat = false;
        //                        result = bool.TryParse(fields[6], out prodStat);
        //                            if (result == true)
        //                            { obj.ProdStatus = prodStat; }
        //                            else
        //                            { obj.ProdStatus = false; }

        //                        prodList.Add(obj);
        //                    }
        //                    break;
        //                case "supplier":
        //                    str = fields[5].ToUpper();
        //                    if (str.IndexOf(name.ToUpper()) > -1)
        //                    {
        //                        foundCount++;
        //                        obj.ProdId = Convert.ToInt32(fields[0]);
        //                        obj.ProdName = fields[1];
        //                        switch (fields[2])
        //                        {
        //                            case "Book":
        //                                obj.ProdCat = ProdCat.Book;
        //                                break;
        //                            case "Software":
        //                                obj.ProdCat = ProdCat.Software;
        //                                break;
        //                            default:
        //                                obj.ProdCat = ProdCat.Other;
        //                                break;
        //                        }
        //                        bool result;
        //                        double numDbl;
        //                        result = double.TryParse(fields[3], out numDbl); //check Unit Price
        //                            if (result == true)
        //                                //if success
        //                                obj.UnitPrice = numDbl;
        //                            else
        //                                //if failed
        //                                obj.UnitPrice = -1;
        //                        int numInt;
        //                        result = int.TryParse(fields[4], out numInt);//check Supplier Id
        //                            if (result == true)
        //                                //if success
        //                                obj.SupplId = numInt;
        //                            else
        //                                //if failed
        //                                obj.SupplId = -1;
        //                        result = int.TryParse(fields[5], out numInt);//check Qty On hand
        //                            if (result == true)
        //                                //if success
        //                                obj.QtyOnHand = numInt;
        //                            else
        //                                //if failed
        //                                obj.QtyOnHand = -1;
        //                        bool prodStat = false;
        //                        result = bool.TryParse(fields[6], out prodStat);
        //                            if (result == true)
        //                            { obj.ProdStatus = prodStat; }
        //                            else
        //                            { obj.ProdStatus = false; }
        //                        prodList.Add(obj);
        //                    }
        //                    break;
        //                default:
        //                    break;
        //            }
        //            //read the next line to continue to check the file:
        //            line = sr.ReadLine();
        //        }
        //        sr.Close();
        //    }
        //    if (foundCount == 0) //if no objects found we have to return nothing
        //    {
        //        MessageBox.Show("Sorry, nothing found!", "Search failed!");
        //        //return null;
        //    }
        //    return prodList;
        //}

        public static List<Product> SearchXMLRecordProd(string name, string searchBy)
        {//Searching a Product(s) - return the list
            int foundCount = 0;
            //we need to return a list, so lets create it now
            List<Product> allProdList = Product.XMLLoadAllProducts();
            List<Product> prodList = new List<Product>();

            switch (searchBy)
            {
                case "name":
                    foreach (Product prod in allProdList)
                    {
                        if (prod.ProdName.ToLower().IndexOf(name.ToLower()) > -1)
                        {
                            prodList.Add(prod);
                            foundCount++;
                        }
                    }
                    break;
                case "supplier":
                    // search by supplier info
                    //List<Supplier> SearchRecord(string name, string searchBy)
                    List<Supplier> suppList = Supplier.SearchRecord(name, "name");

                    Supplier aSupp = new Supplier();
                    //List<Supplier> suppList = Supplier.ListAllRecords();
                    
                    foreach (Product prod in allProdList)
                    {
                        foreach (Supplier supp in suppList)
                        {
                            if (prod.SupplId == supp.SuppId)
                            {
                                prodList.Add(prod);
                                foundCount++;
                            }
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
            return prodList;
        }

        public static List<Product> ListAllRecords()
        {
            //Here we have to return the list of objects:
            List<Product> prodList = new List<Product>();
            if (File.Exists(filePath))
            {
                StreamReader sr = new StreamReader(filePath);
                string line = sr.ReadLine();
                Product obj;
                while (line != null)
                {
                    try
                    {
                        string[] fields = line.Split('|');
                        obj = new Product();
                        obj.ProdId = Convert.ToInt32(fields[0]);
                        obj.ProdName = fields[1];
                        switch (fields[2])
                        {
                            case "Book":
                                obj.ProdCat = ProdCat.Book;
                                break;
                            case "Software":
                                obj.ProdCat = ProdCat.Software;
                                break;
                            default:
                                obj.ProdCat = ProdCat.Other;
                                break;
                        }
                        bool result;
                        double numDbl;
                        result = double.TryParse(fields[3], out numDbl); //check Unit Price
                        if (result == true)
                            //if success
                            obj.UnitPrice = numDbl;
                        else
                            //if failed
                            obj.UnitPrice = -1;
                        int numInt;
                        result = int.TryParse(fields[4], out numInt);//check Supplier Id
                        if (result == true)
                            //if success
                            obj.SupplId = numInt;
                        else
                            //if failed
                            obj.SupplId = -1;
                        result = int.TryParse(fields[5], out numInt);//check Qty On hand
                        if (result == true)
                            //if success
                            obj.QtyOnHand = numInt;
                        else
                            //if failed
                            obj.QtyOnHand = -1;

                        bool prodStat = false;
                        result = bool.TryParse(fields[6], out prodStat);
                            if (result == true)
                            { obj.ProdStatus = prodStat; }
                            else
                            { obj.ProdStatus = false; }

                        prodList.Add(obj); //adding next record to the list

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
            return prodList;
        }

        public static bool UpdateRecord(Product objUpdate)
        {
            if (File.Exists(filePath))
            {
                StreamReader sr = new StreamReader(filePath);
                string line = sr.ReadLine();
                Product obj;
                while (line != null)
                {
                    //obj = ProductDA.getObjFromLine(line);
                    string[] fields = line.Split('|');
                    obj = new Product();
                    obj.ProdId = Convert.ToInt32(fields[0]);
                    obj.ProdName = fields[1];
                    switch (fields[2])
                    {
                        case "Book":
                            obj.ProdCat = ProdCat.Book;
                            break;
                        case "Software":
                            obj.ProdCat = ProdCat.Software;
                            break;
                        default:
                            obj.ProdCat = ProdCat.Other;
                            break;
                    }
                    bool result;
                    double numDbl;
                    result = double.TryParse(fields[3], out numDbl); //check Unit Price
                    if (result == true)
                        //if success
                        obj.UnitPrice = numDbl;
                    else
                        //if failed
                        obj.UnitPrice = -1;
                    int numInt;
                    result = int.TryParse(fields[4], out numInt);//check Supplier Id
                    if (result == true)
                        //if success
                        obj.SupplId = numInt;
                    else
                        //if failed
                        obj.SupplId = -1;
                    result = int.TryParse(fields[5], out numInt);//check Qty On hand
                    if (result == true)
                        //if success
                        obj.QtyOnHand = numInt;
                    else
                        //if failed
                        obj.QtyOnHand = -1;

                    bool prodStat = false;
                    result = bool.TryParse(fields[6], out prodStat);
                    if (result == true)
                    { obj.ProdStatus = prodStat; }
                    else
                    { obj.ProdStatus = false; }
                    if (obj.ProdId == objUpdate.ProdId) //This is existing record
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

        //public static bool SaveBinData(Product obj, string workFilePath)
        //{
        //    if (workFilePath == "")
        //    {
        //        workFilePath = filePathBin;
        //    }
        //    try
        //    {
        //        Stream stream;
        //        BinaryFormatter formatter = new BinaryFormatter();
        //        stream = new FileStream(workFilePath, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);
        //        formatter.Serialize(stream, obj);
        //        stream.Close();
        //    }
        //    catch (Exception Ex)
        //    {
        //        MessageBox.Show("Error while saving to a Binary file: \n" + Ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return false;
        //    }
        //    return true;
        //}

        //public static List<Product> ReadBinData(string workFilePath)
        //{
        //    if (workFilePath == "")
        //    {
        //        workFilePath = filePathBin;
        //    }
        //    try
        //    {
        //        if (File.Exists(filePath))
        //        {
        //            List<Product> prodList;// = new List<Product>();
        //            Stream stream;
        //            BinaryFormatter formatter = new BinaryFormatter();
        //            //stream = new FileStream(workFilePath, FileMode.Create, FileAccess.Write, FileShare.None);
        //            stream = new FileStream(workFilePath, FileMode.Open, FileAccess.Read, FileShare.None);
        //            prodList = (List<Product>)formatter.Deserialize(stream);
        //            //List<Product> deserilizePeople = (List<Product>)formatter.Deserialize(stream);
        //            //foreach (Product prod in deserilizePeople)
        //            //{
        //            //}
        //            stream.Close();
        //            return prodList;
        //        }
        //    }
        //    catch (Exception Ex)
        //    {
        //        MessageBox.Show("Error while reading from a Binary file: \n" + Ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }

        //    return null;
        //}
        public static int NextObjId(List<Product> objList)
        {
            int maxId = 0;
            foreach (Product obj in objList)
            {
                if (obj.ProdId > maxId)
                {
                    maxId = obj.ProdId;
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


        //public static Product getObjFromLine(string line)
        //{
        //    Product obj = new Product();
        //    string[] fields = line.Split('|');
        //    obj.ProdId = Convert.ToInt32(fields[0]);
        //    obj.ProdName = fields[1];
        //    switch (fields[2])
        //    {
        //        case "Book":
        //            obj.ProdCat = ProdCat.Book;
        //            break;
        //        case "Software":
        //            obj.ProdCat = ProdCat.Software;
        //            break;
        //        default:
        //            obj.ProdCat = ProdCat.Other;
        //            break;
        //    }
        //    bool result;
        //    double numDbl;
        //    result = double.TryParse(fields[3], out numDbl); //check Unit Price
        //    if (result == true)
        //        //if success
        //        obj.UnitPrice = numDbl;
        //    else
        //        //if failed
        //        obj.UnitPrice = -1;
        //    int numInt;
        //    result = int.TryParse(fields[4], out numInt);//check Supplier Id
        //    if (result == true)
        //        //if success
        //        obj.SupplId = numInt;
        //    else
        //        //if failed
        //        obj.SupplId = -1;
        //    result = int.TryParse(fields[5], out numInt);//check Qty On hand
        //    if (result == true)
        //        //if success
        //        obj.QtyOnHand = numInt;
        //    else
        //        //if failed
        //        obj.QtyOnHand = -1;

        //    bool prodStat = false;
        //    result = bool.TryParse(fields[6], out prodStat);
        //    if (result == true)
        //    { obj.ProdStatus = prodStat; }
        //    else
        //    { obj.ProdStatus = false; }
                
        //    return obj;
        //}
    }
}
