using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem : MonoBehaviour {

	[SerializeField] private string id;

	public string GetId(){
		return id;
	}

}
