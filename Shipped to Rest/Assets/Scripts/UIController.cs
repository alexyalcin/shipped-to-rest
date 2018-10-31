using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {
	[SerializeField] Text messageText;

	public void SendMessage(string message, float time = 5f) {
		messageText.text = message;
		StartCoroutine (WaitAndClear (messageText, time));
	}

	private IEnumerator WaitAndClear(Text t, float waitTime) {
		yield return new WaitForSeconds (waitTime);
		t.text = "";
	}


}
