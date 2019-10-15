using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;


namespace PasswordEncryptionAuthentication
{
    public class RegisterAthenticate
    {
        Storage store = new Storage();

        public static Dictionary<string, string> UserLogin = new Dictionary<string, string>();

        public void Display()
        {
            foreach (var item in UserLogin)
            {
                Console.WriteLine("                 Name : {0}                   Password Encrypted : {1}", item.Key, item.Value);
            }
        }

        public void Registaraion()
        {
            Console.WriteLine("\n                           System Using User Name and Password to register new account :    \n");

            Console.Write("                                 Enter User Name : ");
            string name = Convert.ToString(Console.ReadLine());
            Console.Write("                                 Enter Password :  ");
            string password = Convert.ToString(Console.ReadLine());

            if (UserLogin.ContainsKey(name))
            {
                Console.WriteLine("                         Already Taken!! Use Diffrent UserName and Password :               ");
                Registaraion();
            }
            else
            {
                store.Name = name;
                string encrypt = Encryption(password);
                store.Password = encrypt;
                // UserLogin.Add(name, encrypt);
                UserLogin.Add(store.Name, password);
                Console.WriteLine($"                         User Name : {name}                      Entered password : {password}");
            }
        }

        public void AskAuthenticate()
        {

            Console.WriteLine("\n                            Authenticate Name and Password by Log IN :                            \n");
            Console.Write("                                  Enter User Name :             ");
            string _name = Console.ReadLine();

            Console.Write("\n                                Enter your Password :         ");
            string _password = Console.ReadLine();

            if (!UserLogin.Contains(new KeyValuePair<string, string>(_name, _password)))
            {
                Console.WriteLine("\n                         Wrong Name and password, try again:                     ");
                AskAuthenticate();
            }
            else
            {

                try
                {
                    store.Name = _name;
                    string encrypt = Encryption(_password);
                    store.Password = encrypt;
                    UserLogin.Add(store.Name, _password);
                    UserLogin.Add(store.Name, store.Password);
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("\n                         Wellcome                      ");



                    Console.WriteLine($"\n                        User Name : {_name}                      Entered password : {_password}      ");
                    // Console.WriteLine("\n                           Your Encryption :" + encrypt);
                }

            }

        }

        public static string Encryption(string password)
        {
            MD5 md5password = MD5.Create();

            byte[] newPassword = Encoding.ASCII.GetBytes(password);
            byte[] encryptPass = md5password.ComputeHash(newPassword);
            System.Text.StringBuilder en = new System.Text.StringBuilder();
            for (int i = 0; i < encryptPass.Length; i++)
            {
                en.Append(encryptPass[i].ToString("X2"));
            }
            return en.ToString();

        }

        public static string Decryption(string encodedData)
        {

            var encodedDataAsBytes = System.Convert.FromBase64String(encodedData);
            // var encodedDataAsBytesa = System.Convert.FromBase64String(encodedData);

            var returnValue = Encoding.BigEndianUnicode.GetString(encodedDataAsBytes);
            //StringBuilder s = new StringBuilder();
            //foreach (byte b in returnValue)
            //    s.Append(b.ToString("X2").ToUpper());
            return returnValue;
        }

    }
}

