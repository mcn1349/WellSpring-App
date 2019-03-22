using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using WellSpring.Core.Interfaces;
using MvvmCross.Platform;
using MvvmCross.Platform.Droid.Platform;

namespace WellSpring.Droid.Services
{
    public class DialogService : IDialogService
    {
        private Dialog dialog = null;
        private string[] notes = null;
        private string text;
        bool button = false;
        bool answer = false;
        DateTime chosen = DateTime.Now;
        
        public async Task<DateTime> alertDatePicker()
        {
            
            
            Application.SynchronizationContext.Post(_ =>
            {
                var mvxTopActivity = Mvx.Resolve<IMvxAndroidCurrentTopActivity>();
                DatePickerDialog.Builder alertDialog = new DatePickerDialog.Builder(mvxTopActivity.Activity);
                dialog = alertDialog.Create();
                dialog.DismissEvent += (object sender, EventArgs e) =>
                {
                    button = true;
                    dialog.Dismiss();
                };
                dialog.Show();
            }, null);
            if (!button)
            {
                await Task.Delay(300);
            }
            return chosen;
        }

        public Task<string> alertEnterText(string title, string message)
        {
            return alertEnterText(title, message, "Confirm", "Cancel");
        }

        public async Task<string> alertEnterText(string title, string message, string confirm, string cancel)
        {
            Application.SynchronizationContext.Post(_ =>
            {
                var mvxTopActivity = Mvx.Resolve<IMvxAndroidCurrentTopActivity>();
                AlertDialog alertDialog = new AlertDialog.Builder(mvxTopActivity.Activity).Create();
                //alertDialog.SetButton(confirm);

            }, null);
            return null;
        }

        public Task<string> alertListString(string title, string[] list)
        {
            return alertListString(title, list, "Confirm", "Cancel");
        }





        public async Task<string> alertListString(string title, string[] list, string confirm, string cancel)
        {
            notes = list;
            Application.SynchronizationContext.Post(_ =>
            {
                var mvxTopActivity = Mvx.Resolve<IMvxAndroidCurrentTopActivity>();
                AlertDialog.Builder alertDialog = new AlertDialog.Builder(mvxTopActivity.Activity);
                alertDialog.SetTitle(title);
                alertDialog.SetSingleChoiceItems(list, -1, listener);
                dialog = alertDialog.Create();
                dialog.DismissEvent += (object sender, EventArgs e) =>
                {
                    button = true;
                    dialog.Dismiss();
                };
                dialog.Show();
            }, null);
            while (!button)
            {
                await Task.Delay(300);
            }
            return text;
        }
        
        private void listener(object sender, DialogClickEventArgs e)
        {
            text = notes[e.Which];
        }

        public Task<bool> alertMessage(string title, string message)
        {
            return alertMessage(title, message, "Confirm", "Cancel");
        }

        public async Task<bool> alertMessage(string title, string message, string confirm, string cancel)
        {
            button = false;
            answer = false;
            Application.SynchronizationContext.Post(_ =>
            {
                var mvxTopActivity = Mvx.Resolve<IMvxAndroidCurrentTopActivity>();
                AlertDialog.Builder alertDialog = new AlertDialog.Builder(mvxTopActivity.Activity);
                alertDialog.SetTitle(title);
                alertDialog.SetMessage(message);
                alertDialog.SetNegativeButton(cancel, (s, args) =>
                {
                    answer = false;
                });
                alertDialog.SetPositiveButton(confirm, (s, args) =>
                {
                    answer = true;
                });
                dialog = alertDialog.Create();
                dialog.DismissEvent += (object sender, EventArgs e) =>
                {
                    button = true;
                    dialog.Dismiss();
                };
                dialog.Show();
            }, null);
            while (!button)
            {
                await Task.Delay(300);
            }
            return answer;

        }

        public async Task<bool> Show(string message, string title)
        {
            return await Show(message, title, "OK", "Cancel");
        }

        public async Task<bool> Show(string message, string title, string confirmButton, string cancelButton)
        {
            bool buttonPressed = false;
            bool chosenOption = false;
            Application.SynchronizationContext.Post(_ =>
            {
                var mvxTopActivity = Mvx.Resolve<IMvxAndroidCurrentTopActivity>();
                Android.App.AlertDialog.Builder alertDialog = new AlertDialog.Builder(mvxTopActivity.Activity);
                alertDialog.SetTitle(title);
                alertDialog.SetMessage(message);
                alertDialog.SetNegativeButton(cancelButton, (s, args) =>
                {
                    chosenOption = false;
                });
                alertDialog.SetPositiveButton(confirmButton, (s, args) =>
                {
                    chosenOption = true;
                });

                dialog = alertDialog.Create();
                dialog.DismissEvent += (object sender, EventArgs e) =>
                {
                    buttonPressed = true;
                    dialog.Dismiss();
                };
                dialog.Show();
            }, null);
            while (!buttonPressed)
            {
                await Task.Delay(100);
            }
            return chosenOption;
        }
    }
}