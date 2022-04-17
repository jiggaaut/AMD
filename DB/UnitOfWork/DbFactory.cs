using DB.Context;

namespace DB.UnitOfWork;

public class DbFactory : IDisposable
{
    private readonly Func<EfDatabaseContext> _instanceFunc;
    private EfDatabaseContext? _dbContext;
    public EfDatabaseContext DbContext => _dbContext ??= _instanceFunc.Invoke();

    public DbFactory(Func<EfDatabaseContext> dbContextFactory)
    {
        _instanceFunc = dbContextFactory;
    }

    public void Dispose()
    {
        _dbContext?.Dispose();
        GC.SuppressFinalize(this);
    }
}