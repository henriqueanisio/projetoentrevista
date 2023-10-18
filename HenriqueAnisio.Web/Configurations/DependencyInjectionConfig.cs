using HenriqueAnisio.Data.Context;
using HenriqueAnisio.Data.Repository;
using HenriqueAnisio.Domain.Interfaces;
using HenriqueAnisio.Domain.Services;

namespace HenriqueAnisio.Web.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<MyDbContext>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();


            return services;
        }
    }
}
