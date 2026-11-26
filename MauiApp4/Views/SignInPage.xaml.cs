using MauiApp4.ViewModels;

namespace MauiApp4.Views;

public partial class SignInPage : ContentPage
{
  
    public SignInPage()
    {
        InitializeComponent();
        BindingContext = new SignInPageViewModel();
       
        }
       
    }

   