using CarPlay;
using UIKit;

namespace Xamarin.Demo.Carplay.iOS
{
  public class CarPlayApplicationDelegate : CPApplicationDelegate
  {
    public delegate void CarPlayApplicationParameter(
      UIApplication application, CPInterfaceController interfaceController, CPWindow window);

    public CarPlayApplicationParameter Connected { get; set; }
    public CarPlayApplicationParameter Disconnected { get; set; }

    public override void DidConnectCarInterfaceController(
      UIApplication application, CPInterfaceController interfaceController, CPWindow window)
    {
      Connected?.Invoke(application, interfaceController, window);
    }

    public override void DidDisconnectCarInterfaceController(
      UIApplication application, CPInterfaceController interfaceController, CPWindow window)
    {
      Disconnected?.Invoke(application, interfaceController, window);
    }


  }
}