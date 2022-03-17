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
                "   lupdate - update librarian",
                "   radd - add new reader",
                "   rls - list of readers",
                "   rremove - remove reader",
                "   rupdate - update reader",
                "   aadd - add new author",
                "   als - list of authors",
                "   aupdate - make author's 'is alive' from true to false",
                "   badd - add new book",
                "   bls - list of books",
                "   abls - list of available books",
                "   bremove - remove book",
                "   bupdate - update book",
                "   gb - give book",
                "   rb - return book",
                "   acls - list of activities",
                "   END - end the program"
            };
            LibrarianView librarianView = new LibrarianView();
            AuthorView authorView = new AuthorView();
            ReaderView readerView = new ReaderView();
            BookView bookView = new BookView();
            ActivityView activityView = new ActivityView();
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
                    case "lupdate":
                        librarianView.UpdateLibrarian();
                        break;
                    case "radd":
                        readerView.AddReader();
                        break;
                    case "rls":
                        readerView.ReadersList();
                        break;
                    case "rremove":
                        readerView.RemoveReader();
                        break;
                    case "rupdate":
                        readerView.UpdateReader();
                        break;
                    case "aadd":
                        authorView.AddAuthor();
                        break;
                    case "als":
                        authorView.AuthorList();
                        break;
                    case "aupdate":
                        authorView.UpdateAuthor();
                        break;
                    case "badd":
                        bookView.AddBook();
                        break;
                    case "bls":
                        bookView.BookList();
                        break;
                    case "abls":
                        bookView.IsAvailable();
                        break;
                    case "bremove":
                        bookView.RemoveBook();
                        break;
                    case "bupdate":
                        bookView.UpdateBook();
                        break;
                    case "gb":
                        activityView.GivingBook();
                        break;
                    case "rb":
                        activityView.ReturningBook();
                        break;
                    case "acls":
                        activityView.ActivitiesList();
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
