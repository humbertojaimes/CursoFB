using System;
using System.Collections.Generic;
using PrimerApp.BaseClasses;
using PrimerApp.Enums;

namespace analisis.Model
{
    public class FacebookPost : ObservableObject
    {
        private string user;

        public string User
        {
            get => user;
            set => SetProperty(ref user, value);
        }

        private string id;

        public string Id
        {
            get => id;
            set => SetProperty(ref id, value);
        }

        private string message;

        public string Message
        {
            get => message;
            set => SetProperty(ref message, value);
        }

        private MessageType messageType;

        public MessageType MessageType
        {
            get => messageType;
            set => SetProperty(ref messageType, value);
        }

        private double score;

        public double Score
        {
            get => score;
            set => SetProperty(ref score, value);
        }

        private List<String> keyPhrases;

        public List<String> KeyPhrases
        {
            get => keyPhrases;
            set => SetProperty(ref keyPhrases, value);
        }
    }
}
