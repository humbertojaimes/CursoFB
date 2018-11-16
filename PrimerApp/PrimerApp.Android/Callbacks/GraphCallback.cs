using System;
using Xamarin.Facebook;

namespace PrimerApp.Droid.Callbacks
{
    class GraphCallback : Java.Lang.Object, GraphRequest.ICallback
    {
        // Event to pass the response when it's completed
        public event OnResponseEventHandler RequestCompleted;

        public delegate void OnResponseEventHandler(object sender, GraphResponseEventArgs e);

        public void OnCompleted(GraphResponse reponse)
        {
            this.RequestCompleted?.Invoke(this, new GraphResponseEventArgs(reponse));
        }
    }

    public class GraphResponseEventArgs : EventArgs
    {
        GraphResponse _response;
        public GraphResponseEventArgs(GraphResponse response)
        {
            _response = response;
        }

        public GraphResponse Response { get { return _response; } }
    }
}
