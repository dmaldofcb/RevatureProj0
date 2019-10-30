using System;
using System.Collections.Generic;
using System.Text;

namespace BankingApplication
{
    class BusinessAccount : Account
    {
        private decimal overdraft;

        public decimal Overdraft { get => overdraft; set => overdraft = value; }

        public BusinessAccount() : base()
        {
            AccountName = "Business Account";
        }

        public override bool Deposit(decimal depositAmount)
        {
            bool depositSuccess = base.Deposit(depositAmount); 
            if (depositSuccess)
            {
             //   Console.WriteLine("INSIDE BUSSINESS ACCOUNT DEPOSIT");
                if (Balance >= 0 && Overdraft > 0) //Check if the deposit completely payed the overdraft and the overdraft is not reset
                    Overdraft = 0; //reset the overdraft value
                else if (Balance < 0 && Overdraft > 0) //Overdraft was not completely payed, but we have to decrease the overdraft total
                    Overdraft = Balance*-1;
                return true;
            }
           // Console.WriteLine("Ouside BUSSINESS ACCOUNT DEPOSIT");

            return false;
        }

        public override bool Withdraw(decimal withdrawAmount)
        {
            if (!IsOpen)
            {
                Console.WriteLine($"Error: That {AccountName} is now Closed !!!");
                return false;
            }
            else if (withdrawAmount <= 0)
            {
                Console.WriteLine($"Error: You cannot withdraw {withdrawAmount}");
                return false;
            }
            else if (withdrawAmount > Balance)
            {
                decimal currOverDraft;
                if (Balance >= 0) //overdraft the first time
                {
                    currOverDraft = withdrawAmount - Balance;
                    Overdraft = currOverDraft; //Initialize Overdraft amount for first time you overdraft
                    CalculateOverdraftInterest(currOverDraft);
                    accountTransactions.Add(new Transaction("Withdraw", Balance * -1, DateTime.Today)); //also add to transaction the withdraw of all the balance

                }
                else //Account in negative already and user overdrafts again
                {
                    currOverDraft = withdrawAmount;
                    Overdraft += currOverDraft; //No funds so total withdraw is the ovedraft  
                    CalculateOverdraftInterest(currOverDraft);
                }
                Console.WriteLine($"**An overdraft of {currOverDraft:c} was charged**");
                accountTransactions.Add(new Transaction("Overdraft",currOverDraft*-1,DateTime.Today));
                Balance = Overdraft*-1;//display a negative balance 
                return true;
            }
            accountTransactions.Add(new Transaction("Withdraw",withdrawAmount*-1,DateTime.Today)); //adding transaction
            Balance -= withdrawAmount;
            return true;
        }

        public override void TransferBetweenAccounts(Account acctDest, decimal amount)
        {
            if (Balance > 0)
            {
                base.TransferBetweenAccounts(acctDest, amount);
                return;
            }
            Console.WriteLine($"Error: Cannot Transfer, current Balance is Negative Balance={Balance:c}");

        }

        public override void CloseAccount()
        {
            if (!IsBalanceEmpty())
            {
                Console.WriteLine($"Attention: Before Closing {AccountNumber}, you must Withdraw all the funds.");
                return;
            } 
            else if(Balance < 0)
            {
                Console.WriteLine($"Attention: Before closing {AccountNumber}, you must pay the Overdraft Fee={Overdraft:c}");
                return;
            }
            base.CloseAccount();
        }

        private void CalculateOverdraftInterest(decimal overdraftFacility)
        {
            //Not Accurate just to demo overdraft interest
            //Most Banks use formula Interest = A/N * R/P for overdraft facilites: Where A = Amount Overdrawn, N = Number of Days in a billing period
            //R = Annual interest rate, P = Number of periods per year. There can be weekly or daily compounding
            Overdraft += (overdraftFacility * InterestRate);
            Console.WriteLine($"**Overdraft Penalty={overdraftFacility*InterestRate:c}**");
        }

  
        

    }
}
