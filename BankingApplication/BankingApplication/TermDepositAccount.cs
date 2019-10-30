using System;
using System.Collections.Generic;
using System.Text;

namespace BankingApplication
{
    class TermDepositAccount : Account
    {
        private readonly DateTime maturityDate;
        private bool depositedFlag = false; //setup flag
        //public TermDepositAccount (int year, int month, int day) : base() //define a specific date for maturity
        //{
        //    AccountName = "Term Deposit Account";
        //    maturityDate = new DateTime(year,month,day);
        //}

        public TermDepositAccount(int years) : base() //define how many years from current date you want maturity date to end
        {
            DateTime predictedTime = DateTime.Today.AddYears(years);
            AccountName = "Term Deposit Account";
            maturityDate = predictedTime;
        }
        public override void CloseAccount()
        {
            if (!reachedMaturity(DateTime.Today))
            {
                Console.WriteLine($"Attention: Cannot close {AccountNumber}, before Maturity Date: {maturityDate.ToString("yyyy/MM/dd")}");
                return;
            }
            else if (!IsBalanceEmpty())
            {
                Console.WriteLine($"Attention: Before Closing {AccountNumber}, you must Withdraw all the funds.");
                return;
            }
            
            base.CloseAccount();
        }

        public override bool Deposit(decimal depositAmount)
        {
            if(!depositedFlag || Balance == 0) //Deposited is false or if balance is 0 then we can deposit 
            {
                return (base.Deposit(depositAmount)) ? depositedFlag = true: depositedFlag = false ; //if deposit was successful change deposit flag or else keep it false
            }
            Console.WriteLine($"Error: You cannot deposit into a {AccountName}: {AccountNumber}");
            return false;
        }

        public override bool Withdraw(decimal withdrawAmount)
        {
            if (reachedMaturity(DateTime.Today)) //passed all the withdraw checking and also passes the maturity check
            {
                return base.Withdraw(withdrawAmount);
            }    
           
            Console.WriteLine($"Error: Cannot Withdraw or Transfer from {AccountName} maturity date: {maturityDate.ToString("yyyy/MM/dd")} -> today: {DateTime.Today.ToString("yyyy/MM/dd")}");
            return false;
        }

        public bool Withdraw(decimal withdrawAmount, DateTime date)
        {
            if (reachedMaturity(date)) //passed all the withdraw checking and also passes the maturity check
            {
                return base.Withdraw(withdrawAmount);
            }
            Console.WriteLine($"Error: Cannot Withdraw or Transfer from {AccountName} maturity date: {maturityDate.ToString("yyyy/MM/dd")} -> today: {date.ToString("yyyy/MM/dd")}");
            return false;
        }

        public override void TransferBetweenAccounts(Account acctDest, decimal amount)
        {
            base.TransferBetweenAccounts(acctDest, amount);
        }

        private bool reachedMaturity(DateTime dateCreated)
        {
            //int value = DateTime.Compare(maturityDate, DateTime.Today); //check maturity date stored with current date
            int value = DateTime.Compare(maturityDate, dateCreated); //Testing
            
            // checking 
            if (value > 0)
            {
                //Console.WriteLine("maturity date is later than date2. " + value);
                return false; //maturity date is later than dateCreated
            }
            else if (value < 0 || value == 0)
            {
                //Console.WriteLine("maturity date/day is earlier than date2. "+value);
                return true; // maturity date is ealier or on the day than dateCreated
            }

            return false;

        }
    }
}
