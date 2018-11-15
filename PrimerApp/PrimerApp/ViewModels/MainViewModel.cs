using System;
using PrimerApp.BaseClasses;
using PrimerApp.Interfaces;
using Xamarin.Forms;

namespace PrimerApp.ViewModels
{
    public class MainViewModel : ObservableObject
    {
        public MainViewModel()
        {
        }

        public Command LoginCommand => new Command(() =>
        {
            DependencyService.Get<IFacebookLogin>().Login();        
        });

    }
}
