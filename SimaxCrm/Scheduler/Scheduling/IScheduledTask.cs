using System.Threading;
using System.Threading.Tasks;

namespace SimaxCrm.Scheduler
{
    public interface IScheduledTask
    {
        string Schedule { get; }
        Task ExecuteAsync(CancellationToken cancellationToken);
    }
}