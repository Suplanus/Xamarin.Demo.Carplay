using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using MediaPlayer;
using UIKit;

namespace Xamarin.Demo.Carplay.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        MPPlayableContentManager playableContentManager;

        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            LoadApplication(new App());

            SetupCarplay();

            return base.FinishedLaunching(app, options);
        }

        private void SetupCarplay()
        {
            playableContentManager = MPPlayableContentManager.Shared;

            PlayableContentDelegate playableContentDelegate = new PlayableContentDelegate();
            playableContentManager.Delegate = playableContentDelegate;

            PlayableContentDataSource playableContentDataSource = new PlayableContentDataSource();
            playableContentManager.DataSource = playableContentDataSource;
        }
    }
}
