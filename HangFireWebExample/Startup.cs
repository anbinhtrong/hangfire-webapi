using Hangfire;
using Microsoft.Owin;
using Owin;
using System.Diagnostics;

[assembly: OwinStartup(typeof(HangFireWebExample.Startup))]
namespace HangFireWebExample
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            GlobalConfiguration.Configuration.UseSqlServerStorage("HangfireContext");

            app.UseHangfireDashboard("/WebJobsDashboard");
            app.UseHangfireServer();

            RecurringJob.AddOrUpdate(
                () => Debug.WriteLine("Minutely Job"), Cron.Minutely);
        }
    }
}