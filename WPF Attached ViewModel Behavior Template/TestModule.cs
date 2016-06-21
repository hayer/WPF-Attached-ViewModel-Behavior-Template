using Prism.Modularity;
using Prism.Regions;
using WPPAttachedViewModelBehaviorTemplate.Views;

namespace WPPAttachedViewModelBehaviorTemplate
{
    public class TestModule : IModule
    {
        readonly IRegionManager _regionManager;

        public TestModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            _regionManager.RegisterViewWithRegion("MainRegion", typeof(TestView));
        }
    }
}