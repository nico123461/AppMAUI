using AppMAUI.ModelView;

namespace AppMAUI;

public partial class WebViewPage : ContentPage
{
	public WebViewPage(WebViewViewModel webViewViewModel)
	{
		InitializeComponent();
		BindingContext= webViewViewModel;
	}
}