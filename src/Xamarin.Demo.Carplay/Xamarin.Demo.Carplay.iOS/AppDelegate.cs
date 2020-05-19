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

    public CPTemplateApplicationScene CPTemplateApplicationScene;

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
      //CPTemplateApplicationScene = new CPTemplateApplicationScene();
      //CarPlayApplicationDelegate carPlayApplicationDelegate = new CarPlayApplicationDelegate();      
      //CPTemplateApplicationScene.Delegate = carPlayApplicationDelegate;

      _playableContentManager = MPPlayableContentManager.Shared;      

      PlayableContentDelegate playableContentDelegate = new PlayableContentDelegate();
      _playableContentManager.Delegate = playableContentDelegate;            

      PlayableContentDataSource playableContentDataSource = new PlayableContentDataSource();
      _playableContentManager.DataSource = playableContentDataSource;
    }
  }
}