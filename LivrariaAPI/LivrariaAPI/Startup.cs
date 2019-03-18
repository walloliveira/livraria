
using LivrariaAPI.Domain.Livro;
using LivrariaAPI.Domain.Livro.UseCases;
using LivrariaAPI.Persistence.LivroPersistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LivrariaAPI
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
            services.AddEntityFrameworkInMemoryDatabase()
                .AddDbContext<LivroContext>(options => options.UseInMemoryDatabase("livraria"));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddScoped<IAddLivroUseCase, AddLivroUseCase>();
            services.AddScoped<ILivroRepository, LivroRepository>();
            services.AddScoped<IGetLivroUseCase, GetLivroUseCase>();
            services.AddScoped<IListLivroUseCase, ListLivroUseCase>();
            services.AddScoped<IUpdateLivroUseCase, UpdateLivroUseCase>();
            services.AddScoped<IDeleteLivroUseCase, DeleteLivroUseCase>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
