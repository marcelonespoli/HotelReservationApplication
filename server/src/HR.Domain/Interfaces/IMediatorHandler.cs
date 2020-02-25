using HR.Domain.Core.Commands;
using HR.Domain.Core.Events;
using System.Threading.Tasks;

namespace HR.Domain.Interfaces
{
    public interface IMediatorHandler
    {
        Task PublishEvent<T>(T @event) where T : Event;
        Task SendCommand<T>(T command) where T : Command;
    }
}
