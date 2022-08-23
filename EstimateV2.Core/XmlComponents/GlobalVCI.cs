using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.IO;

namespace EstimateV2.Core.XmlComponents
{
    public static class GlobalVCI
    {
        public static VCI vci { get; set; }
        private static string path = @"C:\Work\Liam\TestingNewXML\USBAL-MSC MICHAELA-IX227R-25JUL2022-131619.xml";



        static GlobalVCI()
        {
            var vci = new VCI();
            vci = ProcessXML(path);
        }


        #region XML
        private static List<VCI>? _vciList;
        public static List<VCI>? VCIList
        {
            get { return _vciList; }
            set
            {
                _vciList = value;
                //NotifyOfPropertyChange(() => VCIList);
            }
        }

        private static VCI? _selectedVCI;
        public static VCI? SelectedVCI
        {
            get { return _selectedVCI; }
            set { _selectedVCI = value; /*NotifyOfPropertyChange(() => SelectedVCI);*/ }
        }


        public static VCI ProcessXML(string fileEntry)
        {

            VCI vci = new VCI();
            XDocument? doc = XDocument.Load(fileEntry);

            var fullDocument = doc.Root;

            XNamespace? ns = doc?.Root?.GetDefaultNamespace();
            if (ns != null && fullDocument != null)
            {
                Header header = new Header();
                foreach (XElement element in fullDocument.Descendants(ns + "header"))
                {
                    Main main = new Main();
                    if (element != null)
                    {
                        foreach (XElement node in element.Descendants(ns + "main"))
                        {
                            var port = node?.Element(ns + "port")?.Value;
                            var terminal = node?.Element(ns + "terminal")?.Value;
                            var vessel = node?.Element(ns + "vessel")?.Value;
                            var voyage = node?.Element(ns + "voyage")?.Value;

                            var vesselInfo = node?.Element(ns + "vesselinfo");
                            var onhire = vesselInfo?.Element(ns + "onhire");
                            var onhireValue = onhire?.FirstAttribute?.Value;
                            var offhire = vesselInfo?.Element(ns + "onhire");
                            var offhireValue = offhire?.FirstAttribute?.Value;
                            var damage = vesselInfo?.Element(ns + "damage")?.Value;

                            var canalnettonnage = node?.Element(ns + "canalnettonnage")?.Value;
                            var panamateucapacity = node?.Element(ns + "panamateucapacity")?.Value;
                            var sueztier = node?.Element(ns + "sueztier")?.Value;
                            var vcistatus = node?.Element(ns + "vcistatus")?.Value;
                            var calltype = node?.Element(ns + "calltype");

                            List<string> calltypes = new List<string>();

                            foreach (XElement? ct in node.Descendants(ns + "calltype"))
                            {
                                foreach (XElement? n in ct.Elements())
                                {
                                    calltypes.Add(n.Value);
                                }
                            }

                            var bowthruster = node?.Element(ns + "bowthruster");

                            List<string> bowthrusters = new List<string>();

                            foreach (XElement? ct in node.Descendants(ns + "bowthruster"))
                            {
                                foreach (XElement? n in ct.Elements())
                                {
                                    bowthrusters.Add(n.Value);
                                }
                            }

                            var drydockrepair = node?.Element(ns + "drydockrepair");
                            var from = drydockrepair?.Element(ns + "from");
                            var fromValue = from?.FirstAttribute?.Value;

                            var to = drydockrepair?.Element(ns + "to");
                            var toValue = from?.FirstAttribute?.Value;

                            FromTo drydock = new FromTo(fromValue, toValue);

                            var comment = node?.Element(ns + "comment")?.Value;

                            main.Port = port;
                            main.Terminal = terminal;
                            main.Vessel = vessel;
                            main.Voyage = voyage;
                            VesselInfo vesselInfo1 = new VesselInfo();
                            vesselInfo1.OnHire = onhireValue == "true" ? true : false;
                            vesselInfo1.OffHire = offhireValue == "true" ? true : false;
                            vesselInfo1.Damage = Convert.ToInt32(damage);
                            main.vesselInfo = vesselInfo1;
                            main.CanalNetTonage = Convert.ToInt32(canalnettonnage);
                            main.PanamaTeuCapacity = Convert.ToInt32(panamateucapacity);
                            main.Sueztier = Convert.ToInt32(sueztier);
                            main.CallType = calltypes;
                            main.BowThruster = bowthrusters;
                            main.DryDockRepair = drydock;
                            main.Comment = comment;
                            main.VciStatus = vcistatus;
                        }

                        List<VesselBerthItem> vesselBerths = new List<VesselBerthItem>();
                        foreach (XElement node in element.Descendants(ns + "vesselberth"))
                        {
                            var vesselberthitems = node?.Elements(ns + "vesselberthitem");

                            foreach (XElement? item in vesselberthitems)
                            {
                                var id = item?.FirstAttribute?.Value;

                                var terminal = item?.Element(ns + "terminal")?.Value;
                                var arrivalberthtime = item?.Element(ns + "arrivalberthtime")?.Value;
                                var departureberthtime = item?.Element(ns + "departureberthtime")?.Value;

                                List<string> calltypes = new List<string>();

                                foreach (XElement? ct in item?.Descendants(ns + "calltype"))
                                {
                                    foreach (XElement? n in ct.Elements())
                                    {
                                        calltypes.Add(n.Value);
                                    }
                                }

                                var drydockfrom = item?.Element(ns + "drydockfrom")?.FirstAttribute?.Value;
                                var drydockto = item?.Element(ns + "drydockto")?.FirstAttribute?.Value;
                                FromTo drydock = new FromTo(drydockfrom, drydockto);

                                VesselBerthItem vitem = new VesselBerthItem();
                                vitem.ID = Convert.ToInt32(id);
                                vitem.Terminal = terminal;
                                vitem.ArrivalBerthTime = arrivalberthtime;
                                vitem.DepartureBerthTime = departureberthtime;
                                vitem.CallType = calltypes;
                                vitem.DryDock = drydock;

                                vesselBerths.Add(vitem);
                            }
                        }

                        Arrival arrival = new Arrival();
                        foreach (XElement node in element.Descendants(ns + "arrival"))
                        {
                            var vesselarrivesatpilotstationroads = node?.Element(ns + "vesselarrivesatpilotstationroads")?.Value;
                            var drifting = node?.Element(ns + "drifting");
                            var fromDrift = drifting?.Element(ns + "from")?.FirstAttribute?.Value;
                            var toDrift = drifting?.Element(ns + "to")?.FirstAttribute?.Value;
                            var dropanchor = node?.Element(ns + "dropanchor");
                            var fromDrop = dropanchor?.Element(ns + "from")?.FirstAttribute?.Value;
                            var toDrop = dropanchor?.Element(ns + "to")?.FirstAttribute?.Value;
                            var laybyberth = node?.Element(ns + "laybyberth");
                            var fromLayBerth = laybyberth?.Element(ns + "from")?.FirstAttribute?.Value;
                            var toLayBerth = laybyberth?.Element(ns + "to")?.FirstAttribute?.Value;
                            var vesselberth = node?.Element(ns + "vesselberth")?.Value;
                            var commencedtransitconvoy = node?.Element(ns + "commencedtransitconvoy")?.FirstAttribute?.Value;


                            var draft = node?.Element(ns + "draft");
                            var fwd = draft?.Element(ns + "fwd")?.Value;
                            var aft = draft?.Element(ns + "aft")?.Value;

                            var watchmen = node?.Element(ns + "watchmen")?.Value;

                            var pilotage = node.Elements(ns + "pilotage");

                            List<PilotageItem> pilotageItems = new List<PilotageItem>();
                            foreach (XElement item in pilotage.Elements(ns + "pilotageitem"))
                            {
                                var id = Convert.ToInt32(item?.Attribute("id")?.Value);
                                var pilottype = item?.Element(ns + "pilottype")?.Value;
                                var number = item?.Element(ns + "number")?.Value;
                                var from = item?.Element(ns + "from")?.Value;
                                var to = item?.Element(ns + "to")?.Value;
                                var duration = item?.Element(ns + "duration")?.Value;
                                var comment = item?.Element(ns + "comment")?.Value;

                                pilotageItems.Add(new PilotageItem(id, pilottype, number, from, to, duration, comment));

                            }
                            var pilotageextracost = node?.Element(ns + "pilotageextracost")?.Value;


                            List<TowageItem> towageItems = new List<TowageItem>();
                            var towage = node.Elements(ns + "towage");

                            foreach (XElement item in towage.Elements(ns + "towageitem"))
                            {
                                var id = Convert.ToInt32(item?.Attribute("id")?.Value);
                                var tugtype = item?.Element(ns + "tugtype")?.Value;
                                var number = item?.Element(ns + "number")?.Value;
                                var from = item?.Element(ns + "from")?.Value;
                                var to = item?.Element(ns + "to")?.Value;
                                var duration = item?.Element(ns + "duration")?.Value;
                                var duetobowthrusternotoperated = item?.Element(ns + "duetobowthrusternotoperated")?.Value;
                                var comment = item?.Element(ns + "comment")?.Value;
                                towageItems.Add(new TowageItem(id, tugtype, number, from, to, duration, duetobowthrusternotoperated, comment));
                            }
                            var gangwaydown = node?.Element(ns + "gangwaydown")?.Value;
                            var anchoragereason = node?.Element(ns + "anchoragereason")?.Value;

                            arrival.VesselArrivesAtPilotStationRoads = vesselarrivesatpilotstationroads;
                            arrival.Drifitng = new FromTo(fromDrift, toDrift);
                            arrival.DropAnchor = new FromTo(fromDrop, toDrop);
                            arrival.LayByBerth = new FromTo(fromLayBerth, toLayBerth);
                            arrival.VesselBerth = vesselberth;
                            arrival.CommencedTransitConvoy = commencedtransitconvoy == "true" ? true : false;
                            arrival.Draft = new Draft(fwd, aft);
                            arrival.Watchmen = watchmen;
                            arrival.Pilotage = pilotageItems;
                            arrival.Towage = towageItems;
                            arrival.PilotageExtraCost = pilotageextracost;
                            arrival.GangWayDown = gangwaydown;
                            arrival.AnchorageReason = anchoragereason;

                        }

                        List<VesselShiftingItem> vesselShifting = new List<VesselShiftingItem>();
                        foreach (XElement node in element.Descendants(ns + "vesselshifting"))
                        {
                            var vesselshiftingitems = node.Elements(ns + "vesselshiftingitem");

                            foreach (XElement? item in vesselshiftingitems)
                            {
                                var id = Convert.ToInt32(item?.FirstAttribute?.Value);

                                var type = item?.Element(ns + "type")?.Value;
                                var from = item?.Element(ns + "from")?.Value;
                                var to = item?.Element(ns + "to")?.Value;
                                var reason = item?.Element(ns + "reason")?.Value;
                                var pilotsnumber = item?.Element(ns + "pilotsnumber")?.Value;
                                var tugsnumber = item?.Element(ns + "tugsnumber")?.Value;
                                var mooring = item?.Element(ns + "mooring")?.Value;
                                var terminalfrom = item?.Element(ns + "terminalfrom")?.Value;
                                var terminalto = item?.Element(ns + "terminalto")?.Value;

                                vesselShifting.Add(new VesselShiftingItem(id, type, from, to, reason, pilotsnumber, tugsnumber, mooring, terminalfrom, terminalto));
                            }
                        }


                        Departure departure = new Departure();
                        foreach (XElement node in element.Descendants(ns + "departure"))
                        {
                            var draft = node?.Element(ns + "draft");
                            var fwd = draft?.Element(ns + "fwd")?.Value;
                            var aft = draft?.Element(ns + "aft")?.Value;

                            var locomotiveservice = node?.Element(ns + "locomotiveservice")?.Value;
                            var completedtransitconvoy = node?.Element(ns + "completedtransitconvoy")?.FirstAttribute?.Value;
                            var sailedfromberth = node?.Element(ns + "sailedfromberth")?.Value;

                            var anchorageout = node?.Element(ns + "dropanchor");
                            var fromAnchorageout = anchorageout?.Element(ns + "from")?.FirstAttribute?.Value;
                            var toAnchorageout = anchorageout?.Element(ns + "to")?.FirstAttribute?.Value;

                            var laybyberth = node?.Element(ns + "laybyberth");
                            var fromLayBerth = laybyberth?.Element(ns + "from")?.FirstAttribute?.Value;
                            var toLayBerth = laybyberth?.Element(ns + "to")?.FirstAttribute?.Value;

                            var pilotage = node?.Elements(ns + "pilotage");

                            List<PilotageItem> pilotageItems = new List<PilotageItem>();
                            foreach (XElement item in pilotage.Elements(ns + "pilotageitem"))
                            {
                                var id = Convert.ToInt32(item?.Attribute("id")?.Value);
                                var pilottype = item?.Element(ns + "pilottype")?.Value;
                                var number = item?.Element(ns + "number")?.Value;
                                var from = item?.Element(ns + "from")?.Value;
                                var to = item?.Element(ns + "to")?.Value;
                                var duration = item?.Element(ns + "duration")?.Value;
                                var comment = item?.Element(ns + "comment")?.Value;

                                pilotageItems.Add(new PilotageItem(id, pilottype, number, from, to, duration, comment));

                            }
                            var pilotageextracost = node?.Element(ns + "pilotageextracost")?.Value;


                            List<TowageItem> towageItems = new List<TowageItem>();
                            var towage = node.Elements(ns + "towage");

                            foreach (XElement item in towage.Elements(ns + "towageitem"))
                            {
                                var id = Convert.ToInt32(item?.Attribute("id")?.Value);
                                var tugtype = item?.Element(ns + "tugtype")?.Value;
                                var number = item?.Element(ns + "number")?.Value;
                                var from = item?.Element(ns + "from")?.Value;
                                var to = item?.Element(ns + "to")?.Value;
                                var duration = item?.Element(ns + "duration")?.Value;
                                var duetobowthrusternotoperated = item?.Element(ns + "duetobowthrusternotoperated")?.Value;
                                var comment = item?.Element(ns + "comment")?.Value;
                                towageItems.Add(new TowageItem(id, tugtype, number, from, to, duration, duetobowthrusternotoperated, comment));
                            }


                            departure.Draft = new Draft(fwd, aft);
                            departure.LocomotiveService = locomotiveservice;
                            departure.CompletedTransitConvoy = completedtransitconvoy == "true" ? true : false;
                            departure.SailedFromBerth = sailedfromberth;
                            departure.AnchorageOut = new FromTo(fromAnchorageout, toAnchorageout);
                            departure.LayByBerth = new FromTo(fromLayBerth, toLayBerth);
                            departure.Pilotage = pilotageItems;
                            departure.PilotageExtraCost = pilotageextracost;
                            departure.Towage = towageItems;

                        }
                        header.main = main;
                        header.departure = departure;
                        header.vesselBerth = vesselBerths;
                        header.arrival = arrival;
                        header.vesselShifting = vesselShifting;
                    }
                }

                Operation operation = new Operation();
                foreach (XElement? element in fullDocument.Elements(ns + "operation"))
                {
                    List<SteveDoringOperationItem> steveDoringOperationItems = new List<SteveDoringOperationItem>();
                    foreach (XElement? node in element.Descendants(ns + "stevedoringoperation"))
                    {
                        var stevedoringoperationitems = node.Elements(ns + "stevedoringoperationitem");
                        foreach (XElement item in stevedoringoperationitems)
                        {
                            var id = item?.Attribute("id")?.Value;
                            var terminal = item?.Element(ns + "terminal")?.Value;
                            var operationstarted = item?.Element(ns + "operationstarted")?.Value;
                            var operationcompleted = item?.Element(ns + "operationcompleted")?.Value;

                            var unlashing = item?.Element(ns + "unlashing");
                            var completedUnlash = unlashing?.Element(ns + "completed")?.Value;
                            var donebyUnlash = unlashing?.Element(ns + "doneby")?.Value;

                            var lashing = item?.Element(ns + "lashing");
                            var completedLash = lashing?.Element(ns + "completed")?.Value;
                            var donebyLash = lashing?.Element(ns + "doneby")?.Value;

                            List<SteveDoringDetailItem> doringDetailItems = new List<SteveDoringDetailItem>();
                            var details = item.Descendants(ns + "stevedoringdetail");
                            foreach (XElement? detailitem in details.Elements(ns + "stevedoringdetailitem"))
                            {
                                var detailId = detailitem?.Attribute("id")?.Value;
                                var operationtype = detailitem?.Element(ns + "operationtype")?.Value;
                                var stevedoringhourstype = detailitem?.Element(ns + "stevedoringhourstype")?.Value;
                                var numberofgang = detailitem?.Element(ns + "numberofgang")?.Value;
                                var shorecrane = detailitem?.Element(ns + "shorecrane")?.Value;
                                var from = detailitem?.Element(ns + "from")?.Value;
                                var to = detailitem?.Element(ns + "to")?.Value;
                                var duration = detailitem?.Element(ns + "duration")?.Value;
                                var reason = detailitem?.Element(ns + "reason")?.Value;
                                doringDetailItems.Add(new SteveDoringDetailItem(detailId, operationtype, stevedoringhourstype, numberofgang, shorecrane, from, to, duration, reason));
                            }

                            List<StoppageDetailItem> stoppageDetailItems = new List<StoppageDetailItem>();
                            var stoppagedetail = item.Descendants(ns + "stoppagedetail");
                            foreach (XElement? stoppagedetailitem in stoppagedetail.Elements(ns + "stoppagedetailitem"))
                            {
                                var stoppagedetailitemId = stoppagedetailitem?.Attribute("id")?.Value;
                                var operationtype = stoppagedetailitem?.Element(ns + "operationtype")?.Value;
                                var stoppagetype = stoppagedetailitem?.Element(ns + "stoppagetype")?.Value;
                                var stoppagetypegroup = stoppagedetailitem?.Element(ns + "stoppagetypegroup")?.Value;
                                var numberofgang = stoppagedetailitem?.Element(ns + "numberofgang")?.Value;
                                var shorecrane = stoppagedetailitem?.Element(ns + "shorecrane")?.Value;
                                var from = stoppagedetailitem?.Element(ns + "from")?.Value;
                                var to = stoppagedetailitem?.Element(ns + "to")?.Value;
                                var duration = stoppagedetailitem?.Element(ns + "duration")?.Value;
                                var description = stoppagedetailitem?.Element(ns + "description")?.Value;
                                stoppageDetailItems.Add(new StoppageDetailItem(stoppagedetailitemId, operationtype, stoppagetype, stoppagetypegroup, numberofgang, shorecrane, from, to, duration, description));
                            }

                            List<GangGuaranteeItem> gangGuaranteeItems = new List<GangGuaranteeItem>();
                            var gangguarantee = item.Descendants(ns + "gangguarantee");
                            foreach (XElement? gangguaranteeitem in gangguarantee.Elements(ns + "gangguaranteeitem"))
                            {
                                var gangguaranteeitemId = gangguaranteeitem?.Attribute("id")?.Value;
                                var from = gangguaranteeitem?.Element(ns + "from")?.Value;
                                var to = gangguaranteeitem?.Element(ns + "to")?.Value;
                                var quantity = gangguaranteeitem?.Element(ns + "quantity")?.Value;
                                var shorecrane = gangguaranteeitem?.Element(ns + "shorecrane")?.Value;
                                var comment = gangguaranteeitem?.Element(ns + "comment")?.Value;
                                gangGuaranteeItems.Add(new GangGuaranteeItem(gangguaranteeitemId, from, to, quantity, shorecrane, comment)); ;
                            }

                            SteveDoringOperationItem steveDoringOperationItem = new SteveDoringOperationItem();
                            steveDoringOperationItem.ID = id;
                            steveDoringOperationItem.Terminal = terminal;
                            steveDoringOperationItem.OperationStarted = operationstarted;
                            steveDoringOperationItem.OperationCompleted = operationcompleted;
                            steveDoringOperationItem.UnLashing = new Lash(completedUnlash, donebyUnlash);
                            steveDoringOperationItem.Lashing = new Lash(completedLash, donebyLash);
                            steveDoringOperationItem.SteveDoringDetail = doringDetailItems;
                            steveDoringOperationItem.StoppageDetail = stoppageDetailItems;
                            steveDoringOperationItem.GangGuarantee = gangGuaranteeItems;

                            steveDoringOperationItems.Add(steveDoringOperationItem);
                        }
                    }

                    List<ServiceItem> serviceItems = new List<ServiceItem>();
                    var service = element?.Element(ns + "service");

                    foreach (XElement serviceitem in service.Elements(ns + "serviceitem"))
                    {
                        var id = serviceitem?.Attribute("id")?.Value;
                        var type = serviceitem?.Element(ns + "type")?.Value;
                        var comment = serviceitem?.Element(ns + "comment")?.Value;
                        ServiceItem item = new ServiceItem();
                        item.ID = id;
                        item.Type = type;
                        item.Comment = comment;
                        serviceItems.Add(item);
                    }

                    List<BunkerItem> bunkerItems = new List<BunkerItem>();
                    var bunker = element?.Element(ns + "bunker");

                    foreach (XElement bunkeritem in bunker.Elements(ns + "bunkeritem"))
                    {
                        var id = bunkeritem?.Attribute("id")?.Value;
                        var type = bunkeritem?.Element(ns + "type")?.Value;
                        var arrival = bunkeritem?.Element(ns + "arrival")?.Value;
                        var purchase = bunkeritem?.Element(ns + "purchase")?.Value;
                        var price = bunkeritem?.Element(ns + "price")?.Value;
                        var departure = bunkeritem?.Element(ns + "departure")?.Value;
                        var bunkerremark = bunkeritem?.Element(ns + "bunkerremark")?.Value;
                        bunkerItems.Add(new BunkerItem(id, type, arrival, purchase, price, departure, bunkerremark));
                    }

                    operation.SteveDoringOperation = steveDoringOperationItems;
                    operation.Service = serviceItems;
                    operation.Bunker = bunkerItems;
                }

                Container container = new Container();
                foreach (XElement element in fullDocument.Elements(ns + "container"))
                {
                    List<ContainerDetailsOperationItem> containerDetails = new List<ContainerDetailsOperationItem>();
                    var containerdetailsoperation = element.Element(ns + "containersdetailsoperation");

                    foreach (XElement node in containerdetailsoperation.Elements(ns + "containersdetailsoperationitem"))
                    {
                        var id = node?.Attribute("id")?.Value;
                        var terminal = node?.Element(ns + "terminal")?.Value;
                        var movementtype = node?.Element(ns + "movementtype")?.Value;
                        var containeriso = node?.Element(ns + "containeriso")?.Value;
                        var fullempty = node?.Element(ns + "fullempty")?.Value;
                        var operater = node?.Element(ns + "operator")?.Value;
                        var amount = node?.Element(ns + "amount")?.Value;
                        var weight = node?.Element(ns + "weight")?.Value;
                        var oogcargo = node?.Element(ns + "oogcargo")?.Value;
                        var damagedcargo = node?.Element(ns + "damagedcargo")?.Value;
                        var imo = node?.Element(ns + "imo")?.Value;
                        var soc = node?.Element("soc")?.Value;
                        var coastalcargo = node?.Element(ns + "coastalcargo")?.Value;
                        var fromtorail = node?.Element(ns + "fromtorail")?.Value;
                        var fromtobarge = node?.Element(ns + "fromtobarge")?.Value;
                        var fromtotpf = node?.Element(ns + "fromtotpf")?.Value;
                        var fromtotruck = node?.Element(ns + "fromtotruck")?.Value;

                        ContainerDetailsOperationItem newDetails = new ContainerDetailsOperationItem();
                        newDetails.ID = id;
                        newDetails.Terminal = terminal;
                        newDetails.MovementType = movementtype;
                        newDetails.ContainerIso = containeriso;
                        newDetails.FullEmpty = fullempty;
                        newDetails.Operator = operater;
                        newDetails.Amount = amount;
                        newDetails.Weight = weight;
                        newDetails.OOGCargo = oogcargo;
                        newDetails.DamagedCargo = damagedcargo;
                        newDetails.Imo = imo;
                        newDetails.Soc = soc;
                        newDetails.CoastalCargo = coastalcargo;
                        newDetails.FromToRail = fromtorail;
                        newDetails.FromToBarge = fromtobarge;
                        newDetails.FromToTpf = fromtotpf;
                        newDetails.FromToTruck = fromtotruck;

                        containerDetails.Add(newDetails);
                    }

                    List<RestowItem> restowItems = new List<RestowItem>();
                    var restow = element.Element(ns + "restow");

                    foreach (XElement node in restow.Elements(ns + "restowitem"))
                    {
                        var id = node?.Attribute("id")?.Value;
                        var terminal = node?.Element(ns + "terminal")?.Value;
                        var movementtype = node?.Element(ns + "movementtype")?.Value;
                        var sizetype = node?.Element(ns + "sizetype")?.Value;
                        var fullempty = node?.Element(ns + "fullempty")?.Value;
                        var operater = node?.Element(ns + "operator")?.FirstAttribute?.Value == "true" ? true : false;
                        var restowsamount = node?.Element(ns + "restowsamount")?.Value;
                        var reasontype = node?.Element(ns + "reasontype")?.Value;
                        var weight = node?.Element(ns + "weight")?.Value;
                        var oog = node?.Element(ns + "oog")?.Value;
                        var imo = node?.Element(ns + "imo")?.Value;
                        var damaged = node?.Element(ns + "damaged")?.Value;
                        var notformscaccount = node?.Element(ns + "notformscaccount")?.Value;
                        var comment = node?.Element(ns + "comment")?.Value;

                        RestowItem item = new RestowItem();
                        item.ID = id;
                        item.Terminal = terminal;
                        item.MovementType = movementtype;
                        item.SizeType = sizetype;
                        item.FullEmpty = fullempty;
                        item.Operator = operater;
                        item.RestowAmount = restowsamount;
                        item.ReasonType = reasontype;
                        item.Weight = weight;
                        item.OOG = oog;
                        item.Imo = imo;
                        item.Damaged = damaged;
                        item.NotFormsAccount = notformscaccount;
                        item.Comment = comment;

                        restowItems.Add(item);
                    }

                    List<HatchCoverItem> hatchCover = new List<HatchCoverItem>();
                    var hatchcover = element.Element(ns + "hatchcover");

                    foreach (XElement node in hatchcover.Elements(ns + "hatchcoveritem"))
                    {
                        var id = node?.Attribute("id")?.Value;
                        var terminal = node?.Element(ns + "terminal")?.Value;
                        var quantity = node?.Element(ns + "quantity")?.Value;
                        var comment = node?.Element(ns + "comment")?.Value;

                        HatchCoverItem item = new HatchCoverItem();
                        item.ID = id;
                        item.Terminal = terminal;
                        item.Quantity = quantity;
                        item.Comment = comment;
                        hatchCover.Add(item);
                    }

                    container.ContainersDetailsOperation = containerDetails;
                    container.Restow = restowItems;
                    container.HatchCover = hatchCover;
                }

                vci.Header = header;
                vci.Operation = operation;
                vci.Container = container;
            }

            return vci;
        }

        public static List<VCI> GetNewXML()
        {
            string[] fileEntries = Directory.GetFiles(@"C:\Work\Liam\TestingNewXML");

            List<VCI> vciList = new List<VCI>();

            foreach (string fileEntry in fileEntries)
            {
                VCI vci = ProcessXML(fileEntry);
                vciList.Add(vci);
            }

            return vciList;
        }
        #endregion

    }



}
