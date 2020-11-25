using System.Threading.Tasks;
using CarPlay;
using Foundation;
using UIKit;

namespace Xamarin.Demo.Carplay.iOS
{
  [Register("AppDelegateCar")]
  public class AppDelegateCar : UIResponder, ICPTemplateApplicationSceneDelegate
  {
    private CPInterfaceController _interfaceController;

    public void DidConnect(CPTemplateApplicationScene templateApplicationScene, CPInterfaceController interfaceController)
    {
      _interfaceController = interfaceController;
    }

    public void DidDisconnect(CPTemplateApplicationScene templateApplicationScene, CPInterfaceController interfaceController)
    {
      _interfaceController.Dispose();
      _interfaceController = null;
    }

    public async Task ShowNowPlaying()
    {
      await _interfaceController.PushTemplateAsync(CPNowPlayingTemplate.SharedTemplate, true);
    }
  }
}