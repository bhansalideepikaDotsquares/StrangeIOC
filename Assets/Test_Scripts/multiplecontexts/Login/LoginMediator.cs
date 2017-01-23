/// Example mediator
/// =====================
/// Note how we no longer extend EventMediator, and inject Signals instead

using System;
using UnityEngine;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;

namespace strange.test.login
{
	//Not extending EventMediator anymore
	public class LoginMediator : Mediator
	{
		[Inject]
		public LoginView view{ get; set;}
			
		//Injecting this one because we want to fire it
		[Inject]
		public CallWebServiceSignal callWebServiceSignal{ get; set;}

		[Inject]
		public FulfillWebServiceRequestSignal fullfillSignal {get; set;}

		[Inject]
		public LoadSceneSignal loadSceneSignal {get; set;}

		public override void OnRegister()
		{		
			Debug.Log("---on register"); //it is called only if the view is over the child of bootstrap script; like placed login view over canvas and not the login form panel gameobject
			//Listen to the view for a Signal
			fullfillSignal.AddListener(isLoginValid);
			view.clickSignal.AddListener(onLoginClicked);			
			view.Init ();
		}
		
		public override void OnRemove()
		{
			//Clean up listeners just as you do with EventDispatcher
			view.clickSignal.RemoveListener(onLoginClicked);
		}
		
		private void onLoginClicked()
		{
			Debug.Log("---onlogin clicked");

			string[] loginInput = new string[]{
				view.usernameInput.text,
				view.passwordInput.text
			};

			callWebServiceSignal.Dispatch(loginInput);
		}

		private void isLoginValid(bool result)
		{
			if(result == false)
				view.SetErrorText("Invalid Credentials!");
			else{
				view.SetErrorText("Success");
				loadSceneSignal.Dispatch("bonus");
			}
		}
		

	}
}

