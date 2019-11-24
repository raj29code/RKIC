

using System.Threading.Tasks;

namespace Service
{
    public interface IKeyGenerator<in T>
    {
        Task Generate(T entity);
    }
}