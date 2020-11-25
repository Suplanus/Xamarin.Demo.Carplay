using Foundation;
using MediaManager;
using UIKit;
using Xamarin.Demo.Carplay.iOS.Model;
using Xamarin.Forms.Platform.iOS;

namespace Xamarin.Demo.Carplay.iOS
{
  [Register("AppDelegatePhone")]
  public class AppDelegatePhone : UISceneDelegate
  {
    public override void WillConnect(UIScene scene, UISceneSession session, UISceneConnectionOptions connectionOptions)
    {
      var windowScene = scene as UIWindowScene;
      if (windowScene != null)
      {
        //Assign the Xamarin.iOS app window to this scene 
        UIApplication.SharedApplication.KeyWindow.WindowScene = windowScene;
        UIApplication.SharedApplication.KeyWindow.MakeKeyAndVisible();
      }
    }
  }
}