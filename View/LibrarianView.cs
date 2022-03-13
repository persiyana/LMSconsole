using System;
using LMSconsole.Database;
using LMSconsole.Controller;

namespace LMSconsole.View
{
    class LibrarianView
    {
        public void Login()
        {
            Console.Write("Username: ");
            string uname = Console.ReadLine();
            Console.Write("Password: ");
            string pass = Console.ReadLine();
            LibrarianController lc = new LibrarianController();
            if(lc.Login(uname, pass))
            {
                MenuView menuView = new MenuView();
                menuView.MenuAfterLogin();
            }
            else
            {
                Console.WriteLine("Invalid login info");
            }
        }
        public void AddLibrarian()
        {
            Console.Write("Username: ");
            string uname = Console.ReadLine();
            Console.Write("Password: ");
            string pass = Console.ReadLine();
            Console.Write("Confirm password: ");
            string passC = Console.ReadLine();
            Console.Write("Full name: ");
            string fname = Console.ReadLine();
            Console.Write("Address: ");
            string address = Console.ReadLine();
            Console.Write("Phone number: ");
            string phoneNum = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            LibrarianController lc = new LibrarianController();
            lc.AddLibrarian(uname, pass, passC, fname, address, phoneNum, email);
            MenuView menuView = new MenuView();
            menuView.MenuActivities();
        }
        public void LibrariansList()
        {
            Console.WriteLine("List of librarians:");
            LibrarianController lc = new LibrarianController();
            lc.LibrariansList();
            MenuView menuView = new MenuView();
            menuView.MenuActivities();
        }
        public void RemoveLibrarian()
        {
            Console.Write("Username: ");
            string uname = Console.ReadLine();
            if(uname!="admin"){
                LibrarianController lc = new LibrarianController();
                lc.RemoveLibrarian(uname);
            }
            else
            {
                Console.WriteLine("You can't delete an admin!");
            }
            MenuView menuView = new MenuView();
            menuView.MenuActivities();
        }
        public void CheckIfLibrariansHaveItems()
        {
            LibrarianController lc = new LibrarianController();
            lc.CheckIfLibrariansHaveItems();
        }
    }
}
