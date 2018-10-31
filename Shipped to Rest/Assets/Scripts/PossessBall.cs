using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PossessBall : PossessObject {
	public float SPEED = 6f;
	public float JUMP_SPEED = 350f;
	public bool flymode = false;
	// Use this for initialization
	void Start () {
		speed = SPEED;
		setRigidbody (GetComponent<Rigidbody> ());
	}
	
	// Update is called once per frame
	void Update () {
	}

	private bool IsGrounded(){
		float edge = this.gameObject.GetComponent<Collider> ().bounds.extents.y;
		RaycastHit hit;
		return Physics.Raycast(transform.position, -1 * Vector3.up, out hit, .1f + edge);
		return true;
	}

	public override void ActivateAbility() {
		if (IsGrounded() || flymode){
			/*Vector3 vel = rb.velocity;
			vel.y = JUMP_SPEED;
			rb.velocity = vel;*/
			rb.AddForce (new Vector3 (0, JUMP_SPEED, 0));

	}

}
}
