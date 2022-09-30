using Microsoft.Practices.Unity;
using Wcf.Client;

namespace Config
{
    public static class Configuration
    {
        private static IUnityContainer Container = new UnityContainer();
        public static void Configure()
        {
           Container.RegisterType<IBookRepository, BookRepository>();
        }

        public static T Resolve<T>(string key)
        => Container.Resolve<T>(key);

        public static T Resolve<T>()
            => Container.Resolve<T>();
    }

}
