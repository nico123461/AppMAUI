using Android.App;
using Android.Content;
using Android.Hardware.Biometrics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AppMAUI.Utils;
using Java.Lang;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Android.Hardware.Biometrics.BiometricPrompt;

namespace AppAndroidEmployee.Security
{
    public class BiometricUtility: AuthenticationCallback, IDialogInterfaceOnClickListener
    {
        private Action onSuccessAuthentication; 
        private Action onFailedAuthentication;
        private Context context;

        public BiometricUtility(Context context, Action onSuccessAuthentication, Action onFailedAuthentication)
        {
            this.context = context;
            this.onSuccessAuthentication = onSuccessAuthentication;
            this.onFailedAuthentication = onFailedAuthentication;

            BiometricPrompt biometricPrompt = new Builder(context)
                .SetDescription(TextUtils.getStringText("fingerprint_desctiption"))
                .SetTitle(TextUtils.getStringText("fingerprint_title"))
                .SetSubtitle(TextUtils.getStringText("fingerprint_subtitle"))
                .SetNegativeButton(TextUtils.getStringText("cancel"), context.MainExecutor, this)
                .Build();
            var cancellationSignal = new CancellationSignal();
            biometricPrompt.Authenticate(cancellationSignal, context.MainExecutor, this);
        }

        public override void OnAuthenticationSucceeded(AuthenticationResult result)
        {
            Toast.MakeText(context, TextUtils.getStringText("fingerprint_login_success"), ToastLength.Long).Show();
            onSuccessAuthentication?.Invoke();
        }

        public override void OnAuthenticationFailed()
        {
            Toast.MakeText(context, TextUtils.getStringText("fingerprint_login_failed"), ToastLength.Long).Show();
            onFailedAuthentication?.Invoke();
        }

        public override void OnAuthenticationError([GeneratedEnum] BiometricErrorCode errorCode, ICharSequence errString)
        {
            switch (errorCode)
            {
                case BiometricErrorCode.NoBiometrics:
                    Toast.MakeText(context, TextUtils.getStringText("fingerprint_NoBiometrics"), ToastLength.Long).Show();
                    break;
                case BiometricErrorCode.NoDeviceCredential:
                    Toast.MakeText(context, TextUtils.getStringText("fingerprint_NoDeviceCredential"), ToastLength.Short).Show();
                    break;
                case BiometricErrorCode.Timeout:
                    Toast.MakeText(context, TextUtils.getStringText("fingerprint_Timeout"), ToastLength.Short).Show();
                    break;
            }
            onFailedAuthentication?.Invoke();
        }

        public void OnClick(IDialogInterface dialog, int which)
        {
            
        }
    }
}