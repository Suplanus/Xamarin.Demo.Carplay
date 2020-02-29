using Foundation;
using MediaManager;
using MediaPlayer;
using UIKit;
using Xamarin.Demo.Carplay.iOS.Models;

namespace Xamarin.Demo.Carplay.iOS
{
  [Register("AppDelegate")]
  public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
  {
    MPPlayableContentManager _playableContentManager;

    public override bool FinishedLaunching(UIApplication app, NSDictionary options)
    {
      global::Xamarin.Forms.Forms.Init();
      LoadApplication(new App());

      CrossMediaManager.Current.Init();

      SetupCarPlay();

      return base.FinishedLaunching(app, options);
    }

    private void SetupCarPlay()
    {
      _playableContentManager = MPPlayableContentManager.Shared;

      PlayableContentDelegate playableContentDelegate = new PlayableContentDelegate();
      _playableContentManager.Delegate = playableContentDelegate;

      PlayableContentDataSource playableContentDataSource = new PlayableContentDataSource();
      _playableContentManager.DataSource = playableContentDataSource;
    }
  }
}
