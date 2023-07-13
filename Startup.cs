﻿using  IDGS902_Api.Context;
using Microsoft.EntityFrameworkCore;

namespace IDGS902_Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;  
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                var frontendURL = Configuration.GetValue<string>("frontend_url");
                options.AddDefaultPolicy(builder =>
                {
                    //Aqui  va la url de angular, poniendo la ip de la maquina virtual
                    builder.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
                });
            });
                services.AddControllers();
                services.AddDbContext<AppDbContext>(options =>
                
                    options.UseSqlServer(Configuration.GetConnectionString("conexion")));           
        }

        public void Configure(IApplicationBuilder app, IHostApplicationLifetime lifetime)
        {
                      
        }

    }
}
