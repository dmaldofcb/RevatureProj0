using System;
using System.Collections.Generic;
using System.Text;

namespace BankingApplication
{
    class LoanAccount : Account
    {


        public LoanAccount(decimal loanAmount) : base()
        {
            AccountName = "Loan Account";
            Balance = loanAmount;
        }
        public override void CloseAccount()
        {
            if (!IsBalanceEmpty())
            {
                Console.WriteLine($"Sorry Cannot close a {AccountName} that still has balance={Balance:c} owed.");
                return;
            }
            base.CloseAccount();

        }

        public override bool Deposit(decimal depositAmount)
        {
            if (!IsOpen)
            {
                Console.WriteLine($"Error: That {AccountName} is now Closed !!!");
                return false;
            }
            else if (depositAmount <= 0)
            {
                Console.WriteLine("Error: payment amount must be positve");
                return false;
            }
            else if (depositAmount > Balance)
            {
                Console.WriteLine($"Error: payment is more the Loan owed {Balance:c} Payment={depositAmount:c}");
                return false;
            }
            accountTransactions.Add(new Transaction("Payment", depositAmount, DateTime.Today)); //adding payment

            Balance -= depositAmount;
            return true;
        }

        public override bool Withdraw(decimal withdrawAmount)
        {
            Console.WriteLine("Error: Cannot Withdraw from " + AccountName);
            return false;
        }

        public override void TransferBetweenAccounts(Account acctDest, decimal amount)
        {
            Console.WriteLine("Error: you cannot transfer money out of a "+AccountName);
        }

       

       

    }
}
