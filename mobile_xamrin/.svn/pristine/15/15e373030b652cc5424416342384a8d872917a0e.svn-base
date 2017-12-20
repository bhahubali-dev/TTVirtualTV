using System;
using System.Drawing;
using UIKit;

namespace VirtualEvent.iOS
{
	public class LoadingOverlay : UIView
	{
		public static string lbltext = string.Empty;
		// control declarations
		UIActivityIndicatorView activitySpinner;
		UILabel loadingLabel;

		public LoadingOverlay(RectangleF frame)
					: base(frame)
		{
			// configurable bits
			BackgroundColor = UIColor.Black;
			Alpha = 0.9f;
			AutoresizingMask = UIViewAutoresizing.FlexibleDimensions;

			float labelHeight = 22;
			float labelWidth = (float)Frame.Width - 20;
			// derive the center x and y
			float centerX = (float)Frame.Width / 2;
			float centerY = (float)Frame.Height / 2;
			// create the activity spinner, center it horizontall and put it 5 points above center x
			activitySpinner = new UIActivityIndicatorView(UIActivityIndicatorViewStyle.WhiteLarge);

			activitySpinner.Frame = new RectangleF(
				(float)centerX - ((float)activitySpinner.Frame.Width / 2),
				(float)centerY - (float)activitySpinner.Frame.Height - 20,
				(float)activitySpinner.Frame.Width,
				(float)activitySpinner.Frame.Height);



			activitySpinner.AutoresizingMask = UIViewAutoresizing.FlexibleMargins;
			AddSubview(activitySpinner);
			activitySpinner.StartAnimating();

			// create and configure the "Loading Data" label
			loadingLabel = new UILabel(new RectangleF(
				centerX - (labelWidth / 2),
				centerY + 20,
				labelWidth,
				labelHeight
				));
			loadingLabel.BackgroundColor = UIColor.Clear;
			loadingLabel.TextColor = UIColor.White;
			if (string.IsNullOrEmpty(lbltext))
				loadingLabel.Text = "Loading...";
			else
				loadingLabel.Text = lbltext;
			loadingLabel.TextAlignment = UITextAlignment.Center;
			loadingLabel.AutoresizingMask = UIViewAutoresizing.FlexibleMargins;
			AddSubview(loadingLabel);
		}

		/// <summary>
		/// Fades out the control and then removes it from the super view
		/// </summary>
		public void Hide()
		{
			UIView.Animate(
				0.5, // duration
				() => { Alpha = .5f; },
				() => { RemoveFromSuperview(); }
			);
		}
	}
}
