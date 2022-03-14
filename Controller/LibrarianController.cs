using LMSconsole.Database;
using LMSconsole.Database.Entities;
using LMSconsole.Validator;

namespace LMSconsole.Controller
{
    class LibrarianController
    {
        public void CheckIfLibrariansHaveItems()
        {
            try
            {
                using (var db = new MyDbContext())
                {
                    var usernames = db.Librarians.Select(x => x.Username).ToList();
                    bool check = false;
                    if (usernames.Count() > 0) check = true;
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
            catch
            {
                throw;
            }
        }
        public bool Login(string uname, string pass)
        {
            try
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
            catch
            {
                throw;
            }

        }
        public void AddLibrarian(string uname, string pass, string passC, string fname, string address, string phoneNum, string email)
        {
            try
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
            catch
            {
                throw;
            }
        }
        public void LibrariansList()
        {
            try
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
            catch
            {
                throw;
            }
        }
        public void RemoveLibrarian(string uname)
        {
            try
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
            catch
            {
                throw;
            }
        }
        public void UpdateLibrarian(string uname, string address, string pNum, string email, string pass, string passC)
        {
            try
            {
                using (var db = new MyDbContext())
                {
                    if (address != string.Empty)
                    {
                        var librarian = new Librarian()
                        {
                            Username = uname,
                            Address = address
                        };
                        db.Librarians.Attach(librarian);
                        db.Entry(librarian).Property(x => x.Address).IsModified = true;
                        db.SaveChanges();
                    }
                    else if (pNum != string.Empty)
                    {
                        InputValidator inputValidator = new InputValidator(pNum);
                        if (inputValidator.PhoneValidation())
                        {
                            var librarian = new Librarian()
                            {
                                Username = uname,
                                PhoneNumber = pNum
                            };
                            db.Librarians.Attach(librarian);
                            db.Entry(librarian).Property(x => x.PhoneNumber).IsModified = true;
                            db.SaveChanges();
                        }
                    }
                    else if (email != string.Empty)
                    {
                        InputValidator inputValidator = new InputValidator(email);
                        if (inputValidator.EmailValidation())
                        {
                            var librarian = new Librarian()
                            {
                                Username = uname,
                                Email = email
                            };
                            db.Librarians.Attach(librarian);
                            db.Entry(librarian).Property(x => x.Email).IsModified = true;
                            db.SaveChanges();
                        }
                    }
                    else if (pass != string.Empty)
                    {
                        InputValidator inputValidator = new InputValidator(pass, passC);
                        if (inputValidator.AllPassValidation())
                        {
                            var librarian = new Librarian()
                            {
                                Username = uname,
                                Password = pass
                            };
                            db.Librarians.Attach(librarian);
                            db.Entry(librarian).Property(x => x.Password).IsModified = true;
                            db.SaveChanges();
                        }
                    }
                    else Console.WriteLine("There is nothing to update!");
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
