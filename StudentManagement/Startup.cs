using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddMvc(options => options.EnableEndpointRouting = false);
            services.AddMvc(options => options.EnableEndpointRouting = false).AddXmlSerializerFormatters();
            // add mvc core 只包含了核心的MVC功能
            // add MVC 包含了依赖于MVC Core以及相关的第三方常用的服务和方法
            // addMvc()方法会在内部调用AddMvcCore()方法

            // 三种依赖注入的方式
            // services.AddSingleton
            // services.AddTransient
            // services.AddScoped
            services.AddSingleton<IStudentRepository, MockStudentRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // 开发环境(development),集成环境(integration),测试环境(testing),QA验证,模拟环境(staging),生产环境(production)
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //else if (env.IsStaging() || env.IsProduction() || env.IsEnvironment("UAT"))
            //{
            //    app.UseExceptionHandler("/Error");
            //}

            app.UseRouting();

            //DefaultFilesOptions defaultFilesOptions = new DefaultFilesOptions();
            //defaultFilesOptions.DefaultFileNames.Clear();
            //defaultFilesOptions.DefaultFileNames.Add("gl.html");

            app.UseStaticFiles();
            //app.UseMvcWithDefaultRoute();
            app.UseMvc(routes =>
            {
                routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });

            // 替换
            //// 添加默认文件中间件
            //app.UseDefaultFiles(defaultFilesOptions);  //index.html, default.html, and so on
            //// 添加静态文件中间件(MiddleWare)
            //app.UseStaticFiles();

            // index.html index.htm 默认 default.html default.htm

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        // 进程名
            //        // var processName = System.Diagnostics.Process.GetCurrentProcess().ProcessName;
            //        // var configVal = _configuration["Mykey"];
            //        await context.Response.WriteAsync("hello world"); 
            //    });
            //});

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("hello world");
            });
        }
    }
}
