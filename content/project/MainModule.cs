using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using WPFAttachedViewModelBehaviorTemplate.Views;

namespace WPFAttachedViewModelBehaviorTemplate
{
    public class MainModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public MainModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
			// register views with regions here, example;
            // _regionManager.RegisterViewWithRegion("...", typeof(MyView));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }
    }
}