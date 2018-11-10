using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {
	[SerializeField] Text messageText;
    [SerializeField] Text pointerText;

	public void SendMessage(string message, float time = 5f) {
		messageText.text = message;
		StartCoroutine (WaitAndClear (messageText, time));
	}

    public void SetPointerText(string message)
    {
        pointerText.text = "[E] " + message;
    }

    public void ClearPointerText()
    {
        pointerText.text = "";
    }

    public bool PointerIsClear()
    {
        return (pointerText.text == "");
    }

	private IEnumerator WaitAndClear(Text t, float waitTime) {
		yield return new WaitForSeconds (waitTime);
		t.text = "";
	}


}
