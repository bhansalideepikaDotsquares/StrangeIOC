//The Context for our UI.
using System;
using UnityEngine;
using strange.extensions.context.impl;
using strange.extensions.context.api;

namespace strange.test.bonus
{
	public class MysteryPondMainContext : MysteryPondSignalContext
	{

		//All Contexts should extend at least one of the base Constructors
		public MysteryPondMainContext (MonoBehaviour contextView) : base(contextView)
		{

		}

		protected override void mapBindings ()
		{
			base.mapBindings ();

			mediationBinder.Bind<MysteryStartSignal>().To<MysteryPondStartCommand>();
			mediationBinder.Bind<MysteryPondView>().To<MysteryPondMediator>();

			injectionBinder.Bind<CallStartCounterSignal>().ToSingleton();
			injectionBinder.Bind<MysteryStartSignal>().ToSingleton();

		}
		
		protected override void postBindings ()
		{

	
			base.postBindings ();
			

		}
	}

}

