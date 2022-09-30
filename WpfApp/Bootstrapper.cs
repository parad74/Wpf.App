using Prism.Unity;
using System.Windows;

namespace PrismApplication
{
    public class Bootstrapper : UnityBootstrapper
    {
        public override void Run(bool runWithDefaultConfiguration)
        {
            base.Run(runWithDefaultConfiguration);
        }

        protected override DependencyObject CreateShell()
        {
            return Container.TryResolve<Views.Shell>();
        }

        protected override void InitializeShell()
        {
            App.Current.MainWindow = (Window)Shell;
            App.Current.MainWindow.Show();
        }

        protected override void ConfigureModuleCatalog()
        {
            base.ConfigureModuleCatalog();

            var catalogModuleInfo = typeof(CatalogModule.CatalogModule);
            ModuleCatalog.AddModule(new Prism.Modularity.ModuleInfo { ModuleType = catalogModuleInfo.AssemblyQualifiedName, ModuleName = catalogModuleInfo.Name });
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
        }
    }
}
