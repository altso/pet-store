using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using PetStore.DataAccess;
using Swashbuckle.AspNetCore.Swagger;

[assembly: ApiConventionType(typeof(DefaultApiConventions))]

namespace PetStore
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
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddJsonOptions(options =>
                    {
                        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Pet Store API", Version = "v1" });
                c.DescribeAllEnumsAsStrings();
                c.IncludeXmlComments(Path.ChangeExtension(Assembly.GetExecutingAssembly().CodeBase, ".xml"));
                c.EnableAnnotations();
                //c.GeneratePolymorphicSchemas();
            });

            services.AddDbContextPool<PetStoreDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("PetStore"));
            });
            services.AddTransient<IPetRepository, PetRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Pet Store API v1");
            });

            //app.UseReDoc(c =>
            //{
            //    c.SpecUrl = "/swagger/v1/swagger.json";
            //});
        }
    }
}
