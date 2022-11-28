using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMAUI.Utils
{
    internal static class TextUtils
    {
        private static ResourceDictionary resources;
        public static string getStringText(string keyName)
        {
            if(resources == null)
            {
                resources = App.Current.Resources.MergedDictionaries.First();
            }
            return resources[keyName].ToString();
        }
    }
}
