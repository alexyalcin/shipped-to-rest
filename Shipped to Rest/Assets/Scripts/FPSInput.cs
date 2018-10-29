using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSInput : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    public float speed = 6.0f;

    void Update()
    {
        transform.Translate(Input.GetAxis("Horizontal") * speed * Time.deltaTime,
        0,
        Input.GetAxis("Vertical") * speed * Time.deltaTime);
    }

}
