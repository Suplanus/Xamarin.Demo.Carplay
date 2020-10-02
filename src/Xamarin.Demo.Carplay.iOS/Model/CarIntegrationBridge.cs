using CarPlay;
using MediaPlayer;
using Xamarin.Demo.Carplay.iOS.Model;
using Xamarin.Forms;
using Xamarin.Demo.Carplay.Model;

[assembly: Dependency(typeof(CarIntegrationBridge))]

namespace Xamarin.Demo.Carplay.iOS.Model
{
  public class CarIntegrationBridge : ICarIntegrationBridge
  {
    public void ReloadStations()
    {
      MPPlayableContentManager.Shared?.ReloadData();
    }

    public static void Init()
    {
      PlayableContentDelegate playableContentDelegate = new PlayableContentDelegate();
      MPPlayableContentManager.Shared.Delegate = playableContentDelegate;

      PlayableContentDataSource playableContentDataSource = new PlayableContentDataSource();
      MPPlayableContentManager.Shared.DataSource = playableContentDataSource;
    }

    //public delegate void CarPlayApplicationParameter(
    //  CPTemplateApplicationScene templateApplicationScene, CPInterfaceController interfaceController, CPWindow window);

    //public CarPlayApplicationParameter Connected { get; set; }
    //public CarPlayApplicationParameter Disconnected { get; set; }

    //public override void DidConnect(
    //  CPTemplateApplicationScene templateApplicationScene, CPInterfaceController interfaceController, CPWindow window)
    //{
    //  // todo: Not working
    //  base.DidConnect(templateApplicationScene, interfaceController, window);
    //  Connected?.Invoke(templateApplicationScene, interfaceController, window);
    //}
  }
}