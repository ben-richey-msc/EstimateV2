using EstimateV2.Modules.Settings.Views;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using EstimateV2.Modules.Settings.ViewModels;
using System.Xml.Linq;
using EstimateV2.Core.EF;

namespace EstimateV2.Modules.Home.ViewModels
{
    public class HomeViewModel : BindableBase
    {
        public VesselEntities globalEntities = new VesselEntities();

        public HomeViewModel()
        {
            ClickCommand = new DelegateCommand(Click)
                .ObservesCanExecute(() => CanExecute);

            EstCommand = new DelegateCommand(ProcessEstimate)
                .ObservesCanExecute(() => CanExecute);
        }

        public DelegateCommand ClickCommand { get; private set; }
        public DelegateCommand EstCommand { get; private set; }


        private void DbToXml()
        {

            var customers =
                new XElement("customers",
                    from c in globalEntities.DueTodays.AsEnumerable()
                    select
                        new XElement("id", new XAttribute("id", c.ID),
                        new XElement("Port", c.Port),
                        new XElement("Vessel", c.Vessel),
                        new XElement("Voyage", c.Voyage),
                        new XElement("Departure_Date", c.Departure_Date),
                        new XElement("Status", c.Status),
                        new XElement("VCI_Due_Date", c.VCI_Due_Date),
                        new XElement("Days_Overdue_VCI", c.Days_Overdue_VCI),
                        new XElement("PVE_Due_Date", c.PVE_Due_Date),
                        new XElement("Less_Holiday", c.Less_Holiday),
                        new XElement("Days_Overdue_PVE", c.Days_Overdue_PVE),
                        new XElement("Notes", c.Notes),
                        new XElement("Problems", c.Problems),
                        new XElement("LINK_Processed", c.LINK_Processed),
                        new XElement("Potential_Corrections", c.Potential_Corrections),
                        new XElement("Submitted", c.Submitted),
                        new XElement("Submission_Date", c.Submission_Date),
                        new XElement("Submitted_By", c.Submitted_By),
                        new XElement("DA_number", c.DA_number),
                        new XElement("LinkIM_", c.LinkIM_),
                        new XElement("LinkEX_", c.LinkEX_),
                        new XElement("Detail", c.Detail),
                        new XElement("PVE_Status_Date", c.PVE_Status_Date),
                        new XElement("ID_ESTIMATE", c.ID_ESTIMATE),
                        new XElement("IC_REVALIDATED", c.IC_REVALIDATED),
                        new XElement("Ready_To_Process", c.Ready_To_Process),
                        new XElement("TERMINAL", c.TERMINAL),
                        new XElement("Double_Call", c.Double_Call),
                        new XElement("VCI_Validated", c.VCI_Validated)

                        )
                    );
            customers.Save(@"C:\Work\EstimateV2\output.xml");
            string estimate = customers.ToString();
            Console.WriteLine(estimate);

            var customers2 =
                    new XElement("customers",
                    from c in globalEntities.DueTodays.AsEnumerable()
                    let LatestLargeShipment = (from p in globalEntities.DueTodays.AsEnumerable()
                                               where p.ID > 1010
                                               orderby p.Departure_Date descending
                                               select p).FirstOrDefault()
                    where c.ID % 2 == 0
                    select
                        new XElement("id", new XAttribute("id", c.ID),
                        new XElement("Port", c.Port),
                        new XElement("Vessel", c.Vessel),
                        new XElement("Voyage", c.Voyage),
                        new XElement("Departure_Date", c.Departure_Date),
                        new XElement("Status", c.Status),
                        new XElement("VCI_Due_Date", c.VCI_Due_Date),
                        new XElement("Days_Overdue_VCI", c.Days_Overdue_VCI),
                        new XElement("PVE_Due_Date", c.PVE_Due_Date),
                        new XElement("Less_Holiday", c.Less_Holiday),
                        new XElement("Days_Overdue_PVE", c.Days_Overdue_PVE),
                        new XElement("Notes", c.Notes),
                        new XElement("Problems", c.Problems),
                        new XElement("LINK_Processed", c.LINK_Processed),
                        new XElement("Potential_Corrections", c.Potential_Corrections),
                        new XElement("Submitted", c.Submitted),
                        new XElement("Submission_Date", c.Submission_Date),
                        new XElement("Submitted_By", c.Submitted_By),
                        new XElement("DA_number", c.DA_number),
                        new XElement("LinkIM_", c.LinkIM_),
                        new XElement("LinkEX_", c.LinkEX_),
                        new XElement("Detail", c.Detail),
                        new XElement("PVE_Status_Date", c.PVE_Status_Date),
                        new XElement("ID_ESTIMATE", c.ID_ESTIMATE),
                        new XElement("IC_REVALIDATED", c.IC_REVALIDATED),
                        new XElement("Ready_To_Process", c.Ready_To_Process),
                        new XElement("TERMINAL", c.TERMINAL),
                        new XElement("Double_Call", c.Double_Call),
                        new XElement("VCI_Validated", c.VCI_Validated),
                        //additional tags w/ new calculations
                        new XElement("LatestLargeShipment", LatestLargeShipment,
                            new XElement("Vessel", LatestLargeShipment.Vessel),
                            new XElement("Voyage", LatestLargeShipment.Voyage))

                        )
                    );
            customers2.Save(@"C:\Work\EstimateV2\output2.xml");

        }

        private bool _canExecute = true;
        public bool CanExecute
        {
            get { return _canExecute; }
            set
            {
                SetProperty(ref _canExecute, value);
            }
        }

        private void Click()
        {
            SettingsWindow s = new SettingsWindow();
            s.Show();   
        }

        private void ProcessEstimate()
        {
            DbToXml();
        }

        private void ViewHistory()
        {
            SettingsWindow s = new SettingsWindow();
            SettingsWindowViewModel svm = new SettingsWindowViewModel();
            s.Show();
            svm.ShowEst();
        }



    }
}

