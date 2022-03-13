using AutoMapper;
using EntityFrameworkPlayground.Database;
using EntityFrameworkPlayground.Database.Entities;
using Microsoft.EntityFrameworkCore;
using LMSconsole.Models;
using Microsoft.AspNetCore.Mvc;
using LMSconsole.Database;
using LMSconsole.Models;
using LMSconsole.Database.Entities;
using LMSconsole.Validator;

namespace LMSconsole.Controller
{
    class LibrarianController
    {
        public void CheckIfLibrariansHaveItems()
        {
            using (var db = new MyDbContext())
            { 
                var usernames=db.Librarians.Select(x => x.Username).ToList();
                bool check = false;
                if(usernames.Count()>0) check= true;
                if (!check)
                {
                    var librarian = new Librarian
                    {
                        Username = "admin",
                        Password = "admin123",
                        Name = "Georgi Georgiev",
                        Address = "Sofia",
                        PhoneNumber = "0885123695",
                        Email = "lms_admin@gmail.com"
                    };
                    db.Librarians.Add(librarian);
                    db.SaveChanges();
                }
            }
        }
        public bool Login (string uname, string pass)
        {
            using (var db = new MyDbContext())
            {
                var userExists = db.Librarians.FirstOrDefault(a => a.Username.Equals(uname));
                if (userExists != null)
                {
                    if (userExists.Password.Equals(pass)) 
                        return true;
                        else return false;
                }
                else return false;
            }
    
        }
        public void AddLibrarian(string uname, string pass, string passC, string fname, string address, string phoneNum, string email)
        {
            InputValidator librarianV = new InputValidator(uname, pass, passC, fname, address, phoneNum, email);
            if (librarianV.LibrarianAllDataValidation())
            {
                using (var db = new MyDbContext())
                {
                    var librarian = new Librarian
                    {
                        Username = uname,
                        Password = pass,
                        Name = fname,
                        Address = address,
                        PhoneNumber = phoneNum,
                        Email = email
                    };
                    db.Librarians.Add(librarian);
                    db.SaveChanges();
                    Console.WriteLine("You have successfully added new librarian!");
                }
            }
        }
        public void LibrariansList()
        {
            using (var db = new MyDbContext())
            {
                foreach (var item in db.Librarians.ToList())
                {
                    Console.WriteLine($"Username: {item.Username}" +
                        $"\n  Password: {item.Password}" +
                        $"\n  Name: {item.Name}" +
                        $"\n  Address: {item.Address}" +
                        $"\n  Phone number: {item.PhoneNumber}" +
                        $"\n  Email: {item.Email}" +
                        $"\n");
                }
            }
        }
        public void RemoveLibrarian(string uname)
        {
            using (var db = new MyDbContext())
            {
                var librarianR = new Librarian
                {
                    Username = uname
                };
                db.Librarians.Remove(librarianR);
                db.SaveChanges();
                Console.WriteLine("You have successfully removed a librarian!");
            }
        }
    }
}
