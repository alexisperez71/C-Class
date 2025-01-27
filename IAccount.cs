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
interface IAccount
{
    public string GetName();
    public bool SetName(string inName);

    public string GetAddress();
    public bool SetAddress(string  inAddress);

    public void PayInFunds(decimal amount);

    public bool WithdrawFunds(decimal amount);

    public decimal GetBalance();

    public bool SetBalance(decimal inBalance);

    public void GenAccountNumber();

    public void CheckForDupeAccountNumber();
    
    public string GetAccountNumber();

    public bool SetServiceFee(int inServiceFee);

    public int GetServiceFee();

    public int GetMinServiceFee();

    Account.AccountState GetAccountState();

    void SetAccountState(Account.AccountState inState);

    public bool SetAccountType(Account.AccountType accountType);

    public Account.AccountType GetAccountType();

}  


