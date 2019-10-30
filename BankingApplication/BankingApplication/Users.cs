using System;
using System.Collections.Generic;
using System.Text;

namespace BankingApplication
{
    class Users
    {
        private string firstName;
        private string lastName;
        private DateTime dateOfBirth;
        private string username;
        private string password;
        private string address;

        public string FirstName { get => firstName;}
        public DateTime DateOfBirth { get => dateOfBirth;}
        public string LastName { get => lastName; }
        public string Username { get => username; }
        public string Password { get => password; }
        public string Address { get => address;}

        public Users(string firstName, string lastName, DateTime dateOfBirth, string username, string password, string address)
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
            Console.WriteLine("*-------------------------User Information---------------------------*");
            Console.WriteLine(String.Format("{0,-10} {1,15}", "First Name: ".PadLeft(30), newUser.FirstName));
            Console.WriteLine(String.Format("{0,-10} {1,15}", "Last Name:  ".PadLeft(30), newUser.LastName));
            Console.WriteLine(String.Format("{0,-10} {1,15}", "Username:   ".PadLeft(30), newUser.Username));
            Console.WriteLine(String.Format("{0,-10} {1,15}", "Password:   ".PadLeft(30), newUser.Password));
            Console.WriteLine(String.Format("{0,-10} {1,15}", "DOB:        ".PadLeft(30), newUser.DateOfBirth.ToString("MM/dd/yyyy")));
            

        }

    }
}
