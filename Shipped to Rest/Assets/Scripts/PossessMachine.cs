using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PossessMachine : PossessObject {
    [SerializeField] GameObject machine;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Move(Vector3 dir) {
        machine.position;
    }
}
