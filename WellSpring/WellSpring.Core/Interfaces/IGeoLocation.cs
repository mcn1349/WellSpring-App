using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WellSpring.Core.Model;

namespace WellSpring.Core.Interfaces
{
    public interface IGeoCoder
    {
        Task<string> GetCityFromLocation(GeoLocation location);
    }
}
