using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ZBlog.Data;

namespace ZBlog
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
            services.AddDbContext<ZBlogContext>(options =>
                options.UseMySQL(Configuration.GetConnectionString("ZBlogContext")));

            // services.Configure<JwtSettings>(Configuration.GetSection("JwtSettings"));
            // var jwtSettings = new JwtSettings();
            // Configuration.Bind("JwtSettings",jwtSettings);
          
            services.AddMvc().AddXmlSerializerFormatters();

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthorization();
            app.UseAuthentication();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
            // app.MapWhen(x=>x.Request.Path.Value.StartsWith("/user"), builder =>
            // {
            //     builder.UseStaticFiles();
            //     app.UseSpa(spa =>
            //     {
            //         spa.Options.SourcePath = "ClientApp";
            //         //
            //         // if (env.IsDevelopment())
            //         // {
            //         //     spa.UseReactDevelopmentServer(npmScript: "start");
            //         // }
            //     });
            // });
           
            
            
        }
    }
}