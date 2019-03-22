using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WellSpring.Core.Database;
using WellSpring.Core.Interfaces;
using WellSpring.Core.Model;

namespace WellSpring.Core.ViewModels
{
    public class JourneyFoodInfoViewModel
        : MvxViewModel
    {

        private IFoodsTableDatabase foodDatabase;
        private FoodsTableAutoCompleteResult foodDetails;

        public async void Init(FoodsTableAutoCompleteResult parameters)
        {
            foodDetails = parameters;
            foodDatabase = new FoodsTableDatabaseAzure();
            var details = await foodDatabase.GetFood();
            foreach (var detail in details)
            {
                if (detail.Id == foodDetails.Id) //detail.FoodName == "ramen")
                {
                    _foodid = detail.Id;
                    Food = detail.FoodName;
                    Calorie = "" + detail.Calories;
                    Fat = "" + detail.Fat;
                    Carbohydrate = "" + detail.Carbohydrate;
                    Protein = "" + detail.Protein;
                    Fiber = "" + detail.Fiber;
                    Cholesterol = "" + detail.Cholesterol;
                    Sodium = "" + detail.Sodium;
                }
            }
        }

        private string _foodid = "";

        private string food;
        public string Food
        {
            get { return food; }
            set
            {
                if (value != null)
                {
                    SetProperty(ref food, value);
                }
            }
        }

        private string calorie;
        public string Calorie
        {
            get { return calorie; }
            set
            {
                if (value != null)
                {
                    SetProperty(ref calorie, value);
                }
            }
        }

        private string fat;
        public string Fat
        {
            get { return fat; }
            set
            {
                if (value != null)
                {
                    SetProperty(ref fat, value);
                }
            }
        }

        private string carbohydrate;
        public string Carbohydrate
        {
            get { return carbohydrate; }
            set
            {
                if (value != null)
                {
                    SetProperty(ref carbohydrate, value);
                }
            }
        }

        private string protein;
        public string Protein
        {
            get { return protein; }
            set
            {
                if (value != null)
                {
                    SetProperty(ref protein, value);
                }
            }
        }

        private string fiber;
        public string Fiber
        {
            get { return fiber; }
            set
            {
                if (value != null)
                {
                    SetProperty(ref fiber, value);
                }
            }
        }

        private string cholesterol;
        public string Cholesterol
        {
            get { return cholesterol; }
            set
            {
                if (value != null)
                {
                    SetProperty(ref cholesterol, value);
                }
            }
        }

        private string sodium;
        public string Sodium
        {
            get { return sodium; }
            set
            {
                if (value != null)
                {
                    SetProperty(ref sodium, value);
                }
            }
        }




        private MvxCommand _closeCommand;
        public ICommand CloseCommand
        {
            get
            {
                _closeCommand = _closeCommand ?? new MvxCommand(DoClose);
                return _closeCommand;
            }
        }

        public UserTableAutoCompleteResult user = new UserTableAutoCompleteResult();
        public FoodEnteredTableAutoCompleteResult entered = new FoodEnteredTableAutoCompleteResult();

        public IUserTableDatabase entereduUser;
        public IFoodEnteredTableDatabase enteredFood;

        private string _userid = "";
        public async void DoClose()
        {
            entereduUser = new UserTableDatabaseAzure();
            var details = await entereduUser.GetUser();
            foreach (var detail in details)
            {
                if (detail.Name == "Kazuko")
                {
                    _userid = detail.Id;
                }

            }

            entered.UserID = _userid;
            entered.FoodID = _foodid;
            entered.Date = DateTime.Now;

            enteredFood = new FoodEnteredTableDatabaseAzure();
            bool _checked = await enteredFood.CheckIfExists(entered);
            if (!_checked)
            {
                await enteredFood.InsertFood(entered);
            }
            //Close(JourneyFoodViewModel);
            Close(this);
        }

    }
}
