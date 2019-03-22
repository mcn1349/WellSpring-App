using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Web.Http;
using Microsoft.Azure.Mobile.Server;
using Microsoft.Azure.Mobile.Server.Authentication;
using Microsoft.Azure.Mobile.Server.Config;
using WellspringIABService.DataObjects;
using WellspringIABService.Models;
using Owin;

namespace WellspringIABService
{
    public partial class Startup
    {
        public static void ConfigureMobileApp(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();

            //For more information on Web API tracing, see http://go.microsoft.com/fwlink/?LinkId=620686 
            config.EnableSystemDiagnosticsTracing();

            new MobileAppConfiguration()
                .UseDefaultConfiguration()
                .ApplyTo(config);

            // Use Entity Framework Code First to create database tables based on your DbContext
            Database.SetInitializer(new WellspringIABInitializer());
            Database.SetInitializer(new CalendarTableInitializer());
            Database.SetInitializer(new CommentTableInitializer());
            Database.SetInitializer(new CommunityPostTableInitializer());
            Database.SetInitializer(new ConsultTableInitializer());
            Database.SetInitializer(new CustomFoodsTableInitializer());
            Database.SetInitializer(new ExerciseEnteredTableInitializer());
            Database.SetInitializer(new ExerciseTableInitializer());
            Database.SetInitializer(new FoodEnteredTableInitializer());
            Database.SetInitializer(new FoodsTableInitializer());
            Database.SetInitializer(new GoalTableInitializer());
            Database.SetInitializer(new GroupMeetUpTableInitializer());
            Database.SetInitializer(new JourneyTableInitializer());
            Database.SetInitializer(new MeetUpTableInitializer());
            Database.SetInitializer(new NurseTableInitializer());
            Database.SetInitializer(new UserTableInitializer());
            // To prevent Entity Framework from modifying your database schema, use a null database initializer
            // Database.SetInitializer<WellspringIABContext>(null);

            MobileAppSettingsDictionary settings = config.GetMobileAppSettingsProvider().GetMobileAppSettings();

            if (string.IsNullOrEmpty(settings.HostName))
            {
                // This middleware is intended to be used locally for debugging. By default, HostName will
                // only have a value when running in an App Service application.
                app.UseAppServiceAuthentication(new AppServiceAuthenticationOptions
                {
                    SigningKey = ConfigurationManager.AppSettings["SigningKey"],
                    ValidAudiences = new[] { ConfigurationManager.AppSettings["ValidAudience"] },
                    ValidIssuers = new[] { ConfigurationManager.AppSettings["ValidIssuer"] },
                    TokenHandler = config.GetAppServiceTokenHandler()
                });
            }
            app.UseWebApi(config);
        }
    }

    public class WellspringIABInitializer : CreateDatabaseIfNotExists<WellspringIABContext>
    {
        protected override void Seed(WellspringIABContext context)
        {
            List<TodoItem> todoItems = new List<TodoItem>
            {
                new TodoItem { Id = Guid.NewGuid().ToString(), Text = "First item", Complete = false },
                new TodoItem { Id = Guid.NewGuid().ToString(), Text = "Second item", Complete = false },
            };

            foreach (TodoItem todoItem in todoItems)
            {
                context.Set<TodoItem>().Add(todoItem);
            }

            base.Seed(context);
        }
    }

    public class CalendarTableInitializer : CreateDatabaseIfNotExists<CalendarTableContext>
    {
        protected override void Seed(CalendarTableContext context)
        {
            var calendar = new CalendarTable
            {
                Date = DateTime.Now,
                UserId = "1",
                Calorie = 100,
                Weight = 80,
                AimWeight = 70
            };
            context.Set<CalendarTable>().Add(calendar);
            base.Seed(context);
        }
    }

    public class CommentTableInitializer : CreateDatabaseIfNotExists<CommentTableContext>
    {
        protected override void Seed(CommentTableContext context)
        {
            var comment = new CommentTable
            {
                HostID = "1",
                UserID = "1",
                PostID = "1",
                Description = "Charles:This party sucks; Ichika:I know;"
            };
            context.Set<CommentTable>().Add(comment);
            base.Seed(context);
        }
    }

    
    public class CommunityPostTableInitializer : CreateDatabaseIfNotExists<CommunityPostTableContext>
    {
        protected override void Seed(CommunityPostTableContext context)
        {
            var post = new CommunityPostTable
            {
                 HostID = "1",
                 Description = "postal",
                 Image = "  "
            };
            context.Set<CommunityPostTable>().Add(post);
            base.Seed(context);
        }
    }

    public class ConsultTableInitializer : CreateDatabaseIfNotExists<ConsultTableContext>
    {
        protected override void Seed(ConsultTableContext context)
        {
            var consult = new ConsultTable
            {
                NurseID = "1",
                PatientID = "2",
                Question = "I have a sore throat",
                Detail = "i have difficulty breathing"
            };
            context.Set<ConsultTable>().Add(consult);
            base.Seed(context);
        }
    }

    public class CustomFoodsTableInitializer : CreateDatabaseIfNotExists<CustomFoodsTableContext>
    {
        protected override void Seed(CustomFoodsTableContext context)
        {
            var custom = new CustomFoodsTable
            {
                UserID = "1",
                FoodName = "Soup",
                FoodIngredients = "Water",
                FoodMethod = "Boil",
                Protein = 100,
                Calories = 100,
                Fat = 100,
                Carbohydrate = 100,
                Fiber = 100,
                Cholesterol = 100,
                Sodium = 100
            };
            context.Set<CustomFoodsTable>().Add(custom);
            base.Seed(context);
        }
    }

    public class ExerciseEnteredTableInitializer : CreateDatabaseIfNotExists<ExerciseEnteredTableContext>
    {
        protected override void Seed(ExerciseEnteredTableContext context)
        {
            var exerciseEntered = new ExerciseEnteredTable
            {
                UserID = "1",
                ExerciseID = "1",
                Date = DateTime.Now
            };
            context.Set<ExerciseEnteredTable>().Add(exerciseEntered);
            base.Seed(context);
        }
    }

    public class ExerciseTableInitializer : CreateDatabaseIfNotExists<ExerciseTableContext>
    {
        protected override void Seed(ExerciseTableContext context)
        {
            var exercise = new ExerciseTable
            {
                ExerciseType = "",
                Name = "",
                Distance = 0,
                Laps = 0,
                Sets = 0,
                Duration = 0,
                Calories = 0,

            };
            context.Set<ExerciseTable>().Add(exercise);
            base.Seed(context);
        }
    }

    public class FoodEnteredTableInitializer : CreateDatabaseIfNotExists<FoodEnteredTableContext>
    {
        protected override void Seed(FoodEnteredTableContext context)
        {
            var foodEntered = new FoodEnteredTable
            {
                UserID = "1",
                FoodID = "1", 
                Date = DateTime.Now
            };
            context.Set<FoodEnteredTable>().Add(foodEntered);
            base.Seed(context);
        }
    }

    public class FoodsTableInitializer : CreateDatabaseIfNotExists<FoodsTableContext>
    {
        protected override void Seed(FoodsTableContext context)
        {
            var food = new FoodsTable
            {
                FoodName = "Ramen",
                FoodIngredients = "Noodles",
                FoodMethod = "Boil",
                Protein = 100,
                Calories = 100,
                Fat = 100,
                Carbohydrate = 100,
                Fiber = 100,
                Cholesterol = 100,
                Sodium = 100
            };
            context.Set<FoodsTable>().Add(food);
            base.Seed(context);
        }
    }

    public class GoalTableInitializer : CreateDatabaseIfNotExists<GoalTableContext>
    {
        protected override void Seed(GoalTableContext context)
        {
            var goal = new GoalTable
            {
                UserID = "1",
                Title = "Conquest",
                Detail = "Get All the Ladies",
                Completed = true,
                Start = DateTime.Now,
                Finish = DateTime.Now
            };
            context.Set<GoalTable>().Add(goal);
            base.Seed(context);
        }
    }

    public class GroupMeetUpTableInitializer : CreateDatabaseIfNotExists<GroupMeetUpTableContext>
    {
        protected override void Seed(GroupMeetUpTableContext context)
        {
            var group = new GroupMeetUpTable
            {
                HostUserID = "1"
            };
            context.Set<GroupMeetUpTable>().Add(group);
            base.Seed(context);
        }
    }

    public class JourneyTableInitializer : CreateDatabaseIfNotExists<JourneyTableContext>
    {
        protected override void Seed(JourneyTableContext context)
        {
            var journey = new JourneyTable
            {
                UserID = "1",
                Calorie = 100,
                Date = DateTime.Now
            };
            context.Set<JourneyTable>().Add(journey);
            base.Seed(context);
        }
    }

    public class MeetUpMemberTableInitializer: CreateDatabaseIfNotExists<MeetUpMemberTableContext>
    {
        protected override void Seed(MeetUpMemberTableContext context)
        {
            var member = new MeetUpMemberTable
            {
                MeetUpID = "1",
                UserID = "1"
            };
            context.Set<MeetUpMemberTable>().Add(member);
            base.Seed(context);
        }
    }

    public class MeetUpTableInitializer : CreateDatabaseIfNotExists<MeetUpTableContext>
    {
        protected override void Seed(MeetUpTableContext context)
        {
            var meet = new MeetUpTable
            {
                HostID = "1",
                StartDateTime = DateTime.Now,
                FinishDateTime = DateTime.Now,
                AddressName = "mike street",
                Longitude = 152,
                Latitude = -27,
                Name = "Nagging",
                Description = "Nagging to other people about your problems"
            };
            context.Set<MeetUpTable>().Add(meet);
            base.Seed(context);
        }
    }

    public class NurseTableInitializer : CreateDatabaseIfNotExists<NurseTableContext>
    {
        protected override void Seed(NurseTableContext context)
        {
            var nurse = new NurseTable
            {
                NurseName = "Girly",
                Company = "feminism"
            };
            context.Set<NurseTable>().Add(nurse);
            base.Seed(context);
        }
    }
    
    public class UserTableInitializer : CreateDatabaseIfNotExists<UserTableContext>
    {
        protected override void Seed(UserTableContext context)
        {
            var user = new UserTable
            {
                Name = "Brian",
                AimCalorie = 50,  
                DOB = new DateTime(1980, 6, 30),
                Email = "Brian@idkmail.com",
                Weight = 60
            };
            context.Set<UserTable>().Add(user);
            base.Seed(context);
        }
    }
}

