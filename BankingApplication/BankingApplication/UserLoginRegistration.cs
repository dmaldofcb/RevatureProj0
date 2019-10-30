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

        private static bool ValidateUser(string userName,string password)
        {
            if (userInformation.Count == 0)
            {
                return false;
            }
            else if (userInformation.ContainsKey((userName, password)) )
            {
                //Console.WriteLine($"User with username: {userName} and password: {password} exist !!!!");
                return true;
            }

            Console.WriteLine("**Login failed**");

            return false;
        }

        public static bool RegisterUser(Users newUser)
        {
            if (ValidateUser(newUser.Username,newUser.Password)) // check if user with that username and password already exist
            {
                Console.WriteLine($"**Error: User with the {newUser.Username} or {newUser.Password} already exist choose different**");
                return false;
            }
            userInformation.Add((newUser.Username, newUser.Password), newUser);
            
            Console.WriteLine("\n[Successfully Created Account,Please Login]\n");
            return true;
        }

        public static Users LoginUser(string username, string password)
        {
            Users user = null;
            if (UserLoginRegistration.ValidateUser(username, password))
            {
                user = userInformation[(username,password)];
                Console.WriteLine("\n[Successfully Logged In]\n");

                return user;
            }
            else
            {
                Console.WriteLine("\n**Login Failed. Try Again**\n");
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
                Console.WriteLine("DOB: " + newUser.DateOfBirth.ToString("MM/dd/yyyy"));
                Console.WriteLine("--------------------");
            }
        }
    }
}
