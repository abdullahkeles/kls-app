namespace Shared.Database;

public interface IEntity<T>
{
    public T Id { get; set; }
}
