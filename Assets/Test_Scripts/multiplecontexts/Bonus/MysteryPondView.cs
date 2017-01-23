using System;
using strange.extensions.mediation.impl;
using UnityEngine;
using strange.extensions.signal.impl;
using UnityEngine.UI;
using System.Collections;

namespace strange.test.bonus
{
	public class MysteryPondView : View
	{
	
		public Text searchCounterText;
						
		internal Signal startCounterSignal = new Signal();

		internal float startTimerDuration = 5f;

		internal void Init()
		{
			Debug.Log("---------mystery view init");
			SetSearchCounter("");
			StartCoroutine(StartCounter(startTimerDuration));
			//startCounterSignal.Dispatch();
		}

		internal void SetSearchCounter(string value)
		{
			searchCounterText.text = value;
		}
				
		public void OnCollectClick()
		{
			Debug.Log("submit clicked");

		}

		public void OnHireClick()
		{
			Debug.Log("submit clicked");
			//clickSignal.Dispatch(); //it will call the listener added from mediator
		}

		private IEnumerator StartCounter(float timeInSec){
			Debug.Log("--start counter:" + timeInSec);
			float time = timeInSec;

			float seconds = 0f;
			float fraction = 0f;

			bool timerEnd = false;

			while (time>0) {
				time -= Time.deltaTime;

				seconds = Mathf.FloorToInt (time % 60);
				fraction = (time * 100) % 100;
				
				if(time <= 0 ){
					seconds = fraction = 0;
					timerEnd = true;
				}

				string timeStr = String.Format ("{0:00}:{1:00}", seconds, fraction); 
				SetSearchCounter(timeStr);

				if(timerEnd == true){
					yield break;
				}
				
				yield return null;				
			}

		}

	}
}

