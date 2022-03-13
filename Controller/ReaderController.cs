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
    class ReaderController
    {
        public void AddReader(string fname, string address, string phoneNum, string email, bool isStud)
        {
            try
            {
                InputValidator readerV = new InputValidator(fname, phoneNum, address, email);
                if (readerV.ReaderAllDataValidation())
                {
                    using (var db = new MyDbContext())
                    {
                        var reader = new Reader
                        {
                            Name = fname,
                            Address = address,
                            PhoneNumber = phoneNum,
                            Email = email,
                            IsStudent = isStud
                        };
                        db.Readers.Add(reader);
                        db.SaveChanges();
                        Console.WriteLine("You have successfully added new reader!");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void ReadersList()
        {
            try
            {
                using (var db = new MyDbContext())
                {
                    foreach (var item in db.Readers.ToList())
                    {
                        Console.WriteLine($"Id: {item.ReaderId}" +
                            $"\n  Name: {item.Name}" +
                            $"\n  Address: {item.Address}" +
                            $"\n  Phone number: {item.PhoneNumber}" +
                            $"\n  Email: {item.Email}" +
                            $"\n  Is student: {item.IsStudent}" +
                            $"\n");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
