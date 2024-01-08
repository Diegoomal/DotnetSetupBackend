public interface IDAO
{
    void Create(IEntity entity);
    IEnumerable<IEntity> Read(IEntity entity);
    void Update(IEntity entity);
    void Delete(IEntity entity);
}