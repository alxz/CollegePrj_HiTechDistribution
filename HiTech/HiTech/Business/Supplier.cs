using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiTech.DataAccess;

namespace HiTech.Business
{
    public class Supplier
    {
        private int suppId;
        private string suppName;
        private string suppEmail;
        public Supplier() { }
        public Supplier(int suppId, string suppName, string suppEmail)
        {
            this.SuppId = suppId;
            this.SuppName = suppName;
            this.SuppEmail = suppEmail;
        }

        public int SuppId { get => suppId; set => suppId = value; }
        public string SuppName { get => suppName; set => suppName = value; }
        public string SuppEmail { get => suppEmail; set => suppEmail = value; }

        public static bool SaveRecord(Supplier supplier)
        {
            return SupplierDA.SaveRecord(supplier, "");
        }

        public static bool DeleteRecord(Supplier objDelete)
        {
            return SupplierDA.DeleteRecord(objDelete);
        }

        public static bool isDuplicateId(int id)
        {
            return SupplierDA.isDuplicateId(id);
        }
        public static bool isValidId(string valueID, int num)
        {
            return SupplierDA.isValidId(valueID, num);
        }

        public static bool UpdateRecord(Supplier objUpdate)
        {
            return SupplierDA.UpdateRecord(objUpdate);
        }

        public static bool isDigit(string input)
        {
            return SupplierDA.isDigit(input);
        }

        public static Supplier SearchRecord(int id)
        {
            return SupplierDA.SearchRecord(id);
        }
        public static List<Supplier> SearchRecord(string name, string searchBy)
        {
            return SupplierDA.SearchRecord(name, searchBy);
        }

        public static List<Supplier> ListAllRecords()
        {
            return SupplierDA.ListAllRecords();
        }

        public static int NextObjId(List<Supplier> objList)
        {
            return SupplierDA.NextObjId(objList);
        }

    }
}
