namespace SharedKernel.Factories;

public interface IFactory
{
    void Invoke();
}

public interface IFactory<in T1>
{
    void Invoke(T1 t1);
}