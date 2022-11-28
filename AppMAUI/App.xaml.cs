using System.Globalization;

namespace AppMAUI;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
		ConfigureLanguage();

        MainPage = new AppShell();
	}

	public void ConfigureLanguage()
	{ 
		var cultureCurrent = CultureInfo.CurrentCulture;
		int indexRemove = 0;
        if (cultureCurrent.Name.Contains("es-"))
			indexRemove = 1;
        else if (cultureCurrent.Name.Contains("en-"))
            indexRemove = 0;
		var dictionaryRemove = Resources.MergedDictionaries.ToList()[indexRemove];
		Resources.MergedDictionaries.Remove(dictionaryRemove);

    }
}
