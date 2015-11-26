using System.Linq;
using System.Reactive.Linq;
using Reactive.Bindings;
using WPF_Attached_ViewModel_Behavior_Template.ViewModelBehaviors;

namespace WPF_Attached_ViewModel_Behavior_Template.ViewModels
{
    public interface ITestViewModelBehavior : IViewModelBehavior<TestViewModel> { }

    public class TestViewModel
    {
        private readonly ITestViewModelBehavior[] _behaviors;

        public TestViewModel(ITestViewModelBehavior[] behaviors)
        {
            ShowTextCommand = Text.Select(str => !string.IsNullOrWhiteSpace(str)).ToReactiveCommand();

            // initialize behaviors
            _behaviors = behaviors;
            _behaviors.ForEach(b => b.Start(this));
        }

        public ReactiveProperty<string> Text { get; } = new ReactiveProperty<string>();

        public ReactiveCommand ShowTextCommand { get; }
    }
}