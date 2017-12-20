// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace VirtualEvent.iOS
{
    [Register ("SideMenuViewCtr")]
    partial class SideMenuViewCtr
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnContactUs { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnHome { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnLogout { get; set; }

        [Action ("btnContactUs_UpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void btnContactUs_UpInside (UIKit.UIButton sender);

        [Action ("btnHome_UpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void btnHome_UpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (btnContactUs != null) {
                btnContactUs.Dispose ();
                btnContactUs = null;
            }

            if (btnHome != null) {
                btnHome.Dispose ();
                btnHome = null;
            }

            if (btnLogout != null) {
                btnLogout.Dispose ();
                btnLogout = null;
            }
        }
    }
}