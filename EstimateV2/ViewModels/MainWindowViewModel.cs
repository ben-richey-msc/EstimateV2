using EstimateV2.Core.Excel;
using Prism.Mvvm;

namespace EstimateV2.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Prism Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public MainWindowViewModel()
        {
            var tor = new TOR();
            TOR.Main();


        }
    }
}
