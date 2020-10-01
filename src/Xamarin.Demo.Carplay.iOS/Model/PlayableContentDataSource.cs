using System;
using System.Collections.Generic;
using Foundation;
using MediaPlayer;
using Xamarin.Demo.Carplay.Model;
using UIKit;

namespace Xamarin.Demo.Carplay.iOS.Model
{
  internal class PlayableContentDataSource : MPPlayableContentDataSource
  {
    public static List<Station> Stations = new List<Station>
    {
      new Station{Name = "Rainbow radio", Url = "https://stream.rockantenne.de/rockantenne/stream/mp3"},
      new Station{Name = "Unicorn radio", Url = "http://play.rockantenne.de/heavy-metal.m3u"}
    };
    
    public override MPContentItem ContentItem(NSIndexPath indexPath)
    {
      var station = Stations[indexPath.Section];
      var item = new MPContentItem(station.Url);
      item.Title = station.Name;
      item.Playable = true;
      item.StreamingContent = true;
      var artWork = GetImageFromUrl("station.png");
      if (artWork != null)
      {
        item.Artwork = artWork;
      }
      return item;
    }

    public override nint NumberOfChildItems(NSIndexPath indexPath)
    {
      if (indexPath.GetIndexes().Length == 0)
      {
        return Stations.Count;
      }
      throw new NotImplementedException();
    }

    private MPMediaItemArtwork GetImageFromUrl(string imagePath)
    {
      MPMediaItemArtwork result = null;
      try
      {
        using (var nsUrl = new NSUrl(imagePath))
        {
          using (var data = NSData.FromUrl(nsUrl))
          {
            var image = UIImage.LoadFromData(data);
            result = new MPMediaItemArtwork(image);
          }
        }
      }
      catch
      {
        UIImage image = UIImage.FromBundle(imagePath);
        if (image != null)
        {
          result = new MPMediaItemArtwork(image);
        }
      }
      return result;
    }
  }
}