using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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


        private Uri imageUri;

        public Uri ImageUri
        {
            get => imageUri;
            set => SetProperty(ref imageUri, value);
        }


        private ObservableCollection<FacebookPost> feed;

        public ObservableCollection<FacebookPost> Feed
        {
            get => feed;
            set => SetProperty(ref feed, value);
        }


        public Command LoginCommand => new Command(() =>
        {
            DependencyService.Get<IFacebookLogin>().Login();        
        });

        public Command LoadCommand => new Command(async () =>
        {

            var client = DependencyService.Get<IFacebookClient>();
            var profile =  await client.GetProfile();

            FacebookAccount = new FacebookAccount
            {
                Id = profile.Id,
                Name = profile.Name
            };

            var imageUri = await client.GetPicture(FacebookAccount.Id);
            ImageUri = imageUri;


            var feed = await client.GetFeed();
            Feed = new ObservableCollection<FacebookPost>();
            foreach (var post in feed.data)
            {
                Feed.Add(new FacebookPost
                {
                    Message = post.message,
                    Id = post.id
                });
            }

            List<RequestMessage> requestMessages = new List<RequestMessage>();

            foreach (var post in Feed)
            {
                requestMessages.Add(new RequestMessage
                {
                    MessageText = post.Message, 
                    Id = post.Id
                });

            }

            var analysisResult = await Helpers.TextAnalyticsHelper.MakeKeyWordAnalysis
                                              (requestMessages);

            foreach (var result in analysisResult.ResultMessages)
            {
                var resultByKey = Feed.FirstOrDefault
                                      (pre => pre.Id == result.Id);
                resultByKey.KeyPhrases =  result.KeyPhrases;
            }

        });
    }
}
