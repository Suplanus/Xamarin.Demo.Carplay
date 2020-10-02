using Foundation;
using MediaManager;
using UIKit;
using Xamarin.Demo.Carplay.iOS.Model;
using Xamarin.Forms.Platform.iOS;

namespace Xamarin.Demo.Carplay.iOS
{
  [Register("AppDelegate")]
  public class AppDelegate : FormsApplicationDelegate
  {
    public override bool FinishedLaunching(UIApplication app, NSDictionary options)
    {
      Forms.Forms.Init();
      LoadApplication(new App());

      CrossMediaManager.Current.Init();
      CarIntegrationBridge.Init();

      return base.FinishedLaunching(app, options);
    }
  }
}