using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WellSpring.Core.Model
{
    public class CalendarTable
    {

        public CalendarTable() { }
        public CalendarTable(CalendarTableAutoCompleteResult calen)
        {
            Id = calen.Id;
            Date = calen.Date;
            UserId = calen.UserId;
            Calorie = calen.Calorie;
            Weight = calen.Weight;
            AimWeight = calen.AimWeight;
            Version = calen.Version;
            CreatedAt = calen.CreatedAt;
            UpdatedAt = calen.UpdatedAt;
            Deleted = calen.Deleted;
        }

        public string Id { get; set; }
        public DateTime Date { get; set; }
        public string UserId { get; set; }
        public int Calorie { get; set; }
        public int Weight { get; set; }
        public int AimWeight { get; set; }
        public int Version { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool Deleted { get; set; }

    }
}
