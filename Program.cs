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

using System.Text.RegularExpressions;

namespace ConsoleApp1;

using System;

public class Program
{
    public static void Main(string[] args)
    {
        // Variable that holds 100 dashes
        var dashes = new string('-', 100);
        
        // These variables are used to store input from the console
        int userInput = 0;
        string name = "";
        string address = "";
        string status;
        decimal balance = 0;
        var accountStatus = Account.AccountState.New;
        var accountType = Account.AccountType.Null;
        Account bankProgram = null;

        // These variables are used as flags for my while loops below.
        var validName = false;
        var validAddress = false;
        var validWithdrawal = false;
        var validDeposit = false;
        var validAccountStatus = false;
        
        // Instantiating my "database" it's just a list
        var accountDb = new MultiAccounts();

        // Function to ask for account type when creating a new account.
        void AccountTypePrompt()
        {
            var validAccountType = false;
            
            while (validAccountType is false)
            {
                string type;
                Console.WriteLine("Enter the type of the account from the options below: ");
                Console.WriteLine("- Checking \n- Savings \n- Cd");
                Console.Write("Account Type: ");
                type = Console.ReadLine();
                if (!int.TryParse(type, out _) && Enum.TryParse(type, out accountType))
                {
                    Console.WriteLine(dashes);
                    Console.WriteLine($"Thank you! We will be creating a {accountType} account for you.");
                    validAccountType = true;
                }
                else
                {
                    Console.WriteLine($"{dashes} \nError! Please only enter an account type from the choices given (case sensitive)! \n{dashes}");
                }
            
            }
            
        }

        // Function to ask for name when creating a new account
        void NamePrompt()
        {
            while (validName is false)
            {
                Console.Write("Enter Your Name: ");
                name = Console.ReadLine();
                
                // Checks if empty, number and has a regex check to only allow dashes but not any other special character
                if (string.IsNullOrEmpty(name) || int.TryParse(name, out _) || !Regex.IsMatch(name, @"^[a-zA-Z0-9- ]*$"))
                {
                    Console.WriteLine($"{dashes} \nError! Please enter a name without any digits or special characters! \n{dashes}");
                }
                else
                {
                    validName = true;    
                }
            }
            
            // Resetting the flag for repeated use
            validName = false;

        }

        // Function to ask for address when creating a new account
        void AddressPrompt()
        {
            while (validAddress is false)
            {
                Console.Write("Enter Your Address: ");
                address = Console.ReadLine();
                if (string.IsNullOrEmpty(address) || !Regex.IsMatch(address, @"^[a-zA-Z0-9-.# ]*$"))
                {
                    Console.WriteLine($"{dashes} \nError! Address cannot be blank or contain invalid special characters! \n{dashes}");
                }
                else
                {
                    validAddress = true;
                }
            }

            // Resetting the flag for repeated use
            validAddress = false;
        }
        
        // Function to ask for account status when creating a new account.
        void AccountStatusPrompt()
        {
            while (validAccountStatus is false)
            {
                Console.WriteLine("Enter the state of the account from the options below: ");
                Console.WriteLine("- New \n- Active \n- Under Audit \n- Frozen \n- Closed");
                status = Console.ReadLine().Replace(" ", string.Empty);

                if (!int.TryParse(status, out _) && Enum.TryParse(status, out accountStatus))
                {
                    Console.WriteLine($"Success! Your account status has been set as: {accountStatus}");
                    validAccountStatus = true;
                }
                else
                {
                    Console.WriteLine($"{dashes} \nError! The account status must be one of the options given! (Case Sensitive) \n{dashes}");
                }
            }
            
            // Resetting the flag for repeated use
            validAccountStatus = false;
        }
        
        // Function to ask for balance and store it in a variable named 
        void BalancePrompt()
        {
            var validBalance = false;

            while (validBalance is false)
            {
                Console.Write("Set your balance: $");
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
        }
        
        
        // Starts the account creation process. The dashes variable is for formatting.
        Console.WriteLine($"{dashes} \nWelcome To My Banking Program \n{dashes}");
        Console.WriteLine($"Lets Begin With Creating Your Account \n{dashes}");
        
        AccountTypePrompt();
        NamePrompt();
        AddressPrompt();
        AccountStatusPrompt();
        BalancePrompt();

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
            Console.WriteLine("Add Account: 7 \nSearch Account: 8 \nChange Service Fee: 9 \nQuit: 0");

            
            // Converting the user selection to an input to work for the switch statement.
            try
            {
                userInput = Convert.ToInt32(Console.ReadLine());

            }
            catch (FormatException e)
            {
                Console.WriteLine("Error! You cannot enter a blank option");
                continue;
            }

            switch (userInput)
            {
                case 0:
                    Console.WriteLine($"{dashes} \nThis program is now ending, Goodbye!");
                    break;
                case 1:
                    validName = false;
                    while (validName is false)
                    {
                        Console.Write($"{dashes} \nEnter the new name of the account:");
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
                    Console.WriteLine($"{dashes} \n{bankProgram.GetName().PadLeft(50)}'s Account Details \n{dashes}");
                    Console.WriteLine($"Account Type: {bankProgram.GetAccountType()} \nAccount Number: {bankProgram.GetAccountNumber()}");
                    Console.WriteLine($"Name: {bankProgram.GetName()} \nAddress: {bankProgram.GetAddress()}");
                    Console.WriteLine($"Balance: ${bankProgram.GetBalance()} \nAccount State: {bankProgram.GetAccountState()}");
                    Console.WriteLine($"Service Fee: ${bankProgram.GetServiceFee()}");
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
                            Console.WriteLine($"{dashes} \nError! Address cannot be blank or contain invalid special characters!");
                        }
                    }
                    break;
                
                case 4:
                    validWithdrawal = false;
                    while (validWithdrawal is false)
                    {
                        try
                        {
                            Console.Write("How much would you like to withdraw?: $");
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
                        Console.Write($"{dashes} \nEnter your deposit amount: $");
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
                
                case 7:
                    validAccountStatus = false;
                    AccountTypePrompt();
                    NamePrompt();
                    AddressPrompt();
                    AccountStatusPrompt();
                    BalancePrompt();

                    if (accountType == Account.AccountType.Checking)
                    {
                        accountDb.StoreAccount(new CheckingAccount(name, address, balance, accountStatus));
                    }
                    else if (accountType == Account.AccountType.Savings)
                    {
                        accountDb.StoreAccount(new SavingsAccount(name, address, balance, accountStatus));
            
                    }
                    else if (accountType == Account.AccountType.Cd)
                    {
                        accountDb.StoreAccount(new CdAccount(name, address, balance, accountStatus));
                    }

                    var accountDetails = accountDb.FindAccount(name);
                    Console.WriteLine($"{dashes} \n{accountDetails.GetName().PadLeft(50)}'s Account Details \n{dashes}");
                    Console.WriteLine($"Account Type: {accountDetails.GetAccountType()} \nAccount Number: {accountDetails.GetAccountNumber()}");
                    Console.WriteLine($"Name: {accountDetails.GetName()} \nAddress: {accountDetails.GetAddress()}");
                    Console.WriteLine($"Balance: {accountDetails.GetBalance()} \nAccount State: {accountDetails.GetAccountState()}");
                    
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
                    
                case 9:
                    var validServiceFee = false;
                    Console.WriteLine($"{dashes} \nThe current service fee for {bankProgram.GetName()} is ${bankProgram.GetServiceFee()}");
                    
                    // Changes user input to an int, if setservicefee returns false an error will appear
                    while (validServiceFee is false)
                    {
                        Console.Write("What will the new service fee be?: $");
                        if (bankProgram.SetServiceFee(int.Parse(Console.ReadLine())))
                        {
                            Console.WriteLine($"{dashes} \nSuccess! The new service fee for {bankProgram.GetName()} is now ${bankProgram.GetServiceFee()}.");
                            validServiceFee = true;
                        }
                        else
                        {
                            Console.WriteLine($"{dashes} \nError! The service fee must be a number and cannot be less than ${bankProgram.GetMinServiceFee()}");
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