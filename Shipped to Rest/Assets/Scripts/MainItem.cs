using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainItem : MonoBehaviour {
    public float speed = 4f;
    protected Rigidbody rb;
    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {

    }
    void OnCollisionEnter(Collision coll)
    {
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.tag == "ConveyorBelt")
        {
            Move(new Vector3(0, 0, 4));
        }
    }
    public void Move(Vector3 dir)
    {
        rb.AddForce(speed * dir);
    }
}
