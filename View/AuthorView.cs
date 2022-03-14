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
            catch
            {
                Console.WriteLine("Error! New author have NOT been added to the system!");
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
        public void UpdateAuthor()
        {
            try
            {
                Console.WriteLine("Warning! Authors alive status will be updated automatically to FALSE");
                Console.Write("Author's ID:");
                int AuthID = Convert.ToInt32(Console.ReadLine());
                AuthorController authorController = new AuthorController();
                authorController.UpdateAuthor(AuthID);
                Console.WriteLine($"Author with id {AuthID} have been updated!");
                MenuView menuView = new MenuView();
                menuView.MenuActivities();
            }
            catch
            {
                Console.WriteLine("Error! That author have NOT been updated");
            }
        }
    }
}
