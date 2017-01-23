using System;
using strange.extensions.dispatcher.eventdispatcher.api;


public interface IExecuterService
{
	void Request(string url);

	void Request(string url, string[] data);

	//Instead of an EventDispatcher, we put the actual Signals into the Interface
	FulfillWebServiceRequestSignal fulfillSignal{get;}
}