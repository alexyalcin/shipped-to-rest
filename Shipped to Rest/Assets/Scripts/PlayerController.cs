using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public Camera camera; 
	public PossessObject currentObject;
	[SerializeField] private Text interactMessage;
	[SerializeField] private UIController ui;

	private List<InventoryItem> inventory;

	// Use this for initialization
	void Start () {
		inventory = new List<InventoryItem> ();
	}

    void Interact()
    {
        Transform t = CheckInteract();
        if (t == null)
            return;
        if (t.tag == "Possessable")
        {
            ChangeObject(t.gameObject.GetComponent<PossessObject>());
        }
        else if (t.tag == "Item")
        {
            inventory.Add(t.gameObject.GetComponent<InventoryItem>());
            print("key added");
            ui.SendMessage("Key added");
            t.gameObject.SetActive(false);
        }
        else if (t.tag == "ExitDoor")
        {
            if (t.gameObject.GetComponent<DoorScript>().Interact(this) == false)
            {
                ui.SendMessage("Door is locked...", 2);
            }
            else
            {
                ui.SendMessage("Door Opened!!", 5);
                StartCoroutine(LoadVideo(5f));            }
        } else if (t.tag == "Machine") {
            t.gameObject.GetComponent<MachineMove>().Move();
        }
    }

    private IEnumerator LoadVideo(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(sceneName: "FinishVideo");

    }

    public void ChangeObject(PossessObject obj) {
		currentObject = obj;
	}

	void LeaveObject() {
		
	}

    public bool HasItem(string id)
    {
        for (int i = 0; i < inventory.Count; i++)
        {
            if (inventory[i].GetId() == id) return true;
        }
        return false;
    }

	Transform CheckInteract() {
		float INTERACT_DISTANCE = 10f;
		Transform obj = null;
			print ("clicked");
			Vector3 origin = new Vector3 (camera.pixelWidth / 2,
				                camera.pixelHeight / 2,
				currentObject.transform.position.z);
			Ray ray = camera.ScreenPointToRay (origin);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit, INTERACT_DISTANCE)) {
			obj = hit.transform;
			if (hit.transform.tag == "Untagged") {
				interactMessage.text = "";
			} else {
				interactMessage.text = "[E] ";
				if (hit.transform.gameObject.GetComponent<PossessObject>() != null){
					interactMessage.text += "Possess";
				} else if (hit.transform.tag == "Item"){
					interactMessage.text += "Pick Up";
				} else if (hit.transform.tag == "ExitDoor") {
                    interactMessage.text += "Open";
				}
			} 
		} else {
			if (interactMessage.text != ""){
				interactMessage.text = "";
			}
		}
		return obj;
	}

	void InputHandler() {
		if (Input.GetKeyDown("e")){
			Interact ();
		}
		if (Input.GetKey("w")){
			currentObject.Move (this.transform.forward);
		}
		if (Input.GetKey("s")) {
			currentObject.Move(-1 * this.transform.forward);
		}
		if (Input.GetKey("d")) {
			currentObject.Move(this.transform.right);
		} 
		if (Input.GetKey("a")) {
			currentObject.Move(-1 * this.transform.right);
		}
		if (Input.GetKeyDown("space")){
			currentObject.ActivateAbility ();
		}

	}
	// Update is called once per frame
	void Update () {
		InputHandler ();
		this.gameObject.transform.position = currentObject.transform.position;
		CheckInteract ();
	}
}
