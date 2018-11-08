using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCeiling : MonoBehaviour {

    Vector3 pos = new Vector3(0.0f, 11.5f, 20.0f);
    Vector3 deletePos = new Vector3(0.0f, 11.0f, 13.0f);

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKey("o")){
            openTheCeiling();
        }
        if (transform.position.z >= pos.z)
        {
            transform.position = new Vector3(0.0f, 11.0f, 100.0f);
        }
    }

    public void openTheCeiling(){
        transform.position = Vector3.Lerp(transform.position, pos, Time.deltaTime/2);
        if (transform.position.z >= deletePos.z)
        {
            Destroy(gameObject);
        }
    }
}
