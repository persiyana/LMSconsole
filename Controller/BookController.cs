using LMSconsole.Database;
using LMSconsole.Database.Entities;
using LMSconsole.Validator;
using LMSconsole.View;


namespace LMSconsole.Controller
{
    public class BookController
    {
        public void AddBook(string title, int authorID, DateTime issuedAt, bool isAvailable)
        {
            try
            {
                InputValidator bookV = new InputValidator(title);
                if (bookV.BookAllDataValidation())
                {
                    using (var db = new MyDbContext())
                    {
                        var book = new Book
                        {
                            Title = title,
                            AuthorId = authorID,
                            IssuedAt = issuedAt,
                            IsAvailable = isAvailable
                        };
                        db.Books.Add(book);
                        db.SaveChanges();
                        Console.WriteLine("You have successfully added new book!");
                    }
                }
            }
            catch
            {
                throw;
            }
        }
        public void BookList()
        {
            try
            {
                using (var db = new MyDbContext())
                {
                    var data = db.Books.Join(db.Authors,
                        book => book.Author.AuthorId,
                        author => author.AuthorId,
                        (book, author) => new
                        {
                            BookId = book.BookId,
                            AuthorName = author.Name,
                            BookTitle = book.Title,
                            BookIssuedAt = book.IssuedAt,
                            BookIsAvailable = book.IsAvailable
                        }
                        ).ToList();
                    foreach (var item in data)
                    {

                        Console.WriteLine($"Id: {item.BookId}" +
                            $"\n  Title: {item.BookTitle}" +
                            $"\n  Author: {item.AuthorName}" +
                            $"\n  Issued at: {item.BookIssuedAt}" +
                            $"\n  Is available: {item.BookIsAvailable}" +
                            $"\n");
                    }
                }
            }
            catch
            {
                throw;
            }
        }
        public void RemoveBook(int bookID)
        {
            try
            {
                using (var db = new MyDbContext())
                {
                    var bookR = new Book
                    {
                        BookId = bookID
                    };
                    db.Books.Remove(bookR);
                    db.SaveChanges();
                    Console.WriteLine("You have successfully removed a book!");
                }
            }
            catch
            {
                throw;
            }
        }

        public void IsAvailable()
        {
            using (var db = new MyDbContext())
            {
                try
                {
                    var data = db.Books.Join(db.Authors,
                    book => book.Author.AuthorId,
                    author => author.AuthorId,
                    (book, author) => new
                    {
                        BookId = book.BookId,
                        AuthorName = author.Name,
                        BookTitle = book.Title,
                        BookIssuedAt = book.IssuedAt,
                        BookIsAvailable = book.IsAvailable
                    }
                    ).ToList();
                    foreach (var item in data)
                    {
                        if (item.BookIsAvailable == true)
                        {
                            Console.WriteLine($"Id: {item.BookId}" +
                           $"\n  Title: {item.BookTitle}" +
                           $"\n  Author: {item.AuthorName}" +
                           $"\n  Issued at: {item.BookIssuedAt}" +
                           $"\n");
                        }

                    }
                }
                catch
                {
                    throw;
                }

            }
        }

        public void UpdateBook(int id, string command)
        {
            try
            {
                if (command == "title")
                {
                    Console.Write("Write the new title: ");
                    string newTitle = Console.ReadLine();


                    using (var db = new MyDbContext())
                    {
                        var book = new Book()
                        {
                            BookId = id,

                            Title = newTitle

                        };
                        db.Books.Attach(book);
                        db.Entry(book).Property(x => x.Title).IsModified = true;
                        db.SaveChanges();
                    }
                }

                else if (command == "issued-at")
                {
                    Console.Write("Write the new date(dd/mm/yyyy): ");
                    DateTime newDatetime = Convert.ToDateTime(Console.ReadLine());


                    using (var db = new MyDbContext())
                    {
                        var book = new Book()
                        {
                            BookId = id,
                            IssuedAt = newDatetime
                        };
                        db.Books.Attach(book);
                        db.Entry(book).Property(x => x.IssuedAt).IsModified = true;
                        db.SaveChanges();
                    }

                }
                else if (command == "author-id")
                {
                    Console.Write("Which author you want to assign the book to (Author's ID)(type als if you don't know the id): ");

                    string input = Console.ReadLine();

                    int authorID = 0;
                    if (input == "als")
                    {
                        AuthorView authorView = new AuthorView();
                        authorView.AuthorListID();
                        Console.Write("Author's ID: ");

                        input = Console.ReadLine();

                        authorID = Convert.ToInt32(input);
                    }
                    else if (int.TryParse(input, out int value) == true && Convert.ToInt32(input) > 0)
                    {
                        authorID = Convert.ToInt32(input);
                    }
                    using (var db = new MyDbContext())
                    {
                        var book = new Book()
                        {
                            BookId = id,
                            AuthorId = authorID
                        };
                        db.Books.Attach(book);
                        db.Entry(book).Property(x => x.AuthorId).IsModified = true;
                        db.SaveChanges();
                    }

                }
                else
                {
                    Console.WriteLine("Error! Book have NOT been updated. Incorrect command");
                }

            }
            catch
            {
                throw;
            }
        }
        public void BookListID()
        {
            try
            {
                using (var db = new MyDbContext())
                {
                    foreach (var item in db.Books.ToList())
                    {
                        Console.WriteLine($"{item.BookId} - {item.Title}");
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
