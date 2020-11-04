using Microsoft.Extensions.DependencyInjection;

namespace BlazorWasm.Toastr.Services
{
	public static class ServiceCollectionExtension
	{
		public static IServiceCollection AddBlazorToastr(this IServiceCollection services)
			=> services.AddScoped<ToastrService>();
	}
}
