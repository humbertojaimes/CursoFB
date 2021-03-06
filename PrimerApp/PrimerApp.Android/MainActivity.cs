﻿using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Plugin.CurrentActivity;
using Xamarin.Facebook.Login;
using Xamarin.Facebook;
using Android.Content;
using PrimerApp.Droid.Callbacks;

namespace PrimerApp.Droid
{
    [Activity(Label = "PrimerApp", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        ICallbackManager callbackManager;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            CrossCurrentActivity.Current.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());

            var loginCallback = new FacebookCallback<LoginResult>
            {
                HandleSuccess = (loginResult) =>
                {
                    Console.WriteLine(loginResult);
                }
            };

            callbackManager =  CallbackManagerFactory.Create();
            LoginManager.Instance.RegisterCallback(callbackManager, loginCallback);
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            callbackManager.OnActivityResult(requestCode, (int)resultCode, data);
        }

    }
}