using UnityEngine;
using System.Collections;

public class CoroutineWorker : MonoBehaviour{
}

public class CoroutineExecuter : IExecuter {
	private readonly CoroutineWorker _worker;

	public CoroutineExecuter(){
		var go = new GameObject ("CoroutineWorker");
		_worker = go.AddComponent<CoroutineWorker>();
	}

	#region IExecuter implementation

	public void Execute(IEnumerator coroutine){
		_worker.StartCoroutine(coroutine);
	}

	#endregion
}
