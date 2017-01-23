/// Example mediator
/// =====================
/// Note how we no longer extend EventMediator, and inject Signals instead

using System;
using UnityEngine;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;

namespace strange.test.bonus
{
	//Not extending EventMediator anymore
	public class MysteryPondMediator : Mediator
	{
		[Inject]
		public MysteryPondView view{ get; set;}


		public override void OnRegister()
		{		
			Debug.Log("---on register"); //it is called only if the view is over the child of bootstrap script; like placed login view over canvas and not the login form panel gameobject				
			view.Init ();
		}
		
		public override void OnRemove()
		{
			//Clean up listeners just as you do with EventDispatcher
		}
		
		private void onCounterStarted()
		{
		
		}

		

	}
}

