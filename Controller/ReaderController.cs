using LMSconsole.Database;
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
            catch
            {
                throw;
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
            catch
            {
                throw;
            }
        }
        public void RemoveReader(int readerID)
        {
            try
            {
                using (var db = new MyDbContext())
                {
                    var readerR = new Reader
                    {
                        ReaderId = readerID
                    };
                    db.Readers.Remove(readerR);
                    db.SaveChanges();
                    Console.WriteLine("You have successfully removed a reader!");
                }
            }
            catch
            {
                throw;
            }
        }
        public void UpdateReader(int id, string address, string pNum, string email, string isStud)
        {
            try
            {
                using (var db = new MyDbContext())
                {
                    if (address != string.Empty)
                    {
                        var reader = new Reader()
                        {
                            ReaderId = id,
                            Address = address
                        };
                        db.Readers.Attach(reader);
                        db.Entry(reader).Property(x => x.Address).IsModified = true;
                        db.SaveChanges();
                        Console.WriteLine("You have successfully updated reader!");
                    }
                    else if (pNum != string.Empty)
                    {
                        InputValidator inputValidator = new InputValidator(pNum);
                        if (inputValidator.PhoneValidation())
                        {
                            var reader = new Reader()
                            {
                                ReaderId = id,
                                PhoneNumber = pNum
                            };
                            db.Readers.Attach(reader);
                            db.Entry(reader).Property(x => x.PhoneNumber).IsModified = true;
                            db.SaveChanges();
                            Console.WriteLine("You have successfully updated reader!");
                        }
                    }
                    else if (email != string.Empty)
                    {
                        InputValidator inputValidator = new InputValidator(email);
                        if (inputValidator.EmailValidation())
                        {
                            var reader = new Reader()
                            {
                                ReaderId = id,
                                Email = email
                            };
                            db.Readers.Attach(reader);
                            db.Entry(reader).Property(x => x.Email).IsModified = true;
                            db.SaveChanges();
                            Console.WriteLine("You have successfully updated reader!");
                        }
                    }
                    else if (isStud != string.Empty)
                    {
                        var reader = new Reader()
                        {
                            ReaderId = id,
                            IsStudent = Convert.ToBoolean(isStud)
                        };
                        db.Readers.Attach(reader);
                        db.Entry(reader).Property(x => x.IsStudent).IsModified = true;
                        db.SaveChanges();
                        Console.WriteLine("You have successfully updated reader!");
                    }
                    else Console.WriteLine("There is nothing to update!");
                }
            }
            catch
            {
                throw;
            }
        }
        public void ReadersListID()
        {
            try
            {
                using (var db = new MyDbContext())
                {
                    foreach (var item in db.Readers.ToList())
                    {
                        Console.WriteLine($"{item.ReaderId} - {item.Name}");
                    }
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
