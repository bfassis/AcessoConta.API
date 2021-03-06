using AcessoConta.Api.Common.Notifications;
using AcessoConta.Api.Core.Orm.Dapper.Repository;
using AcessoConta.Conta.Infra.CrossCutting.IoC;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcessoConta.Api
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

            services.AddScoped<INotification, Notification>();

            services.AddHttpClient("AcessoApi", opt =>
            {
                opt.BaseAddress = new Uri("http://localhost:5000/api/");
                //var authenticatedUser = services.BuildServiceProvider().GetRequiredService<IAuthenticatedUser>();
                //opt.DefaultRequestHeaders.Add("Authorization", authenticatedUser.User.AcessToken);
            });

            services.AddSwaggerGen();

            services.AddScoped<AcessoContaDataBaseContextDapper>();

            services.AddScoped<RepositoryBaseDapper<AcessoContaDataBaseContextDapper>>();

            NativeInjectorTransferencia.Setup(services);
            


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

            app.UseSwagger();

            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("../swagger/v1/swagger.json", "Acesso Api");
                options.DisplayRequestDuration();
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
