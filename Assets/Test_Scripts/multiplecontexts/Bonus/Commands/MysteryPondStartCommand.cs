//While this Context doesn't actually need a startup Command
//I almost always leave one here...just in case.
//In any sufficiently complex project, there's pretty much
//always **something** that needs to happen on startup.
using System; 
using UnityEngine; 
using strange.extensions.context.api; 
using strange.extensions.command.impl; 
using strange.extensions.dispatcher.eventdispatcher.impl;
using System.Collections;
using strange.extensions.dispatcher.eventdispatcher.api;

namespace strange.test.bonus
{
	public class MysteryPondStartCommand : Command
	{
//		[Inject]
//		public  CallStartCounterSignal callStartCounterSignal {get; set;}

		public override void Execute ()
		{
			Debug.Log("-=========mystery command");
		}


	}

}
