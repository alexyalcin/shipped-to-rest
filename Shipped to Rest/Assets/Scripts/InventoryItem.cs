using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem : MonoBehaviour, IInteractable {

	[SerializeField] private string id;

	public string GetId(){
		return id;
	}

    public string GetMessage()
    {
        return "Pick Up";
    }

}
