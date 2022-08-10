using EstimateV2.Core;
using EstimateV2.Modules.Home.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace EstimateV2.Modules.Home
{
    public class HomeModule : IModule
    {
        private readonly IRegionManager _regionManager;
        public HomeModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RegisterViewWithRegion(RegionNames.ContentRegion, typeof(HomeView));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            
        }
    }
}