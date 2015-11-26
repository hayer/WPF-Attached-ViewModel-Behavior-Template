using System;
using System.Windows;
using WPF_Attached_ViewModel_Behavior_Template.ViewModels;

namespace WPF_Attached_ViewModel_Behavior_Template.ViewModelBehaviors
{
    public class ShowTextBehavior : ITestViewModelBehavior
    {
        private ViewModels.TestViewModel _vm;

        public void Start(ViewModels.TestViewModel viewModel)
        {
            _vm = viewModel;
            viewModel.ShowTextCommand.Subscribe(_ => MessageBox.Show(_vm.Text.Value));
        }
    }
}