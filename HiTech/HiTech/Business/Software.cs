using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiTech.Business
{
    [Serializable]
    public enum SoftCat
    {
        OperationSystem,
        GraphicsDesign,
        TextEditor,
        AudioVideoPlay,
        AudioVedeoEdit,
        Other
    }
    [Serializable]
    public enum OSTypeCat
    {
        Windows,
        MacOS,
        Linux,
        iOS,
        Android
    }
    [Serializable]
    public class Software : Product
    {
        private string softName;
        private SoftCat softCateg;
        private OSTypeCat osCateg;
        //private int suppId;


        public Software() : base() { }

        public Software(string softName, SoftCat softCateg, OSTypeCat osCateg,
            int prodId, ProdCat prodCat, double unitPrice, int supplId, int qtyOnHand, bool prodStat)
            : base(prodId, softName, prodCat, unitPrice, supplId, qtyOnHand, prodStat)
        {
            this.ProdName = softName;
            this.SoftCateg = softCateg;
            this.OsCateg = osCateg;
        }

        public string SoftName { get => softName; set => softName = value; }
        public SoftCat SoftCateg { get => softCateg; set => softCateg = value; }
        public OSTypeCat OsCateg { get => osCateg; set => osCateg = value; }
       //public int SuppId { get => suppId; set => suppId = value; }
    }
}
