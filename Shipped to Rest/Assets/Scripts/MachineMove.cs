using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineMove : MonoBehaviour {
    public GameObject applePrefab;  // This is so the apple tree can make apples.  
                                    // Link it to the apple prefab in the editor.
    public float speed = 4f; // speed at which to move.

    private CharacterController charController;
    // Use this for initialization
    void Start () {
		
	}

    public void Move(){

    }
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;
        if (pos.x > 9) {
            speed = -speed;
        } else if (pos.x < -11) {
            speed = -speed;
        }

    }
}
