using System;
using Plugin.CurrentActivity;
using PrimerApp.Droid.Implementations;
using PrimerApp.Interfaces;
using Xamarin.Facebook;
using Xamarin.Facebook.Login;

[assembly:Xamarin.Forms.Dependency(typeof(FacebookLogin))]
namespace PrimerApp.Droid.Implementations
{
	public class FacebookLogin : IFacebookLogin
    {
     
        public void Login()
        {
            if(!(AccessToken.CurrentAccessToken is null))
            {

            }
            else
            {

                LoginManager.Instance.SetLoginBehavior(LoginBehavior.WebOnly);
                LoginManager.Instance.LogInWithReadPermissions
                            (CrossCurrentActivity.Current.Activity,
                             new string[]{ "public_profile", "email", "user_posts" } 
                            );
            }
        }
    }
}
