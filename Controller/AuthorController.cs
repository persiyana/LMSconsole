using LMSconsole.Database;
using LMSconsole.Database.Entities;
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
            catch
            {
                throw;
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
            catch
            {
                throw;
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
            catch
            {
                throw;
            }
        }
        public void UpdateAuthor(int id)
        {
            try
            {
                using (var db = new MyDbContext())
                {
                    var author = new Author()
                    {
                        AuthorId = id,
                        IsAlive = false
                    };
                    db.Authors.Attach(author);
                    db.Entry(author).Property(x => x.IsAlive).IsModified = true;
                    db.SaveChanges();
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
