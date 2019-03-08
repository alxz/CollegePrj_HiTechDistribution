using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions; //to use with RegEx
using System.Windows.Forms;

namespace HiTech.Validation
{
    public static class Validator
    {
        public static bool isValidId(string input, int size)
        {
            //this could be used to check any size of input string
            //checking the input against numbers only
            if (Regex.IsMatch(input, @"^\d{" + size + "}$"))
            {
                return true;
            }
            return false;
        }

        public static bool isValidId(TextBox txtControl, int size)
        {
            if (Regex.IsMatch(txtControl.Text.Trim(), @"^\d{" + size + "}$"))
            {
                return true;
            }
            MessageBox.Show("Invalid Input:\n" + txtControl.Text.ToString(), "Error Message!");
            return false;
        }

        public static bool isValidName(string input)
        {
            //bool valid = false;
            //return Regex.IsMatch(input, @"^[a-zA-Z]+$");
            //return Regex.IsMatch(input, @"^([A-z][A-Za-z]*\s*[A-Za-z]*)$"); //better match name patterns
            if (input == "")
            { //empty string returns false!
                return false;
            }
            for (int i = 0; i < input.Length; i++)
            {
                if (!Char.IsLetter(input[i]) && (!Char.IsWhiteSpace(input[i])))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool isValidName(string input, System.Windows.Forms.TextBox txtControl)
        {
            if (input == "")
            {
                MessageBox.Show("Invalid Input:\n" + txtControl.Text.ToString(), "Error Message!");
                return false;
            }
            for (int i = 0; i < input.Length; i++)
            {
                if (!Char.IsLetter(input[i]) && (!Char.IsWhiteSpace(input[i])))
                {
                    MessageBox.Show("Invalid Input:\n" + txtControl.Text, "Error Message!");
                    return false;
                }
            }
            return true;
        }

        public static bool isValidUser(string input)
        {
            if (input == "")
            {
                //invalid input!!!
                return false;
            }
            return Regex.IsMatch(input, @"^[a-zA-Z]+$"); //letters only

        }
        public static bool isValidUser(string input, System.Windows.Forms.TextBox txtControl)
        {
            if (input == "")
            {
                MessageBox.Show("Invalid Input:\n" + txtControl.Text.ToString(), "Error Message!");
                return false;
            }
            return Regex.IsMatch(input, @"^[a-zA-Z]+$"); //letters only

        }

        //XOR encryption methods:
        public static string Encrypt(string message, int key)
        {

            string result = "";
            for (int i = 0; i < message.Length; i++)
            {
                result += (char)(message[i] ^ key);
            }
            return result;
        }
        //XOR decryption methods:
        public static string Decrypt(string message, int key)
        {
            return Encrypt(message, key);
        }


        static string Base64Enc(string textEncoded) //this is used for Base64 Encoding
        {
            return System.Text.Encoding.UTF8.EncodeBase64(textEncoded);
        }

        static string Base64Dec(string textEncoded) //this is used for Base64 Decoding
        {
            return System.Text.Encoding.UTF8.DecodeBase64(textEncoded);
        }



        public static string EncodeBase64(this System.Text.Encoding encoding, string text)
        {
            if (text == null)
            {
                return null;
            }

            byte[] textAsBytes = encoding.GetBytes(text);
            return System.Convert.ToBase64String(textAsBytes);
        }

        public static string DecodeBase64(this System.Text.Encoding encoding, string encodedText)
        {
            if (encodedText == null)
            {
                return null;
            }

            byte[] textAsBytes = System.Convert.FromBase64String(encodedText);
            return encoding.GetString(textAsBytes);
        }

        public static bool isCanPostCode(string input)
        { //check if valid Canada Post Code
            return Regex.IsMatch(input, @"^\w\d\w\s?\d\w\d$"); 
        }

        public static bool isDigit(string input)
        { //check if valid numeric string
            return Regex.IsMatch(input, @"^\d+$");
        }


        public static string Strip(string s) //to remove any formatting chars:
                                             //A method that strips formatting characters from a numeric string
        {
            foreach (char c in s)
            {
                if (c == '$' || c == '%' || c == ',' || c == ' ')
                {
                    int i = s.IndexOf(c);
                    s = s.Remove(i, 1);
                }
                if (c == '(' || c == ')' || c == '-' || c == '.')
                {
                    int i = s.IndexOf(c);
                    s = s.Remove(i, 1);
                }
            }
            return s;
        }

        public static bool isPhoneNumber(string phoneStr)
        {
            string rawPhoneStr, numericStr;
            //decimal phoneNumber = 0;
            rawPhoneStr = phoneStr.ToString().Trim(); //assign and trim the string variable
            numericStr = Strip(rawPhoneStr); //just to remove excessive formating characters
            if (!isDigit(numericStr)) //the string must contain numbers
            {
                //phoneNumber = Convert.ToDecimal(Strip(rawPhoneStr));
                MessageBox.Show("Entered string is not a valid phone number!" +
                    "\n\n Please change the string and try again.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (numericStr.ToString().Length != 10)
            {
                MessageBox.Show("Entered string is not a valid phone number!" +
                    "\n\nIt seems to be not enough digits (" + numericStr.ToString().Length +
                    ") - Should be only 10 digits number..." +
                "\n\n Please change the string and try again.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        public static string setPhoneNumber(string phoneStr)
        {
            string rawPhoneStr, numericStr;
            rawPhoneStr = phoneStr.ToString().Trim(); //assign and trim the string variable
            numericStr = Strip(rawPhoneStr); //just to remove excessive formating characters
            if (!isDigit(numericStr)) //the string must contain numbers
            {
                //failed check - return empty string!
                return "";
            }
            if (numericStr.ToString().Length != 10)
            {
                //failed check - return empty string!
                return "";
            }
            numericStr = numericStr.Insert(3, "-");
            numericStr = numericStr.Insert(7, "-");
            return numericStr;
        }

        public static string setNameStr(string str)
        {
            
            try
            {
                string[] strArr = str.Split(' ');
                string longName = "";
                foreach (string name in strArr)
                {
                    string fistLetter = name.Substring(0, 1).ToUpper();
                    string otherLetters = name.Substring(1).ToLower();
                    if (longName != "")
                    {
                        longName = longName + " ";
                    }
                    longName = longName + fistLetter + otherLetters;
                }
                //string fistLetter = str.Substring(0, 1).ToUpper();
                //string otherLetters = str.Substring(1).ToLower();                
                return longName;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while checking name value!\n\n" +
                    ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }                        
        }
    } //end of class Validator
}//end of namespace
