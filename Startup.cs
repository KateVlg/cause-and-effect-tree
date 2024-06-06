using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using VSTU.EquipmentDiagnostics.Dal;
using VSTU.EquipmentDiagnostics.ObjectModel;
using VSTU.EquipmentDiagnostics.Services;

namespace VSTU.EquipmentDiagnostics.RestAPI
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

            services.AddMvc();
            //services.AddDbContext<ApplicationContext>(options =>
            //options.UseSqlServer(connection));

            services.AddTransient<IEquipmentService, EquipmentService>();
            services.AddTransient<IFailureComplectService, FailureComplectService>();
            services.AddTransient<IMatrixService, MatrixService>();
            services.AddTransient<IRootCauseService, RootCauseService>();
            services.AddTransient<ISymptomService, SymptomService>();

            //services.AddTransient<IBaseRepository<Failure>, BaseRepository<Failure>>();
            //services.AddTransient<IBaseRepository<RootCause>, BaseRepository<RootCause>>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
