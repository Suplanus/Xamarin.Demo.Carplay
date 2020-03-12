using CarPlay;
using Foundation;
using MediaManager;
using MediaPlayer;
using UIKit;
using Xamarin.Demo.Carplay.iOS.Models;
using Xamarin.Forms.Platform.iOS;

namespace Xamarin.Demo.Carplay.iOS
{
  [Register("AppDelegate")]
  public class AppDelegate : FormsApplicationDelegate
  {
    private MPPlayableContentManager _playableContentManager;

    public CPApplicationDelegate CpApplicationDelegate;

    public override bool FinishedLaunching(UIApplication app, NSDictionary options)
    {
      Forms.Forms.Init();
      LoadApplication(new App());

      CrossMediaManager.Current.Init();

      SetupCarPlay();

      return base.FinishedLaunching(app, options);
    }

    private void SetupCarPlay()
    {
      CarPlayApplicationDelegate carPlayApplicationDelegate = new CarPlayApplicationDelegate();
      carPlayApplicationDelegate.Connected = Connected;
      carPlayApplicationDelegate.Disconnected = Disconnected;
      CpApplicationDelegate = carPlayApplicationDelegate;

      _playableContentManager = MPPlayableContentManager.Shared;

      PlayableContentDelegate playableContentDelegate = new PlayableContentDelegate();
      _playableContentManager.Delegate = playableContentDelegate;

      PlayableContentDataSource playableContentDataSource = new PlayableContentDataSource();
      _playableContentManager.DataSource = playableContentDataSource;
    }

    private void Disconnected(UIApplication application, CPInterfaceController interfaceController, CPWindow window)
    {
      

    }

    private void Connected(UIApplication application, CPInterfaceController interfaceController, CPWindow window)
    {
    
    }
  }
}