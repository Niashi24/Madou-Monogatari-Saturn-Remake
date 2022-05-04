public interface IHandler<T>
{
    T Handle(T input);
}