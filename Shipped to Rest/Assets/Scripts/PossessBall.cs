using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PossessBall : PossessObject {
	public float SPEED = 6f;
	// Use this for initialization
	void Start () {
		speed = SPEED;
		setRigidbody (GetComponent<Rigidbody> ());
	}
	
	// Update is called once per frame
	void Update () {
	}

	public override void ActivateAbility() {
		
	}

}
