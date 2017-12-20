using Foundation;
using System;
using UIKit;

namespace VirtualEvent.iOS
{
    public partial class NotificationViewCtr : UIViewController
    {
        public NotificationViewCtr (IntPtr handle) : base (handle)
        {
        }
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            var Tabledatasource = new EnrolledClass();

            TableViewNotify.Source = Tabledatasource;
        }
    }
}