using AppMAUI.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMAUI.Services
{
    internal class DisplayMessage : IDisplayMessage
    {
        public Task<bool> ShowDisplayMessage_Confirm_KeyString(string keyTitle, string keyContain, string keyButtonYes, string keyButtonNo)
        {
            return App.Current.MainPage.DisplayAlert(TextUtils.getStringText(keyTitle), TextUtils.getStringText(keyContain), TextUtils.getStringText(keyButtonYes), TextUtils.getStringText(keyButtonNo));
        }

        public Task ShowDisplayMessage_KeyString(string keyTitle, string keyContain, string keyButtonOk)
        {
            return App.Current.MainPage.DisplayAlert(TextUtils.getStringText(keyTitle), TextUtils.getStringText(keyContain), TextUtils.getStringText(keyButtonOk));
        }
    }
}
