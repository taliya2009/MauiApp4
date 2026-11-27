using MauiApp4.Helpers;
using MauiApp4.Services; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;



namespace MauiApp4.ViewModels
{
    public class SignInPageViewModel : ViewModelBase
    {
        # region properties

        private bool _debugMode => true;
        private string? _userName;
        private string? _password;
        private string _messageText;
        private bool _entryAsPassword;
        private DBMokup? _db;
        private bool _isSignInMessageVisible;
        private Color? _messageColor;
        private string? _iconPasswordButton;

        public string IconPasswordButton
        {
            get { return _iconPasswordButton; }
            set
            {
                if (value != _iconPasswordButton)
                {
                    _iconPasswordButton = value;
                    OnPropertyChanged();


                }

            }
        }
        public string MessageText
        {
            get { return _messageText; }
            set
            {
                _messageText = value;
                OnPropertyChanged();
            }
        }
        public bool IsSignInButtonEnabled
        {
            get => !(string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(UserPassword));
        }


        public bool EntryAsPassword
        {
            get { return _entryAsPassword; }
            set
            {
                if (value != _entryAsPassword)
                {
                    _entryAsPassword = value;
                    OnPropertyChanged();
                }
            }
        }
        public string UserName
        {
            get { return _userName; }
            set
            {
                if (value != _userName)
                {
                    _userName = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(IsSignInButtonEnabled));
                }
            }
        }

        public string UserPassword
        {
            get { return _password; }
            set
            {
                if (value != _password)
                {
                    _password = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(IsSignInButtonEnabled));
                }
            }
        }
        public bool IsSignInMessageVisible
        {
            get { return _isSignInMessageVisible; }
            set
            {
                if (value != _isSignInMessageVisible)
                {
                    _isSignInMessageVisible = value;
                    OnPropertyChanged();
                }
            }
        }
        public Color MessageColor
        {
            get { return _messageColor; }
            set
            {
                if (_messageColor != value)
                {
                    _messageColor = value;
                    OnPropertyChanged();
                }
            }
        }
        public ICommand ShowPasswordCommand { get; }
        public ICommand SignInCommand { get; }

#endregion

        public SignInPageViewModel()
        {

            EntryAsPassword = true;
            IsSignInMessageVisible = false;
            IconPasswordButton = FontHelper.OPEN_EYE_ICON;

            _db = new DBMokup();
            ShowPasswordCommand = new Command(TogglePasswordButton);
            SignInCommand = new Command(OnSignInButtonClick);

            if (_debugMode)
            {
                UserName = "admin@mail.com";
                UserPassword = "admin";
            }

        }
        public void TogglePasswordButton()
        {
            if (!EntryAsPassword)
                IconPasswordButton = FontHelper.OPEN_EYE_ICON;
            else
                IconPasswordButton = FontHelper.CLOSED_EYE_ICON;

            //PasswordEntry.IsPassword = !PasswordEntry.IsPassword;
            EntryAsPassword = !EntryAsPassword;

        }
        private void OnSignInButtonClick()
        {
            IsSignInMessageVisible = true;
            if (_db.isExist(UserName, UserPassword))
            {
                MessageText = "ההתחברות הצליחה";
                MessageColor = Colors.Green;

                //Navigate to MainPage
            }
            else
            {
                MessageText = "שגיאת התחברות";
                MessageColor = Colors.Red;

                // Handle sign-in logic here
            }
        }
    }
}
    


