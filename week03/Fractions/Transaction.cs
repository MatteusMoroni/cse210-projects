public class Transaction
{
    public string Date { get; set; }
    public string Description { get; set; }
    public decimal Amount { get; set; }
    public decimal RunningBalance { get; set; }

    public Transaction(string date, string description, decimal amount, decimal runningBalance)
    {
        Date = date;
        Description = description;
        Amount = amount;
        RunningBalance = runningBalance;
    }
}