//The Context for our UI.
using System;
using UnityEngine;
using strange.extensions.context.impl;
using strange.extensions.context.api;

namespace strange.test.login
{
	public class LoginMainContext : LoginSignalContext
	{

		//All Contexts should extend at least one of the base Constructors
		public LoginMainContext (MonoBehaviour contextView) : base(contextView)
		{
		}

		protected override void mapBindings ()
		{
			base.mapBindings ();

			commandBinder.Bind<CallWebServiceSignal>().To<CallWebServiceCommand>();
			commandBinder.Bind<LoadSceneSignal>().To<LoadSceneCommand>().Once();

			mediationBinder.Bind<LoginView>().To<LoginMediator>();

			injectionBinder.Bind<FulfillWebServiceRequestSignal>().ToSingleton();
			injectionBinder.Bind<IExecuterService>().To<LoginService>().ToSingleton();

		}
		
		protected override void postBindings ()
		{

	
			base.postBindings ();
			

		}
	}

}

