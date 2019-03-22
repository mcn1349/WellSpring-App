using MvvmCross.Core.ViewModels;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using System.Collections.ObjectModel;
using System;
using System.Windows.Input;
using System.Collections.Generic;
using WellSpring.Core.Model;
using WellSpring.Core.Interfaces;
using WellSpring.Core.Database;

namespace WellSpring.Core.ViewModels
{
    public class StatisticsViewModel
        : MvxViewModel
    {
        public ObservableCollection<GraphModel> Calories { get; set; }
        public ObservableCollection<GraphModel> Weights { get; set; }

        private ObservableCollection<StatisticsFrameModel> sFrameModels;
        public ObservableCollection<StatisticsFrameModel> SFrameModels
        {
            get { return sFrameModels; }
            set { SetProperty(ref sFrameModels, value); }
        }

        private PlotModel calModel;

        private PlotModel wModel;

        public StatisticsViewModel()
        {
            Calories = new ObservableCollection<GraphModel>();
            Weights = new ObservableCollection<GraphModel>();

            //calenDatabase = new CalendarTableDatabaseAzure();
            FakeSomeData();
            //db();

            calModel = CreateModel(Calories);
            wModel = CreateModel(Weights);
       
            sFrameModels = new ObservableCollection<StatisticsFrameModel>()
            {
                new StatisticsFrameModel("Calories", calModel),
                new StatisticsFrameModel("Weight", wModel)
            };
        }

        private LineSeries CreateSeries()
        {
            LineSeries series = new LineSeries()
            {
                MarkerType = MarkerType.Circle,
                MarkerSize = 4,
                MarkerStroke = OxyColors.White
            };

            return series;
        }

        private void axes(PlotModel plotModel, DateTime x0, DateTime x1)
        {
            var x = new DateTimeAxis();
            x.Position = AxisPosition.Bottom;
            x.IntervalType = DateTimeIntervalType.Days;
            x.IsZoomEnabled = false;
            x.IsPanEnabled = false;
            x.Minimum = DateTimeAxis.ToDouble(x0);
            x.Maximum = DateTimeAxis.ToDouble(x1);
            x.StringFormat = "dd/MM";

            var y = new LinearAxis();
            y.Position = AxisPosition.Left;
            y.IsZoomEnabled = false;
            y.IsPanEnabled = false;

            plotModel.Axes.Add(x);
            plotModel.Axes.Add(y);
        }

        private PlotModel CreateModel(ObservableCollection<GraphModel> gms)
        {
            var plotModel = new PlotModel() { DefaultColors = new List<OxyColor> { OxyColor.FromRgb(239, 103, 141) } };
            getData(plotModel, gms);

            axes(plotModel, DateTime.Now.AddDays(-7).Date, DateTime.Now.Date);

            return plotModel;
        }

        void getData(PlotModel plotModel, ObservableCollection<GraphModel> gms)
        {
            //FakeSomeData();
            //db();
            //moved to construtor

            var series = CreateSeries();

            foreach (var gm in gms)
            {
                series.Points.Add(new DataPoint(DateTimeAxis.ToDouble(gm.Date), gm.Amount));
            }

            plotModel.Series.Add(series);
        }

        void FakeSomeData()
        {
            Calories.Clear();
            Weights.Clear();

            Calories.Add(new GraphModel { Amount = 0, Date = new DateTime(2016, 10, 28) });
            Calories.Add(new GraphModel { Amount = 10, Date = new DateTime(2016, 10, 29) });
            Calories.Add(new GraphModel { Amount = 20, Date = new DateTime(2016, 10, 30) });
            Calories.Add(new GraphModel { Amount = 30, Date = new DateTime(2016, 11, 1) });

            Weights.Add(new GraphModel { Amount = 0, Date = new DateTime(2016, 10, 28) });
            Weights.Add(new GraphModel { Amount = 10, Date = new DateTime(2016, 10, 29) });
            Weights.Add(new GraphModel { Amount = 20, Date = new DateTime(2016, 10, 30) });
            Weights.Add(new GraphModel { Amount = 30, Date = new DateTime(2016, 11, 1) });
            Weights.Add(new GraphModel { Amount = 10, Date = new DateTime(2016, 11, 2) });
            Weights.Add(new GraphModel { Amount = 20, Date = new DateTime(2016, 11, 3) });
        }

        //Azure stuff
        
        private ICalendarTableDatabase calenDatabase;

        public async void db()
        {
            calenDatabase = new CalendarTableDatabaseAzure();
            var details = await calenDatabase.GetCalendar();
            foreach (var row in details)
            {
                Calories.Add(new GraphModel { Amount = row.Calorie, Date = row.Date.Date });
                Weights.Add(new GraphModel { Amount = row.Weight, Date = row.Date.Date });
            }
        }
 
    }
}