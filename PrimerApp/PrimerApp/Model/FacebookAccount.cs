using System;
using PrimerApp.BaseClasses;

namespace analisis.Model
{
    public class FacebookAccount : ObservableObject
    {

        private string name;

        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }


        private Uri profilePicture;

        public Uri ProfilePicture
        {
            get => profilePicture;
            set => SetProperty(ref profilePicture, value);
        }


        private string id;

        public string Id
        {
            get => id;
            set => SetProperty(ref id, value);
        }


    }
}
