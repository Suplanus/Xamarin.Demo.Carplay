using System;
using System.Threading.Tasks;
using CoreFoundation;
using Foundation;
using MediaManager;
using MediaPlayer;
using UIKit;
using Xamarin.Essentials;

namespace Xamarin.Demo.Carplay.iOS.Model
{
  internal class PlayableContentDelegate : MPPlayableContentDelegate
  {
    public override void InitiatePlaybackOfContentItem(
      MPPlayableContentManager contentManager, NSIndexPath indexPath, Action<NSError> completionHandler)
    {
      Execute(contentManager, indexPath);
      completionHandler?.Invoke(null);
    }

    private void Execute(MPPlayableContentManager contentManager, NSIndexPath indexPath)
    {
      DispatchQueue.MainQueue.DispatchAsync(async () => await ItemSelectedAsync(contentManager, indexPath));
    }

    private async Task ItemSelectedAsync(MPPlayableContentManager contentManager, NSIndexPath indexPath)
    {
      // Play
      var station = PlayableContentDataSource.Stations[indexPath.Section];
      await CrossMediaManager.Current.Play(station.Url);

      // Set playing identifier
      MPContentItem item = contentManager.DataSource.ContentItem(indexPath);
      contentManager.NowPlayingIdentifiers = new[] { item.Identifier };

      // Update on simulator
      if (DeviceInfo.DeviceType == DeviceType.Virtual)
      {
        InvokeOnMainThread(() =>
        {
          UIApplication.SharedApplication.EndReceivingRemoteControlEvents();
          UIApplication.SharedApplication.BeginReceivingRemoteControlEvents();
        });
      }
    }
  }
}