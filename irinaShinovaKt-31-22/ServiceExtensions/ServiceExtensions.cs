using irinaShinovaKt_31_22.Services;

namespace irinaShinovaKt_31_22.ServiceExtensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<GradeService, GradeServiceImpl>();
            services.AddScoped<GroupService, GroupServiceImpl>();
            return services;
        }
    }
}
