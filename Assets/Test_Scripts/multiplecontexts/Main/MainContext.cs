//The Context for our UI.
using System;
using UnityEngine;
using strange.extensions.context.impl;
using strange.extensions.context.api;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.dispatcher.eventdispatcher.impl;

namespace strange.test.main
{
	public class MainContext : SignalContext
	{
		public MainContext (MonoBehaviour contextView) : base(contextView)
		{
		}

		protected override void mapBindings ()
		{
			base.mapBindings ();

			//commandBinder.Bind(ContextEvent.START).To<AppStartCommand>().Once();
			commandBinder.Bind <LoadSceneSignal>().To<LoadSceneCommand> ().Once();
			commandBinder.Bind<AppStartSignal>().To<AppStartCommand>().Once();

		}
		
		protected override void postBindings ()
		{	
			base.postBindings ();
		}
	}

}

