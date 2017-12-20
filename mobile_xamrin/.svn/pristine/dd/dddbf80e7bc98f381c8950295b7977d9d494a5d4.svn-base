using System;
using System.Linq;
using MBProgressHUD;
using UIKit;

namespace VirtualEvent.iOS
{
	public static class CommonUtils
	{
		#region AlertView

		public static void AlertView(string message)
		{
			UIAlertView alert = new UIAlertView()
			{
				Title = AppConstant.AlertTitle,
				Message = message
			};
			alert.AddButton("OK");
			alert.Show();
		}

		#endregion

		#region RedirectToController

		public static void RedirectToController(string Controller)
		{
			//var cUser = (UIApplication.SharedApplication.Delegate as AppDelegate).RootViewController.CurrentUser;
			var navController = (UIApplication.SharedApplication.Delegate as AppDelegate).RootViewController.NavController;
			var ExistController = navController.ViewControllers.Where(x => x.Class.Name == Controller).FirstOrDefault();
			if (ExistController == null)
			{
				//var storyboard = (UIApplication.SharedApplication.Delegate as AppDelegate).RootViewController.Storyboard;
				var storyboard = UIStoryboard.FromName(AppConstant.MainStoryboard, null);
				UIViewController viewController = storyboard.InstantiateViewController(Controller);
				navController.PushViewController(viewController, true);
			}
			else
			{
				navController.PopToViewController(ExistController, true);
			}
			//Console.WriteLine("Stack count:-" + navController.ViewControllers.Count());
		}

		#endregion

		#region ProgressBar

		private static MTMBProgressHUD hud = null;

		public static void ShowProgress(UIView View)
		{
			hud = new MTMBProgressHUD(View)
			{
				LabelText = "Waiting...",
				RemoveFromSuperViewOnHide = true
			};
			View.AddSubview(hud);
			hud.Show(animated: true);
		}

		public static void HideProgress()
		{
			hud.Hide(animated: true);
		}

		#endregion

		#region SetImageOnButton
		public static void SetImageOnButton(UIButton button, string title, int size, UIColor tintColor = null)
		{
			button.TitleLabel.Font = UIFont.FromName(AppConstant.IconFile, size);
			button.SetTitle(title, UIControlState.Normal);

			if (tintColor != null)
				button.SetTitleColor(tintColor, UIControlState.Normal);
		}
		#endregion

		//public static string get
		//{
		//	var labelString = new NSMutableAttributedString(Control.AttributedText);

		//var paragraphStyle = new NSMutableParagraphStyle
		//{ //LineSpacing =  * Control.Font.LineHeight,
		//	LineHeightMultiple = (nfloat)label.LineHeightMultiplier
		//};
		//var style = UIStringAttributeKey.ParagraphStyle;
		//var range = new NSRange(0, labelString.Length);

		//labelString.AddAttribute(style, paragraphStyle, range);
  //          Control.AttributedText = labelString;
		//}

	}
}
