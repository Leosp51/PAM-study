using PAM_study.ViewModels;

namespace PAM_study.Views;

public partial class MonitoresView : ContentPage
{
	public MonitoresView()
	{
		InitializeComponent();
		BindingContext = new MonitoresViewModel();
	}
}