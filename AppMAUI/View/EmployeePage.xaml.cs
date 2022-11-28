using AppMAUI.ModelView;

namespace AppMAUI;

public partial class EmployeePage : ContentPage
{
	public EmployeePage(EmployeModelView employeModelView)
	{
		InitializeComponent();
		BindingContext = employeModelView;
	}
}