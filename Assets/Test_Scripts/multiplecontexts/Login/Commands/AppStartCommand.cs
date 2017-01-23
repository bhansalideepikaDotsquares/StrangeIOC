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

namespace strange.test.login
{
	public class AppStartCommand : Command
	{
		[Inject(ContextKeys.CONTEXT_DISPATCHER)]
		public IEventDispatcher dispatcher{ get; set;}
	//
	//	[Inject]
	//	public IExecuter Executer {get; private set;}
		[Inject]
		public IEvent evt{ get; set;}

		public override void Execute ()
		{
			//Retain();

			Debug.Log("App start command!");
			dispatcher.Dispatch(MainEvent.LOAD_SCENE, "login");

		}

		private IEnumerator WaitAndGo(){
			yield return new WaitForSeconds(2f);
			Debug.Log ("ok! Go next!");





		
		//	Release();
		
		}

		public void OnBalanceChange(int coins){
			Debug.Log("OnBalanceChange:" + coins);
		}
	}

}
