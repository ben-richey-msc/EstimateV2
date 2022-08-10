using EstimateV2.Modules.Home;
using EstimateV2.Modules.Settings;
using EstimateV2.Modules.StatusBar;
using EstimateV2.Views;
using Prism.Ioc;
using Prism.Modularity;
using System.Windows;

namespace EstimateV2
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<HomeModule>();
            moduleCatalog.AddModule<SettingsModule>();
            moduleCatalog.AddModule<StatusBarModule>();
        }
    }
}
