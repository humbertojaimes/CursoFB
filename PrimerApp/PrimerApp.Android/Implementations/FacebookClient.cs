using System;
using System.Threading.Tasks;
using analisis.FacebookApiClasses;
using PrimerApp.Droid.Callbacks;
using PrimerApp.Droid.Implementations;
using PrimerApp.Interfaces;
using Xamarin.Facebook;
using Xamarin.Forms;

[assembly:Dependency(typeof(FacebookClient))]
namespace PrimerApp.Droid.Implementations
{
    public class FacebookClient : IFacebookClient
    {

        TaskCompletionSource<GraphResponse> taskCompletion
        = new TaskCompletionSource<GraphResponse>();

        public async Task<FeedResponse> GetFeed()
        {
            taskCompletion = new TaskCompletionSource<GraphResponse>();
            FeedResponse feedResponse = null;
            GraphCallback graphCallback = new GraphCallback();
            graphCallback.RequestCompleted += GraphCallback_RequestCompleted;
            var graphRequest = new GraphRequest(AccessToken.CurrentAccessToken, $"/me/feed", null, HttpMethod.Get, graphCallback);
            graphRequest.ExecuteAsync();
            var graphResponse = await taskCompletion.Task;
            graphCallback.RequestCompleted -= GraphCallback_RequestCompleted;
            feedResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<FeedResponse>(graphResponse.RawResponse);


            return feedResponse;
        }

        public async Task<Uri> GetPicture(string id)
        {
            taskCompletion = new TaskCompletionSource<GraphResponse>();
            Uri uri = null;
            GraphCallback graphCallback = new GraphCallback();
            graphCallback.RequestCompleted += GraphCallback_RequestCompleted;
            var graphRequest = new GraphRequest(AccessToken.CurrentAccessToken, $"/{id}?fields=picture.type(large)", null, HttpMethod.Get, graphCallback);
            graphRequest.ExecuteAsync();
            var graphResponse = await taskCompletion.Task;
            graphCallback.RequestCompleted -= GraphCallback_RequestCompleted;

            uri = new Uri(Newtonsoft.Json.JsonConvert.DeserializeObject<PictureResponse>(graphResponse.RawResponse).picture.data.url);


            return uri;
        }

        public async Task<ProfileResponse> GetProfile()
        {
            taskCompletion = new TaskCompletionSource<GraphResponse>();
            ProfileResponse profileResponse = null;
            GraphCallback graphCallback = new GraphCallback(); 
            graphCallback.RequestCompleted += GraphCallback_RequestCompleted;

            var graphRequest = new GraphRequest(
                AccessToken.CurrentAccessToken,
                "me",
                null,
                HttpMethod.Get,
                graphCallback
            );
            graphRequest.ExecuteAsync();

            var graphResponse = await taskCompletion.Task;

            profileResponse = Newtonsoft.Json.JsonConvert.DeserializeObject
                                        <ProfileResponse>(graphResponse.RawResponse);

            return profileResponse;
        }

        void GraphCallback_RequestCompleted(object sender, GraphResponseEventArgs e)
        {
            taskCompletion.SetResult(e.Response);
        }

    }
}
