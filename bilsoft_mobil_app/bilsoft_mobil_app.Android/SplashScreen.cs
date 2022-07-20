using System;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using Android.Animation;
using Android.Content;

namespace bilsoft_mobil_app.Droid
{
    [Activity(Label = "BilsoftMobile", MainLauncher = true, NoHistory = true, Theme = "@style/MyTheme.Splash")]
    public class SplashScreen : Activity, Android.Animation.Animator.IAnimatorListener
    {
        public void OnAnimationCancel(Animator animation)
        {

        }

        public void OnAnimationEnd(Animator animation)
        {
            StartActivity(new Intent(Application.Context, typeof(MainActivity)));
        }

        public void OnAnimationRepeat(Animator animation)
        {

        }

        public void OnAnimationStart(Animator animation)
        {

        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);


            SetContentView(Resource.Layout.SplashLayout);

            var animation = FindViewById<Com.Airbnb.Lottie.LottieAnimationView>(Resource.Id.animation_view);

            animation.AddAnimatorListener(this);
        }
    }
}