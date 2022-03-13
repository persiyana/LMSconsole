using LMSconsole.Controller;
namespace LMSconsole.View
{
    public class AuthorView
    {
        public void AddAuthor()
        {
            try
            {
                Console.Write("Full name: ");
                string fname = Console.ReadLine();
                Console.Write("Nationality: ");
                string nationality = Console.ReadLine();
                Console.Write("Date of birth(dd/mm/yyyy): ");
                DateTime dateOfB = Convert.ToDateTime(Console.ReadLine());
                Console.Write("Is alive: ");
                bool isAlive = Convert.ToBoolean(Console.ReadLine());
                AuthorController authorController = new AuthorController();
                authorController.AddAuthor(fname, dateOfB, nationality, isAlive);
                MenuView menuView = new MenuView();
                menuView.MenuActivities();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void AuthorList()
        {
            try
            {
                Console.WriteLine("List of authors:");
                AuthorController authorController = new AuthorController();
                authorController.AuthorList();
                MenuView menuView = new MenuView();
                menuView.MenuActivities();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void AuthorListID()
        {
            try
            {
                Console.WriteLine("List of authors:");
                AuthorController authorController = new AuthorController();
                authorController.AuthorListID();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
