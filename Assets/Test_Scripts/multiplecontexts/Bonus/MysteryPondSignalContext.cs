//Base Class for all our Contexts
//We do two jobs here:
//1. Provide the important bindings for a Signals-based app (see http://strangeioc.wordpress.com/2013/09/18/signals-vs-events-a-strange-smackdown-part-2-of-2/)
//2. Scan for Implicit Bindings (see http://strangeioc.wordpress.com/2013/12/16/implicitly-delicious/)
using System;
using strange.extensions.context.impl;
using UnityEngine;
using strange.extensions.command.api;
using strange.extensions.command.impl;
using strange.extensions.context.api;

namespace strange.test.bonus
{
	public class MysteryPondSignalContext :MVCSContext
	{
		public MysteryPondSignalContext (MonoBehaviour contextView) : base(contextView, strange.extensions.context.api.ContextStartupFlags.MANUAL_MAPPING)
		{
		}

		protected override void addCoreComponents(){
			base.addCoreComponents();

			injectionBinder.Unbind<ICommandBinder>();
			injectionBinder.Bind<ICommandBinder>().To<SignalCommandBinder>().ToSingleton();
		}

		public override void Launch(){ 
			base.Launch();
			Debug.Log("=====working");
			var start = injectionBinder.GetInstance<MysteryStartSignal>();
			start.Dispatch();
		}

		protected override void mapBindings(){
			base.mapBindings();
			//implicitBinder.ScanForAnnotatedClasses(new string[]{"strange.test.bonus"});
		}
	}
}
