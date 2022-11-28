namespace AppMAUI;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		//Routing.RegisterRoute("MainPage", typeof(MainPage));
        Routing.RegisterRoute("MainPage/EmployeDetail", typeof(EmployeePage));
        Routing.RegisterRoute("WebViewPage", typeof(WebViewPage));
    }
}
