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
    public class JourneyCustomFoodViewModel
        : MvxViewModel
    {
        private bool hasLetters(string message)
        {
            int accept;
            if (message != "" || message != null)
            {
                return int.TryParse(message, out accept);
            }
            return false;

        }

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

        private string ingredients;
        public string Ingredients
        {
            get { return ingredients; }
            set
            {
                if (value != null)
                {
                    SetProperty(ref ingredients, value);
                }
            }
        }

        private string method;
        public string Method
        {
            get { return method; }
            set
            {
                if (value != null)
                {
                    SetProperty(ref method, value);
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

        public ICommand ReceipeCommand { get; private set; }
        public ICommand AddCommand { get; private set; }
        public ICommand ShareCommand { get; private set; }

        public ICommand SelectUnitCommand { get; private set; }

        public JourneyCustomFoodViewModel()
        {
            ReceipeCommand = new MvxCommand(() => {
                Food = "Katsudon (pork)";
                Ingredients = "";
                Method = "";
                Calorie = "679";
                Fat = "16";
                Carbohydrate = "92";
                Protein = "41";
                Fiber = "2";
                Cholesterol = "353";
                Sodium = "1625";
            });
            AddCommand = new MvxCommand(() => {
                if (!hasLetters(food) && hasLetters(calorie) && hasLetters(fat) &&
                hasLetters(carbohydrate) && hasLetters(protein) && hasLetters(fiber)
                && hasLetters(cholesterol) && hasLetters(sodium))
                {
                    listadd();

                }
            });
            ShareCommand = new MvxCommand(() => {
                Food = "";
                Ingredients = "";
                Method = "";
                Calorie = "";
                Fat = "";
                Carbohydrate = "";
                Protein = "";
                Fiber = "";
                Cholesterol = "";
                Sodium = "";
            });/*
            SelectUnitCommand = new MvxCommand<FoodList>(list =>
            {
                Food = list.Food;
                Ingredients = list.Ingredients;
                Method = list.Method;
                Calorie = list.Calorie;
                Fat = list.Fat;
                Carbohydrate = list.Carbohydrate;
                Protein = list.Protein;
                Fiber = list.Fiber;
                Cholesterol = list.Cholestrol;
                Sodium = list.Sodium;
            });*/
        }
        private void listadd()
        {
            AddFood(new FoodList(food, ingredients, method, calorie, fat, carbohydrate, protein, fiber, cholesterol, sodium));
            RaisePropertyChanged(() => FoodA);
        }
        public void AddFood(FoodList list)
        {
            if (list.Calorie != null && list.Carbohydrate != null && list.Cholestrol != null
                && list.Fat != null && list.Fiber != null && list.Food != null && list.Ingredients != null
                && list.Protein != null && list.Sodium != null)
            {
                if (list.Calorie.Trim() != string.Empty && list.Carbohydrate.Trim() != string.Empty &&
                    list.Cholestrol.Trim() != string.Empty && list.Fat.Trim() != string.Empty &&
                    list.Fiber.Trim() != string.Empty && list.Food.Trim() != string.Empty
                    && list.Ingredients.Trim() != string.Empty && list.Protein.Trim() != string.Empty
                    && list.Sodium.Trim() != string.Empty)
                {
                    FoodA.Add(list);
                }
                else
                {
                    Food = list.Food;
                    Method = list.Method;
                    Calorie = list.Calorie;
                    Fat = list.Fat;
                    Carbohydrate = list.Carbohydrate;
                    Protein = list.Protein;
                    Fiber = list.Fiber;
                    Cholesterol = list.Cholestrol;
                    Sodium = list.Sodium;
                }
            }
        }
        private ObservableCollection<FoodList> foodA;
        public ObservableCollection<FoodList> FoodA
        {
            get { return foodA; }
            set { SetProperty(ref foodA, value); }
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

        private IFoodsTableDatabase foodDatabase;

        private FoodsTableAutoCompleteResult customFood = new FoodsTableAutoCompleteResult();

        public void DoClose()
        {
            customFood.FoodName = "" + Food;
            customFood.FoodIngredients = "" + Ingredients;
            customFood.FoodMethod = "" + Method;

            bool ProteinCorrect = true;
            int ProteinVal = 0;
            ProteinCorrect = int.TryParse(Protein, out ProteinVal);
            customFood.Protein = ProteinVal;

            bool CalorieCorrect = true;
            int CalorieVal = 0;
            CalorieCorrect = int.TryParse(Calorie, out CalorieVal);
            customFood.Calories = CalorieVal;

            bool FatCorrect = true;
            int FatVal = 0;
            FatCorrect = int.TryParse(Fat, out FatVal);
            customFood.Fat = FatVal;

            bool CarbohydrateCorrect = true;
            int CarbohydrateVal = 0;
            CarbohydrateCorrect = int.TryParse(Carbohydrate, out CarbohydrateVal);
            customFood.Carbohydrate = CarbohydrateVal;

            bool FiberCorrect = true;
            int FiberVal = 0;
            FiberCorrect = int.TryParse(Fiber, out FiberVal);
            customFood.Fiber = FiberVal;

            bool CholesterolCorrect = true;
            int CholesterolVal = 0;
            CholesterolCorrect = int.TryParse(Cholesterol, out CholesterolVal);
            customFood.Cholesterol = CholesterolVal;

            bool SodiumCorrect = true;
            int SodiumVal = 0;
            SodiumCorrect = int.TryParse(Sodium, out SodiumVal);
            customFood.Sodium = SodiumVal;

            bool correctValues = (ProteinCorrect && CalorieCorrect && FatCorrect && CarbohydrateCorrect && FiberCorrect && CholesterolCorrect && SodiumCorrect);
            if (correctValues)
            {
                foodDatabase = new FoodsTableDatabaseAzure();
                foodDatabase.InsertFood(customFood);
                Close(this);
            }
        }

        // change all number related ones into ints, and just use tostring
    }
}
