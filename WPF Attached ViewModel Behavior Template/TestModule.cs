using Prism.Modularity;
using Prism.Regions;
using WPF_Attached_ViewModel_Behavior_Template.Views;

namespace WPF_Attached_ViewModel_Behavior_Template
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