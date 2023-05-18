namespace SharedKernel.Factories;

public interface IFactory
{
    void Invoke();
}

public interface IFactory<in T1>
{
    void Initialize(T1 t1);
}