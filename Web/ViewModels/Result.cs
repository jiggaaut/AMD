namespace Web.ViewModels;

public class Result<T>
{
    public bool IsSuccess { get; set; }
    
    public T Entity { get; set; }
}