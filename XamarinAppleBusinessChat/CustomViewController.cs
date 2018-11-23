using System;
using System.Collections.Generic;
using BusinessChat;
using CoreGraphics;
using MessageUI;
using UIKit;

namespace XamarinAppleBusinessChat
{
	public class CustomViewController : UIViewController
	{
		public CustomViewController()
		{
			// Note: this .ctor should not contain any initialization logic.
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.

			View.BackgroundColor = UIColor.White;
			Title = "BC ChatButton";

			var btn = UIButton.FromType(UIButtonType.System);
			btn.Frame = new CGRect(20, 400, 280, 50);
			btn.SetTitle("Click Me", UIControlState.Normal);

			var msgButton = new BCChatButton(style: BCChatButtonStyle.Light); // Option of dark or light
			msgButton.Frame = new CGRect(20, 200, 280, 44);
			msgButton.TouchUpInside += MsgButton_TouchUpInside;
			msgButton.TranslatesAutoresizingMaskIntoConstraints = false;

			// Launch a page with a Magenta backgroun
			var user = new UIViewController();
			user.View.BackgroundColor = UIColor.Magenta;
			btn.TouchUpInside += (sender, e) => {
				this.NavigationController.PushViewController(user, true);
			};

			View.AddSubview(btn);
			View.AddSubview(msgButton);
		}

		void MsgButton_TouchUpInside(object sender, EventArgs e)
		{
			var parameters = new Dictionary<BCParameterName, String>();
			parameters.Add(BCParameterName.Body, "I need to reset my equipment.");
			parameters.Add(BCParameterName.Group, "services_department");
			parameters.Add(BCParameterName.Intent, "reset_all_equipment");
			//var businessID = "9c231233-d943-482a-b913-7c625ba19988";
			var businessID = "8cf6bcd5-889a-40b9-aff1-77373927bc7f";
			BCChatAction.OpenTranscript(businessID, parameters);
		}


		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}