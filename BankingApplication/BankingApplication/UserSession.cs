using System;
using System.Collections.Generic;
using System.Text;

namespace BankingApplication
{
    class UserSession
    {
        private string userName;
        private string password;

        public string UserName { get => userName; set => userName = value; }
        public string Password { get => password; set => password = value; }

        public void RetrieveAccounts()
        {

        }
    }
}
