using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRope : PossessObject{

    private GameObject lift;

    // Use this for initialization
    void Start () {
        lift = GameObject.Find("Lift");
    }
	
	// Update is called once per frame
	void Update () {
        ActivateAbility();
	}

    public override void ActivateAbility()
    {
        if (Input.GetKey("up"))
        {
            lift.transform.Translate(Vector3.up * Time.deltaTime);
        }
        if (Input.GetKey("down"))
        {
            lift.transform.Translate(Vector3.down * Time.deltaTime);
            }
        if (Input.GetKey("left")){
            lift.transform.Rotate(Vector3.left * Time.deltaTime);
        }
        if(Input.GetKey("right")){
            lift.transform.Rotate(Vector3.right * Time.deltaTime);
        }

    }

}
