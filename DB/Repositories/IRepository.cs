using DB.Entities;

namespace DB.Repositories;

public interface IRepository<T> where T: BaseEntity
{
    public T? GetItem(ulong id);
}