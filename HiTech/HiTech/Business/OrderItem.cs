using HiTech.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiTech.Business
{
    [Serializable]
    public class OrderItem
    {
        private int itemId; //global item ID
        private int itemVol; //how many items of the same king
        private double unitPrice; //a unit price per item - for historical records we need to capture

        public OrderItem()
        {
        }

        public OrderItem(int itemId, int itemVol, double unitPrice)
        {
            this.ItemId = itemId;
            this.ItemVol = itemVol;
            this.UnitPrice = unitPrice;
        }

        public int ItemId { get => itemId; set => itemId = value; }
        public int ItemVol { get => itemVol; set => itemVol = value; }
        public double UnitPrice { get => unitPrice; set => unitPrice = value; }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            OrderItem objAsPart = obj as OrderItem;
            if (objAsPart == null) return false;
            else return Equals(objAsPart);
        }
        public override int GetHashCode()
        {
            return ItemId;
        }
        public bool Equals(OrderItem other)
        {
            if (other == null) return false;
            return (this.ItemId.Equals(other.ItemId));
        }
    }
}
