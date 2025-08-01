using HMH.core.Interfaces;
using HMH.Core.Services;
using HMH.Infrastructure.Data;
using HMH.Infrastructure.Repositories;
using HMH.Infrastructure.Repositories.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMH.Infrastructure
{
    public static class InfrastructureRegistration
    {
        public static IServiceCollection InfrastructureConfiguration( this IServiceCollection services,IConfiguration configuration)
        {
            services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));
            //services.AddScoped<IDoctorRepository, DoctorRepository>();
            //services.AddScoped<IClinicsRepository, ClinicsRepository>();
            //services.AddScoped<IRatingRepository, RatingRepository>();
            //services.AddScoped<IRatingRepository, RatingRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IimageserviceMangment, ImageserviceMangment>();
            services.AddSingleton<IFileProvider>(new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(),"wwwroot")));
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("HMHDataBase"));
            });
            return services;
        }
    }
}
