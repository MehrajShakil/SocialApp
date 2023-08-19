using Microsoft.EntityFrameworkCore;
using Socialapp.Api.Data;
using Socialapp.Api.Helpers;
using Socialapp.Api.Interfaces;
using Socialapp.Api.Services;

namespace Socialapp.Api.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(opt =>
            {
                opt.UseSqlite(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddCors();
            services.AddTransient<ITokenService, TokenService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.Configure<CloudinarySettings>(configuration.GetSection(nameof(CloudinarySettings)));
            services.AddScoped<IPhotoService, PhotoService>();
            services.AddSignalR();

            return services;
        }
    }
}
