using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WellSpring.Core.Model
{
    public class MeetupsTable
    {
        public MeetupsTable() { }
        public MeetupsTable(MeetupsTableAutoCompleteResult meetup)
        {
            HostID = meetup.HostID;
            StartDateTime = meetup.StartDateTime;
            FinishDateTime = meetup.FinishDateTime;
            AddressName = meetup.AddressName;
            Longitude = meetup.Longitude;
            Latitude = meetup.Latitude;
            Name = meetup.Name;
            Description = meetup.Description;
        }

        public string Id { get; set; }


        public string HostID { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime FinishDateTime { get; set; }
        public string AddressName { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
