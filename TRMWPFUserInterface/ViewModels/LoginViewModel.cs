using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRMWPFDesktopUserInterface.Helpers;

namespace TRMWPFDesktopUserInterface.ViewModels
{
    public class LoginViewModel : Screen
    {
        private string _userName;
        private string _password;
        private IAPIHelper _apiHelper;
        public LoginViewModel(IAPIHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }
        public string UserName
        {
            get { return _userName; }
            set 
            { 
                _userName = value;
                NotifyOfPropertyChange(() => UserName);
                NotifyOfPropertyChange(() => CanLogIn);

            }
        }


        public string Password
        {
            get { return _password; }
            set 
            {
                _password = value;
                NotifyOfPropertyChange(() => Password);
                //Just to try why login does not work
                //CanLogIn(UserName, Password);
                NotifyOfPropertyChange(() => CanLogIn);


            }
        }
        public bool CanLogIn/*(string userName, string password)*/
        {
            get
            {
                bool output = false;
                if (UserName?.Length > 0 && Password?.Length > 0)
                {
                    output = true;
                }
                return output;
            }
            
        }
        public async Task LogIn(string userName, string password)
        {
            try
            {
                var result = await _apiHelper.Authenticate(UserName, Password);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);   
            }        }
    }
}
