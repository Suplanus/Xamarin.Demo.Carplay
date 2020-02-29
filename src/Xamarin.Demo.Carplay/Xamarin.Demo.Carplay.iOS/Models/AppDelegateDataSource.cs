using System;
using Foundation;
using MediaPlayer;

namespace Xamarin.Demo.Carplay.iOS.Models
{
    internal class PlayableContentDataSource : MPPlayableContentDataSource
    {
        public override MPContentItem ContentItem(NSIndexPath indexPath)
        {
            return null;
        }

        public override nint NumberOfChildItems(NSIndexPath indexPath)
        {
            return 0;
        }

        public override void BeginLoadingChildItems(NSIndexPath indexPath, Action<NSError> completionHandler)
        {
            
        }

        
    }
}