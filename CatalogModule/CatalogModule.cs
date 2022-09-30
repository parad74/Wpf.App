using Prism.Modularity;
using Prism.Regions;

namespace CatalogModule
{
    public class CatalogModule : IModule
    {
        private IRegionManager _regionManager;
        public CatalogModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            _regionManager.RegisterViewWithRegion("Catalog", typeof(Wpf.Module.Views.CatalogView));
			_regionManager.RegisterViewWithRegion("BookAdd", typeof(Wpf.Module.Views.BookAddView));
		}
    }
    
}
