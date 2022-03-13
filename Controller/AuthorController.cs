using EntityFrameworkPlayground.Database.Entities;
using LMSconsole.Database;
using LMSconsole.Validator;

namespace LMSconsole.Controller
{
    internal class AuthorController
    {
        public void AddAuthor(string fname, DateTime dateOfB, string nationality, bool isAlive)
        {
            try
            {
                InputValidator authorV = new InputValidator(fname);
                if (authorV.AuthorAllDataValidation())
                {
                    using (var db = new MyDbContext())
                    {
                        var author = new Author
                        {
                            Name = fname,
                            DateOfBirth = dateOfB,
                            Nationality = nationality,
                            IsAlive = isAlive
                        };
                        db.Authors.Add(author);
                        db.SaveChanges();
                        Console.WriteLine("You have successfully added new author!");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        public void AuthorList()
        {
            try
            {
                using (var db = new MyDbContext())
                {
                    foreach (var item in db.Authors.ToList())
                    {
                        Console.WriteLine($"Id: {item.AuthorId}" +
                            $"\n  Name: {item.Name}" +
                            $"\n  Date of birth: {item.DateOfBirth}" +
                            $"\n  Is alive: {item.IsAlive}" +
                            $"\n  Nationality: {item.Nationality}" +
                            $"\n");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void AuthorListID()
        {
            try
            {
                using (var db = new MyDbContext())
                {
                    foreach (var item in db.Authors.ToList())
                    {
                        Console.WriteLine($"{item.AuthorId} - {item.Name}");
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
