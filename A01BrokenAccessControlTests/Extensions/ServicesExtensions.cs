using System.Reflection;
using A01BrokenAccessControlTests.Core;

namespace A01BrokenAccessControlTests.Extensions;

public static class ServiceCollectionExtensions {
	public static IServiceCollection AddInjectables(this IServiceCollection services) {
		foreach(var a in AppDomain.CurrentDomain.GetAssemblies())
		foreach(var type in a.GetTypes()) {
			if (type is not { IsInterface: false, IsAbstract: false })
				continue;
			var attributes = type.GetCustomAttributes<InjectableAttribute>(true);
			foreach(var attribute in attributes) {
				var serviceType = attribute.Type ?? type;
				services.AddSingleton(serviceType, type);
			}
		}

		return services;
	}
}
