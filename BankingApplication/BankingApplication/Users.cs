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

        public string FirstName { get => firstName;}
        public string DateOfBirth { get => dateOfBirth;}
        public string LastName { get => lastName; }
        public string Username { get => username; }
        public string Password { get => password; }
        public string Address { get => address;}

        public Users(string firstName, string lastName, string dateOfBirth, string username, string password, string address)
        {
            this.firstName = firstName;
            this.dateOfBirth = dateOfBirth;
            this.lastName = lastName;
            this.username = username;
            this.password = password;
            this.address = address;
        }

        //Test user Creation
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
