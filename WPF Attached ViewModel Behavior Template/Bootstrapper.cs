using System.Windows;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using WPPAttachedViewModelBehaviorTemplate.ViewModelBehaviors;
using WPPAttachedViewModelBehaviorTemplate.ViewModels;
using WPPAttachedViewModelBehaviorTemplate.Views;

namespace WPPAttachedViewModelBehaviorTemplate
{
    public class Bootstrapper : PrismUnityBootstrapper
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
            base.ConfigureContainer(); // must be called to initialize PRISM

            /* ### container configurator:
             * on request of page (PRISM)
             * -> create viewmodel container / child container
             * -> run the container configurator
             * -> resolve viewmodel, viewmodel behaviors and all other registered dependencies
             * -> viewmodel returned to PRISM
             */
            RegisterViewModelContainerConfigurator<TestViewModel>(c =>
            {
                c.RegisterViewModelBehavior<ShowTextBehavior>(); // generics guarantee only behaviors for MainPageViewModel can be registered

                // c.ViewModelContainer: reference to the viewmodel container - do custom registrations here
            });
        }
    }
}