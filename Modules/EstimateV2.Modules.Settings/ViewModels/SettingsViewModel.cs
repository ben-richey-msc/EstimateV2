using EstimateV2.Core.EF;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EstimateV2.Modules.Settings.ViewModels
{
    public class SettingsViewModel : BindableBase
    {
        private List<DueToday> _vesselList;
        public List<DueToday> VesselList
        {
            get { return _vesselList; }
            set { SetProperty(ref _vesselList, value); }
        }


        public VesselEntities globalEntities = new VesselEntities();
        public SettingsViewModel()
        {
            //VesselList = globalEntities.DueTodays.ToList();
            refreshList(globalEntities);

        }

        public void refreshList(VesselEntities context)
        {
            VesselList = context.DueTodays.ToList();
        }

        
    }
}
