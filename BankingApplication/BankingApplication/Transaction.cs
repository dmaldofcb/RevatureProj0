using System;
using System.Collections.Generic;
using System.Text;

namespace BankingApplication
{
    class Transaction
    {
        private string transactionType;
        private decimal amount;
        private DateTime dateTransaction;
        //private string description = "Default Description";

        public string TransactionType { get => transactionType; set => transactionType = value; }
        public decimal Amount { get => amount; set => amount = value; }
        public DateTime DateTransaction { get => dateTransaction; set => dateTransaction = value; }
        //public string Description { get => description; set => description = value; }

        public Transaction(string transactionType, decimal amount, DateTime dateTransaction)
        {
            TransactionType = transactionType;
            Amount = amount;
            DateTransaction = dateTransaction;
            //Description = description;
        }

        public override string ToString()
        {
            string str = String.Format("|{0,-16}|{1,-10}|{2,-10}|", TransactionType, Amount.ToString("c"), DateTransaction.ToString("MM/dd/yyyy - H:mm:ss"));
            return str;
        }
    }
}
