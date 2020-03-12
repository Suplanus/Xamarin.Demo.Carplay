using System;
using Foundation;
using MediaPlayer;

namespace Xamarin.Demo.Carplay.iOS.Models
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

        public override nuint RetainCount { get; }

        public override void ContextUpdated(MPPlayableContentManager contentManager, MPPlayableContentManagerContext context)
        {
          base.ContextUpdated(contentManager, context);
        }

        public override NSDictionary GetDictionaryOfValuesFromKeys(NSString[] keys)
        {
          return base.GetDictionaryOfValuesFromKeys(keys);
        }

        
    }
}