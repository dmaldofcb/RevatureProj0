using System;
using System.Collections.Generic;
using System.Text;

namespace BankingApplication
{
    class Users
    {
        private string firstName;
        private string lastName;
        private string dateOfBirth;
        private string username;
        private string password;
        private string address;

        public string FirstName { get => firstName; set => firstName = value; }
        public string DateOfBirth { get => dateOfBirth; set => dateOfBirth = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string Address { get => address; set => address = value; }

        public Users(string firstName, string lastName, string dateOfBirth, string username, string password, string address)
        {
            FirstName = firstName;
            DateOfBirth = dateOfBirth;
            LastName = lastName;
            Username = username;
            Password = password;
            Address = address;
        }

        public static void PrintUser(Users newUser)
        {
            Console.WriteLine("Creating User");
            Console.WriteLine("First Name: "+ newUser.FirstName);
            Console.WriteLine("Last Name: "+ newUser.LastName);
            Console.WriteLine("Username: "+ newUser.Username);
            Console.WriteLine("Password: "+ newUser.Password);
            Console.WriteLine("Address: "+ newUser.Address);

        }

    }
}
