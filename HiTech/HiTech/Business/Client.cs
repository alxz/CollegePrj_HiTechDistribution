using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiTech.DataAccess;

namespace HiTech.Business
{
    public class Client
    {
        //Client class fields
        private int clientId;
        private string clientName; // Client Company Name
        private bool clientStatus; // 0=Inactive; 1=Active;
        private string statComment; //Comments on the status changing

        private string clientPhone; //for primary phone only
        private string clientFax; //for primary phone only
        private string clientEmail; //for primary email only

        private string clientStreet; //for primary Street Address only
        private string clientCity; //for primary City only
        private string clientPCode; //for primary Postal Code only

        private double credLimit; //creadit limit


        public Client() { }

        public Client(int clientId, string clientName, bool clientStatus, string statComment, 
            string clientPhone, string clientFax, string clientEmail, string clientStreet, 
            string clientCity, string clientPCode, double credLimit)
        {
            this.clientId = clientId;
            this.clientName = clientName;
            this.clientStatus = clientStatus;
            this.statComment = statComment;
            this.clientPhone = clientPhone;
            this.clientFax = clientFax;
            this.clientEmail = clientEmail;
            this.clientStreet = clientStreet;
            this.clientCity = clientCity;
            this.clientPCode = clientPCode;
            this.credLimit = credLimit;
        }

        public int ClientId { get => clientId; set => clientId = value; }
        public string ClientName { get => clientName; set => clientName = value; }
        public bool ClientStatus { get => clientStatus; set => clientStatus = value; }
        public string StatComment { get => statComment; set => statComment = value; }
        public string ClientPhone { get => clientPhone; set => clientPhone = value; }
        public string ClientEmail { get => clientEmail; set => clientEmail = value; }
        public double CredLimit { get => credLimit; set => credLimit = value; }
        public string ClientFax { get => clientFax; set => clientFax = value; }
        public string ClientStreet { get => clientStreet; set => clientStreet = value; }
        public string ClientCity { get => clientCity; set => clientCity = value; }
        public string ClientPCode { get => clientPCode; set => clientPCode = value; }

        public static Client SearchRecord(int id)
        {
            return ClientDA.SearchRecord(id);
        }

        public static bool SaveRecord (Client aClient)
        {
            return ClientDA.SaveRecord(aClient, "");
        }

        public static bool isDuplicateId(int id)
        {
            return ClientDA.isDuplicateId(id);
        }

        public static bool isValidId(string valueID, int num)
        {
            return ClientDA.isValidId(valueID, num);
        }

        public static string setPhoneNumber(string phoneStr)
        {
            return ClientDA.setPhoneNumber(phoneStr);
        }
        public static bool UpdateRecord(Client cliToUpdate)
        {
            return ClientDA.UpdateRecord(cliToUpdate);
        }

        public static bool isPhoneNumber(string phoneStr)
        {
            return ClientDA.isPhoneNumber(phoneStr);
        }

        public static bool isDigit(string input)
        {
            return ClientDA.isDigit(input);
        }
        public static bool isCanPostCode(string input)
        { //check if valid Canada Post Code
            return ClientDA.isCanPostCode(input);
        }


        public static List<Client> SearchRecord(string name, string searchBy)
        {
            return ClientDA.SearchRecord(name, searchBy);
        }

        public static List<Client> ListAllRecords()
        {
            return ClientDA.ListAllRecords();
        }

        public static int NextCliId(List<Client> clients)
        {
            return ClientDA.NextCliId(clients);
        }
    }
}
