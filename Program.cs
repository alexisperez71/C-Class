// Name: Alexis Perez
// CS3260 Section X02
// Project: Lab_02
// Date: 09/02/2018 12:44:44 PM
// Purpose: Creating a bank program
//
// I declare that the following code was written by me or provided
// by the instructor for this project. I understand that copying source
// code from any other source constitutes plagiarism, and that I will receive
// a zero on this project if I am found in violation of this policy.
// -----------------------------------------------------------------------

namespace ConsoleApp1;

using System;

public class Program
{
    public static void Main(string[] args)
    {
        // Variable that holds 100 dashes
        var dashes = new string('-', 100);
        
        // These variables are used to store input from the console
        int userInput;
        string name = "";
        string address = "";
        string status;
        decimal balance = 0;
        var accountStatus = Account.AccountState.New;
        var accountType = Account.AccountType.Null;
        Account bankProgram = null;

        // These variables are used as flags for my while loops below.
        var validAccountType = false;
        var validName = false;
        var validAddress = false;
        var validBalance = false;
        var validWithdrawal = false;
        var validDeposit = false;
        var validAccountStatus = false;

        var accountDb = new MultiAccounts();
        
        // Starts the account creation process. The dashes variable is for formatting.
        Console.WriteLine($"{dashes} \nWelcome To My Banking Program \n{dashes}");
        Console.WriteLine($"Lets Begin With Creating Your Account \n{dashes}");

        while (validAccountType is false)
        {
            string type;
            Console.WriteLine("Enter the state of the account from the options below: ");
            Console.WriteLine("- Checking \n- Savings \n- Cd");
            type = Console.ReadLine().Replace(" ", string.Empty);
            if (!int.TryParse(type, out _) && Enum.TryParse(type, out accountType))
            {
                Console.WriteLine(dashes);
                Console.WriteLine($"Thank you! We will be creating a {accountType} account for you.");
                validAccountType = true;
            }
            else
            {
                Console.WriteLine("Error! Please only enter an account type from the choices given!");
            }
            
        }
        
        while (validName is false)
        {
            Console.Write("Enter Your Name: ");
            name = Console.ReadLine();
            if (string.IsNullOrEmpty(name) || int.TryParse(name, out _))
            {
                Console.WriteLine("Error! Please enter a name without any digits or special characters!");
            }
            else
            {
                validName = true;    
            }
        }

        while (validAddress is false)
        {
            Console.Write("Enter Your Address: ");
            address = Console.ReadLine();
            if (string.IsNullOrEmpty((address)))
            {
                Console.WriteLine("Error! Address cannot be blank!");
            }
            else
            {
                validAddress = true;
            }
        }

        while (validAccountStatus is false)
        {
            Console.WriteLine("Enter the state of the account from the options below: ");
            Console.WriteLine("- New \n- Active \n- Under Audit \n- Frozen \n- Closed");
            status = Console.ReadLine().Replace(" ", string.Empty);

            if (!int.TryParse(status, out _) && Enum.TryParse(status, out accountStatus))
            {
                Console.WriteLine($"Success! Your account status has been set as : {accountStatus}");
                validAccountStatus = true;
            }
            else
            {
                Console.WriteLine("Error! The account status must be one of the options given!");
            }
        }
        
        while (validBalance is false)
        {
            Console.Write("Set your balance: ");
            try
            {
                balance = Convert.ToDecimal(Console.ReadLine());
                if (accountType == Account.AccountType.Checking && balance >= 10)
                {
                    validBalance = true;
                }
                else if (accountType == Account.AccountType.Savings && balance >= 100)
                {
                    validBalance = true;
                }
                else if (accountType == Account.AccountType.Cd && balance >= 500)
                {
                    validBalance = true;
                }
                else
                {
                    Console.WriteLine("Error! Balance must be set to $10 or more");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Error! Balance must be an integer!");
            }
            
        }

        // Validating that the account number upon creation is valid
        // while (validAccountNumber is false)
        // {
        //     Console.WriteLine("Enter your account number:");
        //     try
        //     {
        //         var accountNumber = Convert.ToInt32(Console.ReadLine());
        //         if (bankProgram.SetAccountNumber(accountNumber))
        //         {
        //             validAccountNumber = true;
        //         }
        //         else
        //         {
        //             Console.WriteLine("Error! Account Number must be a positive number!");
        //         }
        //         
        //     }
        //     catch (System.FormatException)
        //     {
        //         Console.WriteLine("Error! Account number must contain only numbers!");
        //     }
        // }

        if (accountType == Account.AccountType.Checking)
        {
            bankProgram = new CheckingAccount(name, address, balance, accountStatus);
            accountDb.StoreAccount(bankProgram);
        }
        else if (accountType == Account.AccountType.Savings)
        {
            bankProgram = new SavingsAccount(name, address, balance, accountStatus);
            accountDb.StoreAccount(bankProgram);
            
        }
        else if (accountType == Account.AccountType.Cd)
        {
            bankProgram = new CdAccount(name, address, balance, accountStatus);
            accountDb.StoreAccount(bankProgram);
        }

        
        
        Console.WriteLine($"{dashes}\nThank you! Your account has been created :)");
        Console.WriteLine($"{dashes} \nAccount Details: \nAccount Type: {accountType} \nName: {bankProgram.GetName()} \nAddress: {bankProgram.GetAddress()}");
        Console.WriteLine($"Initial balance: {bankProgram.GetBalance()} \nAccount Number: {bankProgram.GetAccountNumber()}");
        Console.WriteLine($"Account Status: {bankProgram.GetAccountState()}");

        do
        {
            // Begin menu for the bank application.
            Console.WriteLine(dashes);
            Console.WriteLine("Welcome To My Banking Program".PadLeft(60));
            
            // Adding padding to center the message.
            Console.WriteLine(dashes);
            Console.WriteLine($"Please enter the number that corresponds to the action you would like to complete\n{dashes}");
        
            // Displaying the options
            Console.WriteLine("Change Account Name: 1 \nDisplay Account Details: 2 \nChange Address: 3");
            Console.WriteLine("Withdraw Funds: 4 \nDeposit Funds: 5 \nChange Account Status: 6");
            Console.WriteLine("Add Account: 7 \nSearch Account: 8  \nQuit: 0");
            // Console.WriteLine("Change Account Name: 1 \nDisplay Account Name: 2 \nChange Address: 3 \nDisplay Address: 4");
            // Console.WriteLine("Display Balance: 5 \nWithdraw Funds: 6 \nDeposit Funds: 7 \nDisplay Account Status: 8");
            // Console.WriteLine("Change Account Status: 9 \nQuit: 0");
            
            // Converting the user selection to an input to work for the switch statement.
            userInput = Convert.ToInt32(Console.ReadLine());

            switch (userInput)
            {
                case 0:
                    Console.WriteLine($"{dashes} \nThis program is now ending, Goodbye!");
                    break;
                case 1:
                    validName = false;
                    while (validName is false)
                    {
                        Console.WriteLine($"{dashes} \nEnter the new name of the account:");
                        name = Console.ReadLine();
                        if (bankProgram.SetName(name))
                        {
                            validName = true;
                            Console.WriteLine($"{dashes} \nSuccess! The new name on the account is {bankProgram.GetName()}");
                        }
                        else
                        {
                            Console.WriteLine($"{dashes} \nError! Please enter a name without any digits or special characters!");
                        }
                    }
                    break;
                case 2:
                    // Console.WriteLine($"{dashes} \nThe name of the account holder is: {bankProgram.GetName()}");
                    Console.WriteLine($"{dashes} \n{bankProgram.GetName().PadLeft(50)}'s Account Details \n{dashes}");
                    Console.WriteLine($"Account Type: {bankProgram.GetAccountType()} \nAccount Number: {bankProgram.GetAccountNumber()}");
                    Console.WriteLine($"Name: {bankProgram.GetName()} \nAddress: {bankProgram.GetAddress()}");
                    Console.WriteLine($"Balance: {bankProgram.GetBalance()} \nAccount State: {bankProgram.GetAccountState()}");
                    break;
                case 3:
                    validAddress = false;
                    while (validAddress is false)
                    {
                        Console.WriteLine($"{dashes} \nEnter your new address:");
                        address = Console.ReadLine();
                        if (bankProgram.SetAddress(address))
                        {
                            validAddress = true;
                            Console.WriteLine($"{dashes} \nSuccess! Your new address is: {bankProgram.GetAddress()}");
                        }
                        else
                        {
                            Console.WriteLine($"{dashes} \nError! Address cannot be blank!");
                        }
                    }
                    break;
                // case 4:
                //     Console.WriteLine($"{dashes} \nYour address is: {bankProgram.GetAddress()}");
                //     break;
                // case 5:
                //     Console.WriteLine($"{dashes} \nYour balance is ${bankProgram.GetBalance()}");
                //     break;
                case 4:
                    validWithdrawal = false;
                    while (validWithdrawal is false)
                    {
                        try
                        {
                            Console.WriteLine("How much would you like to withdraw?");
                            var withdrawalAmount = Convert.ToDecimal(Console.ReadLine());
                            if (bankProgram.WithdrawFunds(withdrawalAmount))
                            {
                                Console.WriteLine($"{dashes} \nSuccess! You have withdrawn: ${withdrawalAmount} \nYour account balance is now ${bankProgram.GetBalance()}");
                                validWithdrawal = true;
                            }
                            else
                            {
                                Console.WriteLine($"{dashes} \nError! Withdrawal must be a positive number and cannot exceed your current balance!");
                            }
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine($"{dashes} \nError! Withdrawal amount must be a positive number!");
                        }

                    }
                    break;
                case 5:
                    while (validDeposit is false)
                    {
                        Console.WriteLine($"{dashes} \nEnter your deposit amount: ");
                        try
                        {
                            var depositAmount = Convert.ToDecimal(Console.ReadLine());
                            if (depositAmount > 0)
                            {
                                bankProgram.PayInFunds(depositAmount);
                                Console.WriteLine($"{dashes} \nSuccess you have deposited: ${depositAmount} \nYour new account balance is ${bankProgram.GetBalance()}");
                                validDeposit = true;
                            }
                            else
                            {
                                Console.WriteLine($"{dashes} \nDeposit cannot be a negative number!");
                            }
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine($"{dashes} \nError! Deposit amount must be a positive number!");
                        }

                    }

                    validDeposit = false;
                    break;
                    
                // case 8:
                //     Console.WriteLine($"{dashes} \nYour account status is: {bankProgram.GetAccountState()}");
                //     break;
                
                case 6:
                    validAccountStatus = false;
                    while (validAccountStatus is false)
                    {
                        Console.WriteLine("Enter the new state of you account, choose from the options below: ");
                        Console.WriteLine("- New \n- Active \n- Under Audit \n- Frozen \n- Closed");
                        status = Console.ReadLine().Replace(" ", string.Empty);

                        if (!int.TryParse(status, out _) && Enum.TryParse(status, out accountStatus))
                        {
                            Console.WriteLine($"{dashes} \nSuccess! Your account status has been set as : {accountStatus}");
                            bankProgram.SetAccountState(accountStatus);
                            validAccountStatus = true;
                        }
                        else
                        {
                            Console.WriteLine($"{dashes} \nError! The account status must be one of the options given!");
                        }
                    }

                    break;
                
                case 8:
                    var searchFlag = false;
                    while (searchFlag is false)
                    {
                        Console.Write("Please enter the name of the account you are looking for: ");
                        var tempAccount = accountDb.FindAccount(Console.ReadLine());
                        if (tempAccount == null)
                        {
                            Console.WriteLine("Error! Account was not found! \nTip: Input is case sensitive!");
                        }
                        else
                        {
                            Console.WriteLine($"{dashes} \n{tempAccount.GetName().PadLeft(50)}'s Account Details \n{dashes}");
                            Console.WriteLine($"Account Type: {tempAccount.GetAccountType()} \nAccount Number: {tempAccount.GetAccountNumber()}");
                            Console.WriteLine($"Name: {tempAccount.GetName()} \nAddress: {tempAccount.GetAddress()}");
                            Console.WriteLine($"Balance: {tempAccount.GetBalance()} \nAccount State: {tempAccount.GetAccountState()}");
                            searchFlag = true;
                        }
                    }

                    break;

                default:
                    Console.WriteLine($"{dashes} \nError! Please only enter a number from the menu!");
                    break;
            }
            
        } while (userInput != 0);
        
    }
}