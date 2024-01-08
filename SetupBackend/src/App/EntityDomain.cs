public class EntityDomain : IEntity
{
    public int Id { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreatedAt { get; set; }

    public override string ToString() {
        return UtilString.GetDataClass(this);
    }
}