using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Project.Bll.Core.Interfaces;
using Project.Bll.Core.Services;
using Project.Configuration;
using Project.Dal.Ef;
using Project.Dal.Ef.Repositories;
using Swashbuckle.AspNetCore.Swagger;

namespace Atol.ControlPanel
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var config = ProjectConfiguration.OverrideWithEnvironment();

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<ProductService>();
            services.AddScoped<TransactionService>();
            services.AddScoped<UserService>();

            //todo тут надо бы припилить выбор базы данных от environment variables
            services.AddScoped<IUnitOfWorkFactory>(provider => EfUnitOfWorkFactory.CreateMsSqlBy(config.DbSettings.ConnectionString));

            services.AddMvc();

            //добавление swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(name: "v1", info: new Info
                {
                    Title = "ControlPanel"
                });

                c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory,
                    $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"));

            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();

            InitializeDatabase(app);
        }

        private void InitializeDatabase(IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var ef = scope.ServiceProvider.GetRequiredService<IUnitOfWorkFactory>()
                    as EfUnitOfWorkFactory;

                ef?.GetContext().Database.Migrate();
            }
        }
    }
}
