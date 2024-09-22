namespace Shared.DAL;

public interface IEntity<T>
{
    public T Id { get; set; }
}
