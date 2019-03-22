using MvvmCross.Core.ViewModels;
using OxyPlot;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using WellSpring.Core.Interfaces;
using WellSpring.Core.ViewModels;

namespace WellSpring.Core.Model
{
    public class StatisticsFrameModel : MvxViewModel
    {
        public string Title { get; set; }
        public PlotModel PlotModel { get; set; }
        public ICommand GotoDetail { get; set; }

        public StatisticsFrameModel(string title, PlotModel plotModel)
        {
            Title = title;
            PlotModel = plotModel;
            GotoDetail = new MvxCommand(() =>
                 ShowViewModel<StatisticsDetailViewModel>(new DateModel() { Title = title, Start = DateTime.Now.AddDays(-7).ToString("MM/dd/yyyy"), End = DateTime.Now.ToString("MM/dd/yyyy") })
               );
        }


    }
}
