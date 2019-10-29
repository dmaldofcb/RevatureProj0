using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace BankingApplication
{
    static class UserLoginRegistration
    {
        //Keep track of all the user login information 
        private static Dictionary<(string,string), Users> userInformation = new Dictionary<(string, string), Users>();        

        public static bool ValidateUser(string userName,string password)
        {
            //foreach(var credentials in userInformation.Keys)
            //{
            //    if(credentials == (userName, password))
            //    {
            //        Console.WriteLine($"User with username: {userName} and password: {password} exist !!!!");
            //        return true;
            //    }
            //}

            if (userInformation.ContainsKey((userName, password)) )
            {
                Console.WriteLine($"User with username: {userName} and password: {password} exist !!!!");
                return true;
            }

            Console.WriteLine("Login failed");

            return false;
        }

        public static void RegisterUser(Users newUser)
        {
            userInformation.Add((newUser.Username, newUser.Password), newUser);
            Console.WriteLine("Successfully Created Account !!!");
        }

        public static Users LoginUser(string username, string password)
        {
            Users user = null;
            if (UserLoginRegistration.ValidateUser(username, password))
            {
                user = userInformation[(username,password)];
                return user;
            }
            else
            {
                Console.WriteLine("Login Failed. Try Again");
                return user;
            }
        }



        //test method
        public static void printAllAccounts()
        {
            Console.WriteLine("-------------Users---------------");

            ICollection accountList = userInformation.Values;
            foreach (Users newUser in accountList)
            {
                Console.WriteLine("First Name: " + newUser.FirstName);
                Console.WriteLine("Last Name: " + newUser.LastName);
                Console.WriteLine("Username: " + newUser.Username);
                Console.WriteLine("Password: " + newUser.Password);
                Console.WriteLine("Address: " + newUser.Address);
                Console.WriteLine("--------------------");
            }
        }
    }
}
