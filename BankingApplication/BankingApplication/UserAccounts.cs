using System;
using System.Collections.Generic;
using System.Text;

namespace BankingApplication
{
    static class UserAccounts
    {
        private static Dictionary<(string, string), List<Account> > userAccount = new Dictionary<(string, string), List<Account> >();

        private static bool FindUserAccount(string userName, string password)
        {
            if (userAccount.Count == 0)
            {
                return false;
            }
            else if (userAccount.ContainsKey((userName, password)))
            {
                return true;
            }

            //Console.WriteLine("**Could not find user**");

            return false;
        }

        static public void AddAccount(Account acct, string username, string password)
        {
            if (FindUserAccount(username, password)) //checking if user already has a list of  accounts stored all we do is append to list
            {
                userAccount[(username, password)].Add(acct);

            }
            else //we have to add user to dictionary first then create a list of accounts
            {
                userAccount.Add((username, password), new List<Account>());
                userAccount[(username, password)].Add(acct);

            }
        }

        static public void ListAccounts(string username, string password)
        {
            if(FindUserAccount(username,password))
            { 
                List<Account> listAccount = userAccount[(username, password)];
                foreach (var act in listAccount)
                {
                    act.printAccountInfo();
                }
            }
            else
                Console.WriteLine("[No Accounts to List]");

        }

        static public List<Account> GetListAccounts(string username,string password)
        {
            List<Account> listAccount = null;
            if (FindUserAccount(username, password))
            {
                listAccount = userAccount[(username, password)];
                return listAccount;
            }
            else
                Console.WriteLine("[No Accounts to Retrieve]");
            return listAccount;
        }
    }
}
