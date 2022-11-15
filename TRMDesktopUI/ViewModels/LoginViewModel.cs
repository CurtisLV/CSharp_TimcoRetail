using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace TRMDesktopUI.ViewModels
{
    public class LoginViewModel : Screen
    {
        private string _userName;
        private string _password;
        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
                NotifyOfPropertyChange(() => _userName);
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                NotifyOfPropertyChange(() => _password);
            }
        }

        public bool CanLogIn(string userName, string password)
        {
            bool output = false;
            // TODO - proper email & password check
            if (userName.Length > 0 && password.Length > 0)
            {
                output = true;
            }
            return output;
        }

        public void LogIn(string userName, string password)
        {
            Console.WriteLine();
        }
    }
}
