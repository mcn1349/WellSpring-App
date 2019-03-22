using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WellSpring.Core.Database;
using WellSpring.Core.Interfaces;
using WellSpring.Core.Model;
using WellSpring.Core.Services;

namespace WellSpring.Core.ViewModels
{
    public class CommunityCreateMeetupViewModel
        : MvxViewModel
    {

        private readonly IDialogService dialog;
        private readonly ILocationsDatabase locationsDatabase;
        private ObservableCollection<LocationAutoCompleteResult> locations;
        public ObservableCollection<LocationAutoCompleteResult> Locations
        {
            get { return locations; }
            set { SetProperty(ref locations, value); }
        }

        private string searchTerm;

        public string SearchTerm
        {
            get { return searchTerm; }
            set
            {
                SetProperty(ref searchTerm, value);
                if (searchTerm.Length > 3)
                {
                    SearchLocations(searchTerm);
                }
            }
        }

        public ICommand SelectLocationCommand { get; private set; }

        public CommunityCreateMeetupViewModel(IDialogService dialog, ILocationsDatabase locationsDatabase)
        {
            this.dialog = dialog;
            this.locationsDatabase = locationsDatabase;
            Locations = new ObservableCollection<LocationAutoCompleteResult>();
            SelectLocationCommand = new MvxCommand<LocationAutoCompleteResult>(selectedLocation =>
            {
                searchTerm = selectedLocation.LocalizedName;
            });
        }

        public async void SelectLocation(LocationAutoCompleteResult selectedLocation)
        {

            if (!await locationsDatabase.CheckIfExists(selectedLocation))
            {
                await locationsDatabase.InsertLocation(selectedLocation);

                Close(this);
            }
            else
            {
                if (await dialog.Show("This location has already been added", "Location Exists", "Keep Searching", "Go Back"))
                {
                    SearchTerm = string.Empty;
                    Locations.Clear();
                }
                else
                {
                    Close(this);
                }
            }
        }

        public async void SearchLocations(string searchTerm)
        {
            WeatherService weatherService = new WeatherService();
            Locations.Clear();
            var locationResults = await weatherService.GetLocations(searchTerm);
            var bestLocationResults = locationResults.Where(location => location.Rank > 80);
            foreach (var item in bestLocationResults)
            {
                Locations.Add(item);
            }
        }

        private string _meetUpName;
        public string MeetUpName
        {
            get { return _meetUpName; }
            set
            {
                if (value != null)
                {
                    SetProperty(ref _meetUpName, value);
                }
            }
        }
        
        DateTime MeetUpStartDateTime = DateTime.Now;
        DateTime MeetUpFinishDateTime = DateTime.Now;

        private string _meetUpDescription;
        public string MeetUpDescription
        {
            get { return _meetUpDescription; }
            set
            {
                if (value != null)
                {
                    SetProperty(ref _meetUpDescription, value);
                }
            }
        }
        
        private MvxCommand _createMeetUpCommand;

        public ICommand CreateMeetupCommand
        {
            get
            {
                _createMeetUpCommand = _createMeetUpCommand ?? new MvxCommand(DoCreateMeetUp);
                return _createMeetUpCommand;
            }
        }

        public double MeetUpLatitude { get; private set; }
        public double MeetUpLongitude { get; private set; }
        public string MeetUpStreet { get; private set; }

        private MeetupsTable meeting = new MeetupsTable();
        private IMeetupsTableDatabase Meet;
        public void DoCreateMeetUp()
        {
            Meet = new MeetupsTableDatabaseAzure();
            meeting.Name = MeetUpName;
            meeting.AddressName = MeetUpStreet;
            meeting.Longitude = MeetUpLongitude;
            meeting.Latitude = MeetUpLatitude;
            meeting.StartDateTime = MeetUpStartDateTime;
            meeting.FinishDateTime = MeetUpFinishDateTime;
            meeting.Description = MeetUpDescription;
            Meet.InsertMeetUp(meeting);
            Close(this);
        }
    }
}
