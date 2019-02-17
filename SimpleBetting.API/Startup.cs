using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimpleBetting.Data;
using SimpleBetting.Repo.Interfaces;
using SimpleBetting.Repo.Repositories;
using SimpleBetting.Service.Interfaces;
using SimpleBetting.Service.Services;

namespace SimpleBetting.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public static IConfiguration Configuration { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddDbContext<SimpleBettingContext>(o =>
                o.UseSqlServer(Configuration.GetConnectionString("SimpleBettingDB")));

            services.AddScoped<IMatchRepository, MatchRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();
            services.AddScoped<ITicketRepository, TicketRepository>();

            services.AddScoped<ITicketService, TicketService>();

            services.AddAutoMapper();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,
            SimpleBettingContext simpleBettingContext)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.UseMvc();
        }
    }
}