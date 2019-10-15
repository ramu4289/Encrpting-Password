using System;
namespace PasswordEncryptionAuthentication
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("");
                Menu ask = new Menu();
                //ask.AskUser();
                ask.AskUser();
            }
            catch (ArgumentNullException)
            {
                throw;
            }
            finally
            {
                Console.WriteLine("Good bye");

            }
        }
    }
}
