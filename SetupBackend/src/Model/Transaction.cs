public class Transaction : EntityDomain  {
    public string? TypeOperation { get; set; }
    public double? FinanceValue { get; set; }
    public Transaction() {
        this.TypeOperation = string.Empty;
        this.FinanceValue = 0.0;
    }
}