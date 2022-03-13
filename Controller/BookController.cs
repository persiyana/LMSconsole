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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
