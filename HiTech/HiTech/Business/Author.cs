using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiTech.DataAccess;

namespace HiTech.Business
{
    public class Author
    {
        private int authId;
        private string authFirstName;
        private string authLastName;

        public Author() { }
        public Author(int authId, string authFirstName, string authLastName)
        {
            this.AuthId = authId;
            this.AuthFirstName = authFirstName;
            this.AuthLastName = authLastName;
        }

        public int AuthId { get => authId; set => authId = value; }
        public string AuthFirstName { get => authFirstName; set => authFirstName = value; }
        public string AuthLastName { get => authLastName; set => authLastName = value; }

        public static bool SaveRecord(Author author)
        {
            return AuthorDA.SaveRecord(author, "");
        }

        public static bool isDuplicateId(int id)
        {
            return AuthorDA.isDuplicateId(id);
        }
        public static bool isValidId(string valueID, int num)
        {
            return AuthorDA.isValidId(valueID, num);
        }

        public static bool UpdateRecord(Author autToUpdate)
        {
            return AuthorDA.UpdateRecord(autToUpdate);
        }

        public static bool DeleteRecord(Author objDelete)
        {
            return AuthorDA.DeleteRecord(objDelete);
        }

        public static bool isDigit(string input)
        {
            return AuthorDA.isDigit(input);
        }

        public static Author SearchRecord(int id)
        {
            return AuthorDA.SearchRecord(id);
        }
        public static List<Author> SearchRecord(string name, string searchBy)
        {
            return AuthorDA.SearchRecord(name, searchBy);
        }

        public static List<Author> ListAllRecords()
        {
            return AuthorDA.ListAllRecords();
        }

        public static int NextObjId(List<Author> objList)
        {
            return AuthorDA.NextObjId(objList);
        }

        public string GettoString()
        {
            string str = "";
            //str = this.authId + ", " + this.authFirstName + ", " + this.authLastName;
            str = this.authFirstName + ", " + this.authLastName;
            return str;
        }
    }
}
