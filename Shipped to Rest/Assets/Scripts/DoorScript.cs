using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour {

    [SerializeField] private bool unlocked = false;
    private bool open = false;
    [SerializeField] private string keyID;
	// Use this for initialization
	void Start () {
		
	}
    
    public bool Interact(PlayerController pc)
    {
        if (pc.HasItem(keyID)) unlocked = true;
        if (unlocked) return true;
        return false;
        openDoor();
    }

    private void openDoor()
    {

    }

    

	// Update is called once per frame
	void Update () {
		
	}
}
