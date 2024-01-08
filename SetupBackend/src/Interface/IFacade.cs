public interface IFacade
{
    Result Create(IEntity entity);
    public Result Read(IEntity entity);
    Result Update(IEntity entity);
    Result Delete(IEntity entity);
}