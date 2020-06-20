using CentralizedLogging.BL;
using CentralizedLogging.DB.EF.Data;
using CentralizedLogging.DB.EF.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CentralizedLoggingSystem
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddScoped<IServiceListTable, ServiceListTable>();
            services.AddScoped<ILogsTableData, LogsTableData>();
            services.AddScoped<ILogsTable, LogsTable>();

            services.AddDbContext<CentralizedLoggingContext>(option =>
            {
                option.UseSqlServer(Configuration.GetConnectionString("DatabaseConnection"));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env ,ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            loggerFactory.AddFile("Logs/mylog-{Date}.txt");

            app.UseHttpsRedirection();

            app.UseCors(configurePolicy => configurePolicy.AllowAnyOrigin());

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
