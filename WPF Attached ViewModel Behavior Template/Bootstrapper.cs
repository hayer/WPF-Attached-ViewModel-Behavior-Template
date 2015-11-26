using System.Windows;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Unity;
using WPF_Attached_ViewModel_Behavior_Template.ViewModelBehaviors;
using WPF_Attached_ViewModel_Behavior_Template.ViewModels;
using WPF_Attached_ViewModel_Behavior_Template.Views;

namespace WPF_Attached_ViewModel_Behavior_Template
{
    public class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void InitializeShell()
        {
            Application.Current.MainWindow.Show();
        }

        protected override void ConfigureModuleCatalog()
        {
            var catalog = (ModuleCatalog)ModuleCatalog;
            catalog.AddModule(typeof(TestModule));
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();

            // behaviors
            Container.RegisterType<ITestViewModelBehavior, ShowTextBehavior>(nameof(ShowTextBehavior));
        }
    }
}