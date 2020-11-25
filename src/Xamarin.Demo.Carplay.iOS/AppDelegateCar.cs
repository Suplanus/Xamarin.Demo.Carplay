using CarPlay;
using Foundation;
using UIKit;

namespace Xamarin.Demo.Carplay.iOS
{
  [Register("AppDelegateCar")]
  public class AppDelegateCar : UIResponder, ICPTemplateApplicationSceneDelegate
  {
    private CPInterfaceController _interfaceController;

    public async void DidConnect(CPTemplateApplicationScene templateApplicationScene, CPInterfaceController interfaceController)
    {
      _interfaceController = interfaceController;
    }

    public void DidDisconnect(CPTemplateApplicationScene templateApplicationScene, CPInterfaceController interfaceController)
    {
      _interfaceController.Dispose();
      _interfaceController = null;
    }
  }
}