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
    [Register ("MediaPlayerViewCtr")]
    partial class MediaPlayerViewCtr
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISlider BufferedProgressSlider { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton NextButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISlider PlayingProgressSlider { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton PlayPauseButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton PreviousButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel QueueLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton RepeatButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton ShuffleButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel SubtitleLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel TimePlayedLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel TimeTotalLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel TitleLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView TrackCoverImageView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (BufferedProgressSlider != null) {
                BufferedProgressSlider.Dispose ();
                BufferedProgressSlider = null;
            }

            if (NextButton != null) {
                NextButton.Dispose ();
                NextButton = null;
            }

            if (PlayingProgressSlider != null) {
                PlayingProgressSlider.Dispose ();
                PlayingProgressSlider = null;
            }

            if (PlayPauseButton != null) {
                PlayPauseButton.Dispose ();
                PlayPauseButton = null;
            }

            if (PreviousButton != null) {
                PreviousButton.Dispose ();
                PreviousButton = null;
            }

            if (QueueLabel != null) {
                QueueLabel.Dispose ();
                QueueLabel = null;
            }

            if (RepeatButton != null) {
                RepeatButton.Dispose ();
                RepeatButton = null;
            }

            if (ShuffleButton != null) {
                ShuffleButton.Dispose ();
                ShuffleButton = null;
            }

            if (SubtitleLabel != null) {
                SubtitleLabel.Dispose ();
                SubtitleLabel = null;
            }

            if (TimePlayedLabel != null) {
                TimePlayedLabel.Dispose ();
                TimePlayedLabel = null;
            }

            if (TimeTotalLabel != null) {
                TimeTotalLabel.Dispose ();
                TimeTotalLabel = null;
            }

            if (TitleLabel != null) {
                TitleLabel.Dispose ();
                TitleLabel = null;
            }

            if (TrackCoverImageView != null) {
                TrackCoverImageView.Dispose ();
                TrackCoverImageView = null;
            }
        }
    }
}