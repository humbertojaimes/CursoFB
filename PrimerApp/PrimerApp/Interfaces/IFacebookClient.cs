using System;
using System.Threading.Tasks;
using analisis.FacebookApiClasses;

namespace PrimerApp.Interfaces
{
    public interface IFacebookClient
    {
        Task<ProfileResponse> GetProfile();
        Task<FeedResponse> GetFeed();
        Task<Uri> GetPicture(string id);
    }
}
