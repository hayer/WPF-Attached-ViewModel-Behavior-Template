using System.Windows;

namespace WPPAttachedViewModelBehaviorTemplate
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var bs = new Bootstrapper();
            bs.Run();
        }
    }
}