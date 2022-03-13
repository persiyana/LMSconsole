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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
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
            }
        }
    }
}
