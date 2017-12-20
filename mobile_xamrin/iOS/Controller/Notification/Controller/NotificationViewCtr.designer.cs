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
    [Register ("NotificationViewCtr")]
    partial class NotificationViewCtr
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnSideMenu { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblNotification { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView TableViewNotify { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (btnSideMenu != null) {
                btnSideMenu.Dispose ();
                btnSideMenu = null;
            }

            if (lblNotification != null) {
                lblNotification.Dispose ();
                lblNotification = null;
            }

            if (TableViewNotify != null) {
                TableViewNotify.Dispose ();
                TableViewNotify = null;
            }
        }
    }
}