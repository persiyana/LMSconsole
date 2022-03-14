using LMSconsole.Controller;

namespace LMSconsole.View
{
    class LibrarianView
    {
        public void Login()
        {
            try
            {
                Console.Write("Username: ");
                string uname = Console.ReadLine();
                Console.Write("Password: ");
                string pass = Console.ReadLine();
                LibrarianController lc = new LibrarianController();
                if (lc.Login(uname, pass))
                {
                    MenuView menuView = new MenuView();
                    menuView.MenuAfterLogin();
                }
                else
                {
                    Console.WriteLine("Invalid login info");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void AddLibrarian()
        {
            try
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
            catch
            {
                Console.WriteLine("Error! New librarian have NOT been added to the system!");
            }
        }
        public void LibrariansList()
        {
            try
            {
                Console.WriteLine("List of librarians:");
                LibrarianController lc = new LibrarianController();
                lc.LibrariansList();
                MenuView menuView = new MenuView();
                menuView.MenuActivities();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void RemoveLibrarian()
        {
            try
            {
                Console.Write("Username: ");
                string uname = Console.ReadLine();
                if (uname != "admin")
                {
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
            catch
            {
                Console.WriteLine("Error! Librarian have NOT been removed from the system!");
            }
        }
        public void CheckIfLibrariansHaveItems()
        {
            LibrarianController lc = new LibrarianController();
            lc.CheckIfLibrariansHaveItems();
        }
        public void UpdateLibrarian()
        {

            try
            {
                Console.Write("Librarian's username: ");
                string uname = Console.ReadLine();
                Console.Write("What do you want to change?(address/phone-number/email/password) ");
                string input = Console.ReadLine();
                string address = string.Empty;
                string pNum = string.Empty;
                string email = string.Empty;
                string pass = string.Empty;
                string passC = string.Empty;
                switch (input)
                {
                    case "address":
                        Console.Write("Address: ");
                        address = Console.ReadLine();
                        break;
                    case "phone-number":
                        Console.Write("Phone number: ");
                        pNum = Console.ReadLine();
                        break;
                    case "email":
                        Console.Write("Email: ");
                        email = Console.ReadLine();
                        break;
                    case "password":
                        Console.Write("Password: ");
                        pass = Console.ReadLine();
                        Console.Write("Confirm password: ");
                        passC = Console.ReadLine();
                        break;
                    default:
                        Console.WriteLine("Invalid input!");
                        break;
                }

                LibrarianController lc = new LibrarianController();

                lc.UpdateLibrarian(uname, address, pNum, email, pass, passC);
                Console.WriteLine("You have successfully updated librarian!");
                MenuView menuView = new MenuView();
                menuView.MenuActivities();
            }
            catch
            {
                Console.WriteLine("Error! Librarian have NOT been updated!");
            }

        }
    }
}
