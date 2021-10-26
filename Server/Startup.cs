using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;
using DockerTraining.Server.Data;
using Microsoft.EntityFrameworkCore;

namespace DockerTraining.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            var server = Configuration["Database:DBServer"] ?? "localhost";
            var database = Configuration["Database"] ?? "ItemsDb";
            var port = Configuration["DBPort"] ?? "1443";
            var user = Configuration["DBUser"] ?? "SA";
            var password = Configuration["DBPassword"] ?? "P@ssword1";


            services.AddDbContext<AppDbContext>(options =>
            {
                //options.UseSqlServer(Configuration.GetConnectionString("sqlConnection"));
                //options.UseSqlServer($"Server=localhost, 1433;Database=ItemsDb;User=SA;Password=P@ssword1;"); //local db container
                options.UseSqlServer($"Server=db;Database=ItemsDb;User=SA;Password=Pa55word1;"); // DockerCompose
            });

            services.AddControllersWithViews();
            services.AddScoped<IItemRepo, ItemRepo>();
            services.AddRazorPages();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            DBManagementService.MigrationInitialisation(app);

            app.UseHttpsRedirection();
            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapFallbackToFile("index.html");
            });
        }
    }
}
