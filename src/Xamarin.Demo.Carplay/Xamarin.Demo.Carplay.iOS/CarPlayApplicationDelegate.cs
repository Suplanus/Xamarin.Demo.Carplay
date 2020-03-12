using CarPlay;
using UIKit;

namespace Xamarin.Demo.Carplay.iOS
{
  public class CarPlayApplicationDelegate : CPTemplateApplicationSceneDelegate
  {
    public delegate void CarPlayApplicationParameter(
      CPTemplateApplicationScene templateApplicationScene, CPInterfaceController interfaceController, CPWindow window);

    public CarPlayApplicationParameter Connected { get; set; }
    public CarPlayApplicationParameter Disconnected { get; set; }

    public override void DidConnect(
      CPTemplateApplicationScene templateApplicationScene, CPInterfaceController interfaceController, CPWindow window)
    {
      base.DidConnect(templateApplicationScene, interfaceController, window);
      Connected?.Invoke(templateApplicationScene, interfaceController, window);
    }
  }
}