using LMSconsole.View;

namespace LMSconsole
{
    internal class Program
    {
        static void Main(string[] args)
        {

            LibrarianView librarianView = new LibrarianView();
            librarianView.CheckIfThereAreLibrarians();
            librarianView.Login();
        }
    }
}