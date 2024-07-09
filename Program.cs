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
        string name;
        string address;
        string status;
        Account.AccountState accountStatus;

        // These variables are used for checks in my while loops below.
        var validName = false;
        var validAddress = false;
        var validBalance = false;
        var validAccountNumber = false;
        var validWithdrawal = false;
        var validDeposit = false;
        var validAccountStatus = false;

        // Instantiate the Account class
        Account bankProgram = new Account();
        
        // Starts the account creation process. The dashes variable is for formatting.
        Console.WriteLine($"{dashes} \nWelcome To My Banking Program \n{dashes}");
        Console.WriteLine($"Lets Begin With Creating Your Account \n{dashes}");
        
        while (validName is false)
        {
            Console.WriteLine("Enter Your Name:");
            name = Console.ReadLine();
            if (bankProgram.SetName(name))
            {
                validName = true;
            }
            else
            {
                Console.WriteLine("Error! Please enter a name without any digits or special characters!");
            }
        }

        while (validAddress is false)
        {
            Console.WriteLine("Enter Your Address:");
            address = Console.ReadLine();
            if (bankProgram.SetAddress(address))
            {
                validAddress = true;
            }
            else
            {
                Console.WriteLine("Error! Address cannot be blank!");
            }
        }

        while (validBalance is false)
        {
            Console.WriteLine("Set your balance:");
            try
            {
                var balance = Convert.ToDecimal(Console.ReadLine());
                if (bankProgram.SetBalance(balance))
                {
                    validBalance = true;
                }
                else
                {
                    Console.WriteLine("Error! Balance must be set to $100 or more");
                }
            }
            catch (System.FormatException)
            {
                Console.WriteLine("Error! Balance must be an integer!");
            }
            
        }

        // Validating that the account number upon creation is valid
        while (validAccountNumber is false)
        {
            Console.WriteLine("Enter your account number:");
            try
            {
                var accountNumber = Convert.ToInt32(Console.ReadLine());
                if (bankProgram.SetAccountNumber(accountNumber))
                {
                    validAccountNumber = true;
                }
                else
                {
                    Console.WriteLine("Error! Account Number must be a positive number!");
                }
                
            }
            catch (System.FormatException)
            {
                Console.WriteLine("Error! Account number must contain only numbers!");
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
                bankProgram.SetAccountState(accountStatus);
                validAccountStatus = true;
            }
            else
            {
                Console.WriteLine("Error! The account status must be one of the options given!");
            }
        }
        
        Console.WriteLine($"{dashes}\nThank you! Your account has been created :)");
        Console.WriteLine($"{dashes} \nAccount Details: \nName: {bankProgram.GetName()} \nAddress: {bankProgram.GetAddress()}");
        Console.WriteLine($"Initial balance: {bankProgram.GetBalance()} \nAccount Number: {bankProgram.GetAccountNumber()}");
        Console.WriteLine($"Account Status: {bankProgram.GetAccountState()}");

        do
        {
            // Prompt for the  console application.
            Console.WriteLine(dashes);
            Console.WriteLine("Welcome To My Banking Program".PadLeft(60));
            
            // Adding padding to center the message.
            Console.WriteLine(dashes);
            Console.WriteLine($"Please enter the number that corresponds to the action you would like to complete\n{dashes}");
        
            // Displaying the options
            Console.WriteLine("Change Account Name: 1 \nDisplay Account Name: 2 \nChange Address: 3 \nDisplay Address: 4");
            Console.WriteLine("Display Balance: 5 \nWithdraw Funds: 6 \nDeposit Funds: 7 \nDisplay Account Status: 8");
            Console.WriteLine("Change Account Status: 9 \nQuit: 0");
            
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
                    Console.WriteLine($"{dashes} \nThe name of the account holder is: {bankProgram.GetName()}");
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
                case 4:
                    Console.WriteLine($"{dashes} \nYour address is: {bankProgram.GetAddress()}");
                    break;
                case 5:
                    Console.WriteLine($"{dashes} \nYour balance is ${bankProgram.GetBalance()}");
                    break;
                case 6:
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
                        catch (System.FormatException)
                        {
                            Console.WriteLine($"{dashes} \nError! Withdrawal amount must be a positive number!");
                        }

                    }
                    break;
                case 7:
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
                        catch (System.FormatException)
                        {
                            Console.WriteLine($"{dashes} \nError! Deposit amount must be a positive number!");
                        }

                    }
                    break;
                    
                case 8:
                    Console.WriteLine($"{dashes} \nYour account status is: {bankProgram.GetAccountState()}");
                    break;
                
                case 9:
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

                default:
                    Console.WriteLine($"{dashes} \nError! Please only enter a number from the menu!");
                    break;
            }
            
        } while (userInput != 0);
        
    }
}