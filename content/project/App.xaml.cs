using System;
using System.Collections.Generic;
using System.Windows;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Unity;
using Unity;
using WPFAttachedViewModelBehaviorTemplate.ViewModelBehaviors;
using WPFAttachedViewModelBehaviorTemplate.ViewModels;

namespace WPFAttachedViewModelBehaviorTemplate
{
    public partial class App : PrismApplication
    {
        private readonly Dictionary<Type, Func<IUnityContainer>> _createViewModelContainerFuncMap = new Dictionary<Type, Func<IUnityContainer>>();

        protected override void ConfigureViewModelLocator()
        {
            Prism.Mvvm.ViewModelLocationProvider.SetDefaultViewModelFactory(ViewModelFactory);
        }

        private object ViewModelFactory(Type viewModelType)
        {
            // try get viewmodel container func (for creation of container on request)
            Func<IUnityContainer> createViewModelContainerFunc;
            var viewModelTypeHasRegistration = _createViewModelContainerFuncMap.TryGetValue(viewModelType, out createViewModelContainerFunc);

            if (viewModelTypeHasRegistration)
            {
                // instantiate viewmodel container
                var container = createViewModelContainerFunc();

                // get viewmodel from container
                var viewModel = container.Resolve(viewModelType) as IDisposableList;
                viewModel?.RegisterDisposable(container);

                return viewModel;
            }

            // no registration for viewModelType found -> fallback to default resolution from main container
            return Container.GetContainer().TryResolve(viewModelType);
        }

        protected override Window CreateShell()
        {
            return new Views.MainWindow();
        }

        protected override void InitializeShell(Window shell)
        {
            shell.Show();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            /* ### container configurator:
             * on request of page (PRISM)
             * -> create viewmodel container / child container
             * -> run the container configurator
             * -> resolve viewmodel, viewmodel behaviors and all other registered dependencies
             * -> viewmodel returned to PRISM
             */

            // register viewmodels, RegisterViewModelContainerConfigurator<MyViewModel>(c => {});

            RegisterViewModelContainerConfigurator<TestViewModel>(c =>
            {
                c.RegisterViewModelBehavior<ShowTextBehavior>(); // generics guarantee only behaviors for MainPageViewModel can be registered

                // c.ViewModelContainer: reference to the viewmodel container - do custom registrations here
            });
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            base.ConfigureModuleCatalog(moduleCatalog);

            moduleCatalog.AddModule(typeof(MainModule));
        }

        /// <summary>
        /// Registers the viewmodel container configurator. Use for registering behaviors with container as well as custom registrations.
        /// </summary>
        /// <typeparam name="TViewModel">The type of the viewmodel.</typeparam>
        /// <param name="viewModelContainerConfiguratorCallback">The viewmodel container configurator callback.</param>
        /// <exception cref="ArgumentNullException"></exception>
        protected void RegisterViewModelContainerConfigurator<TViewModel>(Action<ViewModelContainerReference<TViewModel>> viewModelContainerConfiguratorCallback)
            where TViewModel : ViewModel<TViewModel>
        {
            if (viewModelContainerConfiguratorCallback == null)
            {
                throw new ArgumentNullException(nameof(viewModelContainerConfiguratorCallback));
            }

            // function for creating a viewmodel container - this line removes dependency on generic type
            Func<IUnityContainer> createViewModelContainerFunc = () => CreateViewModelContainer<TViewModel>(base.Container.GetContainer(), viewModelContainerConfiguratorCallback);
            
            // add to lookup - map on typeof(TViewModel)
            _createViewModelContainerFuncMap.Add(typeof(TViewModel), createViewModelContainerFunc);
        }

        private static IUnityContainer CreateViewModelContainer<TViewModel>(IUnityContainer parentContainer, Action<ViewModelContainerReference<TViewModel>> viewModelContainerConfiguratorCallback)
        {
            // create child container for viewmodel
            var childContainer = parentContainer.CreateChildContainer();

            // register viewmodel and controller (viewmodel behaviors controller)
            childContainer.RegisterViewModelAndBehaviorsControllerFactory<TViewModel>();

            // run callback which should register behaviors and custom registrations with viewmodel container / child container
            viewModelContainerConfiguratorCallback(new ViewModelContainerReference<TViewModel>(childContainer));

            return childContainer;
        }
    }
}