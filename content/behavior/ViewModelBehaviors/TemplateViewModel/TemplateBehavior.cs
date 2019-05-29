using System;
using System.Windows;
using JetBrains.Annotations;
using WpfAvmb.ViewModels;

#error Remember to register the behavior in App.xaml.cs, c.RegisterViewModelBehavior<TemplateBehavior>(); 

namespace WpfAvmb.ViewModelBehaviors
{
    [UsedImplicitly]
    public class TemplateBehavior : ViewModelBehavior<TemplateViewModel>
    {
        protected override void OnStart()
        {
            // subscribe to command - add subscription to dispose list
            // RegisterDisposable(ViewModel.YourCommand.Subscribe(_ => MyHandler()));
        }

        private void MyHandler()
        {
            // ViewModel: property available on a behavior
        }
    }
}