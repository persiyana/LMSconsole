using LMSconsole.Controller;

namespace LMSconsole.View
{
    public class ReaderView
    {
        public void AddReader()
        {
            try
            {
                Console.Write("Full name: ");
                string fname = Console.ReadLine();
                Console.Write("Address: ");
                string address = Console.ReadLine();
                Console.Write("Phone number: ");
                string phoneNum = Console.ReadLine();
                Console.Write("Email: ");
                string email = Console.ReadLine();
                Console.Write("Is student: ");
                bool isStud = Convert.ToBoolean(Console.ReadLine());
                ReaderController readerController = new ReaderController();
                readerController.AddReader(fname, address, phoneNum, email, isStud);
                MenuView menuView = new MenuView();
                menuView.MenuActivities();
            }
            catch
            {
                Console.WriteLine("Error! New reader have NOT been added to the system!");
            }
        }
        public void ReadersList()
        {
            try
            {
                Console.WriteLine("List of readers:");
                ReaderController readerController = new ReaderController();
                readerController.ReadersList();
                MenuView menuView = new MenuView();
                menuView.MenuActivities();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void RemoveReader()
        {
            try
            {
                Console.Write("Reader's ID: ");
                int readID = Convert.ToInt32(Console.ReadLine());

                ReaderController readerController = new ReaderController();
                readerController.RemoveReader(readID);

                MenuView menuView = new MenuView();
                menuView.MenuActivities();
            }
            catch
            {
                Console.WriteLine("Error! Reader have NOT been removed from the system!");
            }
        }

        public void UpdateReader()
        {
            try
            {
                Console.Write("Reader's ID: ");
                int readID = Convert.ToInt32(Console.ReadLine());
                Console.Write("What do you want to change?(address/phone-number/email/is-student) ");
                string input = Console.ReadLine();
                string address = string.Empty;
                string pNum = string.Empty;
                string email = string.Empty;
                string isStud = string.Empty;
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
                    case "is-student":
                        Console.Write("Is student: ");
                        isStud = Console.ReadLine();
                        break;
                    default:
                        Console.WriteLine("Invalid input!");
                        break;
                }

                ReaderController readerController = new ReaderController();
                readerController.UpdateReader(readID, address, pNum, email, isStud);
                Console.WriteLine("You have successfully updated reader!");
                MenuView menuView = new MenuView();
                menuView.MenuActivities();
            }
            catch
            {
                Console.WriteLine("Error! Reader have NOT been updated!");
            }
        }
    }
}
