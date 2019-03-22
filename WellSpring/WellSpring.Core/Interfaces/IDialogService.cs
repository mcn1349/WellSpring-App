using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WellSpring.Core.Interfaces
{
    public interface IDialogService
    {
        Task<DateTime> alertDatePicker();
        Task<string> alertListString(string title, string[] list, string confirm, string cancel);
        Task<string> alertListString(string title, string[] list);
        Task<bool> alertMessage(string title, string message);
        Task<bool> alertMessage(string title, string message, string confirm, string cancel);
        Task<string> alertEnterText(string title, string message);
        Task<string> alertEnterText(string title, string message, string confirm, string cancel);

        /// <summary>
        /// Shows a dialog to the user, with a chosen message and title
        /// </summary>
        /// <param name="message"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        Task<bool> Show(string message, string title);

        /// <summary>
        /// Shows a dialog to the user, with a chosen message, title, confirm button and cancel button
        /// </summary>
        /// <param name="message"></param>
        /// <param name="title"></param>
        /// <param name="confirmButton"></param>
        /// <param name="cancelButton"></param>
        /// <returns></returns>
        Task<bool> Show(string message, string title, string confirmButton, string cancelButton);

    }
}
