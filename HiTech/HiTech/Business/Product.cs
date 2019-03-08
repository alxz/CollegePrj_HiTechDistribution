using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using HiTech.DataAccess;

namespace HiTech.Business
{
    [Serializable]
    public enum ProdCat
    {
        Book,
        Software,
        Other
    }
    [Serializable]
    [XmlInclude(typeof(Book))]
    [XmlInclude(typeof(Software))]
    public class Product
    {
        private int prodId;
        private string prodName;
        private ProdCat prodCat;
        private double unitPrice;
        private int supplId;
        private int qtyOnHand;
        private bool prodStatus;

        public Product()
        { }
        public Product(int prodId, string prodName, ProdCat prodCat, double unitPrice, 
            int supplId, int qtyOnHand, bool prodStatus)
        {
            this.ProdId = prodId;
            this.ProdName = prodName;
            this.ProdCat = prodCat;
            this.UnitPrice = unitPrice;
            this.SupplId = supplId;
            this.QtyOnHand = qtyOnHand;
            this.ProdStatus = prodStatus;
        }

        public int ProdId { get => prodId; set => prodId = value; }
        public double UnitPrice { get => unitPrice; set => unitPrice = value; }
        public int SupplId { get => supplId; set => supplId = value; }
        public int QtyOnHand { get => qtyOnHand; set => qtyOnHand = value; }
        public string ProdName { get => prodName; set => prodName = value; }
        public ProdCat ProdCat { get => prodCat; set => prodCat = value; }
        public bool ProdStatus { get => prodStatus; set => prodStatus = value; }

        public override string ToString()
        {
            string str = "";
            str = str + this.ProdId + ",";
            str = str + this.ProdName + ",";
            str = str + this.ProdCat + ",";
            str = str + this.UnitPrice + ",";
            str = str + this.SupplId + ",";
            str = str + this.QtyOnHand + ",";
            str = str + this.ProdStatus;
            return str;
        }
        public static void SaveAllProducts(List<Product> products)
        {
            ProductDA.SaveAllProducts(products);
        }


        public static List<Product> XMLLoadAllProducts()
        {
            try
            {
                return ProductDA.XMLLoadAllProducts();
            }
            catch (Exception)
            {
                List<Product> prodEmpty = new List<Product>();
                return prodEmpty;
            }
            
        }

        public static bool SaveRecord(Product obj)
        {
            return ProductDA.SaveRecord(obj);
        }

        public static bool UpdateRecord(Product objUpdate)
        {
            return ProductDA.UpdateRecord(objUpdate);
        }

        public static bool isDuplicateId(int id)
        {
            return ProductDA.isDuplicateId(id);
        }

        public static bool isValidId(string valueID, int num)
        {
            return ProductDA.isValidId(valueID, num);
        }

        //public static Product SearchRecord(int id)
        //{
        //    return ProductDA.SearchRecord(id);
        //}

        public static Product SearchXMLRecordProd(int id)
        {
            return ProductDA.SearchXMLRecordProd(id);
        }
        public static List<Product> SearchXMLRecordProd(string name, string searchBy)
        {
            return ProductDA.SearchXMLRecordProd(name, searchBy);
        }
        //public static List<Product> SearchRecord(string name, string searchBy)
        //{
        //    return ProductDA.SearchRecord(name, searchBy);
        //}
        public static List<Product> ListAllRecords()
        {
            return ProductDA.ListAllRecords();
        }

        //public static bool SaveBinData(Product obj)
        //{
        //    return ProductDA.SaveBinData(obj, null);
        //}

        //public static List<Product> ReadBinData()
        //{
        //    return ProductDA.ReadBinData(null);
        //}

        public static int NextObjId(List<Product> objList)
        {
            return ProductDA.NextObjId(objList);
        }

        public static bool isDigit(string input)
        {
            return ProductDA.isDigit(input);
        }

        //public static Product getObjFromLine(string line)
        //{
        //    return ProductDA.getObjFromLine(line);
        //}
    }
}
