using System.IO;
using System.Reflection;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Rest.Serialization;
using Newtonsoft.Json.Converters;
using PetStore.CodeFirst.Models;
using PetStore.CodeFirst.Plumbing;
using PetStore.DataAccess;
using Swashbuckle.AspNetCore.Swagger;

[assembly: ApiConventionType(typeof(DefaultApiConventions))]

namespace PetStore.CodeFirst
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddJsonOptions(options =>
                {
                    options.SerializerSettings.Converters.Add(
                        new StringEnumConverter());
                    options.SerializerSettings.Converters.Add(
                        new PolymorphicDeserializeJsonConverter<PetViewModel>("petType"));
                });

            services.AddCors(options =>
            {
                options.AddPolicy("Demo", b => b
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowAnyOrigin());
            });

            services.AddAutoMapper(config => config.CreateMissingTypeMaps = false, Assembly.GetExecutingAssembly());

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Pet Store API", Version = "v1" });
                c.DescribeAllEnumsAsStrings();
                c.IncludeXmlComments(Path.ChangeExtension(Assembly.GetExecutingAssembly().CodeBase, ".xml"));
                c.OperationFilter<XCorrelationIdFilter>();
                //c.EnableAnnotations();
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseCors("Demo");

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Pet Store API v1");
            });

            app.UseMvc();
        }
    }
}
