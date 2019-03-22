using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WellSpring.Core.Database;
using WellSpring.Core.Interfaces;
using WellSpring.Core.Model;

namespace WellSpring.Core.ViewModels
{
    public class CommunityMeetupViewModel
        : MvxViewModel
    {
        private MeetupsTableAutoCompleteResult meetupDetails = new MeetupsTableAutoCompleteResult();
        private IMeetupsTableDatabase meetupDatabase;
        public async void Init(MeetupsTableAutoCompleteResult parameters)
        {
            meetupDetails = parameters;
            meetupDatabase = new MeetupsTableDatabaseAzure();
            var details = await meetupDatabase.GetMeetUp();
            foreach (var detail in details)
            {
                if (detail.Id == meetupDetails.Id)
                {
                    MeetUpName = "" + detail.Name;
                    MeetUpStreet = "" + detail.AddressName;
                    MeetUpStartDateTime = "" + detail.StartDateTime;
                    MeetUpFinishDateTime = "" + detail.FinishDateTime;
                    MeetUpDescription = "" + detail.Description;
                }
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

        private string _meetUpStreet;
        public string MeetUpStreet
        {
            get { return _meetUpStreet; }
            set
            {
                if (value != null)
                {
                    SetProperty(ref _meetUpStreet, value);
                }
            }
        }

        private string _meetUpStartDateTime;
        public string MeetUpStartDateTime
        {
            get { return _meetUpStartDateTime; }
            set
            {
                if (value != null)
                {
                    SetProperty(ref _meetUpStartDateTime, value);
                }
            }
        }
        private string _meetUpFinishDateTime;
        public string MeetUpFinishDateTime
        {
            get { return _meetUpFinishDateTime; }
            set
            {
                if (value != null)
                {
                    SetProperty(ref _meetUpFinishDateTime, value);
                }
            }
        }

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

    }
}
