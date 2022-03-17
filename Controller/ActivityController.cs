using LMSconsole.Database;
using LMSconsole.Database.Entities;

namespace LMSconsole.Controller
{
    internal class ActivityController
    {
        public void GivingBook(int bookId, int readerId, DateTime givenAt)
        {
            try
            {
                bool tf = false;
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
                        if (item.BookId == bookId)
                        {
                            if (item.BookIsAvailable == true)
                            {
                                tf = true;
                            }
                            else
                            {
                                tf = false;
                            }
                        }
                    }

                }
                if (tf == true)
                {
                    using (var db = new MyDbContext())
                    {
                        var activity = new Activity
                        {
                            BookId = bookId,
                            ReaderId = readerId,
                            GivenAt = givenAt

                        };
                        db.Activities.Add(activity);
                        db.SaveChanges();
                        Console.WriteLine($"You have successfully given the book with id {activity.BookId} to the reader with id {activity.ReaderId}!");

                        var book = new Book()
                        {
                            BookId = bookId,
                            IsAvailable = false
                        };
                        db.Books.Attach(book);
                        db.Entry(book).Property(x => x.IsAvailable).IsModified = true;
                        db.SaveChanges();
                    }
                }
                else
                {
                    Console.WriteLine("Error! The book is unavailable at the moment.");
                }
            }
            catch
            {
                throw;
            }

        }
        public void ReturningBook(int activityId, int bookId, DateTime returnedAt)
        {
            try
            {
                bool tf = true;
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
                        if (item.BookId == bookId)
                        {
                            if (item.BookIsAvailable == true)
                            {
                                tf = true;
                            }
                            else
                            {
                                tf = false;
                            }
                        }
                    }

                }
                if (tf == false)
                {

                    using (var db = new MyDbContext())
                    {
                        var activity = new Activity()
                        {
                            ActivityId = activityId,
                            ReturnedAt = returnedAt
                        };
                        db.Activities.Attach(activity);
                        db.Entry(activity).Property(x => x.ReturnedAt).IsModified = true;
                        db.SaveChanges();
                        Console.WriteLine($"You have successfully returned the book with id {activity.BookId} to the reader with id {activity.ReaderId}!");

                        var book = new Book()
                        {
                            BookId = bookId,
                            IsAvailable = true
                        };
                        db.Books.Attach(book);
                        db.Entry(book).Property(x => x.IsAvailable).IsModified = true;
                        db.SaveChanges();
                    }
                }
                else
                {
                    Console.WriteLine("Error! The book is unavailable at the moment.");
                }
            }
            catch
            {
                throw;
            }

        }

        public void ActivitiesList()
        {
            try
            {
                using (var db = new MyDbContext())
                {
                    foreach (var item in db.Activities.ToList())
                    {
                        Console.WriteLine($"Activity's ID: {item.ActivityId}" +
                            $"\n  Book's ID: {item.BookId}" +
                            $"\n  Reader's ID: {item.ReaderId}" +
                            $"\n  Given at: {item.GivenAt}" +
                            $"\n  Returned at: {item.ReturnedAt}" +
                            $"\n");
                    }
                }
            }
            catch
            {
                throw;
            }

        }

        public void ActivityListID()
        {
            try
            {
                using (var db = new MyDbContext())
                {
                    foreach (var item in db.Activities.ToList())
                    {
                        Console.WriteLine($"{item.ActivityId} - {item.BookId}, {item.ReaderId}, {item.GivenAt}");
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
