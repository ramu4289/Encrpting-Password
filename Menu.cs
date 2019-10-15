using Enumeration;
using System;

namespace PasswordEncryptionAuthentication
{
    public class Menu
    {
        public void AskUser()
        {
            Console.WriteLine("                                        PASSWORD AUTHENTICATION SYSTEM                           \n");
            Console.WriteLine("                  -------------------------------------------------------------------------------\n");

            Console.WriteLine("                                 Choose Number to : \n                                             ");
            Console.WriteLine("                                       1. Register New UserId and Password                       \n");
            Console.WriteLine("                                       2. Authenticate Your UserName and Password                \n");
            Console.WriteLine("                                       3. Exit From System                                       \n");

            Console.WriteLine("                  ---------------------------------------------------------------------------------");


            Console.Write("                      =|-:> "); ChooseMenu();

        }
        public void ChooseMenu()
        {
            UserEnum choose = (UserEnum)int.Parse(Console.ReadLine());
            while (choose == UserEnum.None)
            {
                Console.WriteLine("Envalid Input Try Again!");
                choose = (UserEnum)int.Parse(Console.ReadLine());
            }

            switch (choose)
            {
                case UserEnum.Register:
                    var regist = new RegisterAthenticate();
                    regist.Registaraion();
                    Clear();
                    AskUser();
                    break;
                case UserEnum.Authenticate:
                    //Authenticate autho = new Authenticate();
                    //autho.Authorize();
                    RegisterAthenticate valid = new RegisterAthenticate();
                    valid.AskAuthenticate();
                    Clear();
                    AskUser();
                    break;
                case UserEnum.Exit:
                    ExitSystem();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Wrong Input Try again");
                    AskUser();
                    break;
            }
        }

        public void ExitSystem()
        {
            RegisterAthenticate regis = new RegisterAthenticate();
            regis.Display();
            Console.ReadKey();

            Environment.Exit(0);
        }

        public void Clear()
        {
            //Console.ReadLine();
            Console.ReadKey();
            //Console.Write("Enter");
            Console.Clear();
        }

    }
}
