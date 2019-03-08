using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiTech.DataAccess;

namespace HiTech.Business
{
    [Serializable]
    public enum BookCateg
    {
        [Description("Text Book")]
        Text_Book = 1,
        [Description("Science Fiction")]
        Science_Fiction,
        [Description("Satire")]
        Satire,
        [Description("Drama")]
        Drama,
        [Description("Action Adventure")]
        Action_Adventure,
        [Description("Romace")]
        Romance,
        [Description("Mystery")]
        Mystery,
        [Description("Horror")]
        Horror,
        [Description("Self Help")]
        Self_help,
        [Description("Other")]
        Other
    }
    [Serializable]
    public class Book : Product
    {
        private string bookISBN;
        private string bookTitle;
        private int yearReleased;
        private BookCateg bookCat;
        private List<Author> listAuthors;
        public Book() : base() { }
        public Book(string bookISBN, string bookTitle, int yearReleased, BookCateg bookCat, List<Author> listAuthors,
            int prodId, ProdCat prodCat, double unitPrice, int supplId, int qtyOnHand, bool prodStat)
            : base(prodId, bookTitle, prodCat, unitPrice, supplId, qtyOnHand, prodStat)
        { 
            this.BookISBN = bookISBN;
            this.BookTitle = bookTitle;
            this.YearReleased = yearReleased;
            this.BookCat = bookCat;
            this.ListAuthors = listAuthors;
        }

        public string BookISBN { get => bookISBN; set => bookISBN = value; }
        public string BookTitle { get => bookTitle; set => bookTitle = value; }
        public int YearReleased { get => yearReleased; set => yearReleased = value; }
        public BookCateg BookCat { get => bookCat; set => bookCat = value; }
        public List<Author> ListAuthors { get => listAuthors; set => listAuthors = value; }

        public string GetAuthorsString()
        {
            string str = "";

            foreach (Author author in this.ListAuthors)
            {
                if (str != "")
                {
                    str = str + "; " + author.GettoString();
                }
                else
                {
                    str = author.GettoString();
                }
            }

            return str;
        }
    }
}
