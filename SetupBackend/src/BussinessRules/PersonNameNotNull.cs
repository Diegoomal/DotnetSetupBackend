public class NameProductNotNull : IStrategy
{
    public string Execute(IEntity entity)
    {
        Person p = (Person)entity;

        if (string.IsNullOrEmpty(p.Name))
            return "Name of person is null or empty.";

        return string.Empty;
    }

    public override string ToString()
    {
        return "NameProductNotNull";
    }
}
