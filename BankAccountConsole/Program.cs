using System;
using System.Collections.Generic;
using System.Threading;

namespace BankAccountConsole
{
    public class Program
    {
        private static void Main(string[] args)
        {
            //var authService = new AuthService();
            //BankAccount currentUser = null;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("===== Bank System =====");
                Console.WriteLine("1. Log in");
                Console.WriteLine("2. Register");
                Console.WriteLine("3.Exit");
                Console.WriteLine("Choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        try
                        {
                            Console.WriteLine("Enter username: ");
                            string username = Console.ReadLine();
                            Console.WriteLine("Enter password");
                            string password = Console.ReadLine();

                            //currentUser = authService.Login(username, password);
                            Console.WriteLine("Login successful!");
                            Thread.Sleep(1500);
                            //ShowLoggedInMenu(currentUser);
                        }
                        catch (UnauthorizedAccessException ex)
                        {
                            Console.WriteLine($"Login faild: {ex.Message}.");
                            Console.ReadKey();
                        }
                        break;

                    case "2":
                        try
                        {
                            Console.WriteLine("Enter full name: ");
                            string name = Console.ReadLine();

                            Console.WriteLine("Choose a username: ");
                            string username = Console.ReadLine();

                            Console.WriteLine("Create a password: ");
                            string password = Console.ReadLine();
                            Console.WriteLine("Confirm your password: ");
                            string confirmPassword = Console.ReadLine();
                            while (password != confirmPassword)
                            {
                                Console.WriteLine("Password do not match. Try again.  ");

                                Console.WriteLine("Create a password: ");
                                Console.ReadLine();
                                Console.WriteLine("Confirm your password: ");
                                Console.ReadLine();
                            }
                            //var newAccount = authService.Register(name, username, password);
                            //Console.WriteLine($"Account created. You account number is: {newAccount.AccountNumber}");
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine($"Registration faild: {ex.Message}");
                        }
                        Console.ReadKey();
                        break;

                    case "3":
                        Console.WriteLine("Goodbye!");
                        Thread.Sleep(1500);
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        //private static void ShowLoggedInMenu(BankAccount user)
        //{
        //    while (true)
        //    {
        //        Console.Clear();
        //        Console.WriteLine($"=== Welcome, {user.OwnerName}! Account number: {user.AccountNumber} ===");
        //        Console.WriteLine("1. Check  account ballance.");
        //        Console.WriteLine("2. Deposit.");
        //        Console.WriteLine("3. Withdraw.");
        //        Console.WriteLine("4. Transaction history.");
        //        Console.WriteLine("5. Log out.");
        //        Console.Write("Choose an option: ");
        //        string option = Console.ReadLine();

        //        switch (option)
        //        {
        //            case "1":
        //                Console.WriteLine($"Your current balance is: {user.Balance:N2} PLN");
        //                Console.ReadKey();
        //                break;

        //            case "2":
        //                {
        //                    Console.WriteLine("How much would you to deposit?");
        //                    string input = Console.ReadLine();
        //                    decimal amount;

        //                    if (decimal.TryParse(input, out amount))
        //                    {
        //                        try
        //                        {
        //                            //var depositService = new DepositService();
        //                            //depositService.Deposit(user, amount);
        //                            //AccountDataService.SaveAccounts(new List<BankAccount> { user });
        //                            //Console.WriteLine($"Successfully deposited {amount:N2} PLN. New balance: {user.Balance:N2} PLN");
        //                        }
        //                        catch (ArgumentException ex)
        //                        {
        //                            Console.WriteLine($"Deposit faild: {ex.Message}");
        //                        }
        //                    }
        //                    else
        //                    {
        //                        Console.WriteLine("Invalid amount entered.");
        //                    }
        //                    Console.ReadKey();
        //                    break;
        //                }

        //            case "3":
        //                {
        //                    Console.WriteLine("How much would you to withdraw?");
        //                    string input = Console.ReadLine();
        //                    decimal amount;

        //                    if (decimal.TryParse(input, out amount))
        //                    {
        //                        //var depositService = new DepositService();
        //                        try
        //                        {
        //                            //depositService.Withdrawal(user, amount);
        //                            //AccountDataService.SaveAccounts(new List<BankAccount> { user });
        //                            //Console.WriteLine($"Successfully withdrawal {amount:N2} PLN. New balance: {user.Balance:N2} PLN");
        //                        }
        //                        catch (ArgumentException ex)
        //                        {
        //                            Console.WriteLine($"Withdrawal failed: {ex.Message}");
        //                        }
        //                        catch (/*InsufficientFundsException*/ Exception)
        //                        {
        //                            Console.WriteLine("Error: Insufficient funds in the account.");
        //                        }
        //                    }
        //                    else
        //                    {
        //                        Console.WriteLine("Invalid amount entered.");
        //                    }
        //                    break;
        //                }
        //            case "4":
        //                //IEnumerable<Transaction> transactions = user.GetTransactionHistory();
        //                //foreach (var element in transactions)
        //                //{
        //                //    Console.WriteLine($"{element.Date:g} | {element.Type} | {element.Amount:N2} PLN");
        //                //}
        //                //break;

        //            case "5":
        //                Console.WriteLine("===  Thank you for using BankAccountConsole. Goodbye!  === ");
        //                Thread.Sleep(1500);
        //                Environment.Exit(0);
        //                break;
        //        }
        //        Console.ReadKey();
            //}
        //}
    }
}