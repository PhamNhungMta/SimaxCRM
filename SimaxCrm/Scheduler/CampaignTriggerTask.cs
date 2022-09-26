//using SimaxEmailPost.Service.Interface;
using SimaxCrm.Service.Interface;
using System.Threading;
using System.Threading.Tasks;

namespace SimaxCrm.Scheduler
{
    public class CampaignTriggerTask : IScheduledTask
    {
        private readonly IProcessJobService _processJobService;
        public CampaignTriggerTask(IProcessJobService processJobService)
        {
            _processJobService = processJobService;
        }

        public string Schedule => "*/5 * * * *";

        public async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            _processJobService.PushFollowUpNotifications();
            await Task.Delay(5000, cancellationToken);
        }
    }
}