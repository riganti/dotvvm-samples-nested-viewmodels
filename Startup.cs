using DotVVM.Framework.Hosting;
using DotVVM.Framework.ViewModel;
using DotVVM.Samples.NestedViewModel.DAL;
using DotVVM.Samples.NestedViewModel.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;

namespace DotVVM.Samples.NestedViewModel
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            // Set up configuration sources.
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath);

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDataProtection();
            services.AddAuthorization();
            services.AddWebEncoders();
            services.AddSingleton<FakeDatabase>();
            services.AddMiniProfiler(options => options.RouteBasePath = "/profiler");
            services.AddDotVVM<DotvvmStartup>();

            services.Scan(scan => scan
                    .FromEntryAssembly()
                    .AddClasses(classes => classes.AssignableTo<IDotvvmViewModel>())
                        .AsSelf()
                        .WithTransientLifetime()
                    .AddClasses(classes => classes.AssignableTo<ServiceBase>())
                        .AsSelf()
                        .WithTransientLifetime());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            app.UseMiniProfiler();
            // use DotVVM
            app.UseDotVVM<DotvvmStartup>(env.ContentRootPath);

            // use static files
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(env.WebRootPath)
            });
        }
    }
}