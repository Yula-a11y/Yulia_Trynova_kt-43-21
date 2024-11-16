using Yulya_trynova_kt_43_21.Filters;
using Yulya_trynova_kt_43_21.Interfaces;

namespace Yulya_trynova_kt_43_21.ServiceExtensions
{
	public static class ServiceExtensions
	{
		public static IServiceCollection AddServices(this IServiceCollection services)
		{
			services.AddScoped<ITeacherGetterService, TeacherGetterService>();
			services.AddScoped<ITeacherModifierService, TeacherModifierService>();
			return services;
		}
	}
}
