using LMSconsole.Controller;
namespace LMSconsole.View
{
    public class ActivityView
    {
        public void GivingBook()
        {
            try
            {
                Console.Write("Book's ID (type bls if you don't know the id): ");
                string input = Console.ReadLine();
                int bookID = 0;
                if (input == "bls")
                {
                    BookView bookView = new BookView();
                    bookView.BookListID();
                    Console.Write("Book's ID: ");
                    bookID = Convert.ToInt32(Console.ReadLine());
                }
                else if (int.TryParse(input, out int value) == true && Convert.ToInt32(input) > 0)
                {
                    bookID = Convert.ToInt32(input);
                }
                else
                {
                    Console.WriteLine("Error! Incorrect ID");
                }

                Console.Write("Reader's ID(type rls if you don't know the id): ");
                string input1 = Console.ReadLine();
                int readerID = 0;
                if (input1 == "rls")
                {
                    ReaderView readerView = new ReaderView();
                    readerView.ReaderListID();
                    Console.Write("Reader's ID: ");
                    readerID = Convert.ToInt32(Console.ReadLine());
                }
                else if (int.TryParse(input1, out int value) == true && Convert.ToInt32(input1) > 0)
                {
                    readerID = Convert.ToInt32(input1);
                }
                else
                {
                    Console.WriteLine("Error! Incorrect ID");
                }

                Console.Write("Given on(dd/mm/yyyy): ");
                DateTime dateOfG = Convert.ToDateTime(Console.ReadLine());

                ActivityController activityController = new ActivityController();
                activityController.GivingBook(bookID, readerID, dateOfG);
                MenuView menuView = new MenuView();
                menuView.MenuActivities();
            }
            catch
            {
                Console.WriteLine("Error! Book have not been given!");
                MenuView menuView = new MenuView();
                menuView.MenuActivities();
            }
        }

        public void ReturningBook()
        {
            try
            {
                Console.Write("Activity's ID (type acls if you don't know the id): ");
                string input = Console.ReadLine();
                int activityId = 0;
                if (input == "acls")
                {
                    ActivityView activityView = new ActivityView();
                    activityView.ActivitiesListID();
                    Console.Write("Activity's ID: ");
                    activityId = Convert.ToInt32(Console.ReadLine());
                }
                else if (int.TryParse(input, out int value) == true && Convert.ToInt32(input) > 0)
                {
                    activityId = Convert.ToInt32(input);
                }
                else
                {
                    Console.WriteLine("Error! Incorrect ID");
                }

                Console.Write("Book's ID (type bls if you don't know the id): ");
                string input1 = Console.ReadLine();
                int bookId = 0;
                if (input1 == "bls")
                {
                    BookView bookView = new BookView();
                    bookView.BookListID();
                    Console.Write("Book's ID: ");
                    bookId = Convert.ToInt32(Console.ReadLine());

                }
                else if (int.TryParse(input1, out int value) == true && Convert.ToInt32(input1) > 0)
                {
                    bookId = Convert.ToInt32(input1);
                }
                else
                {
                    Console.WriteLine("Error! Incorrect ID");
                }

                Console.Write("Returned on(dd/mm/yyyy): ");
                DateTime dateOfR = Convert.ToDateTime(Console.ReadLine());

                ActivityController activityController = new ActivityController();
                activityController.ReturningBook(activityId, bookId, dateOfR);
                MenuView menuView = new MenuView();
                menuView.MenuActivities();
            }
            catch
            {
                Console.WriteLine("Error! Book have not been returned!");
                MenuView menuView = new MenuView();
                menuView.MenuActivities();
            }
        }

        public void ActivitiesList()
        {
            try
            {
                Console.WriteLine("List of activities:");
                ActivityController activitiesController = new ActivityController();
                activitiesController.ActivitiesList();
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
        public void ActivitiesListID()
        {
            try
            {
                Console.WriteLine("List of activities:");
                ActivityController activityController = new ActivityController();
                activityController.ActivityListID();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MenuView menuView = new MenuView();
                menuView.MenuActivities();
            }

        }


    }
}
