using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSconsole.Validator
{
    class InputValidator
    {
        public string FullName { set; get; }
        public string Username { set; get; }
        public string Password { set; get; }
        public string PassConfirm { set; get; }
        public string Address { set; get; }
        public string PhoneNum { set; get; }
        public string Email { set; get; }
        public string Title { get; set; }

        public InputValidator(string uname, string pass, string passC, string fname, string address, string phoneNum, string email)
        {
            this.FullName = fname;
            this.Address = address;
            this.PhoneNum = phoneNum;
            this.Email = email;
            this.Password = pass;
            this.Username = uname;
            this.PassConfirm = passC;
        }
        public InputValidator(string ft)
        {
            this.Title = ft;
            this.FullName = ft;
        }
        public InputValidator(string fname,  string pnum, string address, string email)
        {
            this.FullName = fname;
            this.Address = address;
            this.PhoneNum = pnum;
            this.Email = email;
        }

        public bool AuthorAllDataValidation()
        {
            if (this.FullName != string.Empty)
            {
                return true;
            }
            if (this.FullName == string.Empty)
            { Console.WriteLine("Please enter full name!"); }
            return false;
        }
        public bool ReaderAllDataValidation()
        {
            if (PhoneValidation() && EmailValidation()&&
               this.FullName != string.Empty && this.Address != string.Empty)
            {
                return true;
            }
            if (this.FullName == string.Empty  || this.Address == string.Empty)
            { Console.WriteLine("Please fill all the blank fields!"); }
            return false;
        }
        public bool BookAllDataValidation()
        {
            if (this.Title != string.Empty)
            {
                return true;
            }
            else
            { Console.WriteLine("Please enter title!"); }
            return false;
        }
        public bool LibrarianAllDataValidation()
        {
            if (AllPassValidation() && Pass1Validation() && EmailValidation() && PhoneValidation() &&
               this.FullName != string.Empty&& this.Username != string.Empty && this.Address != string.Empty)
            {
                return true;
            }
            if (this.FullName == string.Empty || this.Username == string.Empty || this.Address == string.Empty)
            { Console.WriteLine("Please fill all the blank fields!"); }
            return false;
        }
        public bool AllPassValidation()
        {
            if (this.Password == this.PassConfirm) return true;
            Console.WriteLine("Passwords doesnt match!");
            return false;
        }
        public bool Pass1Validation()
        {
            int validConditions = 0;
            foreach (char c in this.Password)
            {
                if (c >= 'a' && c <= 'z')
                {
                    validConditions++;
                    break;
                }
            }
            foreach (char c in this.Password)
            {
                if (c >= 'A' && c <= 'Z')
                {
                    validConditions++;
                    break;
                }
            }
            if (validConditions == 0) return false;
            foreach (char c in this.Password)
            {
                if (c >= '0' && c <= '9')
                {
                    validConditions++;
                    break;
                }
            }
            if (validConditions == 1)
            {
                Console.WriteLine("Password must have at least one lower case letter, " +
                    "\nat least one upper case letter," +
                    "\nat least one special character," +
                    "\nat least one number" +
                    "\nat least 8 characters length");
                return false;
            }
            if (validConditions == 2)
            {
                char[] special = { '@', '#', '$', '%', '^', '&', '+', '=', '-', };
                if (this.Password.IndexOfAny(special) == -1) return false;
                else Console.WriteLine("You must use one of those special characters: " +
                    "\n@ # $ % ^ & + = -");
            }
            return true;
        }
        public bool EmailValidation()
        {
            var trimmedEmail = this.Email.Trim();

            if (trimmedEmail.EndsWith("."))
            {
                return false;
            }
            try
            {
                var addr = new System.Net.Mail.MailAddress(this.Email);
                return addr.Address == trimmedEmail;
            }
            catch
            {
                Console.WriteLine("Invalid e-mail!");
                return false;
            }
        }
        public bool PhoneValidation()
        {
            if (this.PhoneNum.Length == 13 && this.PhoneNum.StartsWith("+359")) return true;
            if (this.PhoneNum.Length == 10 && this.PhoneNum.StartsWith("0")) return true;
            Console.WriteLine("Invalid phone number! Our system only allows Bulgarian phone numbers.");
            return false;
        }

    }
}
