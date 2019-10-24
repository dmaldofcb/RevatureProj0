using System;

namespace BankingApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Banking Application");
            Users user1 = new Users("Bob", "Joe", "11/5/1959", "bob01", "bob12563", "123 Court St.");
            Users user2 = new Users("Rock", "Richardson", "12/15/1995", "rocky101", "pass123", "526 First St.");
            Users user3 = new Users("Lucas", "Sonic", "1/5/1989", "lucas506", "sonic563", "999 Fith Av.");
            Users user4 = new Users("Bianca", "Michi", "6/5/1998", "webble566", "1256pass", "6159 Newport Ter.");

            UserLoginRegistration.RegisterUser(user1);
            UserLoginRegistration.RegisterUser(user2);
            UserLoginRegistration.RegisterUser(user3);
            UserLoginRegistration.RegisterUser(user4);

            UserLoginRegistration.printAllAccounts();
            Console.WriteLine("***********************************");

            Users storedUser = UserLoginRegistration.LoginUser("webble566", "1256pass");
            Users.PrintUser(storedUser);
            Users storedUser2 = UserLoginRegistration.LoginUser("lucas506", "sonic563");
            Users.PrintUser(storedUser2);




        }
    }
}
