using AppMAUI.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AppMAUI.ModelView
{
    public abstract class AbstractModelView: ObservableObject
    {
        public ICommand CommandLogoutAction { private set; get; }
        public ICommand CommandBackButton { private set; get; }

        protected Action onLogoutAction;

        private IDisplayMessage displayMessage;
        public AbstractModelView(IDisplayMessage displayMessage) 
        {
            this.displayMessage = displayMessage;
            CommandLogoutAction = new Command(async () =>
            {
                if (await displayMessage.ShowDisplayMessage_Confirm_KeyString("Logout_title", "Logout_Subtitle"))
                {
                    onLogoutAction?.Invoke();
                    await Shell.Current.GoToAsync("//Login");
                }
            });
            CommandBackButton = new Command( async () => 
            {
                await Shell.Current.GoToAsync("..");
                Shell.Current.SendBackButtonPressed();
            });
        }
    }
}
