using AppMAUI.Services;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AppMAUI.ModelView
{
    internal class LoginModelView
    {
        public ICommand OnClickFingerprint { get; private set; }

        public LoginModelView()
        {
            OnClickFingerprint = new Command(onClickButtonEvent);
        }

        private void onClickButtonEvent()
        {
            BiometricService biometricService = new BiometricService();
            biometricService.FingerprintValidate( async () => { await Shell.Current.GoToAsync("//MainPage"); }, () => { });
        }
    }
}
