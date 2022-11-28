using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMAUI.ModelView
{
    public class WebViewViewModel: ObservableObject, IQueryAttributable
    {
        private string uRL;
        public string URL { get => uRL; set => SetProperty(ref uRL, value); }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            URL = query["URL"].ToString();
        }
    }
}
