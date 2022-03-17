using LMSconsole.Controller;
namespace LMSconsole.View
{
    public class BookView
    {
        public void AddBook()
        {
            try
            {
                Console.Write("Title: ");
                string title = Console.ReadLine();
                Console.Write("Author ID(type als if you don't know the id): ");
                string input = Console.ReadLine();
                if (input == "als")
                {
                    AuthorView authorView = new AuthorView();
                    authorView.AuthorListID();
                    Console.Write("Author ID: ");
                    input = Console.ReadLine();
                }
                Console.Write("Issued at(dd/mm/yyyy): ");
                DateTime issuedAt = Convert.ToDateTime(Console.ReadLine());
                Console.Write("Is available: ");
                bool isAvailable = Convert.ToBoolean(Console.ReadLine());
                int authorID = Convert.ToInt32(input);

                BookController bookController = new BookController();
                bookController.AddBook(title, authorID, issuedAt, isAvailable);

                MenuView menuView = new MenuView();
                menuView.MenuActivities();
            }
            catch
            {
                Console.WriteLine("Error! New book have NOT been added to the system!");
                MenuView menuView = new MenuView();
                menuView.MenuActivities();
            }
        }
        public void BookList()
        {
            try
            {
                Console.WriteLine("List of books:");
                BookController bookController = new BookController();
                bookController.BookList();
                MenuView menuView = new MenuView();
                menuView.MenuActivities();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MenuView menuView = new MenuView();
                menuView.MenuActivities();
            }
        }
        public void RemoveBook()
        {
            try
            {
                Console.Write("Book's ID: ");
                int bookID = Convert.ToInt32(Console.ReadLine());

                BookController bookController = new BookController();
                bookController.RemoveBook(bookID);

                MenuView menuView = new MenuView();
                menuView.MenuActivities();
            }
            catch
            {
                Console.WriteLine("Error! Book have NOT been removed from the system!");
                MenuView menuView = new MenuView();
                menuView.MenuActivities();
            }
        }


        public void IsAvailable()
        {
            try
            {
                Console.WriteLine("List of available books:");
                BookController bookController = new BookController();
                bookController.IsAvailable();
                MenuView menuView = new MenuView();
                menuView.MenuActivities();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MenuView menuView = new MenuView();
                menuView.MenuActivities();
            }
        }
        public void BookListID()
        {
            try
            {
                Console.WriteLine("List of books:");
                BookController bookCon = new BookController();
                bookCon.BookListID();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MenuView menuView = new MenuView();
                menuView.MenuActivities();
            }

        }

        public void UpdateBook()
        {

            try
            {

                Console.Write("Book's ID (type bls if you don't know the id): ");
                string input = Console.ReadLine();
                int BookID = 0;
                if (input == "bls")
                {
                    BookView bookView = new BookView();
                    bookView.BookListID();
                    Console.Write("Book's ID: ");
                    BookID = Convert.ToInt32(Console.ReadLine());
                    Console.Write("What do you want to change (title/author-id/issued-at/is-available): ");
                    string command = Console.ReadLine();
                    BookController bookController = new BookController();
                    bookController.UpdateBook(BookID, command);
                    Console.WriteLine($"Book with id {BookID} have been updated!");
                    MenuView menuView = new MenuView();
                    menuView.MenuActivities();
                }
                else if (int.TryParse(input, out int value) == true && Convert.ToInt32(input) > 0)
                {
                    BookID = Convert.ToInt32(input);
                    Console.Write("What do you want to change (title/author-id/issued-at): ");
                    string command = Console.ReadLine().ToLower();
                    if (command == "title" || command == "author-id" || command == "issued-at")
                    {
                        BookController bookController = new BookController();
                        bookController.UpdateBook(BookID, command);
                        Console.WriteLine($"Book with id {BookID} have been updated!");
                        MenuView menuView = new MenuView();
                        menuView.MenuActivities();
                    }
                    else
                    {
                        Console.WriteLine("Error! Book have NOT been updated. Incorrect command");
                    }

                }
                else
                {
                    Console.WriteLine("Error! Book have NOT been updated. Incorrect ID");
                }


            }
            catch
            {
                Console.WriteLine("Error! Book have NOT been updated. Incorrect ID");
                MenuView menuView = new MenuView();
                menuView.MenuActivities();
            }



        }
    }

}
