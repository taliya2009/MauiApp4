using MauiApp4.ViewModels;

namespace MauiApp4.Views;

public partial class SignUpView : ContentPage
{
	public SignUpView()
	{
		InitializeComponent();
		BindingContext = new SignUpViewModel();
	}
}