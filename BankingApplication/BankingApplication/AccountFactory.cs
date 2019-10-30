using System;
using System.Collections.Generic;
using System.Text;

namespace BankingApplication
{
    class AccountFactory
    {
        protected static readonly Random getrandom = new Random();

        public Account CreateAccount(AccountsType accountType)
        {
            Account account = null; 
            double percent = .1 + ((.3 - .1) * getrandom.NextDouble());
            decimal interest = (decimal)(Math.Round(percent, 2) * 100); //to generate random interest rate
            switch (accountType)
            {
                case AccountsType.Checking:
                    account = new CheckingAccount();
                    account.InterestRate = interest;
                    break;
                case AccountsType.Business:
                    account = new BusinessAccount();
                    account.InterestRate = interest;
                    break;
                case AccountsType.Loan:
                    decimal loan = GetLoanPrompt();
                    if(loan != 0)
                        account = new LoanAccount(loan);
                        account.InterestRate = interest;
                    break;
                case AccountsType.Term_Deposit:
                    int years = MaturityYears();
                    if(years != 0)
                        account = new TermDepositAccount(years);
                        account.InterestRate = interest;
                    break;
                default:

                    break;
            }
            return account;
        }

       

        public enum AccountsType
        {
            Checking = 1,
            Business = 2,
            Loan = 3,
            Term_Deposit = 4
        }

        private decimal GetLoanPrompt()
        {
            decimal amount=0;
            bool exit = false;
            while (amount <= 0 && !exit)
            {
                Console.Write("Please enter the loan amount (Exit enter -1)$");
                string str = Console.ReadLine();
                if (!decimal.TryParse(str, out amount))
                {
                    Console.WriteLine($"Error: [{str}] is not a number");
                }
                else
                {
                    if (amount == -1)
                        exit = true;
                    if (amount <= 0)
                        Console.WriteLine("Error: Loan amount must postive or greater than 0");
                }
            }
           // Console.WriteLine("Decimal="+amount);
            return amount;
        }

        private int MaturityYears()
        {
            int years = 0;
            bool exit = false;
            while (years <= 0 && !exit)
            {
                Console.Write("Please enter years of maturity on Term Deposit Account(Exit enter -1): ");
                string str = Console.ReadLine();
                if (!int.TryParse(str, out years))
                {
                    Console.WriteLine($"Error: [{str}] is not a number");
                }
                else
                {
                    if (years == -1)
                        exit = true;
                    else if (years <= 0)
                        Console.WriteLine("Error: Years amount must postive and greater than 0");
                }
            }
          //  Console.WriteLine("Decimal=" + years);
            return years;
      
        }

    }
}
