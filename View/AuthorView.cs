using System;
using LMSconsole.Database;
using LMSconsole.Controller;
namespace LMSconsole.View
{
    public class AuthorView
    {
        public void AddAuthor()
        {
            Console.Write("Full name: ");
            string fname = Console.ReadLine();
            Console.Write("Nationality: ");
            string nationality = Console.ReadLine();
            Console.Write("Date of birth(dd/mm/yyyy): ");
            DateTime dateOfB = Convert.ToDateTime(Console.ReadLine());
            Console.Write("Is alive: ");
            bool isAlive= Convert.ToBoolean(Console.ReadLine());
            AuthorController authorController = new AuthorController();
            authorController.AddAuthor(fname, dateOfB, nationality, isAlive);
            MenuView menuView = new MenuView();
            menuView.MenuActivities();
        }
        public void AuthorList()
        {
            Console.WriteLine("List of authors:");
            AuthorController authorController = new AuthorController();
            authorController.AuthorList();
            MenuView menuView = new MenuView();
            menuView.MenuActivities();
        }
        public void AuthorListID()
        {
            Console.WriteLine("List of authors:");
            AuthorController authorController = new AuthorController();
            authorController.AuthorListID();

        }
    }
}
