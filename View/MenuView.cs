using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LMSconsole.View;


namespace LMSconsole.View
{
    public class MenuView
    {
        public void MenuAfterLogin()
        {
            Console.WriteLine();
            Console.WriteLine("You are in the menu! Type ls if you want to see every possible command.");
            MenuActivities();
        }
        public void MenuActivities()
        {
            Console.WriteLine();
            Console.Write("Type your command: ");
            string command = Console.ReadLine();
            List<string> lsCommand = new List<string>
            {
                "command name - what the command does",
                "   ladd - add new librarian",
                "   lls - list of librarians",
                "   lremove - remove librarian",
                "   radd - add new reader",
                "   rls - list of readers",
                "   aadd - add new author",
                "   als - list of authors",
                "   badd - add new book",
                "   bls - list of books",
                "   END - end the program"
            };
            LibrarianView librarianView = new LibrarianView();
            AuthorView authorView = new AuthorView();
            ReaderView readerView = new ReaderView();
            BookView bookView = new BookView();
            if (command != "END")
            {
                switch (command)
                {
                    case "ls":
                        foreach (var item in lsCommand)
                        {
                            Console.WriteLine(item);
                        }
                        MenuActivities();
                        break;
                    case "ladd":
                        librarianView.AddLibrarian();
                        break;
                    case "lls":
                        librarianView.LibrariansList();
                        break;
                    case "lremove":
                        librarianView.RemoveLibrarian();
                        break;
                    case "radd":
                        readerView.AddReader();
                        break;
                    case "rls":
                        readerView.ReadersList();
                        break;
                    case "aadd":
                        authorView.AddAuthor();
                        break;
                    case "als":
                        authorView.AuthorList();
                        break;
                    case "badd":
                        bookView.AddBook();
                        break;
                    case "bls":
                        bookView.BookList();
                        break;
                    default:
                        Console.WriteLine("Invalid command");
                        MenuActivities();
                        break;
                }

            }

            
        }
    }
}
