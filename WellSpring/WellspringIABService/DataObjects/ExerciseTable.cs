using Microsoft.Azure.Mobile.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WellspringIABService.DataObjects
{
    public class ExerciseTable : EntityData
    {
        public string ExerciseType { get; set; }
        public string Name { get; set; }

        public int Distance { get; set; }

        public int Laps { get; set; }

        public int Sets { get; set; }

        public int Duration { get; set; }

        public int Calories { get; set; }

    }
}