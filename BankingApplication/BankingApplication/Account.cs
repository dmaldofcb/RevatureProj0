﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BankingApplication
{
    abstract class Account
    {
        private decimal balance;
        private readonly string accountNumber;
        private string accountName;
        private bool isOpen;
        private decimal interestRate;
        protected readonly DateTime dateCreated;
        protected static readonly Random getrandom = new Random();

        public List<Transaction> accountTransactions = new List<Transaction>();

        protected decimal Balance{ get => balance; set => balance = value; }
        protected string AccountNumber { get => accountNumber; }
        protected string AccountName { get => accountName; set => accountName = value; }
        protected bool IsOpen { get => isOpen; set => isOpen = value; }
        public virtual decimal InterestRate { get => interestRate; 
            set {
                    if (value <= 0.0M)
                    {
                        Console.WriteLine("Interest Rate must be higher than 0.");
                        return;
                    }
                   interestRate = value/100;
                }
        
        }

        protected Account()
        {
            accountNumber = randomAccountNumber();
            IsOpen = true;
            dateCreated = DateTime.Today;
        }

        public virtual bool Withdraw(decimal withdrawAmount)
        {
            if (!IsOpen)
            {
                Console.WriteLine($"Error: That {AccountName} is now Closed !!!");
                return false;
            }
            else if (withdrawAmount <= 0 || withdrawAmount > Balance)
            {
                Console.WriteLine($"Error: insufficient funds to complete transaction, withdraw={withdrawAmount:c} balance={Balance:c}");
                return false;
            }
      
            Balance -= withdrawAmount;

            accountTransactions.Add(new Transaction("Withdraw",withdrawAmount*-1,DateTime.Today));
            return true;
        }

        public virtual bool Deposit(decimal depositAmount)
        {
            if (!IsOpen)
            {
                Console.WriteLine($"Error: That {AccountName} is now Closed !!!");
                return false;
            }
            else if (depositAmount <= 0)
            {
                Console.WriteLine("Error: deposit amount must be positve");
                return false;
            }
            Balance += depositAmount;
            accountTransactions.Add(new Transaction("Deposit", depositAmount, DateTime.Today));

            return true;
        }

        public virtual void CloseAccount()
        {
       
            IsOpen = false;
            Console.WriteLine("Succesfully Closed Account !!!");

        }

        public virtual void CalculateSimpleInterest(int time) // time must be in years 
        {
            //Simple interest is calculated on the principal, or original, amount of a loan/Balance.
            //A = P(1 + rt)
            decimal totalAmount = Balance * (1 + InterestRate*time);
            Console.WriteLine($"Calculated Simple Interest for {AccountName} Current Balance={Balance:c}");
            Console.WriteLine($"Total Principal Balance={totalAmount:c} after {time} years with interest of {InterestRate:p}");
        }

        public virtual void TransferBetweenAccounts(Account acctDest, decimal amount)
        {
            if (this.Withdraw(amount))
            {
                if (acctDest.Deposit(amount))
                {
                    Transaction last = accountTransactions[accountTransactions.Count-1];
                    last.TransactionType = "Transfer";
                    accountTransactions[accountTransactions.Count - 1] = last;
                    Console.WriteLine($"Succesfully Transferred {amount:c} from {this.AccountName.ToUpper()}:{this.AccountNumber} --> {acctDest.AccountName.ToUpper()}:{acctDest.AccountNumber}");
                }
                return;
            }
            Console.WriteLine("Error: Failed to Complete Transfer");
        }

        //public virtual void TransferBetweenAccounts(LoanAccount acctDest, decimal amount)
        //{
        //    Console.WriteLine("Error: You cannot transfer money into a " + acctDest.AccountName);
        //}

        public void printAccountInfo()
        {
            Console.WriteLine("Account Type: "+ AccountName);
            Console.WriteLine("Account Number: "+ accountNumber);
            Console.WriteLine($"Balance: { Balance :c} ");
            Console.WriteLine($"Interest Rate: {InterestRate:p}");
            Console.WriteLine("Date Account Created: " + dateCreated.ToString());
        }

        protected bool IsBalanceEmpty()
        {
            if(Balance > 0)
            {
                return false;
            }
            return true;
        }
        private string randomAccountNumber()
        {
            string acct ="";
             for (int ctr = 0; ctr <= 9; ctr++)
                acct += getrandom.Next(9).ToString();
            return acct;
        }
    }
}
