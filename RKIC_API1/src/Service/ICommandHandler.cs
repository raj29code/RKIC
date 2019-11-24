

using System.Threading.Tasks;
#pragma warning disable 1591

namespace Service
{
    public interface ICommand { }

    public interface ICommandHandler<in TCommand>
        where TCommand : ICommand
    {
        Task<bool> Handle(TCommand command);
    }
}