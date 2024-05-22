

using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Company.Patients.Application.DependencyHelpers
{
  public static class DependencyInjectionHelper
  {
    public static IServiceCollection AddApplication(this IServiceCollection serviceCollection)
    {
      serviceCollection.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
      return serviceCollection;
    }
  }
}
