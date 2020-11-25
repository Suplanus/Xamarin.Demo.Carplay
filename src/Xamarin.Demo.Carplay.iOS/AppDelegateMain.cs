using System;
using System.Runtime.InteropServices;
using Foundation;
using MediaManager;
using ObjCRuntime;
using UIKit;
using Xamarin.Demo.Carplay.iOS.Model;
using Xamarin.Forms.Platform.iOS;

namespace Xamarin.Demo.Carplay.iOS
{
  [Register("AppDelegateMain")]
  public class AppDelegateMain : FormsApplicationDelegate
  {
    public override bool FinishedLaunching(UIApplication app, NSDictionary options)
    {
      Forms.Forms.Init();
      LoadApplication(new App());

      CrossMediaManager.Current.Init();
      CarIntegrationBridge.Init();

      return base.FinishedLaunching(app, options);
    }

    [DllImport("/usr/lib/libobjc.dylib", EntryPoint = "objc_msgSend")]
    public extern static IntPtr IntPtr_objc_msgSend_IntPtr_IntPtr(IntPtr receiver, IntPtr selector, IntPtr arg1, IntPtr arg2);

    public static UISceneConfiguration Create(string? name, NSString sessionRole)
    {
      global::UIKit.UIApplication.EnsureUIThread();
      var nsname = NSString.CreateNative(name);

      UISceneConfiguration sceneConfig;
      sceneConfig = Runtime.GetNSObject<UISceneConfiguration>(IntPtr_objc_msgSend_IntPtr_IntPtr(Class.GetHandle("UISceneConfiguration"), Selector.GetHandle("configurationWithName:sessionRole:"), nsname, sessionRole.Handle));
      NSString.ReleaseNative(nsname);
      //Because only the CarPlay scene will be here to create a scene configuration
      //We need manually assign the CarPlay scene delegate here!
      sceneConfig.DelegateType = typeof(AppDelegateCar);
      return sceneConfig!;
    }

    [Export("application:configurationForConnectingSceneSession:options:")]
    public UISceneConfiguration GetConfiguration(UIApplication application, UISceneSession connectingSceneSession, UISceneConnectionOptions options)
    {
      UIWindowSceneSessionRole sessionRole;
      bool isCarPlaySceneSession = false;
      try
      {
        //When the connecting scene is a CarPlay scene, an expected exception will be thrown
        //Under this moment from Xamarin.iOS.
        sessionRole = connectingSceneSession.Role;
      }
      catch (NotSupportedException ex)
      {
        if (!string.IsNullOrEmpty(ex.Message) &&
            ex.Message.Contains("CPTemplateApplicationSceneSessionRoleApplication"))
        {
          isCarPlaySceneSession = true;
        }
      }

      if (isCarPlaySceneSession && UIDevice.CurrentDevice.CheckSystemVersion(14, 0))
      {
        return Create("Car", CarPlay.CPTemplateApplicationScene.SessionRoleApplication);
      }
      else
      {
        //If it is phone scene, we need the regular UIWindow scene
        UISceneConfiguration phoneScene = new UISceneConfiguration("Phone", UIWindowSceneSessionRole.Application);
        //And assign the scene delegate here.
        phoneScene.DelegateType = typeof(AppDelegatePhone);
        return phoneScene;
      }
    }
  }


}