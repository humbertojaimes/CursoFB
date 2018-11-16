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

        public Task<FeedResponse> GetFeed()
        {
            throw new NotImplementedException();
        }

        public Task<Uri> GetPicture(string id)
        {
            throw new NotImplementedException();
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
