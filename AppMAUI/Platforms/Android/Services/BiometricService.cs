using AppAndroidEmployee.Security;
using Android.App;
using Microsoft.Maui.Controls.PlatformConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.Content;
using Application = Android.App.Application;

namespace AppMAUI.Services
{
    public partial class BiometricService
    {
        public partial void FingerprintValidate(Action onSuccess, Action onFailure)
        {
            new BiometricUtility(Application.Context, onSuccess, onFailure);
        }
    }
}
