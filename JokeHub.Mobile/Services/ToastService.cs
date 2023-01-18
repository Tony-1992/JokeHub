using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JokeHub.Mobile.Services
{
    public class ToastService
    {
        public async Task ShowToast(string msg)
        {
            var t = Toast.Make(msg, ToastDuration.Short, 12);
            await t.Show();
        }
    }
}
