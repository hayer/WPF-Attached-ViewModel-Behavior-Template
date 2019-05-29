using System;
using System.Reactive.Linq;
using JetBrains.Annotations;
using Reactive.Bindings;

#error Remeber to register the viewmodel in App.xaml.cs RegisterTypes(), RegisterViewModelContainerConfigurator<TemplateViewModel>(c => {});

namespace WpfAvmb.ViewModels
{
    [UsedImplicitly]
    public class TemplateViewModel : ViewModel<TemplateViewModel>
    {
        public TemplateViewModel(Func<TemplateViewModel, ViewModelBehaviorsController<TemplateViewModel>> a) : base(a)
        {
            // setup commands

            // determistic start of behaviors
            BehaviorsController.Start();
        }
    }
}