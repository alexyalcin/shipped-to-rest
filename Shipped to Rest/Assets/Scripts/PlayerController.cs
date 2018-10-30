using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	Camera camera; 
	public PossessObject currentObject;

	// Use this for initialization
	void Start () {
		camera = Camera.main;
	}
		
	GameObject Interact(){
		return null;
	}

	void ChangeObject(PossessObject obj) {
		currentObject = obj;
		this.gameObject.transform.parent = obj.gameObject.transform.parent;
	}

	void LeaveObject() {
		
	}

	void InputHandler() {
		if (Input.GetMouseButtonDown(0)){
			Interact();
		} 
		if (Input.GetKey("w")){
			currentObject.Move (this.transform.forward);
		}
		if (Input.GetKey("s")) {
			currentObject.Move(-1 * this.transform.forward);
		}
		if (Input.GetKey("d")) {
			currentObject.Move(this.transform.right);
		} 
		if (Input.GetKey("a")) {
			currentObject.Move(-1 * this.transform.right);
		}

	}
	// Update is called once per frame
	void Update () {
		InputHandler ();
		this.gameObject.transform.position = currentObject.transform.position;
	}
}
