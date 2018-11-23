using System;
using System.Collections.Generic;
using BusinessChat;
using CoreGraphics;
using Foundation;
using MessageUI;
using UIKit;

namespace XamarinAppleBusinessChat
{
	public class CustomViewController : UIViewController
	{
		public CustomViewController() { }

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			View.BackgroundColor = UIColor.White;
			Title = "BC ChatButton";


			// Launch through BCChatButton
			var msgButton = new BCChatButton(style: BCChatButtonStyle.Light); // Option of dark or light
			msgButton.Frame = new CGRect(20, 200, 280, 44);
			msgButton.TouchUpInside += MsgButton_TouchUpInside;
			msgButton.TranslatesAutoresizingMaskIntoConstraints = false;

			// Launch through Web
			var btn = UIButton.FromType(UIButtonType.System);
			btn.Frame = new CGRect(20, 400, 280, 50);
			btn.SetTitle("Click Me", UIControlState.Normal);
			btn.TouchUpInside += (sender, e) =>
			{
				// URL format for including body, group & intent details:
				// https://bcrw.apple.com/urn:biz:9c231233-d943-482a-b913-7c625ba19988?biz-intent-id=account_question&biz-group-id=credit_card_department&body=Order%20additional%20credit%20card
				UIApplication.SharedApplication.OpenUrl(new NSUrl("https://bcrw.apple.com/urn:biz:8cf6bcd5-889a-40b9-aff1-77373927bc7f"));
			};

			#region Older Code
			// Launch a page with a Magenta backgroun
			//var user = new UIViewController();
			//user.View.BackgroundColor = UIColor.Magenta;
			//btn.TouchUpInside += (sender, e) =>
			//{
			//	this.NavigationController.PushViewController(user, true);
			//};

			// Cannot be launched through text message
			//btn.TouchUpInside += (sender, e) => {
			//	if (MFMessageComposeViewController.CanSendText)
			//	{
			//		var recipients = new String[] { "+39800290915" };
			//		var messageController = new MFMessageComposeViewController();
			//		messageController.Recipients = recipients;
			//		messageController.Body = "Your_message_text";
			//		PresentViewController(messageController, true, null);
			//	}
			//};
			#endregion Older Code

			View.AddSubview(msgButton);
			View.AddSubview(btn);
		}

		void MsgButton_TouchUpInside(object sender, EventArgs e)
		{
			var parameters = new Dictionary<BCParameterName, String>();
			parameters.Add(BCParameterName.Body, "I need to reset my equipment.");
			parameters.Add(BCParameterName.Group, "services_department");
			parameters.Add(BCParameterName.Intent, "reset_all_equipment");
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