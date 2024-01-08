public class EntityNotNull : IStrategy
{
    public string Execute(IEntity entity)
    {
        return (entity == null) ? "Entidade Nula" : string.Empty;
    }

    public override string ToString()
    {
        return "EntityNotNull";
    }
}