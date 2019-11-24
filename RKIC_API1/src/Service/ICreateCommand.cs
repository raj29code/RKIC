
namespace Service
{
    public interface ICreateCommand<out T> : ICommand where T : class
    {
        T NewEntity();
    }
}