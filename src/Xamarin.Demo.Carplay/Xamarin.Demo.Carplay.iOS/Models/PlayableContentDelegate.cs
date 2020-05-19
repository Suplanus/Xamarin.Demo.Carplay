using System;
using CoreFoundation;
using Foundation;
using MediaPlayer;
using UIKit;

namespace Xamarin.Demo.Carplay.iOS.Models
{
    internal class PlayableContentDelegate : MPPlayableContentDelegate
    {
        [Export("playableContentManager:initiatePlaybackOfContentItemAtIndexPath:completionHandler:")]
        public override void InitiatePlaybackOfContentItem(MPPlayableContentManager contentManager, NSIndexPath indexPath, Action<NSError> completionHandler)
        {
            DispatchQueue.MainQueue.DispatchAsync(() => ItemSelected(contentManager, indexPath));
            completionHandler?.Invoke(null);
        }

        private void ItemSelected(MPPlayableContentManager contentManager, NSIndexPath indexPath)
        {
            // todo: Play

            MPContentItem item = contentManager.DataSource.ContentItem(indexPath);
            contentManager.NowPlayingIdentifiers = new[] { item.Identifier };

#if DEBUG
            InvokeOnMainThread(() =>
            {
                UIApplication.SharedApplication.EndReceivingRemoteControlEvents();
                UIApplication.SharedApplication.BeginReceivingRemoteControlEvents();
            });
#endif
        }


    }
}