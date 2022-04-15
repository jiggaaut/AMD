namespace Web.ViewModels;

public class Result<T>
{
    public bool Success { get; set; }
    
    public T Entity { get; set; }
    
    public Result(bool success, T entity)
    {
        Success = success;
        Entity = entity;
    }
}