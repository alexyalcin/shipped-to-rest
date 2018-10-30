using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public Camera camera; 
	public PossessObject currentObject;

	// Use this for initialization
	void Start () {
		
	}
		
	GameObject Interact(){
		return null;
	}

	void ChangeObject(PossessObject obj) {
		currentObject = obj;
	}

	void LeaveObject() {
		
	}

	GameObject CheckInteract() {
		float INTERACT_DISTANCE = 5f;

		if (Input.GetMouseButtonDown (0)) {
			print ("clicked");
			Vector3 origin = new Vector3 (camera.pixelWidth / 2,
				                camera.pixelHeight / 2,
				currentObject.transform.position.z);
			Ray ray = camera.ScreenPointToRay (origin);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit)) {
				StartCoroutine (Shoot (hit.point));
			}
		}
		return this.gameObject;
	}

	private IEnumerator Shoot(Vector3 position)
	{
		GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		sphere.transform.position = position;
		sphere.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
		yield return new WaitForSeconds(1);
		Destroy(sphere);
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
		CheckInteract ();
	}
}
