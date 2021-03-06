using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using WellSpring.Core.Interfaces;
using WellSpring.Core.Model;
using System.Threading.Tasks;
using Android.Locations;

namespace WellSpring.Droid.Maps
{
    public class GeoCoder : IGeoCoder
    {
        public async Task<string> GetCityFromLocation(GeoLocation location)
        {
            var geocoder = new Geocoder(Application.Context);
            var foundLocation = await geocoder.GetFromLocationAsync(location.Latitude, location.Longitude, 1);
            return foundLocation.FirstOrDefault().Locality;
        }
    }
}