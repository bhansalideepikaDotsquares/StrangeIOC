using System;
using strange.extensions.mediation.impl;
using UnityEngine;
using strange.extensions.signal.impl;
using UnityEngine.UI;

namespace strange.test.login
{
	public class LoginView : View
	{
	
		public Button submitButton;

		public InputField usernameInput;
		public InputField passwordInput;

		public Text errorText;

				
		internal Signal clickSignal = new Signal ();
		
		internal void Init()
		{
			SetUsername("");
			SetPassword("");
			SetErrorText("");
		}

		internal void SetUsername(string value)
		{
			usernameInput.text = value;
		}

		internal void SetPassword(string value)
		{
			passwordInput.text = value;
		}

		internal void SetErrorText(string value)
		{
			errorText.text = value;
		}
		
		public void onSubmitClick()
		{
			Debug.Log("submit clicked");
			clickSignal.Dispatch(); //it will call the listener added from mediator
		}
	}
}

