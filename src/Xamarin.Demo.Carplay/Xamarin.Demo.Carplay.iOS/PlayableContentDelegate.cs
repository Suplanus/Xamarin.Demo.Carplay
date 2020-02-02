using System;
using Foundation;
using MediaPlayer;

namespace Xamarin.Demo.Carplay.iOS
{
    internal class PlayableContentDelegate : MPPlayableContentDelegate
    {
        public override void PlayableContentManager(MPPlayableContentManager contentManager, NSIndexPath indexPath, Action<NSError> completionHandler)
        {
            base.PlayableContentManager(contentManager, indexPath, completionHandler);
        }

        [Export("playableContentManager:initiatePlaybackOfContentItemAtIndexPath:completionHandler:")]
        public override void InitiatePlaybackOfContentItem(MPPlayableContentManager contentManager, NSIndexPath indexPath, Action<NSError> completionHandler)
        {
            
        }
    }
}