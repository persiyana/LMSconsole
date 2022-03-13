using System;
using LMSconsole.Database;
using LMSconsole.Controller;

namespace LMSconsole.View
{
    public class ReaderView
    {
        public void AddReader()
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
            readerController.AddReader(fname, address, phoneNum, email,isStud);
            MenuView menuView = new MenuView();
            menuView.MenuActivities();
        }
        public void ReadersList()
        {
            Console.WriteLine("List of readers:");
            ReaderController readerController = new ReaderController();
            readerController.ReadersList();
            MenuView menuView = new MenuView();
            menuView.MenuActivities();
        }
    }
}
