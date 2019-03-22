using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WellSpring.Core.Interfaces;

namespace WellSpring.Core.Model
{
    public class DateModel
    {
        public string Title { get; set; }
        public string Start { get; set; }
        public string End { get; set; }
        //public ObservableCollection<GraphModel> Gms { get; set; }
        //public ICalendarTableDatabase CalenDatabase { get; set; }
        public DateModel() { }
        public DateModel(string title, string start, string end)
        {
            Title = title;
            Start = start;
            End = end;
            //CalenDatabase = calenDatabase;
        }
    }
}
