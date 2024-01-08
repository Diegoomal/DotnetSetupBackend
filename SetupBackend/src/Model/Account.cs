public class Account : EntityDomain  {
    public string? Agency { get; set; }
    public string? CurrentAccount { get; set; }
    public double? Balance { get; set; }

    public Account() {
        this.Agency = string.Empty;
        this.CurrentAccount = string.Empty;
        this.Balance = 0.0;
    }
}