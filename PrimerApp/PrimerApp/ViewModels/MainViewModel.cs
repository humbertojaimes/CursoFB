using System;
using analisis.Model;
using PrimerApp.BaseClasses;
using PrimerApp.Interfaces;
using Xamarin.Forms;

namespace PrimerApp.ViewModels
{
    public class MainViewModel : ObservableObject
    {
        private FacebookAccount facebookAccount;

        public FacebookAccount FacebookAccount
        {
            get => facebookAccount;
            set => SetProperty(ref facebookAccount, value);
        }

        public Command LoginCommand => new Command(() =>
        {
            DependencyService.Get<IFacebookLogin>().Login();        
        });

        public Command LoadCommand => new Command(async () =>
        {
            var profile =  await DependencyService.Get<IFacebookClient>().GetProfile();

            FacebookAccount = new FacebookAccount
            {
                Id = profile.Id,
                Name = profile.Name
            };

        });
    }
}
