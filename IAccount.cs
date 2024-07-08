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

    public bool SetAccountNumber(int inAccountNumber);

    public int GetAccountNumber();

    Account.AccountState GetAccountState();

    void SetAccountState(Account.AccountState inState);
}  


