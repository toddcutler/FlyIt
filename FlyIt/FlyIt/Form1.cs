using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp.WinForms;
using CefSharp;
using System.Threading;
using Newtonsoft.Json;
using System.IO;
using Microsoft.SqlServer.Types;
using FlyIt.BusinessObject;

namespace FlyIt
{
    public partial class bntPlaneAdd : Form
    {
        private const string _vor_image = @"VOR_Label.svg";
        private const string _fix_image = @"Fix_Label.svg";
        private const string _plane_icon = @"aircraft.svg";

        private static readonly string _myPath = Application.StartupPath;
        private static readonly string _pagesPath = Path.Combine(_myPath, "FlyItWeb");
        private static readonly string _pointsPath = Path.Combine(_myPath, "Points");
        private static readonly string _airportsPath = Path.Combine(_myPath, "Airports");

        private List<Fix> _fixes = new List<Fix>();
        private List<Vor> _vors = new List<Vor>();
        private List<Airport> _airports = new List<Airport>();
        private List<SessionInfo> _sessions = new List<SessionInfo>();


        private readonly ChromiumWebBrowser browser;
        private static System.Timers.Timer aTimer;
        private Airport selectedAirport = new Airport();
        private View selectedView = new View();
        private List<FlightInfo> previousFlights = new List<FlightInfo>();

        public bntPlaneAdd()
        {
            InitializeComponent();

            WindowState = FormWindowState.Maximized;

            var settings = new CefSharp.CefSettings { RemoteDebuggingPort = 8088 };
            CefSharp.Cef.Initialize(settings);

            var defaultPage = Path.Combine(_pagesPath, "flyit.htm");

            browser = new ChromiumWebBrowser(defaultPage)
            {
                Dock = DockStyle.Fill,
            };
            pnlBrowser.Controls.Add(browser);

            //browser.IsBrowserInitializedChanged += browser_IsBrowserInitializedChanged;
	        browser.FrameLoadEnd += browser_FrameLoadEnd;

            Task.Run(async () =>
            {
                _sessions = await InfiniteFlightAccess.GetSessionInfo();
            }).Wait();

            // Create a timer with a two second interval.
            aTimer = new System.Timers.Timer(2000);

            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;

            // Have the timer fire repeated events (true is the default)
            aTimer.AutoReset = true;

            aTimer.Stop();

            //
            var dataPath = Path.Combine(_pointsPath, "Fixes.json");
            _fixes = JsonConvert.DeserializeObject<List<Fix>>(File.ReadAllText(dataPath));

            dataPath = Path.Combine(_pointsPath, "VOR.json");
            _vors = JsonConvert.DeserializeObject<List<Vor>>(File.ReadAllText(dataPath));

            dataPath = Path.Combine(_airportsPath, "airports.json");
            _airports = JsonConvert.DeserializeObject<List<Airport>>(File.ReadAllText(dataPath));

            var regions = _airports.Select(x => x.Region).Distinct().ToList();
            cbxRegions.DataSource = regions;

            cbxViews.DataSource = Globals.ViewList;
            cbxViews.DisplayMember = "ViewName";
            cbxViews.ValueMember = "Radius";

            var tmp = _sessions.FirstOrDefault(x => x.Name.Contains("Playground"));

            cbxSession.DataSource = _sessions;
            cbxSession.DisplayMember = "Name";
            cbxSession.ValueMember = "Id";
            cbxSession.SelectedItem = tmp.Name;

        }

        private void LoadAirportsByRegion(string region)
        {
            var airportList = _airports.Where(y => y.Region == region).Select(x => x.IcaoCode).ToList();

            cbxAirports.DataSource = airportList;
        }

        public void PlotPlane(FlightInfo flight)
        {
            int heading = (int)(Math.Round(flight.Track / 10) * 10);

            string functionCall = "displayPlane('{0}', {1}, {2}, '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', {11}, '{12}', '{13}', '{14}', '{15}')";

            var script = string.Format(functionCall,
                _plane_icon, flight.Longitude, flight.Latitude, flight.CallSign, flight.IconClass, flight.Aircraft, flight.Livery, flight.Track.ToString(), flight.Altitude.ToString(), flight.DisplayName, flight.FlightID, flight.LastReportUTC, flight.Speed.ToString(), flight.UserID, flight.VerticalSpeed.ToString(), Globals.SelectedSession.Id);

            Task.Run(() =>
            {
                if (browser.IsBrowserInitialized)
                {
                    browser.ExecuteScriptAsync(script);
                }
            }).Wait();

        }

        public void ClearPlane(string id)
        {
            string functionCall = "clearPlane('{0}')";

            var script = string.Format(functionCall, id);

            Task.Run(() =>
            {
                if (browser.IsBrowserInitialized)
                {
                    browser.ExecuteScriptAsync(script);
                }
            }).Wait();

        }

        public void PlotItem(string function, string Image, double lng, double lat)
        {
            string functionCall = "{0}('{1}', {2}, {3})";

            var script = string.Format(functionCall, function, Image, lng, lat);

            Task.Run(() =>
            {
                if (browser.IsBrowserInitialized)
                {
                    browser.ExecuteScriptAsync(script);
                }
            }).Wait();
        }

        public void DisplayVors()
        {
            foreach (var vor in _vors)
            {
                PlotItem("plotVorItem", _vor_image, vor.Longitude, vor.Latitude);
            }
        }

        public void RemoveVors()
        {
            Task.Run(() =>
            {
                if (browser.IsBrowserInitialized)
                {
                    browser.ExecuteScriptAsync("clearVors()");
                }
            }).Wait();
        }

        public void DisplayFixes()
        {
            foreach (var fix in _fixes)
            {
                PlotItem("plotFixItem", _fix_image, fix.Longitude, fix.Latitude);
            }
        }

        public void RemoveFixes()
        {
            Task.Run(() =>
            {
                if (browser.IsBrowserInitialized)
                {
                    browser.ExecuteScriptAsync("clearFixes()");
                }
            }).Wait();
        }

        public void DisplayAircraft()
        {
            aTimer.Stop();
            //Get Aircraft
            List<FlightInfo> flights = new List<FlightInfo>();

            Task.Run(async () =>
            {
                try
                {
                    flights = await InfiniteFlightAccess.GetFlights(Globals.SelectedSession.Id);
                }
                catch (Exception ex)
                {
                }
            }).Wait();

            double radius = selectedView.Radius * 1609.344;

            //LAX coordinates
            var yourLocation = SqlGeography.Point(selectedAirport.CenterLat, selectedAirport.CenterLng, 4326);

            var query = from flight in flights
                        let distance = SqlGeography
                                      .Point(flight.Latitude, flight.Longitude, 4326)
                                      .STDistance(yourLocation)
                                      .Value
                        where distance < radius
                        orderby distance
                        select flight;

            var flightsInRadius = query.Distinct().ToList();

            foreach (var flight in flightsInRadius)
            {
                PlotPlane(flight);
            }

            if (previousFlights.Count() != flightsInRadius.Count())
            {
                var result = previousFlights.Where(p => !flightsInRadius.Any(p2 => p2.FlightID == p.FlightID));

                foreach(var flight in result)
                {
                    ClearPlane(flight.FlightID);
                }
            }

            previousFlights = flightsInRadius;

            aTimer.Start();
        }

        public void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            //Test(source, e);
            DisplayAircraft();

            //aTimer.Interval = 5000;
        }

	    public void InitializeView(View view, Airport airport)
	    {
            string functionCall = "initializeViewInfo({0}, {1}, '{2}', {3}, {4}, {5}, {6}, {7}, {8})";

            var script = string.Format(functionCall, view.Radius, view.Zoom, airport.ImageName, airport.CenterLng, airport.CenterLat, 
                airport.SouthWestLng, airport.SouthWestLat, airport.NorthEastLng, airport.NorthEastLat);

            Task.Run(() =>
            {
                if (browser.IsBrowserInitialized)
                {
                    browser.ExecuteScriptAsync(script);
                }
            }).Wait();
	    }

        private delegate void SetBtnSelectDelegate();
        void SetBtnSelect()
        {
            btnSelect.Enabled = true;
        }


		void browser_FrameLoadEnd(object sender, CefSharp.FrameLoadEndEventArgs e)
		{
            this.BeginInvoke(new SetBtnSelectDelegate(SetBtnSelect), null);
		}

        private void checkVors_CheckedChanged(object sender, EventArgs e)
        {
            if (checkVors.Checked)
            {
                DisplayVors();
            }
            else
            {
                RemoveVors();
            }
        }

        private void checkFixes_CheckedChanged(object sender, EventArgs e)
        {
            if (checkFixes.Checked)
            {
                DisplayFixes();
            }
            else
            {
                RemoveFixes();
            }
        }

        private void cbxRegions_SelectedIndexChanged(object sender, EventArgs e)
        {
            string region = (string)cbxRegions.SelectedItem;

            LoadAirportsByRegion(region);
        }

        private void cbxAirports_SelectedIndexChanged(object sender, EventArgs e)
        {
            var x = 0;
        }

        private void cbxViews_SelectedIndexChanged(object sender, EventArgs e)
        {
            var view = (View)cbxViews.SelectedItem;

            string functionCall = "setViewRadius({0})";

            var script = string.Format(functionCall, view.Radius);

            Task.Run(() =>
            {
                if (browser.IsBrowserInitialized)
                {
                    browser.ExecuteScriptAsync(script);
                }
            }).Wait();

            selectedView = view;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            aTimer.Stop();

            var region = cbxRegions.SelectedItem;
            var ioc = cbxAirports.SelectedItem;

            selectedView = (View)cbxViews.SelectedItem;

            selectedAirport = _airports.FirstOrDefault(x => x.Region == region && x.IcaoCode == ioc);

            InitializeView(selectedView, selectedAirport);

            DisplayAircraft();

            aTimer.Start();
        }

        private void cbxSession_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool isTimerStarted = aTimer.Enabled;

            aTimer.Stop();

            Globals.SelectedSession = (SessionInfo)cbxSession.SelectedItem;

            Task.Run(() =>
            {
                if (browser.IsBrowserInitialized)
                {
                    browser.ExecuteScriptAsync("clearPlanes()");
                }
            }).Wait();

            if (isTimerStarted) aTimer.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var flight = new FlightInfo();

            flight.Latitude = 33.943414;
            flight.Longitude = -118.408433;
            flight.FlightID = "1234";

            PlotPlane(flight);
        }

        private void btnPlaneRemove_Click(object sender, EventArgs e)
        {
            ClearPlane("1234");
        }
    }
}
