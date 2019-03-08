using HiTech.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiTech.Business
{
    [Serializable]
    public enum OrderState
    {
        New,
        Hold,
        Shipped,
        Delivered,
        Closed
    }
    [Serializable]
    public enum OrderTakeBy
    {
        Phone,
        Fax,
        Email
    }
    [Serializable]
    //[XmlInclude(typeof(Book))]
    //[XmlInclude(typeof(Software))]
    public class Order
    {
        private int ordId;
        private DateTime createdTime;
        private DateTime shippingTime;
        private DateTime requiredTime;
        private int createdByEmpId;
        private int clientId;
        private double totalAmount;
        private OrderState ordState;
        private OrderTakeBy ordTakeBy;
        private List<OrderItem> productsList;

        public Order() { }
        public Order(int ordId, DateTime createdTime, DateTime shippingTime, DateTime requiredTime, 
            int createdByEmpId, int clientId, double totalAmount, OrderState ordState, OrderTakeBy ordTakeBy, 
            List<OrderItem> productsList)
        {
            this.OrdId = ordId;
            this.CreatedTime = createdTime;
            this.ShippingTime = shippingTime;
            this.RequiredTime = requiredTime;
            this.CreatedByEmpId = createdByEmpId;
            this.ClientId = clientId;
            this.TotalAmount = totalAmount;
            this.OrdState = ordState;
            this.OrdTakeBy = ordTakeBy;
            this.ProductsList = productsList;
        }

        public int OrdId { get => ordId; set => ordId = value; }
        public DateTime CreatedTime { get => createdTime; set => createdTime = value; }
        public DateTime ShippingTime { get => shippingTime; set => shippingTime = value; }
        public DateTime RequiredTime { get => requiredTime; set => requiredTime = value; }
        public int CreatedByEmpId { get => createdByEmpId; set => createdByEmpId = value; }
        public int ClientId { get => clientId; set => clientId = value; }
        public double TotalAmount { get => totalAmount; set => totalAmount = value; }
        public OrderState OrdState { get => ordState; set => ordState = value; }
        public OrderTakeBy OrdTakeBy { get => ordTakeBy; set => ordTakeBy = value; }
        public List<OrderItem> ProductsList { get => productsList; set => productsList = value; }

        public static int NextObjId(List<Order> objList)
        {
            return OrderDA.NextObjId(objList);
        }

        public static List<Order> XMLLoadAllProducts()
        {
            return OrderDA.XMLLoadAllProducts();
        }

        public static Order SearchXMLRecordProd(int id)
        {
            return OrderDA.SearchXMLRecordProd(id);
        }

        public static List<Order> SearchXMLRecordProd(string name, string searchBy)
        {
            return OrderDA.SearchXMLRecordProd(name,searchBy);
        }

        public static bool isDigit(string input)
        {
            return OrderDA.isDigit(input);
        }
        public static bool isValidId(string valueID, int num)
        {
            return OrderDA.isValidId(valueID, num);
        }

        public static bool isDuplicate(int orderId)
        {
            return OrderDA.isDuplicate(orderId);
        }
        public static void SaveAllProducts(List<Order> orders)
        {
            OrderDA.SaveAllProducts(orders);
        }

        public static string ProductListString (List<OrderItem> productsList)
        {
            string str = "";
            foreach (OrderItem item in productsList)
            {
                str = "" + item.ItemId + " x " + item.ItemVol + ", ";
            }
            
            return str;
        }

        public override string ToString()
        {
            return "ID: " + clientId + " Created: " + createdTime + " clientID " + clientId + " createdBy: " + createdByEmpId;
        }
    }
}
