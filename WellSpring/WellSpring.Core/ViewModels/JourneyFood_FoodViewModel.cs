using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WellSpring.Core.Database;
using WellSpring.Core.Interfaces;
using WellSpring.Core.Model;

namespace WellSpring.Core.ViewModels
{
    public class JourneyFood_FoodViewModel
        : MvxViewModel
    {
        private ObservableCollection<FoodsTable> meals;
        public ObservableCollection<FoodsTable> Meals
        {
            get { return meals; }
            set { SetProperty(ref meals, value); }
        }
        

        public ICommand GoFoodInfoCommand { get; private set; }

        public JourneyFood_FoodViewModel()
        {
            Meals = new ObservableCollection<FoodsTable>();
            startup();
            GoFoodInfoCommand = new MvxCommand<FoodsTable>(foodDetails =>
            {
                ShowViewModel<JourneyFoodInfoViewModel>(foodDetails);
            });
        }
        private IFoodsTableDatabase foodDatabase;
        private async void startup()
        {
            foodDatabase = new FoodsTableDatabaseAzure();
            var details = await foodDatabase.GetFood();
            foreach (var detail in details)
            {
                Meals.Add(detail);
            }
        }

        // Custom Food
        private MvxCommand _goCustomFoodCommand;
        public ICommand GoCustomFoodCommand
        {
            get
            {
                _goCustomFoodCommand = _goCustomFoodCommand ?? new MvxCommand(DoGoCustomFood);
                return _goCustomFoodCommand;
            }
        }

        public void DoGoCustomFood()
        {
            ShowViewModel<JourneyCustomFoodViewModel>();
        }

    }
}
