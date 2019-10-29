using System;
using System.Collections.Generic;
using System.Text;

namespace BankingApplication
{
    class CheckingAccount : Account
    {

        private static decimal INTEREST_RATE = 0.0M;

        public override decimal InterestRate
        {
            get => INTEREST_RATE;
            set
            {
                if (value <= 0.0M)
                {
                    Console.WriteLine("Interest Rate must be higher than 0.");
                    return;
                }
                INTEREST_RATE = value/100;
            }

        }
        public CheckingAccount() : base()
        {
            AccountName = "Checking Account";
            
        }

        public override void TransferBetweenAccounts(Account acctDest, decimal amount)
        {
            base.TransferBetweenAccounts(acctDest, amount);
        }

       


        public override void CloseAccount()
        {
            if (!IsBalanceEmpty())
            {
                Console.WriteLine($"Attention: Before Closing {AccountNumber}, you must Withdraw all the funds.");
                return;
            }
            base.CloseAccount();
        }
    }
}
