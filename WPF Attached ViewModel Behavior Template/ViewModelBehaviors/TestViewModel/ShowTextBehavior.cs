using System;
using System.Windows;
using JetBrains.Annotations;
using WPPAttachedViewModelBehaviorTemplate.ViewModels;

namespace WPPAttachedViewModelBehaviorTemplate.ViewModelBehaviors
{
    [UsedImplicitly]
    public class ShowTextBehavior : ViewModelBehavior<TestViewModel>
    {
        protected override void OnStart()
        {
            // subscribe to command - add subscription to dispose list
            RegisterDisposable(ViewModel.ShowTextCommand.Subscribe(_ => ShowMessageDialog()));
        }

        private void ShowMessageDialog()
        {
            // ViewModel: property available on a behavior
            MessageBox.Show(ViewModel.Text.Value, "The message is");
        }
    }
}