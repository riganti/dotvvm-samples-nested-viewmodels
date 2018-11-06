using DotVVM.Framework.Configuration;
using DotVVM.Framework.ResourceManagement;
using DotVVM.Framework.Runtime.Tracing;
using DotVVM.Tracing.MiniProfiler.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using StackExchange.Profiling;

namespace DotVVM.Samples.NestedViewModel
{
    public class DotvvmStartup : IDotvvmStartup, IDotvvmServiceConfigurator
    {
        public void ConfigureServices(IDotvvmServiceCollection options)
        {
            options.AddDefaultTempStorages("temp");
            AddMiniProfilerEventTracing(options);
        }

        public static IDotvvmServiceCollection AddMiniProfilerEventTracing(IDotvvmServiceCollection services)
        {
            services.Services.AddTransient<IRequestTracer, MiniProfilerTracer>();
            services.Services.Configure((MiniProfilerOptions opt) => opt.IgnoredPaths.Add("/dotvvmResource/"));

            services.Services.Configure((DotvvmConfiguration conf) =>
            {
                conf.Markup.AddCodeControls(DotvvmConfiguration.DotvvmControlTagPrefix, typeof(MiniProfilerWidget));
                conf.Runtime.GlobalFilters.Add(
                    new MiniProfilerActionFilter(conf.ServiceProvider.GetService<IOptions<MiniProfilerOptions>>()));
            });
            return services;
        }

        // For more information about this class, visit https://dotvvm.com/docs/tutorials/basics-project-structure
        public void Configure(DotvvmConfiguration config, string applicationPath)
        {
            ConfigureRoutes(config, applicationPath);
            ConfigureControls(config, applicationPath);
            ConfigureResources(config, applicationPath);
        }

        private void ConfigureRoutes(DotvvmConfiguration config, string applicationPath)
        {
            config.RouteTable.Add("Default", string.Empty, "Views/default.dothtml");

            config.RouteTable.Add("TaskDetail", "task/{Id}", "Views/Task/TaskDetail.dothtml");
            config.RouteTable.Add("TaskList", "tasks", "Views/Task/TaskList.dothtml");
            config.RouteTable.Add("ProjectDetail", "project/{Id}", "Views/Project/ProjectDetail.dothtml");
            config.RouteTable.Add("ProjectList", "projects", "Views/Project/ProjectList.dothtml");
        }

        private void ConfigureControls(DotvvmConfiguration config, string applicationPath)
        {
            // register code-only controls and markup controls
        }

        private void ConfigureResources(DotvvmConfiguration config, string applicationPath)
        {
            // register custom resources and adjust paths to the built-in resources
            config.Resources.Register("Styles", new StylesheetResource
            {
                Location = new UrlResourceLocation("~/styles.css")
            });
        }
    }
}