using System;
using CoreFoundation;
using Foundation;
using MediaPlayer;
using UIKit;

namespace Xamarin.Demo.Carplay.iOS.Models
{
  internal class PlayableContentDataSource : MPPlayableContentDataSource
  {
    string _defaultImage = "https://cuterdio.com/user/themes/landed/images/pic01.png";

    public override MPContentItem ContentItem(NSIndexPath indexPath)
    {
      if (indexPath.Length == 1)
      {
        var item = new MPContentItem("Stations");
        item.Title = "Stations";
        item.Container = true;
        item.Playable = false;               
        //item.Artwork = GetImageFromUrl(_defaultImage);
        return item;
      }
      else
      {
        // SubItems
        var item = new MPContentItem("Test" + indexPath.Row);
        item.Title = "TITLE" + indexPath.Row;
        item.Subtitle = "SUBTITLE" + indexPath.Row;
        item.Playable = true;
        item.StreamingContent = false;
                
        //item.Artwork = GetImageFromUrl(_defaultImage);
        return item;
      }
    }

    public override nint NumberOfChildItems(NSIndexPath indexPath)
    {
      if (indexPath.GetIndexes().Length == 0)
      {
        return 1;
      }
      return 3;
    }

    private MPMediaItemArtwork GetImageFromUrl(string url)
    {
      UIImage image = null;
      NSUrlSession session = NSUrlSession.SharedSession;
      NSUrlSessionDataTask dataTask = session.CreateDataTask(new NSUrlRequest(new NSUrl(url)),
                                                             (data, response, error) =>
                                                             {
                                                               if (response != null)
                                                               {
                                                                 image = GetImageFromUrl(data);
                                                               }
                                                             });
      dataTask.Resume();

      if (image != null)
      {
        return new MPMediaItemArtwork(image);
      }
      return null;
    }

    private static UIImage GetImageFromUrl(NSData data)
    {
      UIImage image = null;
      DispatchQueue.MainQueue.DispatchAsync(() =>
      {
        image = UIImage
          .LoadFromData(
            data);
      });
      return image;
    }
  }
}