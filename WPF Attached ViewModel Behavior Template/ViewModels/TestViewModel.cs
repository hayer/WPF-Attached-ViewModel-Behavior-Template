using System;
using System.Reactive.Linq;
using JetBrains.Annotations;
using Reactive.Bindings;

namespace WPPAttachedViewModelBehaviorTemplate.ViewModels
{
    [UsedImplicitly]
    public class TestViewModel : ViewModel<TestViewModel>
    {
        public TestViewModel(Func<TestViewModel, ViewModelBehaviorsController<TestViewModel>> a) : base(a)
        {
            ShowTextCommand = Text.Select(str => !string.IsNullOrWhiteSpace(str)).ToReactiveCommand();

            // determistic start of behaviors
            BehaviorsController.Start();
        }

        public ReactiveProperty<string> Text { get; } = new ReactiveProperty<string>();

        public ReactiveCommand ShowTextCommand { get; }
    }
}