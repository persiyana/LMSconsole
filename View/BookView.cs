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
    }
}
