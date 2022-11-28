using AppMAUI.ModelView;

namespace AppMAUI;

public partial class MainPage : ContentPage
{
	public MainPage(MainPageModelView mainPageModelView)
	{
		InitializeComponent();
		BindingContext = mainPageModelView;
	}
}