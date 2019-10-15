using System;
using System.Security.Cryptography;
using System.Text;


namespace PasswordEncryptionAuthentication
{

    class Authenticate
    {

        Storage store = new Storage();
        public static RegisterAthenticate register = new RegisterAthenticate();


        public void Authorize()
        {

            Console.WriteLine("\n                     Authenticate Name and Password by Log IN :                    \n");
            Console.Write("                           Enter User Name :       ");
            string Name = Console.ReadLine().ToString();
            store.Name = Name;
            Console.Write("                           Enter your Password :  ");
            string Password = Console.ReadLine().ToString();
            store.Password = Password;
            MD5 hash1 = MD5.Create();

            string encrypt = Encryptions(hash1, Password);

            Console.WriteLine($"\n                    User Name : {Name}              Entered password : {Password}    ");
            //Console.WriteLine("\n                           Your Encryption :" + encrypt);


            register.GetType();
            validateUser(hash1, encrypt, store.Password);

        }

        public static void validateUser(MD5 hash, string newPassword, string hashPassword)
        {
            Console.WriteLine("                       Authenticating User : ");
            if (!AuthenticatUser(hash, newPassword, hashPassword))
            {
                Console.WriteLine("\n                 Your Validation Approve. Wellcome");
            }
            else
            {
                Console.WriteLine("\n                 Warning!! Try Again");
            }
        }

        static bool AuthenticatUser(MD5 newhash, string input, string hash)
        {
            //MD5 newhash = MD5.Create(input);
            //string newHash = User.Encryption(newhash.ToString());
            string newHash = Encryptions(newhash, input);
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(newHash, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static string Encryptions(MD5 hash, string password)
        {
            using (hash = MD5.Create())
            {
                ///UTF8, 32 , BigEndianUnicode, Unicode, ASCII
                byte[] inputPassword = Encoding.ASCII.GetBytes(password);  //change to byte

                byte[] hashPassword = hash.ComputeHash(inputPassword);

                StringBuilder en = new StringBuilder();
                for (int i = 0; i < hashPassword.Length; i++)
                {
                    en.Append(hashPassword[i].ToString("X2"));
                }
                return en.ToString();
            }
        }

    }

}


