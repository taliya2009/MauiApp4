
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp4.ViewModels
{

    public partial class SignUpViewModel : ObservableObject
    {
        [ObservableProperty]
        private string? _firstName;


        public SignUpViewModel()
        {
            FirstName = "Bad Cartel Team";
        }
    }
}