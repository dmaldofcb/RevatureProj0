using System;

namespace BankingApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Banking Application");
            //Users user1 = new Users("Bob", "Joe", "11/5/1959", "bob01", "bob12563", "123 Court St.");
            //Users user2 = new Users("Rock", "Richardson", "12/15/1995", "rocky101", "pass123", "526 First St.");
            //Users user3 = new Users("Lucas", "Sonic", "1/5/1989", "lucas506", "sonic563", "999 Fith Av.");
            //Users user4 = new Users("Bianca", "Michi", "6/5/1998", "webble566", "1256pass", "6159 Newport Ter.");
            //string g = user1.FirstName;
            //Console.WriteLine(g);
            //UserLoginRegistration.RegisterUser(user1);
            //UserLoginRegistration.RegisterUser(user2);
            //UserLoginRegistration.RegisterUser(user3);
            //UserLoginRegistration.RegisterUser(user4);

            //UserLoginRegistration.printAllAccounts();
            //Console.WriteLine("***********************************");

            //Users storedUser = UserLoginRegistration.LoginUser("webble566", "1256pass");
            //Users.PrintUser(storedUser);
            //Users storedUser2 = UserLoginRegistration.LoginUser("lucas506", "sonic563");
            //Users.PrintUser(storedUser2);

            CheckingAccount chk = new CheckingAccount();
            CheckingAccount chk4 = new CheckingAccount();
            BusinessAccount buss = new BusinessAccount();
            BusinessAccount buss2 = new BusinessAccount();

            LoanAccount chk2 = new LoanAccount((decimal)3500);
            TermDepositAccount chk3 = new TermDepositAccount(2000,5,2);
            TermDepositAccount term = new TermDepositAccount(5);

            

            
            chk.printAccountInfo();
            chk.InterestRate = 5.5M;
            //chk2.InterestRate = 5.5M;
            chk.Deposit(3000M);
            chk4.Deposit(30000M);
            chk.Withdraw(500M);
            chk.TransferBetweenAccounts(chk4,150M);
            chk4.TransferBetweenAccounts(chk,10000M);

            buss.Deposit(5000M);
            buss.Withdraw(100M);
            buss.TransferBetweenAccounts(chk4, 600M);
            chk4.TransferBetweenAccounts(buss, 60M);

            chk2.Deposit(1000M);
            chk2.Withdraw(100M);
            chk2.TransferBetweenAccounts(chk4, 600M);
            chk4.TransferBetweenAccounts(chk2, 60M);

            term.Deposit(1000M);
            term.Withdraw(100M);
            term.TransferBetweenAccounts(chk4, 600M);
            chk4.TransferBetweenAccounts(term, 60M);

            foreach (var transac in chk.accountTransactions)
            {
                Console.WriteLine(transac);
            }
            Console.WriteLine("-------------------------------");
            foreach (var transac in buss.accountTransactions)
            {
                Console.WriteLine(transac);
            }
            Console.WriteLine("-------------------------------");
            foreach (var transac in chk2.accountTransactions)
            {
                Console.WriteLine(transac);
            }
            Console.WriteLine("-------------------------------");
            foreach (var transac in term.accountTransactions)
            {
                Console.WriteLine(transac);
            }

            //chk2.printAccountInfo();
            //chk2.Deposit(1000M);
            //chk2.printAccountInfo();
            //chk2.printAccountInfo();
            //chk2.Deposit(500M);


            chk.CalculateSimpleInterest(5);
            //chk2.CalculateSimpleInterest(5);


            chk3.TransferBetweenAccounts(chk, 500M);
            chk.TransferBetweenAccounts(chk3, 300M);


            // chk3.Withdraw(100M, new DateTime(2019,5,3));
            chk3.printAccountInfo();
            //chk.printAccountInfo();
            //chk2.printAccountInfo();
            //chk3.printAccountInfo();
            //chk.Withdraw((decimal)0);

            buss.InterestRate = 5.5M;
            buss2.InterestRate = 5.5M;
            chk2.InterestRate = 32.50M;
            //chk3.InterestRate = 18.5M;
            //buss.printAccountInfo();
            //buss2.printAccountInfo();

            //chk.Deposit((decimal)1000);
            //chk4.Deposit((decimal)500);
            ////chk3.Deposit((decimal)3500);
            //buss.Deposit((decimal)200);
            //buss2.Deposit((decimal)400);
            //buss2.TransferBetweenAccounts(chk, 500M);
            //chk.printAccountInfo();

            //buss2.TransferBetweenAccounts(chk4, 500M);
            //buss2.printAccountInfo();


            //chk.TransferBetweenAccounts(buss2,100M);
            //buss2.printAccountInfo();
            //chk.printAccountInfo();


            //chk.TransferBetweenAccounts(buss2, 100M);
            //buss2.printAccountInfo();
            //chk.printAccountInfo();

            //chk.TransferBetweenAccounts(buss2, 100M);
            //buss2.printAccountInfo();

            //buss2.TransferBetweenAccounts(chk, 300M);

            //buss2.printAccountInfo();

            //chk3.printAccountInfo();
            //chk4.printAccountInfo();
            //buss.printAccountInfo();
            //Console.WriteLine(buss.Overdraft);

            //buss.Withdraw((decimal)400);
            ////chk.TransferBetweenAccounts(chk4,(decimal)100);
            ////chk2.TransferBetweenAccounts(chk4,(decimal)100);
            ////chk2.TransferBetweenAccounts(buss,(decimal)100);
            ////buss.TransferBetweenAccounts(chk, (decimal)100);
            //buss.printAccountInfo();

            //buss.Withdraw(200M);
            //buss.printAccountInfo();
            //buss.Withdraw(200M);

            //buss.TransferBetweenAccounts(chk, 500M) ;
            //buss.printAccountInfo();

            Console.WriteLine(buss2.Overdraft);
            //chk2.printAccountInfo();
            //chk.printAccountInfo();
            //chk4.printAccountInfo();



            //chk.Deposit((decimal)1000);

            //chk.printAccountInfo();
            //chk2.printAccountInfo();
            //chk3.printAccountInfo();


        }
    }
}
