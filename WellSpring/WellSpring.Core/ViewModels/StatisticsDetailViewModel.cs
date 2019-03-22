using MvvmCross.Core.ViewModels;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using System.Collections.ObjectModel;
using System;
using System.Windows.Input;
using System.ComponentModel;
using System.Collections.Generic;
using WellSpring.Core.Model;
using WellSpring.Core.Interfaces;
using WellSpring.Core.Database;

namespace WellSpring.Core.ViewModels
{
    public class StatisticsDetailViewModel
        : MvxViewModel, INotifyPropertyChanged
    {
        public ObservableCollection<GraphModel> gms1 { get; set; }

        private PlotModel plotModel;
        public PlotModel PlotModel
        {
            get { return plotModel; }
            set { SetProperty(ref plotModel, value); }
        }

        private DateTime from;
        public DateTime From
        {
            get { return from; }
            set { SetProperty(ref from, value); }

        }

        private DateTime to;
        public DateTime To
        {
            get { return to; }
            set { SetProperty(ref to, value); }
        }

        private String fromStr;
        public String FromStr
        {
            get { return fromStr; }
            set
            {
                SetProperty(ref fromStr, value);
                from = Convert.ToDateTime(fromStr);
                axes(plotModel, from, to);
                plotModel.InvalidatePlot(true);
                RaiseAllPropertiesChanged();
            }
        }

        private String toStr;
        public String ToStr
        {
            get { return toStr; }
            set
            {
                SetProperty(ref toStr, value);
                to = Convert.ToDateTime(toStr);
                axes(plotModel, from, to);
                plotModel.InvalidatePlot(true);
                RaiseAllPropertiesChanged();
            }
        }


        private String title;
        public String Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        private ICalendarTableDatabase calenDatabase { get; set; }
        public void Init(DateModel para)
        {
            title = para.Title;
            fromStr = para.Start;
            toStr = para.End;
        }


        public StatisticsDetailViewModel()
        {
            from = DateTime.Now.AddDays(-7);
            to = DateTime.Now;

            gms1 = new ObservableCollection<GraphModel>();

            FakeSomeData();
            //db();

            plotModel = CreateModel(gms1);
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
            plotModel.Axes.Clear();

            var x = new DateTimeAxis();
            x.Position = AxisPosition.Bottom;
            x.IntervalType = DateTimeIntervalType.Days;
            x.IsZoomEnabled = false;
            x.IsPanEnabled = false;
            x.Minimum = DateTimeAxis.ToDouble(x0);
            x.Maximum = DateTimeAxis.ToDouble(x1);
            x.StringFormat = "MM/dd/yyyy";

            var y = new LinearAxis();
            y.Position = AxisPosition.Left;
            y.IsZoomEnabled = false;
            y.IsPanEnabled = false;

            plotModel.Axes.Add(x);
            plotModel.Axes.Add(y);
        }

        private PlotModel CreateModel(ObservableCollection<GraphModel> gms)
        {
            //gms.Clear();

            var plotModel = new PlotModel() { DefaultColors = new List<OxyColor> { OxyColor.FromRgb(239, 103, 141) } };

            getData(plotModel, gms);

            axes(plotModel, From, To);

            return plotModel;
        }

        void getData(PlotModel plotModel, ObservableCollection<GraphModel> gms)
        {
            var series = CreateSeries();

            foreach (var gm in gms)
            {
                series.Points.Add(new DataPoint(DateTimeAxis.ToDouble(gm.Date), gm.Amount));
            }

            plotModel.Series.Add(series);
        }

        void FakeSomeData()
        {
            gms1.Add(new GraphModel { Amount = 0, Date = new DateTime(2016, 9, 28) });
            gms1.Add(new GraphModel { Amount = 10, Date = new DateTime(2016, 9, 29) });
            gms1.Add(new GraphModel { Amount = 20, Date = new DateTime(2016, 9, 30) });
            gms1.Add(new GraphModel { Amount = 30, Date = new DateTime(2016, 10, 1) });
            gms1.Add(new GraphModel { Amount = 10, Date = new DateTime(2016, 11, 2) });
            gms1.Add(new GraphModel { Amount = 20, Date = new DateTime(2016, 11, 3) });

        }

        public async void db()
        {
            calenDatabase = new CalendarTableDatabaseAzure();
            var details = await calenDatabase.GetCalendar();
            if (Title == "Calories")
            {
                gms1.Clear();
                foreach (var row in details)
                {
                    gms1.Add(new GraphModel { Amount = row.Calorie, Date = row.Date.Date });
                }
            }
            else
            {
                gms1.Clear();
                foreach (var row in details)
                {
                    gms1.Add(new GraphModel { Amount = row.Weight, Date = row.Date.Date });
                }
            }
        }
    }
}