/// The service, now with signals

using System;
using System.Collections;
using UnityEngine;
using strange.extensions.context.api;
using strange.extensions.dispatcher.eventdispatcher.api;
using System.Collections.Generic;

namespace strange.test.login
{
	public class LoginService : IExecuterService
	{
		[Inject(ContextKeys.CONTEXT_VIEW)]
		public GameObject contextView{get;set;}
		
		//The interface demands this signal
		[Inject]
		public FulfillWebServiceRequestSignal fulfillSignal{get;set;}
		
		private string url;

		private string userListJson = @"{
			""success"": true,
			""data"": { [
				{
					""username"": ""1"",
					""password"": ""1"",
					""coins"" : 0,
					""mermaids"":[].
					""rewards"":[]
				},{
					""username"": ""2"",
					""password"": ""2"",
					""coins"" : 0,
					""mermaids"":[].
					""rewards"":[]
				},{
					""username"": ""3"",
					""password"": ""pass"",
					""coins"" : 0,
					""mermaids"":[].
					""rewards"":[]
				}
	
			]}}";



		public LoginService()
		{
		}

		public void Request(string url)
		{
		}

		public void Request(string url, string[] data)
		{
			this.url = url;

//			WWWForm postData = new WWWForm();
//			postData.AddField("username", data[0]);
//			postData.AddField("password", data[1]);

			MonoBehaviour root = contextView.GetComponent<LoginBootstrap>();
			//root.StartCoroutine(CallLoginAPI(postData));
			root.StartCoroutine(CallLoginAPI(data[0], data[1]));
		}

		
		private IEnumerator CallLoginAPI(WWWForm postData)
		{

			Debug.Log("-login service CallLoginAPI");
			yield return new WaitForSeconds(1f);

//			WWW www = new WWW(this.url, postData);
//			yield return www;
					

			//Pass back some fake data via a Signal
			fulfillSignal.Dispatch(true);
		}


		private IEnumerator CallLoginAPI(string username, string password){
			yield return new WaitForSeconds(1f);

			//parse json
			JSONObject j = JSONObject.Create(userListJson);

			List<JSONObject> jDataList = j["data"][0].list;
			bool isLoginValid = false;

			for (int i = 0; i < jDataList.Count ; i++) {
				string jDataUsername = jDataList[i]["username"].str;
				string jDataPassword = jDataList[i]["password"].str;
			
				if(jDataUsername == username && jDataPassword == password){
					isLoginValid = true;
				}
			}

			fulfillSignal.Dispatch(isLoginValid);
		}
	}
}

