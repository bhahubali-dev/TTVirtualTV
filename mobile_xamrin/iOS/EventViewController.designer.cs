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
    [Register ("EventViewController")]
    partial class EventViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnEnrolled { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnEvent { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnSideMenu { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UICollectionView EventCollectionView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblTitleVirtualEvent { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (btnEnrolled != null) {
                btnEnrolled.Dispose ();
                btnEnrolled = null;
            }

            if (btnEvent != null) {
                btnEvent.Dispose ();
                btnEvent = null;
            }

            if (btnSideMenu != null) {
                btnSideMenu.Dispose ();
                btnSideMenu = null;
            }

            if (EventCollectionView != null) {
                EventCollectionView.Dispose ();
                EventCollectionView = null;
            }

            if (lblTitleVirtualEvent != null) {
                lblTitleVirtualEvent.Dispose ();
                lblTitleVirtualEvent = null;
            }
        }
    }
}