using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WellSpring.Core.Model
{
    public class StatisticsDetailFrameModel
    {
        public string Attribute { get; set; }
        public string DateStr { get; set; }

        public StatisticsDetailFrameModel(string attribute, string dateStr)
        {
            Attribute = attribute;
            DateStr = dateStr;
        }
    }
}
