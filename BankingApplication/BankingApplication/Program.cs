using System;
using System.Collections.Generic;

namespace BankingApplication
{
    class Program
    {
        static int HomeScreen()
        {
            Console.WriteLine("\n--Welcome To Banking Application--");
            int option = 0;
            do
            {
                Console.WriteLine("Choose one of the following options");
                Console.WriteLine("1) New user please register");
                Console.WriteLine("2) Already have an account please login");
                Console.WriteLine("3) Exit Application");
                Console.Write("Enter Option: ");
                string str = Console.ReadLine();
                if (!int.TryParse(str, out option))
                {
                    Console.WriteLine($"Error: [{str}] is not a option");
                }

                Console.WriteLine();
            } while (option < 1 || option > 3);
            return option;
        }

        static void RegistrationScreen()
        {
            string myDateFormat = "MM/dd/yyyy";
            DateTime userBirthday;
            string userName;
            string firstName;
            string lastName;
            string password;
            string address;
            bool successRegistration = false;
            do
            {
                Console.WriteLine("\t*-------------Register-------------*");
                Console.WriteLine("Please Fill Out Registraion Screen (To exit Register Screen Enter:-1 ):");
                Console.Write("Enter First Name: ");
                firstName = Console.ReadLine();
                if (firstName.Equals("-1")) break;
                Console.Write("Enter Last Name: ");
                lastName = Console.ReadLine();
                if (lastName.Equals("-1")) break;
                Console.Write("Enter your Address: ");
                address = Console.ReadLine();
                if (address.Equals("-1")) break;
                Console.Write("Enter a Username: ");
                userName = Console.ReadLine();
                if (userName.Equals("-1")) break;
                Console.Write("Enter a Password: ");
                password = Console.ReadLine();
                if (password.Equals("-1")) break;
                Console.Write("Enter your Birth Date in the format {0} (example : {1}) : ", myDateFormat, DateTime.Today.ToString(myDateFormat));
                if (!DateTime.TryParseExact(Console.ReadLine(), myDateFormat, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out userBirthday))
                {
                    Console.WriteLine("Wrongly formated input");
                }
                else if (UserLoginRegistration.RegisterUser(new Users(firstName,lastName,userBirthday,userName,password,address)))
                {
                    successRegistration = true;
                }
            } while (!successRegistration);
        }

        static Users LoginScreen()
        {
            string userName;
            string password;
            bool loginSuccess = false;
            Users storedUser = null;
            do
            {
                Console.WriteLine("\t*-------------Login-------------*");
                Console.WriteLine("Enter Login information below (To exit Login Screen Enter:-1)");
                Console.Write("Enter Username: ");
                userName = Console.ReadLine();
                if (userName.Equals("-1")) break;
                Console.Write("Enter Password: ");
                password = Console.ReadLine();
                if (password.Equals("-1")) break;

                storedUser = UserLoginRegistration.LoginUser(userName, password);
                if(storedUser != null)
                {
                    loginSuccess = true;
                }

            } while (!loginSuccess);
            return storedUser;
        }

        static void UserScreen(Users user)
        {
            int option = 0;
            do
            {
                Console.WriteLine("\t*-------------User Options-------------*");
                Console.WriteLine("Choose one of the following options");
                Console.WriteLine("1) Check User Information");
                Console.WriteLine("2) List All Accounts");
                Console.WriteLine("3) Create Account");
                Console.WriteLine("4) Account Actions");
                Console.WriteLine("0) Log Out ");
                Console.Write("Enter Option: ");
                string str = Console.ReadLine();
                if (!int.TryParse(str, out option))
                {
                    Console.WriteLine($"Error: [{str}] is not a option");
                }
                else if (option == 1)
                {
                    Users.PrintUser(user);
                }
                else if (option == 2)
                {
                    UserAccounts.ListAccounts(user.Username, user.Password);
                }
                else if (option == 3)
                {
                    Account newAccount = AccountCreationMenu();
                    if(newAccount != null)
                    {
                        UserAccounts.AddAccount(newAccount, user.Username, user.Password);
                        Console.WriteLine("[Succesfully Created Account !!!]");
                    }

                }
                else if (option == 4)
                {
                    List<Account> list = UserAccounts.GetListAccounts(user.Username, user.Password);
                    if (list != null)
                        ActionMenu(list);
                }
                else if (option == 0)
                    break;
                Console.WriteLine();
            } while (true);
        }

        static void ActionMenu(List<Account> list)
        {
            int optionCount = list.Count;
            Console.WriteLine("Count: =" + optionCount);
            int count = 1;
            int option;
            do
            {
                Console.WriteLine("\t*-------------Account Options-------------*");
                Console.WriteLine("Choose one of the following Accounts to withdraw, desposit, transfer, or view transactions (Enter 0 to go back)");
                foreach (var acct in list)
                {
                    Console.WriteLine($"{count}) {acct.ToString()}");
                    count++;
                }
                Console.Write("Choose Account: ");
                string str = Console.ReadLine();
                count = 1;
                if (!int.TryParse(str, out option))
                {
                    Console.WriteLine($"Error: [{str}] is not a option");
                }
                else if(option == 0)
                {
                    break; //brake out of loop to go back to user menu
                }
                else if(option < 1 || option > optionCount)
                {
                    Console.WriteLine($"Error: {option} is not an option");
                }
                else
                {
                    int opt;
                    Account acct = list[option - 1];
                    do
                    {

                        Console.WriteLine("\t*-------------Action Options-------------*");
                        Console.WriteLine("Choose one of the following options");
                        Console.WriteLine("1) Withdraw From Account");
                        Console.WriteLine("2) Deposit Into Account");
                        Console.WriteLine("3) Transfer Between Account");
                        Console.WriteLine("4) Close Account");
                        Console.WriteLine("5) View Account Transaction History");
                        Console.WriteLine("0) Go Back");
                        Console.Write("Enter Option: ");
                        string st = Console.ReadLine();
                        if (!int.TryParse(st, out opt))
                        {
                            Console.WriteLine($"Error: [{st}] is not a option");
                        }
                        else if (opt == 0)
                            break;
                        else if (opt < 1 || opt > 5)
                        {
                            Console.WriteLine($"Error: {opt} is not an option");
                        }
                        else
                        {
                            switch (opt)
                            {
                                case 1:
                                    decimal amount = 0;
                                    Console.Write("Enter a Withdraw Amount: ");
                                    string amt = Console.ReadLine();
                                    if (!decimal.TryParse(amt, out amount))
                                    {
                                        Console.WriteLine($"Error: [{amt}] is not a number");
                                    } 
                                    else if (acct.Withdraw(amount))
                                    {
                                        Console.WriteLine("[Withdraw was Successful]");
                                        Console.WriteLine(acct.ToString());
                                    }
                                    break;
                                case 2:
                                    decimal amount2 = 0;
                                    Console.Write("Enter a Deposit Amount: ");
                                    string amt2 = Console.ReadLine();
                                    if (!decimal.TryParse(amt2, out amount2))
                                    {
                                        Console.WriteLine($"Error: [{amt2}] is not a number");
                                    }
                                    else if (acct.Deposit(amount2))
                                    {
                                        Console.WriteLine("[Deposit was Successful]");
                                        Console.WriteLine(acct.ToString());
                                    }
                                    break;
                                case 3:
                                    if(list.Count == 1)
                                    {
                                        Console.WriteLine("Error: Cannot transfer with only one account");
                                    }
                                    else
                                    {
                                        Account destAcct = GetAccount(list, acct);
                                        decimal amount3 = 0;
                                        if(destAcct != null)
                                        {
                                            Console.Write("Enter a Transfer Amount: ");
                                            string amt3 = Console.ReadLine();
                                            if (!decimal.TryParse(amt3, out amount3))
                                            {
                                                Console.WriteLine($"Error: [{amt3}] is not a number");
                                            }
                                            else 
                                            {
                                                acct.TransferBetweenAccounts(destAcct, amount3);
                                                //Console.WriteLine("[Transfer was Successful]");
                                                Console.WriteLine(acct.ToString());
                                            }
                                        }
                                    }
                                    break;
                                case 4:
                                    acct.CloseAccount();
                                    break;
                                case 5:
                                    PrintTransaction(acct.accountTransactions);
                                    break;
                                default:
                                    break;
                            }
                           // Console.WriteLine("GOT TO ACTions");
                        }

                    } while (true);
                }
               
            } while (true);
            
        }

        static Account GetAccount(List<Account> list, Account currAccount)
        {
            Account act =null;
            int optionCount = list.Count;
            Console.WriteLine("Count: =" + optionCount);
            int count = 1;
            int option;
            int index = 0;
            do
            {
                Console.WriteLine("\t*-------------Choose Transfer Account-------------*");
                Console.WriteLine("Choose one of the following Accounts to transfer funds too (Enter 0 to go back):");
                foreach (var acct in list)
                {
                    if (!currAccount.Equals(acct))
                    {
                        Console.WriteLine($"{count}) {acct.ToString()}");
                        count++;
                    }
                    else 
                    {
                        Console.WriteLine($"**[{count}) {acct.ToString()}]**");
                        index = count;
                        count++;
                    }

                }
                Console.Write("Choose Account: ");
                string str = Console.ReadLine();
                count = 1;
                if (!int.TryParse(str, out option))
                {
                    Console.WriteLine($"Error: [{str}] is not a option");
                }
                else if (option == 0)
                {
                    break; //brake out of loop to go back to Action Menu
                }
                else if (option < 1 || option > optionCount)
                {
                    Console.WriteLine($"Error: {option} is not an option");
                }
                else if(option == index)
                {
                    Console.WriteLine($"Error: Cannot transfer to same account, choose a different one");
                }
                else
                {
                    act = list[option - 1];
                    //Console.WriteLine("Option" + (option-1));
                    break;
                }
            } while (true);
            return act;
        }

        static void PrintTransaction(List<Transaction> list)
        {
            if (list.Count == 0)
            {
                Console.WriteLine("[No Transaction History]");
            }
            else
            {
                Console.WriteLine("------------------------------------------------");
                Console.WriteLine(String.Format("|{0,16}|{1,10}|{2,15}|", "Type Transaction", "Amount", "Date of Transaction".PadLeft(10)));
                Console.WriteLine("------------------------------------------------");
                foreach (var transac in list)
                {
                    Console.WriteLine(transac);
                    Console.WriteLine("------------------------------------------------");

                }
            }
        }

        static Account AccountCreationMenu()
        {
            AccountFactory acctFactory = new AccountFactory();
            int opt;
            do
            {
                Console.WriteLine("\t*-------------Create Account Menu-------------*");

                Console.WriteLine("Choose an account type to create: ");
                Console.WriteLine("1) Checking Account");
                Console.WriteLine("2) Businness Account");
                Console.WriteLine("3) Loan Account");
                Console.WriteLine("4) Term Deposit Account");
                Console.WriteLine("0) Go Back");
                Console.Write("Enter Option: ");
                string st = Console.ReadLine();
                if (!int.TryParse(st, out opt))
                {
                    Console.WriteLine($"Error: [{st}] is not a option");
                }
                else if (opt == 0)
                    break;
                else if (opt < 1 || opt > 4)
                {
                    Console.WriteLine($"Error: {opt} is not an option");
                }
                else
                {
                    //Console.WriteLine("INSIDE CREATE");
                    Console.WriteLine((AccountFactory.AccountsType)opt);
                    Account createdAccount = acctFactory.CreateAccount((AccountFactory.AccountsType)opt);
                    return createdAccount;
                }
            } while (true);
            return null;
        }

        static void Main(string[] args)
        {


            int mainOption;
            do //main application loop
            {
                mainOption = HomeScreen();
                
                if(mainOption == 1)
                {
                    RegistrationScreen();
                    //UserLoginRegistration.printAllAccounts();
                }
                else if(mainOption == 2)
                {
                    Users user = LoginScreen();
                    if(user == null) // failed login, let user try again
                    {
                        continue;
                    }

                    UserScreen(user);
                }

                if (mainOption == 3)
                {
                    Console.WriteLine("\n[Thank you for using our application!!]");
                }
            } while (mainOption != 3);

            


        }
    }
}
