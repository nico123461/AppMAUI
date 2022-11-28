using AppMAUI.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AppMAUI.ModelView
{
    public class EmployeModelView: ObservableObject, IQueryAttributable
    {
        private Employee employeProcess;
        private IDisplayMessage displayMessage;

        public Employee Employee { get => employeProcess; set => SetProperty(ref employeProcess, value); }
        public ICommand OnClickButtonFind { get; private set; }

        public EmployeModelView(IDisplayMessage displayMessage) 
        {
            this.displayMessage = displayMessage;
            OnClickButtonFind = new Command(OnClickButtonFindEmail);
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            Employee = (Employee)query["employe"];
        }

        private void OnClickButtonFindEmail()
        {
            if (string.IsNullOrEmpty(employeProcess.Email))
            {
                displayMessage.ShowDisplayMessage_KeyString("Error", "NoEmailEmployee");
            }
            else
            {
                var navigationParameters = new Dictionary<string, object>
                {
                    {"URL", "https://www.google.com/search?q=" + employeProcess.Email}
                };
                Shell.Current.GoToAsync("WebViewPage", navigationParameters);
            }
        }
    }
}
