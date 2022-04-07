namespace DB.Entities;

public class BaseEntity
{
    public ulong ID { get; set; }

    public bool IsDeleted { get; set; }
}