public class CompleteRegisterDate : IStrategy
{
    public string Execute(IEntity entity)
    {
        entity.CreatedAt = DateTime.Now;
        return string.Empty;
    }

    public override string ToString()
    {
        return "CompleteRegisterDate";
    }

}
