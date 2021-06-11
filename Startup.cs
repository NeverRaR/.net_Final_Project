using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;
using ServiceStack.Redis;
using SyaBackend.Utils;
using Newtonsoft.Json;
using SyaBackend.Services;

namespace SyaBackend
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
            string connStr = Configuration.GetConnectionString("MySql");
            services.AddDbContext<SyaDbContext>(options =>
            options.UseMySql(connStr, ServerVersion.Parse("8.0.22 MySQL Community Server - GPL")));
            var section = Configuration.GetSection("Redis:Default");
            string _connectionString = section.GetSection("Connection").Value;//连接字符串
            string _instanceName = section.GetSection("InstanceName").Value; //实例名称
            int _defaultDB = int.Parse(section.GetSection("DefaultDB").Value ?? "0"); //默认数据库
            services.AddSingleton(new Utils.RedisClient(_connectionString, _instanceName, _defaultDB));
            services.AddMvc().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNamingPolicy = new UnderScoreCaseConverter();//使用小驼峰格式序列化
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
