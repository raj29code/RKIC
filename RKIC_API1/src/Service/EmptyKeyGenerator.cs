


using System.Threading.Tasks;

namespace Service
{
    public class EmptyKeyGenerator<T> : IKeyGenerator<T>
    {
        public Task Generate(T entity)
        {
            return Task.CompletedTask;
        }
    }
}