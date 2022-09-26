using Lamar;
using Microsoft.Extensions.DependencyInjection;
using SimaxCrm.Scheduler;
using SimaxCrm.Scheduler.Scheduling;

namespace SimaxCrm.Registry
{
    public class ApplicationRegistry : ServiceRegistry
    {
        public ApplicationRegistry()
        {
            Scan(scanner =>
            {
                scanner.TheCallingAssembly();
                scanner.WithDefaultConventions();
                scanner.AssembliesAndExecutablesFromApplicationBaseDirectory(assembly =>
                    assembly.GetName().Name.StartsWith("SimaxCrm."));
            });

            this.AddSingleton<IScheduledTask, CampaignTriggerTask>();
            this.AddScheduler((sender, args) =>
            {
                args.SetObserved();
            });
        }
    }
}
