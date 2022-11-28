using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMAUI.Services
{
    public interface IDisplayMessage
    {
        Task<bool> ShowDisplayMessage_Confirm_KeyString(string keyTitle, string keyContain, string keyButtonYes = "Yes", string keyButtonNo = "No");
        Task ShowDisplayMessage_KeyString(string keyTitle, string keyContain, string keyButtonOk = "Ok");
    }
}
