/// An Asynchronous Command
/// ============================
/// This demonstrates how to use a Command to perform an asynchronous action;
/// for example, if you need to call a web service. The two most important lines
/// are the Retain() and Release() calls.

using System;
using System.Collections;
using UnityEngine;
using strange.extensions.context.api;
using strange.extensions.command.impl;
using strange.extensions.dispatcher.eventdispatcher.api;

namespace strange.test.login
{
	//Again, we extend Command, not EventCommand
	public class CallWebServiceCommand : Command
	{
		
		//[Inject]
		//public IExecuterModel model{get;set;}
		
		[Inject]
		public IExecuterService service{get;set;}

		[Inject]
		public string[] Arguments {get; set;}

		static int counter = 0;
		
		public CallWebServiceCommand()
		{
			++counter;
		}
		
		public override void Execute()
		{
			Retain ();
			Debug.Log("----signal dispatched,, command executed");
			service.fulfillSignal.AddListener(onComplete); //add listener to fulfillsignal called on the completion of api execution
			service.Request("http://www.thirdmotion.com/ ::: " + counter.ToString(), Arguments);
		}
		
		//The payload is now a type-safe string
		private void onComplete(bool isValid)
		{
			service.fulfillSignal.RemoveListener(onComplete);			
			//model.data = url;
			Release ();


		}
	}
}

