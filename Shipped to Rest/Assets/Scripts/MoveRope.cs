using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRope : PossessObject{

    private GameObject lift;
    private PlayerController player;

    // Use this for initialization
    void Start () {
        lift = GameObject.Find("Lift");
        player = new PlayerController();
    }
	
    void pcSet(PlayerController pc) {
        this.player = pc;
    }
	// Update is called once per frame
	void Update () {
        ActivateAbility();
	}

    public override void ActivateAbility()
    {

        if (Input.GetKey("up"))
        {
            lift.transform.Translate(Vector3.up * Time.deltaTime * 2);
        }
        if (Input.GetKey("down"))
        {
            lift.transform.Translate(Vector3.down * Time.deltaTime * 2);
            }

    }
    public void Upmove() {
        for (int i = 0; i < 1000; i++) {
            lift.transform.Translate(Vector3.up);
        }
    }

}
