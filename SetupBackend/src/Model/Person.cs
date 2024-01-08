public class Person : EntityDomain {

    public string? Name { get; set; }
    public string? Lastname { get; set; }
    public DateTime? Birthday { get; set; }

    public Person() {
        this.Name = string.Empty;
        this.Lastname = string.Empty;
        this.Birthday = new DateTime();
    }

}